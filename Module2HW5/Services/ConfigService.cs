using System.IO;
using Module2HW5.Services.Abstractions;
using Module2HW5.Models;
using Newtonsoft.Json;

namespace Module2HW5.Services
{
    public class ConfigService : IConfigService
    {
        private ConfigModel _configModel;
        public ConfigService()
        {
            var json = File.ReadAllText("config.json");
            _configModel = JsonConvert.DeserializeObject<ConfigModel>(json);
        }

        public ConfigModel Get()
        {
            return _configModel;
        }
    }
}
