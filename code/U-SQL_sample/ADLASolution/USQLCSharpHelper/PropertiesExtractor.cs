using Microsoft.Analytics.Types.Sql;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USQLCSharpHelper
{
    /// <summary>
    /// this class extracts specific properties from JSON fields and send those properties back to U-SQL
    /// it is not generic, but this sample code is reusable as an example of how to deal with malformed JSON documents.
    /// </summary>
    public class PropertiesExtractor
    {
        public static SqlMap<string, string> ExtractPropertiesFromJson(string jsonText)
        {
            const string VERSION = "V170311a";
            string deviceId = "?";
            double var0Value = 0;
            DateTime var0Timestamp = DateTime.MinValue;
            string message = "OK";

            try
            {
                JObject data = JObject.Parse(jsonText);

                try
                {
                    var var0 = data["Variables"][0];
                    var0Value = (double)var0["Value"];
                    var0Timestamp = (DateTime)var0["Timestamp"];
                    deviceId = (string)data["DeviceId"];
                }
                catch (Exception ex)
                {
                    message = $"Field could not be extracted: {ex.Message}";
                }
            }
            catch (Exception ex)
            {
                message=$"Json could not be parsed: {ex.Message}";
            }

            KeyValuePair<string, string>[] result = new KeyValuePair<string, string>[5];
            result[0] = new KeyValuePair<string, string>("deviceId", deviceId);
            result[1] = new KeyValuePair<string, string>("var0Timestamp", var0Timestamp.ToString("o"));
            result[2] = new KeyValuePair<string, string>("var0Value", var0Value.ToString());
            result[3] = new KeyValuePair<string, string>("message", message);
            result[4] = new KeyValuePair<string, string>("version", VERSION);

            return SqlMap.Create(result);
        }

        public static string ExtractPropertiesFromJsonAsString(string jsonText)
        {
            const string sep = "|";
            StringBuilder result = new StringBuilder();

            try
            {
                JObject data = JObject.Parse(jsonText);

                try
                {
                    result.Append($"{(double)data["Variables"][0]["Value"]}{sep}OK");
                }
                catch (Exception ex)
                {
                    result.Append($"0.{sep}Field could not be extracted: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                result.Append($"0.{sep}Json could not be parsed: {ex.Message}");
            }

            return result.ToString();
        }
    }
}
