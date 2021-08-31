using System;
using System.Collections.Generic;
using CursoXamarin.ViewModels;
using Xamarin.Forms;

namespace CursoXamarin.Views
{
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();

            BindingContext = new MapViewModel();
        }
    }
}
