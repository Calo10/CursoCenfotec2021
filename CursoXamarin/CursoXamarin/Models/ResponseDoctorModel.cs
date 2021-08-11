using System;
using System.Collections.ObjectModel;

namespace CursoXamarin.Models
{
    public class ResponseDoctorModel : ResponseModel
    {

        public ObservableCollection<DoctorModel> data { get; set; }

        public ResponseDoctorModel()
        {
        }
    }
}
