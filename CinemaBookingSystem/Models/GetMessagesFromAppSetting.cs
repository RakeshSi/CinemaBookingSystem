using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBookingSystem.Models
{
    public class GetMessagesFromAppSetting
    {
        public IConfigurationRoot Configuration { get; set; }
        /// <summary>
        /// This Method is use to read the data from appsetting.json file.
        /// We are using that file to store messages and configuration setting.
        /// </summary>
        /// <param name="tagName">tag name are the root value of the json which contains the keys,Like ResponseCode,StatusCode,Messages,AppSettings</param>
        /// <param name="key">Provide the key name to read the value from appsetting.json</param>
        /// <returns>Method will return the value according to the key</returns>
        public string GetMessageFromConfiguration(string tagName, string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json"); Configuration = builder.Build();
            var SettingsEnumerable = Configuration.AsEnumerable();
            List<KeyValuePair<string, string>> listOfSettings = SettingsEnumerable.ToList();
            string value = (from c in listOfSettings.Where(x => x.Key == tagName + ":" + key) select c.Value).FirstOrDefault();
            return value;
        }
    }
}
