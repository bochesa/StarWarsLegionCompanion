﻿using StarWarsLegionMobile.Views;
using System.Net.Http.Json;

namespace StarWarsLegionMobile.Services
{
    public class DatabaseServices
    {
        HttpClient httpClient;
        public DatabaseServices()
        {
            httpClient= new HttpClient();
        }

        List<KeywordModel> keywords = new List<KeywordModel>();
        List<UpgradeModel> upgrades = new List<UpgradeModel>();
        List<UnitModel> units = new List<UnitModel>();

        public async Task<List<KeywordModel>> GetKeywordsLocally()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("keywordsdata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            keywords = JsonSerializer.Deserialize<List<KeywordModel>>(contents);

            return keywords;
        }
        public async Task<List<UpgradeModel>> GetUpgradesLocally()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("upgradesdata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            upgrades = JsonSerializer.Deserialize<List<UpgradeModel>>(contents);

            return upgrades;
        }
        public async Task<List<UnitModel>> GetUnitsLocally()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("unitsdata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            units = JsonSerializer.Deserialize<List<UnitModel>>(contents);

            return units;
        }
        public async Task<List<KeywordModel>> GetKeywords()
        {
            if (keywords?.Count > 0)
            {
                return keywords;
            }

            var url = "https://localhost:5001/Keywords";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                keywords = await response.Content.ReadFromJsonAsync<List<KeywordModel>>();
            }

            return keywords;

        }

    }
}