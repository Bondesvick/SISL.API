namespace SISL.Core.Interfaces
{
    public interface IAppSettings
    {
        object Get(string key);

        string GetString(string key);

        int GetInt(string key);

        bool GetBool(string key);

        long GetLong(string key);
    }
}