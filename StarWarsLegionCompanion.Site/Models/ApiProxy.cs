using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Site.Models
{
    public class ApiProxy
    {
        private readonly HttpClient client;

        public ApiProxy(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> GetAllUnits()
        {
            var response = await client.GetAsync($"{client.BaseAddress}units");
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }

    }
}
