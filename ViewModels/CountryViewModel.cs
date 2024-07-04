using ExamPro3MateoHerrera.Modelos;
using ExamPro3MateoHerrera.Repositorios;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamPro3MateoHerrera.ViewModels
    
{

    

    public class CountryViewModel : INotifyPropertyChanged
    {
        private Country _model;

        public Country Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    
                    OnPropertyChanged(nameof(Model)); 
                }

            }
        }

        public ICommand MuestraCountry { get; }

        public CountryViewModel()
        {
            Model = new Country();
            MuestraCountry = new Command(async () => await ObtenerCountry());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public async Task ObtenerCountry()
        {
            CountryRepositorio repo = new CountryRepositorio("country.db");
            Country country = await repo.DevuelveCountryAsync();
            repo.GuardarCountry(country);
            Model.Name = country.Name;
            OnPropertyChanged(nameof(Model));
        }

       

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }







    }

        



}
