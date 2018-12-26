using GalaSoft.MvvmLight.Command;
using Marvel.Models;
using Marvel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    public class CharactersViewModel : BaseViewModel
    {
        #region Contructors
        public CharactersViewModel()
        {
            this.apiService = new ApiService();
            this.LoadCharacters();
        }
        #endregion

        #region Properties
        public ObservableCollection<CharacterItemViewModel> Characters
        {
            get { return this.characters; }
            set { SetValue(ref this.characters, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Attributes
        private ObservableCollection<CharacterItemViewModel> characters;
        private bool isRefreshing;
        private string filter;
        private ApiService apiService;
        #endregion

        #region Methods
        private async void LoadCharacters()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;
            }

            var response = await this.apiService.GetList<RootObject>("http://gateway.marvel.com", "/v1/public", "/characters?ts=9&apikey=933b10f922534c7fc5fc7e809081ba8e&hash=b2306de7f116811f8b70d282f2601ba3");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var list = ((RootObject)response.Result).data.results;
            MainViewModel.GetInstance().CharactersList = this.ToCharacterItemViewModel(list);
            //MainViewModel.GetInstance().CharactersList = listViewModel;
            this.Characters = new ObservableCollection<CharacterItemViewModel>(MainViewModel.GetInstance().CharactersList);
            this.IsRefreshing = false;
        }

        private IEnumerable<CharacterItemViewModel> ToCharacterItemViewModel(List<Result> list)
        {
            return list.Select(c => new CharacterItemViewModel
            {
                comics = c.comics,
                description = c.description,
                events = c.events,
                id = c.id,
                modified = c.modified,
                name = c.name,
                resourceURI = c.resourceURI,
                series = c.series,
                stories = c.stories,
                image = string.Format("{0}.{1}", c.thumbnail.path, c.thumbnail.extension),
                urls = c.urls
            });
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Characters = new ObservableCollection<CharacterItemViewModel>(MainViewModel.GetInstance().CharactersList);
            }
            else
            {
                this.Characters = new ObservableCollection<CharacterItemViewModel>(MainViewModel.GetInstance().CharactersList.Where(c => c.name.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get { return new RelayCommand(LoadCharacters); }
        }

        public ICommand SearchCommand
        {
            get { return new RelayCommand(Search); }
        }
        #endregion
    }
}
