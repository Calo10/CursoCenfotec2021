using System;
using System.Collections.Generic;
using CursoXamarin.ViewModels;
using Xamarin.Forms;

namespace CursoXamarin.Views
{
    public partial class DetailDoctorView : ContentPage
    {
        public DetailDoctorView()
        {
            InitializeComponent();

            BindingContext = HomeViewModel.GetInstance();
        }
    }
}
