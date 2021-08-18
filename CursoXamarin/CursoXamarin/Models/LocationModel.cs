using System;
namespace CursoXamarin.Models
{
    public class LocationModel
    {

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Timezone { get; set; }


        public LocationModel()
        {
        }
    }
}
