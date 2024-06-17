using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TurkMedya.Data.Abstract;
using TurkMedya.Entity;
using TurkMedya.Entity.DetailEntities;

namespace TurkMedya.Data.Concrete
{
    public class NewsRepository : INewsRepository
    {
        //ilgili interfaceleri çağırabilmek için INewsRepository sınıfından kalıtım aldık


        private readonly HttpClient  _httpClient;

        public NewsRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //bütün haberleri çekecek metod
        public async Task<List<Item>> GetAllNewsAsync()
        {
            //httpClient ile anasayfa.json verisini çekiyoruz
            HttpResponseMessage response = await _httpClient.GetAsync("https://www.turkmedya.com.tr/anasayfa.json");
            response.EnsureSuccessStatusCode();
            //json veriyi bir string değer ile karşılıyoruz
            string jsonData = await response.Content.ReadAsStringAsync();

            //string olarak tuttuğumuz datayı deserialize ederek Root sınıfıyla karşılıyoruz         
            var newsRoot = JsonConvert.DeserializeObject<Root>(jsonData);

            var allNews = new List<Item>();

            foreach (var data in newsRoot.Data)
            {
                allNews.AddRange(data.ItemList);

            }


            return allNews;
        }





        //haber detay sayfalarını çekecek metod
        public async Task<DetailRoot> GetNewsDetailAsync()
        {
            //httpClient ile verilen link üzerinden json formatındaki veriyi GetAsync metodu ile çekiyoruz
            HttpResponseMessage response = await _httpClient.GetAsync("https://www.turkmedya.com.tr/detay.json");
            //Yanıt başarılı mı kontrol 
            response.EnsureSuccessStatusCode();

            //json veriyi bir string ile karşılıyoruz
            string jsonData = await response.Content.ReadAsStringAsync();

            //string veriyi DetailRoot sınıfına göre deserialize ediyoruz 
            var detail = JsonConvert.DeserializeObject<DetailRoot>(jsonData);


            return detail;

        }

    }
}

 