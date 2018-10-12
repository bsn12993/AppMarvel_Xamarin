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
        }
        public CharactersViewModel Characters { get; set; }
        public IEnumerable<CharacterItemViewModel> CharactersList { get; set; }


        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null) return new MainViewModel();
            else return instance;
        }
        #endregion

    }
}
