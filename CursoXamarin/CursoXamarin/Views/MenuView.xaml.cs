﻿using System;
using System.Collections.Generic;
using CursoXamarin.ViewModels;
using Xamarin.Forms;

namespace CursoXamarin.Views
{
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();

            BindingContext = new MenuViewModel();
        }
    }
}
