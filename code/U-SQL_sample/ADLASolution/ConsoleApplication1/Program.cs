using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string sampleOK = @"{""DeviceId"":""device001"",""Country"":""FR"",""Variables"":[{""Name"":""varX"",""Timestamp"":""2016-11-28T18:25:43.5110000Z"",""Value"":59}],""EventProcessedUtcTime"":""2016-12-08T12:17:01.1548870Z"",""PartitionId"":3,""EventEnqueuedUtcTime"":""2016-12-06T11:03:09.1030000Z"",""IoTHub"":{""MessageId"":""473ec94c-f922-4775-8735-62e2cef57096"",""CorrelationId"":null,""ConnectionDeviceId"":""device001"",""ConnectionDeviceGenerationId"":""5673653"",""EnqueuedTime"":""0001-01-01T00:00:00.0000000"",""StreamId"":null}}";
            Console.WriteLine(USQLCSharpHelper.PropertiesExtractor.ExtractPropertiesFromJsonAsString(sampleOK));

            string sampleKO1 = @"{""DeviceId""=""device001"",""Country"":""FR"",""Variables"":[{""Name"":""varX"",""Timestamp"":""2016-11-28T18:25:43.5110000Z"",""Value"":59}],""EventProcessedUtcTime"":""2016-12-08T12:17:01.1548870Z"",""PartitionId"":3,""EventEnqueuedUtcTime"":""2016-12-06T11:03:09.1030000Z"",""IoTHub"":{""MessageId"":""473ec94c-f922-4775-8735-62e2cef57096"",""CorrelationId"":null,""ConnectionDeviceId"":""device001"",""ConnectionDeviceGenerationId"":""5673653"",""EnqueuedTime"":""0001-01-01T00:00:00.0000000"",""StreamId"":null}}";
            Console.WriteLine(USQLCSharpHelper.PropertiesExtractor.ExtractPropertiesFromJsonAsString(sampleKO1));

            string sampleKO2 = @"{""DeviceId"":""device001"",""Country"":""FR"",""VariablesBad"":[{""Name"":""varX"",""Timestamp"":""2016-11-28T18:25:43.5110000Z"",""Value"":59}],""EventProcessedUtcTime"":""2016-12-08T12:17:01.1548870Z"",""PartitionId"":3,""EventEnqueuedUtcTime"":""2016-12-06T11:03:09.1030000Z"",""IoTHub"":{""MessageId"":""473ec94c-f922-4775-8735-62e2cef57096"",""CorrelationId"":null,""ConnectionDeviceId"":""device001"",""ConnectionDeviceGenerationId"":""5673653"",""EnqueuedTime"":""0001-01-01T00:00:00.0000000"",""StreamId"":null}}";
            Console.WriteLine(USQLCSharpHelper.PropertiesExtractor.ExtractPropertiesFromJsonAsString(sampleKO2));

            Console.ReadLine();
        }
    }
}
