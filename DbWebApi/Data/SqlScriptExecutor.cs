using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Data.SqlClient;

namespace DbWebApi.Data
{
    public class SqlScriptExecutor : ISqlScriptExecutor
    {
        private readonly string _connectionString;
        private readonly IHostEnvironment _hostEnvironment;

        public SqlScriptExecutor(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            _connectionString = configuration.GetConnectionString("DbConnection");
            _hostEnvironment = hostEnvironment;
        }

        public void ExecuteScriptFromFile(string filePath)
        {
            string scriptPath = Path.Combine(_hostEnvironment.ContentRootPath, filePath);

            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException($"Script file not found: {scriptPath}");
            }

            string scriptContent = File.ReadAllText(scriptPath);
            ExecuteScript(scriptContent);
        }

        private void ExecuteScript(string script)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(script, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
