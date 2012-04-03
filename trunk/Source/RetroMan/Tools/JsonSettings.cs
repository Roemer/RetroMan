using System.IO;
using Newtonsoft.Json;

namespace RetroMan.Tools
{
    public class JsonSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public static void Save(T settingsObject, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(settingsObject, Formatting.Indented));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
            {
                t = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
            }
            return t;
        }
    }
}
