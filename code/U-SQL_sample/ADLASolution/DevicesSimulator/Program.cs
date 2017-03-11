using System;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using Nito.AsyncEx;

namespace DevicesSimulator
{
    /// <summary>
    /// this program injects data into IoTHub
    /// it does this thru one IoT Hub device (device001) so that it's simpler to configure IoT Hub but the messages themselves contain different device names.
    /// the IoT Hub device could be seen as a gateway that sends messages on behalf of different other devices
    /// </summary>
    class Program
    {
        static string iotHubUri = "tbrfabrikamiothub.azure-devices.net";
        static string deviceKey = "MCeCE##obfuscated##Vyv7v8f0s="; // the corresponding device id is expected to be: device001
        
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        static async void MainAsync(string[] args)
        {
            int nbDevices = 5;
            var now = DateTime.Now;
            DateTime dtStart = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // Time at which we start sending messages
            DateTime dtStartErratic = dtStart.AddMinutes(75); // Time at which the erratic device will start sending erratic values
            DateTime dtEndErratic = dtStart.AddMinutes(120); // Time at which the erratic device will go back to sending standard values
            DateTime dtEnd = dtStart.AddHours(48); // Time at which the last messages are being sent
            TimeSpan periodBetweenDataPoints = TimeSpan.FromMinutes(15);
            int missedPercentage = 5;         
            var rnd = new Random();
            int erraticDeviceNumber = rnd.Next(nbDevices);

            // {0} Device id (0 to nbDevices)
            // {1} Date time (2016-12-08T12:17:01.1548870Z)
            // {2} Value (500-600) (normal)
            // {2} Value (0-999) (erratic)
            string messageTemplate = @"{{""DeviceId"":""DEVICE_{0}"",""Country"":""FR"",""Variables"":[{{""Name"":""varX"",""Timestamp"":""{1}"",""Value"":{2}}}],""EventProcessedUtcTime"":""2016-12-08T12:17:01.1548870Z"",""PartitionId"":3,""EventEnqueuedUtcTime"":""2016-12-06T11:03:09.1030000Z"",""IoTHub"":{{""MessageId"":""ab40e85c-dbff-4924-8c99-4bb843e302e3"",""CorrelationId"":null,""ConnectionDeviceId"":""device001"",""ConnectionDeviceGenerationId"":""3653573573"",""EnqueuedTime"":""0001-01-01T00:00:00.0000000"",""StreamId"":null}}}}";
            var deviceClient = DeviceClient.Create(iotHubUri, 
                new DeviceAuthenticationWithRegistrySymmetricKey("device001", deviceKey), 
                TransportType.Http1);

            Console.WriteLine($"Simulating {nbDevices} device(s) sending 1 message every {periodBetweenDataPoints.TotalSeconds} second(s)");
            Console.WriteLine($"About {missedPercentage}% of the messages will not be sent");
            Console.WriteLine();
            Console.WriteLine($" [{dtStart.ToString("o")}] Messages are sent with values ranging from 500 to 599");
            Console.WriteLine($" [{dtStartErratic.ToString("o")}] Device {erraticDeviceNumber} starts sending erratic values from 0 to 999");
            Console.WriteLine($" [{dtEndErratic.ToString("o")}] Device {erraticDeviceNumber} stops sending erratic values and is back to normal (500 to 599)");
            Console.WriteLine($" [{dtEnd.ToString("o")}] Last messages are sent");
            Console.WriteLine($"Press any key to start sending around {nbDevices * ((dtEnd-dtStart).TotalSeconds / periodBetweenDataPoints.TotalSeconds) * (1-(double)missedPercentage/100)} messages...");
            Console.ReadLine();

            var totalTimeInSeconds = (dtEnd - dtStart).TotalSeconds;
            int value, nbMessages = 0;            


            for (double sec = 0; sec < totalTimeInSeconds; sec += periodBetweenDataPoints.TotalSeconds)
            {
                for (int deviceNumber = 0; deviceNumber < nbDevices; deviceNumber++)
                {
                    // Simulates missed measurements
                    if (rnd.Next(100) < missedPercentage)
                        continue;

                    var dt = dtStart.AddSeconds(sec);
                    if (dt >= dtStartErratic && dt <= dtEndErratic && deviceNumber == erraticDeviceNumber)
                        value = rnd.Next(999);
                    else
                        value = rnd.Next(99) + 500;
                    var message = string.Format(messageTemplate, deviceNumber.ToString("00"), dt.ToString("o"), value.ToString());
                    //Console.WriteLine($"[{deviceNumber} @ {dt.ToString("o")}] Value={value}");
                    await deviceClient.SendEventAsync(new Message(Encoding.ASCII.GetBytes(message)));
                    Console.WriteLine($"{message}");
                    nbMessages++;
                }
            }

            Console.WriteLine($"{nbMessages} messages generated");
            Console.WriteLine("All done...");
            Console.ReadLine();
        }

    }
}
