using MySqlConnector;
using System.Text.Json;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace CoreApplication
{
    public class Database
    {
        public static Database Instance {
            get {
                if(_instance == null)
                {
                    _instance = new Database();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        private static Database? _instance;

        public MySqlConnection connection;

        public Database()
        {
            connection = new MySqlConnection(GetConnectionString());
            connection.Open();
        }

        private string GetConnectionString()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "CoreApplication.Config.mysql.json";

            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
                throw new NullReferenceException($"Could not find the resource: '{resourceName}'");

            var json = JsonDocument.Parse(stream, new JsonDocumentOptions
            {
                AllowTrailingCommas = true,
                CommentHandling = JsonCommentHandling.Skip,
            });

            var host = json.RootElement.GetProperty("host").GetString();
            var port = json.RootElement.GetProperty("port").GetUInt32();
            var user = json.RootElement.GetProperty("user").GetString();
            var pass = json.RootElement.GetProperty("password").GetString();
            var db = json.RootElement.GetProperty("database").GetString();

            var builder = new MySqlConnectionStringBuilder();
            builder.Server = host;
            builder.Port = port;
            builder.UserID = user;
            builder.Password = pass;
            builder.Database = db;

            return builder.ToString();
        }
    }
}
