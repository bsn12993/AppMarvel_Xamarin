using Marvel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Infrastructure
{
    public class InstanceLocator
    {
        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion

        #region Properties
        public MainViewModel Main { get; set; }
        #endregion
    }
}
