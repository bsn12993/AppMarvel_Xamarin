﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvel.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterTabbedPage : TabbedPage
	{
		public CharacterTabbedPage ()
		{
			InitializeComponent ();
		}
	}
}