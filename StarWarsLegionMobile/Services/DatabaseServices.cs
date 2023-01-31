using Microsoft.Maui.Storage;
using StarWarsLegionMobile.Views;
using System.Net.Http.Json;
using UtilityLibrary.Models;

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
        List<ArmyModel> armies = new ();

        public async void PostArmy(ArmyModel army)
        {

            var jsonString = JsonSerializer.Serialize(army);
            await Shell.Current.DisplayAlert("Saving", $"{jsonString}", "ok så!");

        }

        public async Task<List<KeywordModel>> GetKeywordsLocally()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("keywordsdata.json");
            using var reader = new StreamReader(stream);
            
            var contents = await reader.ReadToEndAsync();
            keywords = JsonSerializer.Deserialize<List<KeywordModel>>(contents);

            return keywords;
        }
        public async Task<List<ArmyModel>> GetArmiesLocally()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("armylistdata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            armies = JsonSerializer.Deserialize<List<ArmyModel>>(contents);

            return armies;
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
            if(units is not null ) 
            {
                foreach (var unit in units)
                {
                    var unitName = Helper.RemoveWhitespace(unit.Name).ToLower();
                    unit.UnitThumb = $"https://image.bochesa.dk/Units/Icons/{unitName}.jpeg";
                    
                }
            }
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
