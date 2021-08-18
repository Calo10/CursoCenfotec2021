using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CursoXamarin.Models
{
    public class PostModel
    {

        public string Text { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
        public string Link { get; set; }
        public string PublishDate { get; set; }

        public async static Task<ObservableCollection<PostModel>> GetAllPostFromDoctor(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri("https://dummyapi.io/data/api/user/" + id + "/post");

                client.DefaultRequestHeaders.Add("app-id", "5fad867bca750f4fc7508473");

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);

                string ans = await response.Content.ReadAsStringAsync();

                ResponsePostModel responseObject = JsonConvert.DeserializeObject<ResponsePostModel>(ans);

                return responseObject.data;
            }
        }

        public PostModel()
        {
        }
    }
}
