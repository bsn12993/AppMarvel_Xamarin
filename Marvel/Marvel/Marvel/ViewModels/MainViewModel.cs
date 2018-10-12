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
            this.Characters = new CharactersViewModel();
        }
       public CharactersViewModel Characters { get; set; }
    }
}
