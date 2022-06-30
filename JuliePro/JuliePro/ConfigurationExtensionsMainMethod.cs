using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.Configuration
{
    public static partial class ConfigurationExtensions
    {
        private class ConnectionString
        {
            private string _connectionStringWithoutServer;

            public ConnectionString()
            { }
            public ConnectionString(string connectionString)
            {
                _connectionStringWithoutServer = string.Join(';', connectionString.Split(';').Where(i => i.Split('=')[0] != "Server"));
            }

            public string ToString(string serverValue)
            {
                return "Server=" + serverValue + ";" + _connectionStringWithoutServer;
            }
        }


        public static string GetConnectionStringForComputer(this IConfiguration config, string connectionStringName)
        {
            ConnectionString cs = new ConnectionString(config.GetConnectionString(connectionStringName));
            string computerName = System.Environment.MachineName;
            Dictionary<string, string> computerNameInfos = config.GetComputerNameInfos();
            string serverValue;

            if (computerNameInfos.Keys.Contains(computerName))
            {
                if(computerNameInfos.TryGetValue(computerName, out serverValue))
                {
                    return cs.ToString(serverValue);    
                }
            }
            else
            {
                Dictionary<string, string> namePrefixesInfos = config.GetNamePrefixesInfos();
                string key = namePrefixesInfos.Keys.Where(k => computerName.StartsWith(k)).FirstOrDefault();

                if (key != null && namePrefixesInfos.TryGetValue(key, out serverValue))
                {
                    return cs.ToString(serverValue.Replace("%ComputerName%", computerName));
                }
            }

            return "";
        }
    }
}
