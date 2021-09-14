using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CursoXamarin.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

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

        private ImageSource _ImageSource;
        public ImageSource ImageSource
        {
            get { return _ImageSource; }

            set
            {
                _ImageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        public ICommand TakePhotoCommand { get; set; }

        #endregion


        public PostViewModel(string id)
        {
            FillPost(id);

            TakePhotoCommand = new Command(TakePhoto);
          
        }

        public async void TakePhoto()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                if (photo == null)
                {
                    return;
                }

                ImageSource = photo.FullPath;

            }
            catch (Exception ex)
            {

            }
            
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
