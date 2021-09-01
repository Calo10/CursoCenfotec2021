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

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }


        public LocationModel()
        {
        }
    }
}
