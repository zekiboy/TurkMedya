using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using TurkMedya.Business.Abstract;
using TurkMedya.Entity;
using TurkMedya.Entity.DetailEntities;
using TurkMedya.Presentation.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace TurkMedya.Presentation.Controllers;

public class HomeController : Controller
{

    //constructor içerisinde veri çekeceğimiz metodları kullanmak için INewsService sınıfını çağırdık
    private readonly INewsService _newsService;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, INewsService newsService)
    {
        _newsService = newsService;
        _logger = logger;
    }



    public async Task<IActionResult> Index(string category, string keyword, int pageNumber = 1, int pageSize = 5)
    {
        //html sayfasına aktarılacak boş bir model oluşturdum
        var viewModel = new HomeViewModel
        {
            NewsItems = new List<Item>(),
        };

        //HomeViewModel nesnesi olarak öynyüze aktarabilmek adına elimizdeki List<Item> türündeki veriyi servisten çekiyoruz 
        var newsList = await _newsService.GetAllNewsAsync() ;

        //anahtar kelime ve kategori aramalarını kombinasyonlarına göre karşıladık
        if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(keyword))
        {
            //Hem anahtar kelime hem de kategori değeri dönülürse yapılacak işlemler

                foreach (Item item in newsList)
                {
                    //ilgili haber başlığı için anahtar kelime VE kategori bilgisi için içerik kontrolü yapılıyor
                    if (item.Category.Title.ToUpper(new CultureInfo("tr-TR", false)).Contains(category.ToUpper(new CultureInfo("tr-TR", false)))
                    && item.Title.ToUpper(new CultureInfo("tr-TR", false)).Contains(keyword.ToUpper(new CultureInfo("tr-TR", false))))
                    {

                         viewModel.NewsItems.Add(item);
                    }
      
                }


        }
        else if (!string.IsNullOrEmpty(category) && string.IsNullOrEmpty(keyword))
        {
            //Sadece kategori değeri dönülürse yapılacak işlemler


                foreach (Item item in newsList)
                {
                    if (item.Category.Title.ToUpper(new CultureInfo("tr-TR", false)).Contains(category.ToUpper(new CultureInfo("tr-TR", false))))
                    {
                        viewModel.NewsItems.Add(item);
                    }
                }


        }

        else if (string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(keyword))
        {

            //Sadece anahtar kelime verilirse çalışacak kod

            //html sayfamızın view modeli Root.cs olduğu için, anahtar kelimeyi bir haber başlığı içerisinde bulduğunda

                foreach (Item item in newsList)
                {
                    if (item.Title.ToUpper(new CultureInfo("tr-TR", false)).Contains(keyword.ToUpper(new CultureInfo("tr-TR", false))))
                    {
                         viewModel.NewsItems.Add(item);
                    }

                 }


        }
        else
        {
            viewModel.NewsItems = newsList;

        }


        //Alt satırlardaki kodlar haberleri beşerli olarak listeleyebilmek için yapıldı 
        // Filtrelenmiş öğelerin toplam sayısını hesapla
        var toplamFiltrelenmisHaberler = viewModel.NewsItems.Count();

        // Filtrelenmiş listeye sayfalama uygula
        var sayfalananHaberler = viewModel.NewsItems
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        //sayfalama verileri viewModel nesnesine aktarılarak html sayfasına gönderildi
        viewModel.NewsItems = sayfalananHaberler;
        viewModel.PageNumber = pageNumber;
        viewModel.PageSize = pageSize;
        viewModel.TotalPages = (int)Math.Ceiling(toplamFiltrelenmisHaberler / (double)pageSize);

        return View(viewModel);

    }



    //Detail.cshtml sayfamızı ayağa kaldıracak metod
    public async Task<IActionResult> DetailAsync(string id)
    {

        //servis aracılığla https://www.turkmedya.com.tr/detay.json adresinden ön yüze gönderilecek haberin detaylarını çekiyoruz
        var detailRoot = await _newsService.GetNewsDetailAsync();

        return View(detailRoot);
    }





    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

