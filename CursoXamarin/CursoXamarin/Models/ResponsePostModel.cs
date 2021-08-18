using System;
using System.Collections.ObjectModel;

namespace CursoXamarin.Models
{
    public class ResponsePostModel : ResponseModel
    {
        public ObservableCollection<PostModel> data { get; set; }

        public ResponsePostModel()
        {
        }
    }
}
