using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Exchange.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Exchange.Repository
{
    public class JsonRepositoryReader : IRepositoryReader
    {
        public IEnumerable<Currency> GetCurrencies()
        {
            var dir =  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var jsonFile = Path.Combine(dir, @"Data\currencies.json");
            var content = File.ReadAllText(jsonFile);

            return
                JsonConvert
                .DeserializeObject<Currency[]>(content);
        }
    }
}
