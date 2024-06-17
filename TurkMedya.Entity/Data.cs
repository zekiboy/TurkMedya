using System;
using TurkMedya.Entity.DetailEntities;

namespace TurkMedya.Entity
{
	public class Data
	{
        public string SectionType { get; set; }
        public string RepeatType { get; set; }
        public int ItemCountInRow { get; set; }
        public bool LazyLoadingEnabled { get; set; }
        public bool TitleVisible { get; set; }
        public string Title { get; set; }
        public string TitleColor { get; set; }
        public string TitleBgColor { get; set; }
        public string SectionBgColor { get; set; }
        public List<Item> ItemList { get; set; }


        public Ad HeaderAd { get; set; }
        public NewsDetail NewsDetail { get; set; }
        public Ad FooterAd { get; set; }
        public Multimedia Multimedia { get; set; }
        public List<NewsDetail> ItemListDetail { get; set; }
        public RelatedNews RelatedNews { get; set; }
        public Video Video { get; set; }
        public PhotoGallery PhotoGallery { get; set; }
    }
}

