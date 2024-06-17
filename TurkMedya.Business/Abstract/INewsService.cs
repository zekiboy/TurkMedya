using System;
using TurkMedya.Entity;
using TurkMedya.Entity.DetailEntities;

namespace TurkMedya.Business.Abstract
{
	public interface INewsService
	{
        //Kapsülleme amaçlı business katmanında kullanılmak üzere interfaceler oluşturuldu
        //entity ve data katmanları referans eklendi


        Task<DetailRoot> GetNewsDetailAsync();

        Task<List<Item>> GetAllNewsAsync();

    }
}

