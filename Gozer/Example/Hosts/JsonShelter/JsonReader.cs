using System.IO;
using System.Threading.Tasks;

namespace JsonShelter
{
    public class JsonRepository
    {
        private readonly string _path;

        public JsonRepository(string path)
        {
            _path = Path.Combine(path, "Serives.json");

            if (!File.Exists(_path))
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                
                File.Create(_path).Close();
            }
        }

        public async Task Write(string fileText)
        {
            await System.IO.File.WriteAllTextAsync(_path, fileText);
        }

        public string Read()
        {
            var text = System.IO.File.ReadAllText(_path);
            return text;
        }
    }
}