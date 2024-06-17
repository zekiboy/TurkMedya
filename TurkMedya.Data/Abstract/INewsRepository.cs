using System;
using System.Reflection.Emit;
using TurkMedya.Entity;
using TurkMedya.Entity.DetailEntities;

namespace TurkMedya.Data.Abstract
{
	public interface INewsRepository
	{
        // Projemizdeki repositoryleri interface ile karşılıyoruz.Metod gövdeleri aynı katmandaki Concrete klasörü altında bulunmaktadır
        //Projede katmanlı mimari kullanıldığı için, Entity katmanına bağımlılık ekleyerek DetailRoot, Item  sınıflarını çağırıyoruz
        Task<DetailRoot> GetNewsDetailAsync();
        Task<List<Item>> GetAllNewsAsync();


    }
}

