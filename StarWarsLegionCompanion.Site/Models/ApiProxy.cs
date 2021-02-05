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

        //GET UNITS
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
        public async Task<List<Unit>> GetAllUnitsByFaction(int id)
        {
            var response = await client.GetAsync($"{client.BaseAddress}units/faction/{id}");
            string result = await response.Content.ReadAsStringAsync();
            List<Unit> units = JsonConvert.DeserializeObject<List<Unit>>(result);

            return units;
        }

        //GET UPGRADES
        public async Task<List<Upgrade>> GetAllUpgrades()
        {
            var response = await client.GetAsync($"{client.BaseAddress}upgrade");
            string result = await response.Content.ReadAsStringAsync();
            List<Upgrade> upgrades = JsonConvert.DeserializeObject<List<Upgrade>>(result);

            return upgrades;
        }
        public async Task<Upgrade> GetUpgrade(int id)
        {
            var response = await client.GetAsync($"{client.BaseAddress}upgrade/{id}");
            string result = await response.Content.ReadAsStringAsync();
            Upgrade upgrade = JsonConvert.DeserializeObject<Upgrade>(result);

            return upgrade;
        }
        public async Task<List<Upgrade>> GetAllUpgradesByCategory(int id)
        {
            var response = await client.GetAsync($"{client.BaseAddress}Upgrade/Category/{id}");
            string result = await response.Content.ReadAsStringAsync();
            List<Upgrade> upgrades = JsonConvert.DeserializeObject<List<Upgrade>>(result);

            return upgrades;
        }

        //GET CHOSEN UNITS
        public async Task<List<ChosenUnit>> GetAllChosenUnits()
        {
            var response = await client.GetAsync($"{client.BaseAddress}chosenunit");
            string result = await response.Content.ReadAsStringAsync();
            List<ChosenUnit> chosenunits = JsonConvert.DeserializeObject<List<ChosenUnit>>(result);

            return chosenunits;
        }
        public async Task<ChosenUnit> GetChosenUnit(int id)
        {
            var response = await client.GetAsync($"{client.BaseAddress}chosenunit/{id}");
            string result = await response.Content.ReadAsStringAsync();
            ChosenUnit chosenunit = JsonConvert.DeserializeObject<ChosenUnit>(result);

            return chosenunit;
        }
        public async Task<List<ChosenUnit>> GetChosenUnitByArmy(int id)
        {
            var response = await client.GetAsync($"{client.BaseAddress}chosenunit/army/{id}");
            string result = await response.Content.ReadAsStringAsync();
            List<ChosenUnit> chosenunit = JsonConvert.DeserializeObject<List<ChosenUnit>>(result);

            return chosenunit;
        }

        //GET CHOSEN UPGRADES
        public async Task<List<ChosenUpgrade>> GetAllChosenUpgrades()
        {
            var response = await client.GetAsync($"{client.BaseAddress}ChosenUpgrade");
            string result = await response.Content.ReadAsStringAsync();
            List<ChosenUpgrade> chosenupgrades = JsonConvert.DeserializeObject<List<ChosenUpgrade>>(result);

            return chosenupgrades;
        }
        public async Task<List<ChosenUpgrade>> GetChosenUpgradeByChosenUnit(int id) //by ChosenUnit Id
        {
            var response = await client.GetAsync($"{client.BaseAddress}ChosenUpgrade/ChosenUnit/{id}");
            string result = await response.Content.ReadAsStringAsync();
            List<ChosenUpgrade> chosenupgrades = JsonConvert.DeserializeObject<List<ChosenUpgrade>>(result);

            return chosenupgrades;
        }
        //GET ARMY
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
        //GET OTHER
        public async Task<List<Faction>> GetFactions()
        {
            var response = await client.GetAsync($"{client.BaseAddress}factions");
            string result = await response.Content.ReadAsStringAsync();
            List<Faction> factions = JsonConvert.DeserializeObject<List<Faction>>(result);

            return factions;
        }

        //POST
        public async Task PostChosenUnit(ChosenUnit model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await client.PostAsync($"{client.BaseAddress}chosenunit", content);
        }

        public async Task PostChosenUpgrade(ChosenUpgrade model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await client.PostAsync($"{client.BaseAddress}ChosenUpgrade", content);
        }
        /// <summary>
        /// Post a newly created Army
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The new army's Id as int</returns>
        public async Task<int> PostArmyList(Army model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{client.BaseAddress}armylist", content);
            var result = await response.Content.ReadAsStringAsync();
            Army armyList = JsonConvert.DeserializeObject<Army>(result);
            var newId = armyList.Id;
            return newId;
        }

        //PUT
        public async Task UpdateArmyList(int id, Army model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await client.PutAsync($"{client.BaseAddress}armylist/{id}", content);
        }

        //DELETE
        public async Task DeleteChosenUnit(int id)
        {
            await client.DeleteAsync($"{client.BaseAddress}chosenunit/{id}");
        }
        public async Task DeleteChosenUpgrade(int id)
        {
            await client.DeleteAsync($"{client.BaseAddress}ChosenUpgrade/{id}");
        }

        public async Task DeleteArmyList(int id)
        {
            await client.DeleteAsync($"{client.BaseAddress}armylist/{id}");
            //Maybe return armyname for user feedback
        }
    }
}
