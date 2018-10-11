using Marvel.Models;
using Marvel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    public class CharactersViewModel : BaseViewModel
    {
        public CharactersViewModel()
        {
            this.apiService = new ApiService();
            this.LoadCharacters();
        }

        public ObservableCollection<CharacterItemViewModel> Characters
        {
            get { return this.characters; }
            set { SetValue(ref this.characters, value); }
        }

        public ObservableCollection<CharacterItemViewModel> characters;

        private ApiService apiService;


        private async void LoadCharacters()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;
            }

            var response = await this.apiService.GetList<RootObject>("http://gateway.marvel.com", "/v1/public", "/characters?ts=9&apikey=933b10f922534c7fc5fc7e809081ba8e&hash=b2306de7f116811f8b70d282f2601ba3");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var list = ((RootObject)response.Result).data.results;
            var listViewModel = this.ToCharacterItemViewModel(list);
            try
            {
                this.Characters = new ObservableCollection<CharacterItemViewModel>(listViewModel);
            }
            catch(Exception e)
            {
                var a = e.Message;
            }
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
                thumbnail = c.thumbnail,
                urls = c.urls
            });
        }
    }
}
