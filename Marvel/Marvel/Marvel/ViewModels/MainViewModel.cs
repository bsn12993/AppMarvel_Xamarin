using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Marvel.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            instance = this;
            this.Characters = new CharactersViewModel();
            this.LoadMenu();
        }

        public CharactersViewModel Characters { get; set; }
        public CharacterViewModel Character { get; set; }
        public IEnumerable<CharacterItemViewModel> CharactersList { get; set; }
        public ObservableCollection<MenuViewModel> Menu { get; set; }


        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null) return new MainViewModel();
            else return instance;
        }
        #endregion

        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuViewModel>();
            this.Menu.Add(new MenuViewModel
            {
                Title = "Characters",
                Icon = "",
                PageName = "CharactersPage"
            });
        }


    }
}
