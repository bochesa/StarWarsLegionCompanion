using StarWarsLegionMobile.Services;
using StarWarsLegionMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.ViewModels
{
    public partial class KeywordViewModel : BaseViewModel
    {
        DatabaseServices databaseServices;
       
        public ObservableCollection<KeywordModel> Keywords { get; } = new ObservableCollection<KeywordModel>();

        public KeywordViewModel(DatabaseServices databaseServices)
        {
            Title = "Keywords database";
            this.databaseServices = databaseServices;
        }

        

        // Commands - [RelayCommand]
        [RelayCommand]
        async Task GoToDetailsAsync(KeywordModel keywordModel)
        {
            if (keywordModel is null) return;

            await Shell.Current.GoToAsync($"{nameof(KeywordDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    { 
                        "KeywordModel",keywordModel
                    }
                });

        }


        [RelayCommand]
        async Task GetKeywords()
        {
            if(IsBusy) return;

            try
            {
                IsBusy = true;
                var keywords = await databaseServices.GetKeywordsLocally();
                //var keywords = await databaseServices.GetKeywords();
                if(Keywords.Count != 0) 
                {
                    Keywords.Clear();
                }
                foreach (var keyword in keywords)
                {
                    if(keyword.ActionType == ActionType.CardAction) 
                    { keyword.IsCardAction = true; }
                    if(keyword.ActionType == ActionType.FreeAction)
                    { keyword.IsFreeAction = true; }
                    if(keyword.KeywordType == KeywordType.None)
                    { keyword.IsTypeNotNone = false; }
                    Keywords.Add(keyword);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get keywords: {ex.Message}", "OK");
            }
            finally 
            { 
                IsBusy = false;
            }

        }
    }
}
