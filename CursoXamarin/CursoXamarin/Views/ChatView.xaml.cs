using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CursoXamarin.ViewModels;
using Xamarin.Forms;

namespace CursoXamarin.Views
{
    public partial class ChatView : ContentPage
    {
        public ICommand ScrollListCommand { set; get; }

        public ChatView()
        {
            InitializeComponent();

            BindingContext = new ChatViewModel();

            ScrollListCommand = new Command(() => ChatList.ScrollTo((this.BindingContext as ChatViewModel).Messages.Last(), ScrollToPosition.End, true));
        }
    }
}
