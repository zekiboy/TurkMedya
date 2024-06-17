using System;
using Microsoft.Extensions.DependencyInjection;
using TurkMedya.Business.Abstract;
using TurkMedya.Business.Concrete;

namespace TurkMedya.Business
{
    //Business katmanındaki bağımlılıkların hazırlandığı enjeksiyon dosyası 
	public static class ServiceRegistration
	{
        public static void AddBusinessServices(this IServiceCollection serviceCollection)
        {
            //projede NewsManager sınıfı ile INewsService interfacei üzerinden iletişim kurulacak, soyutlama yapılacak
            serviceCollection.AddScoped<INewsService, NewsManager>();

        }
    }
}

