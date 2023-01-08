﻿using CommunityToolkit.Mvvm.Messaging;
using StarWarsLegionMobile.Messages;
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
    public partial class ArmyListViewModel: BaseViewModel
    {
        DatabaseServices databaseServices;
        public ArmyListViewModel(DatabaseServices databaseServices)
        {
            this.databaseServices = databaseServices;
        }

        public ObservableCollection<ArmyModel> Armies { get; } = new();

        [RelayCommand]
        async Task CreateNewArmyAsync(string faction)
        {
            await Shell.Current.GoToAsync($"{nameof(ArmyBuilderPage)}?faction={faction}", true);
            WeakReferenceMessenger.Default.Send(new UpdateArmyFaction(faction));
        }

        [RelayCommand]
        async Task GetArmies()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var armies = await databaseServices.GetArmiesLocally();
                //var armies = await databaseServices.GetArmies();
                if (Armies.Count != 0)
                {
                    Armies.Clear();
                }
                foreach (var armyModel in armies)
                {
                    Armies.Add(armyModel);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get army: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

    }
}
