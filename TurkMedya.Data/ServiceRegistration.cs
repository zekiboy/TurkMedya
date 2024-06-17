using System;
using Microsoft.Extensions.DependencyInjection;
using TurkMedya.Data.Abstract;
using TurkMedya.Data.Concrete;

namespace TurkMedya.Data
{
    //Data katmanındaki bağımlılıkların hazırlandığı enjeksiyon dosyası 
    public static class ServiceRegistration
	{
        public static void AddDataServices(this IServiceCollection serviceCollection)
        {
            //projede NewsRepository sınıfı ile INewsRepository interfacei üzerinden iletişim kurulacak, soyutlama yapılacak
            serviceCollection.AddScoped<INewsRepository, NewsRepository>();

        }


    }
}

