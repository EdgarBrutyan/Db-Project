namespace DbWebApi.Data
{
    public interface ISqlScriptExecutor
    {
        void ExecuteScriptFromFile(string filePath);
    }
}