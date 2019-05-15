using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var content = File.ReadAllText(@"Data\currencies.json");

            return
                JsonConvert
                .DeserializeObject<Currency[]>(content);
        }
    }
}
