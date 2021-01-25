using Newtonsoft.Json;
using StarWarsLegionCompanion.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public async Task<List<Unit>> GetAllUnits()
        {
            var response = await client.GetAsync($"{client.BaseAddress}units");
            string result = await response.Content.ReadAsStringAsync();
            List<Unit> units = JsonConvert.DeserializeObject<List<Unit>>(result);

            return units;
        }
        public async Task<Unit> GetUnit(int id)
        {
            var response = await client.GetAsync($"{client.BaseAddress}units/{id}");
            string result = await response.Content.ReadAsStringAsync();
            Unit unit = JsonConvert.DeserializeObject<Unit>(result);

            return unit;
        }
        public async Task<Army> GetArmyList(int id)
        {
            var response = await client.GetAsync($"{client.BaseAddress}armylist/{id}");
            string result = await response.Content.ReadAsStringAsync();
            Army armyList = JsonConvert.DeserializeObject<Army>(result);
            return armyList;
        }
        public async Task<List<Army>> GetArmyLists()
        {
            var response = await client.GetAsync($"{client.BaseAddress}armylist");
            string result = await response.Content.ReadAsStringAsync();
            List<Army> armyLists = JsonConvert.DeserializeObject<List<Army>>(result);
            return armyLists;
        }
        public async Task<List<Faction>> GetFactions()
        {
            var response = await client.GetAsync($"{client.BaseAddress}factions");
            string result = await response.Content.ReadAsStringAsync();
            List<Faction> factions = JsonConvert.DeserializeObject<List<Faction>>(result);

            return factions;
        }

        public async Task PostArmyList(Army model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await client.PostAsync($"{client.BaseAddress}armylist", content);

        }

    }
}
