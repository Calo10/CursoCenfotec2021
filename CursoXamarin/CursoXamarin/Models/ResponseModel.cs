using System;
namespace CursoXamarin.Models
{
    public class ResponseModel
    {

        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }

        public ResponseModel()
        {
        }
    }
}
