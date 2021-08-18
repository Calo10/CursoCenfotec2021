using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CursoXamarin.Models;

namespace CursoXamarin.ViewModels
{
    public class PostViewModel : INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<PostModel> _lstPost = new ObservableCollection<PostModel>();

        public ObservableCollection<PostModel> lstPost
        {
            get
            {
                return _lstPost;
            }
            set
            {
                _lstPost = value;
                OnPropertyChanged("lstPost");
            }
        }

        #endregion


        public PostViewModel(string id)
        {
            FillPost(id);
        }

        public async void FillPost(string id)
        {
            lstPost = await PostModel.GetAllPostFromDoctor(id);
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
