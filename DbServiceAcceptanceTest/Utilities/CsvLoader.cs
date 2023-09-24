using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace DbServiceAcceptanceTest.Utilities
{
    public class CsvLoader<T>
    {
        private readonly string _filePath;

        public CsvLoader(string filePath)
        {
            _filePath = filePath;
        }

        public IAsyncEnumerable<T> ReadFile()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecordsAsync<T>();
            }
        }
    }
}