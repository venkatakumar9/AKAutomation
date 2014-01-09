using System.Linq;
using System.Xml.Linq;

namespace AKEcommerceAutomation.Framework
{
    /// <summary>
    ///     Example to obtain the environment configuration variable "URL":
    ///     string url = EnvironmentConfiguration.Instance.GetEnvironmentVariable("URL");
    /// </summary>
    public class EnvironmentConfiguration
    {
        private static EnvironmentConfiguration instance;
        private XElement environmentConfiguration;

        public static EnvironmentConfiguration Instance
        {
            get { return instance; }
        }

        public static void CreateInstance(string filename, string environmentName)
        {
            var environmentConfiguration = new EnvironmentConfiguration();
            environmentConfiguration.LoadEnvironmentConfiguration(filename, environmentName);
            instance = environmentConfiguration;
        }

        public string GetEnvironmentVariable(string variableName)
        {
            return environmentConfiguration.Element("Variables").Element(variableName).Value;
        }

        private void LoadEnvironmentConfiguration(string filename, string environmentName)
        {
            XDocument xmlData = XDocument.Load(filename);
            environmentConfiguration =
                xmlData.Root.Elements("Environment").Single(x => x.Attribute("name").Value == environmentName);
        }
    }
}