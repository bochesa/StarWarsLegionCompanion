using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace StarWarsLegionMobile.Models
{
    public partial class ArmyModel : Army, INotifyPropertyChanged
    {
        private int activations;

        public int Activations
        {
            get => activations; set
            {
                activations = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Activations)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
