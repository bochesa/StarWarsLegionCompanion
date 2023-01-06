using StarWarsLegionMobile.Services;
using StarWarsLegionMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace StarWarsLegionMobile.ViewModels
{
    public partial class UnitViewModel : BaseViewModel
    {
        DatabaseServices databaseServices;

        public ObservableCollection<UnitModel> Units { get; } = new ObservableCollection<UnitModel>();
        public UnitViewModel(DatabaseServices databaseServices)
        {
            Title = "Unit database";
            this.databaseServices = databaseServices;

        }

        [RelayCommand]
        async Task GoToDetailsAsync(UnitModel unitModel)
        {
            if (unitModel is null) return;

            await Shell.Current.GoToAsync($"{nameof(UnitDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "UnitModel",unitModel
                    }
                });

        }

        [RelayCommand]
        async Task GetUnits()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var units = await databaseServices.GetUnitsLocally();
                //var keywords = await databaseServices.GetUnits();
                if (Units.Count != 0)
                {
                    Units.Clear();
                }
                foreach (var unit in units)
                {
                    Units.Add(unit);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get unit: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

    }
}
