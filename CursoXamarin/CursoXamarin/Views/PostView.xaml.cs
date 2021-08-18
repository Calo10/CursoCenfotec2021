using System;
using System.Collections.Generic;
using CursoXamarin.ViewModels;
using Xamarin.Forms;

namespace CursoXamarin.Views
{
    public partial class PostView : ContentPage
    {
        public PostView(string id)
        {
            InitializeComponent();

            BindingContext = new PostViewModel(id);
        }
    }
}
