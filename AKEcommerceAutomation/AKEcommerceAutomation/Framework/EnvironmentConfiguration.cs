using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace AKEcommerceAutomation.Framework
{
    /// <summary>
    /// Example to obtain the environment configuration variable "URL":
    /// string url = EnvironmentConfiguration.Instance.GetEnvironmentVariable("URL");
    /// </summary>
    public class EnvironmentConfiguration
    {
        private static EnvironmentConfiguration instance;

        public static EnvironmentConfiguration Instance
        {
            get
            {
                return instance;
            }
        }

        public static void CreateInstance(string filename, string environmentName)
        {
            EnvironmentConfiguration environmentConfiguration = new EnvironmentConfiguration();
            environmentConfiguration.LoadEnvironmentConfiguration(filename, environmentName);
            instance = environmentConfiguration;
        }

        private XElement environmentConfiguration;

        public string GetEnvironmentVariable(string variableName)
        {
            return this.environmentConfiguration.Element("Variables").Element(variableName).Value;
        }

        private void LoadEnvironmentConfiguration(string filename, string environmentName)
        {
            XDocument xmlData = XDocument.Load(filename);
            this.environmentConfiguration =
                xmlData.Root.Elements("Environment").Single(x => x.Attribute("name").Value == environmentName);
        }
    }
}
