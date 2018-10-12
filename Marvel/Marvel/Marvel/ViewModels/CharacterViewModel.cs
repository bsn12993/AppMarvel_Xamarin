using Marvel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        #region Contructors
        public CharacterViewModel(Result character)
        {
            this.Character = character;
        }
        #endregion

        #region Properties
        public Result Character { get; set; }
        #endregion
    }
}
