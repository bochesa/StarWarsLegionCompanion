using StarWarsLegionCompanion.Api.Models;
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

        public async Task<string> GetArmyLists()
        {
            var response = await client.GetAsync($"{client.BaseAddress}armylists");
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
        public async Task<string> GetFactions()
        {
            var response = await client.GetAsync($"{client.BaseAddress}factions");
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task PostArmyList(HttpContent content)
        {
            await client.PostAsync($"{client.BaseAddress}armylist", content);
        }

    }
}
