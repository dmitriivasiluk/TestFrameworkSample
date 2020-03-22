using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestFrameworkSample.Utils
{
    internal class ConfigurationManager
    {
        private static Dictionary<string, string> properties;

        public static string GetProperty(string key)
        {
            string configFileName = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                @"Configuration\",
                $"{GetEnvironment()}_config.json");

            if (File.Exists(configFileName))
            {
                properties = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(configFileName));
            }
            else
            {
                throw new FileNotFoundException($"{configFileName} missing and can't find configuration!");
            }

            var property = properties.FirstOrDefault(x => x.Key == key).Value;

            if (string.IsNullOrEmpty(property))
            {
                throw new ArgumentNullException($"A property with the key: '{key}' not found in configuration file");
            }
            else
            {
                return property;
            }
        }

        public static string GetEnvironment()
        {
            string environment = Environment.GetEnvironmentVariable("QA_TEST_ENV");

            return (environment ?? "qa").ToLower();
        }
    }
}