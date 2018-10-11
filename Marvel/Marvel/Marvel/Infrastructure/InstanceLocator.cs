using Marvel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Infrastructure
{
    public class InstanceLocator
    {
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }

        public MainViewModel Main { get; set; }
    }
}
