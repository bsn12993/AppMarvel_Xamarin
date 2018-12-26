using Marvel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Marvel.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        #region Contructors
        public CharacterViewModel(Result character)
        {
            this.Character = character;
            this.Comics = character.comics;
            this.Series = character.series;
            this.Stories = character.stories;
            this.Events = character.events;
        }
        #endregion

        #region Properties
        public Result Character { get; set; }
        public Comics Comics
        {
            get { return this.comics; }
            set { SetValue(ref this.comics, value); }
        }

        public Series Series
        {
            get { return this.series; }
            set { SetValue(ref this.series, value); }
        }

        public Stories Stories
        {
            get { return this.stories; }
            set { SetValue(ref this.stories, value); }
        }

        public Events Events
        {
            get { return this.events; }
            set { SetValue(ref this.events, value); }
        }
        #endregion

        #region Attributes
        private Comics comics;
        private Series series;
        private Stories stories;
        private Events events;
        #endregion
    }
}
