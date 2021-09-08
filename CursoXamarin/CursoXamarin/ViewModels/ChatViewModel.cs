using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CursoXamarin.Models;
using Xamarin.Forms;

namespace CursoXamarin.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {

        #region Properties


        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();

        public string TextToSend { get; set; }

        public ICommand OnSendCommand { get; set; }

        #endregion

        public ChatViewModel()
        {
            InitClass();
            InitCommands();
        }

        public async void InitClass()
        {
            Messages.Add(new MessageModel() { Text = "Hi" });
            Messages.Add(new MessageModel() { Text = "How are you?" });
            Messages.Add(new MessageModel() { Text = "Very good thanks!!!", User = "User1" });
        }
        
        public async void InitCommands()
        {
            OnSendCommand = new Command(OnSend);
        }

        public void OnSend()
        {
            if (!string.IsNullOrEmpty(TextToSend))
            {
                Messages.Add(new MessageModel() { Text = TextToSend, User = "User1" });
                TextToSend = string.Empty;
            }
        }
     

        #region PropertyChangedImplementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
