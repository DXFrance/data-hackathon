# Data Hackathon resources

Documentation on tools you may want to use during a data hackathon that leverages Microsoft Azure resources.

You can go to [azure.com](https://azure.microsoft.com/en-us/), Documentation. 
The main chapters of interest for a data Hackathon are: 

- Compute
    - Windows Virtual Machines: create your own Windows Virtual Machine, connect thru Remote Desktop protocol to it and install whatever you need
    - Linux Virtual Machines: create your own Linux Virtual Machine, connect thru SSH to it and install whatever you need
- Web & Mobile
	- App Service (Web Apps, Mobile Apps, API Apps, Logic Apps) is a quite easy to use PaaS. It can host a mobile App backend, a web site, APIs or a workflow
- Data & Storage
    - (Blob) Storage: HDInsight considers it as its default Hadoop distributed file system (HDFS). It can also store virtual hard disks, files. 
    - Data Lake store: It can do the same as blob storage, with specific features for big data such as: native Web HDFS interface, no size limit (for a single file or for an account), ...
    - SQL Data Warehouse: create your own relational database that can run on multiple nodes and gets data from its Polybase engine (define an external table to Azure storage and load data that way)
- Intelligence
    - Cognitive Services: deep learning made easy. Just use the API that are made available to you for images, language, and other subjects
- Analytics
    - Data Lake Analytics: serverless big data engine. Language is U-SQL, a mix of SQL and procedural (C#)
    - HDInsight: Spark, Hadoop, Storm, HBase as a service
    - Machine Learning: Develop your own Machine Learning learning and scoring experiments with Microsoft algorithms, or R, or Python (Anaconda distribution). You can do that from the Azure ML Studio (HTML5) or a Jupyter notebook
- Developer Services
    - Visual Studio Team Services: get your own private git repo, with its bug database and more

In this repo, you'll find more specific documentation. Here are the topics covered here:

- [How can I create an Azure subscription with the PASS code I received?](AzurePASS.md)
- [How can I create an Azure storage account?](AzureStorage.md)
- [Where can I get some useful tools to access Azure?](Tools.md)
- [How to create and use a Linux VM on Azure?](AzureLinux.md)
- [How to create and use a Windows VM on Azure?](AzureWindows.md)
- [How could I leverage Docker?](Docker.md)
- [How can I get started with Azure Machine Learning?](AzureML.md)
- [How can I get started with the Cognitive Services APIs?](CognitiveServices.md)
- [How can I start with Azure Data Lake Analytics (serverless big data queries)](AzureDataLake.md)
- [HDInsight - How can I run Hadoop/Spark/R Server as a service?](HDInsight.md)
- [How can I load my data and analyze it in a relational database?](AzureSQLDW.md)
- [How can I visualize my data?](PowerBI.md)
- [How much did I spend in my Azure subscription?](AzureConsumption.md)
- [How can I analyze text?](Text.md)

Here are a few additional public links: 

- [http://azure.com](http://azure.com)
- [Azure management portal](https://portal.azure.com)
- [Azure SDKs, code samples (GitHub)](http://github.com/azure)
- [Azure Resource Manager Quick startup templates](https://github.com/azure/azure-quickstart-templates/)
- [Big Data workloads in Azure as a dataviz (French)](http://dev.microsoft.fr/data/index.html)

Have questions? 
Meet with Microsoft mentors in person.
