using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CursoXamarin.Views.Partials
{
    public partial class ChatInputBarView : ContentView
    {
        public ChatInputBarView()
        {
            InitializeComponent();
        }

        public void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            (this.Parent.Parent as ChatView).ScrollListCommand.Execute(null);
        }
    }
}
