using GalaSoft.MvvmLight.Command;
using Marvel.Models;
using Marvel.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Marvel.ViewModels
{
    public class CharacterItemViewModel : Result
    {
        public string image { get; set; }

        public ICommand SelectedCharacterCommand
        {
            get { return new RelayCommand(SelectedCharacter); }
        }

        private async void SelectedCharacter()
        {
            MainViewModel.GetInstance().Character = new CharacterViewModel(this);
            //await Application.Current.MainPage.Navigation.PushAsync(new CharacterPage());
            await Application.Current.MainPage.Navigation.PushAsync(new CharacterTabbedPage());
        }
    }
}
