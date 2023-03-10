using Microsoft.AspNetCore.HttpLogging;
using MySqlConnector;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace CoreApplication.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TableColumnAttribute : Attribute
    {
        public string Name { get; private set; }
        public TableColumnAttribute(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute
    {
        public string Name { get; private set; }
        public TableNameAttribute(string name)
        {
            Name = name;
        }
    }

    public abstract class AbstractModel<T> where T : AbstractModel<T>, new()
    {
        public static T? findById(int id)
        {
            var property = typeof(T).GetProperty("Id");
            var attribute = property?.GetCustomAttribute<TableColumnAttribute>();

            if (property == null || attribute == null)
                throw new Exception($"The model {typeof(T).FullName} does not have an 'Id' property.");

            return find(Tuple.Create(attribute.Name, "=", id as object)).FirstOrDefault();
        }

        protected static IReadOnlyList<T> find(params Tuple<string, string, object>?[] clauses)
        {
            var tableName = typeof(T).GetCustomAttribute<TableNameAttribute>()?.Name;
            if (tableName == null)
                throw new Exception($"The model is missing the table name attribute: '{typeof(T).FullName}'");

            var clauseBuilder = new StringBuilder();
            foreach (var clause in clauses)
            {
                if (clause == null) continue;
                clauseBuilder.Append($" {clause.Item1} {clause.Item2} @{clause.Item1}");
            }

            using var command = new MySqlCommand()
            {
                Connection = Database.Instance.connection,
                CommandText = $"SELECT * FROM {tableName} WHERE {clauseBuilder}",
            };

            foreach (var clause in clauses)
            {
                if (clause == null) continue;
                command.Parameters.AddWithValue(clause.Item1, clause.Item3);
            }

            using var reader = command.ExecuteReader();

            var result = new List<T>();
            if (!reader.HasRows)
                return result.AsReadOnly();
                
            while (reader.Read())
                result.Add(fromReader(reader));

            return result.AsReadOnly();
        }


        public static T fromReader(MySqlDataReader reader)
        {
            var data = new T();

            var properties = Assembly.GetAssembly(typeof(T))!.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(AbstractModel<T>)))
                .SelectMany(t => t.GetProperties());

            if (!reader.CanGetColumnSchema())
                throw new Exception("Couldnt get the column schema of the MySqlDataReader");
            
            foreach (var property in properties)
            {
                if (!property.CanWrite) continue;
                var attribute = property.GetCustomAttribute<TableColumnAttribute>();
                if (attribute == null) continue;

                if(property.PropertyType.IsEnum)
                {
                    property.SetValue(data, Enum.Parse(property.PropertyType, reader.GetString(attribute.Name), true));
                    continue;
                }

                // Switch virker ikke med typer...
                if(property.PropertyType == typeof(string))
                {
                    property.SetValue(data, reader.GetString(attribute.Name));
                }
                else if(property.PropertyType == typeof(int))
                {
                    property.SetValue(data, reader.GetInt32(attribute.Name));
                }
                else if(property.PropertyType == typeof(DateTime))
                {
                    property.SetValue(data, reader.GetDateTime(attribute.Name));
                }
                else if(property.PropertyType == typeof(float))
                {
                    property.SetValue(data, reader.GetFloat(attribute.Name));
                }
                else if(property.PropertyType == typeof(bool))
                {
                    property.SetValue(data, reader.GetInt32(attribute.Name) != 0);
                }
                else if(property.PropertyType == typeof(double))
                {
                    property.SetValue(data, reader.GetDouble(attribute.Name));
                }
                else
                {
                    throw new Exception($"Unhandled model property type: '{property.PropertyType.FullName}'");
                }
            }

            return data;
        }
    }
}
