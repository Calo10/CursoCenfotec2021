using System;
using Realms;

namespace CursoXamarin.Models
{
    public class UserModel : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserModel()
        {
        }
         
    }
}
