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
            this.Character = new CharactersViewModel();
        }
       public CharactersViewModel Character { get; set; }
    }
}
