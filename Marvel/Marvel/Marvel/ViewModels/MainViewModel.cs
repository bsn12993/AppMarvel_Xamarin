using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Marvel.ViewModels
{
    public class MainViewModel
    {
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Characters = new CharactersViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Properties
        public CharactersViewModel Characters { get; set; }
        public CharacterViewModel Character { get; set; }
        public IEnumerable<CharacterItemViewModel> CharactersList { get; set; }
        public ObservableCollection<MenuViewModel> Menu { get; set; }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null) return new MainViewModel();
            else return instance;
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuViewModel>();
            this.Menu.Add(new MenuViewModel
            {
                Title = "Characters",
                Icon = "",
                PageName = "CharactersPage"
            });
            //this.Menu.Add(new MenuViewModel
            //{
            //    Title = "Comics",
            //    Icon = "",
            //    PageName = "CharactersPage"
            //});

            //this.Menu.Add(new MenuViewModel
            //{
            //    Title = "Events",
            //    Icon = "",
            //    PageName = "CharactersPage"
            //});

            //this.Menu.Add(new MenuViewModel
            //{
            //    Title = "Stories",
            //    Icon = "",
            //    PageName = "CharactersPage"
            //});

            //this.Menu.Add(new MenuViewModel
            //{
            //    Title = "Series",
            //    Icon = "",
            //    PageName = "CharactersPage"
            //});
        }
        #endregion

    }
}
