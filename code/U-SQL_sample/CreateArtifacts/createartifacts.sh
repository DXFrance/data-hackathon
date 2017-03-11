#!/bin/bash

usage() { echo "Usage: $0 -i <subscriptionId> -p <namingPrefix>" 1>&2; exit 1; }

declare subscriptionId=""
declare namingPrefix=""

# Initialize parameters specified from command line
while getopts ":i:g:" arg; do
	case "${arg}" in
		i)
			subscriptionId=${OPTARG}
			;;
		p)
			namingPrefix=${OPTARG}
			;;
		esac
done
shift $((OPTIND-1))

#Prompt for parameters is some required parameters are missing
if [[ -z "$subscriptionId" ]]; then
	echo "Subscription Id:"
	read subscriptionId
	[[ "${subscriptionId:?}" ]]
fi

if [[ -z "$namingPrefix" ]]; then
	echo "Naming Prefix:"
	read subscriptionId
	[[ "${namingPrefix:?}" ]]
fi

resourceGroupName="${namingPrefix}rg"
deploymentName="${namingPrefix}deployment"
resourceGroupLocation="northeurope"
iothubname="${namingPrefix}iothub"
iothubsku="S1"
iothubunit=1

#login to azure using your credentials
az account show 1> /dev/null
if [ $? != 0 ];
then
	az login
fi

#set the default subscription id
az account set --subscription $subscriptionId

if [ $(az group exists --name $resourceGroupName --output tsv) == 'true' ]; 
then
	echo "Using existing resource group..."
else
	echo "Resource group with name ${resourceGroupName} could not be found. Creating new resource group.."
    az group create --name $resourceGroupName --location $resourceGroupLocation
fi

#templateFile Path - template file to be used
templateFilePath="template.json"
if [ ! -f "$templateFilePath" ]; then
	echo "$templateFilePath not found"
	exit 1
fi

#Start deployment
params='{"namingprefix":{"value":"'$namingPrefix'"}}'
echo "parameters: " $params
echo "Starting deployment..."
az group deployment create --name $deploymentName --resource-group $resourceGroupName \
	--template-file $templateFilePath \
	--parameters $params

#Start IOT Hub creation
echo "creating IOT Hub ..."
az iot hub create --resource-group $resourceGroupName --name $iothubname --sku $iothubsku --unit $iothubunit --location $resourceGroupLocation
