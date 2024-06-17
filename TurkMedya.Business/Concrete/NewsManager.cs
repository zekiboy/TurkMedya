using System;
using TurkMedya.Business.Abstract;
using TurkMedya.Data.Abstract;
using TurkMedya.Data.Concrete;
using TurkMedya.Entity;
using TurkMedya.Entity.DetailEntities;

namespace TurkMedya.Business.Concrete
{
	public class NewsManager : INewsService 
	{
        //Data katmanından çekilen repositorylere ilgili iş kuralları bu sınıfta uygulandıktan sonra sunum katmanına gönderildi

        private INewsRepository _newsRepository;  
		public NewsManager(INewsRepository newsRepository)
		{
            _newsRepository = newsRepository;
		}
        public async Task<List<Item>> GetAllNewsAsync()
        {
            return await _newsRepository.GetAllNewsAsync();
        }


        public async Task<DetailRoot> GetNewsDetailAsync()
        {
            return await _newsRepository.GetNewsDetailAsync();
        }

 
    }
}

