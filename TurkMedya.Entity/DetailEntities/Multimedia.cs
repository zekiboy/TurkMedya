using System;
namespace TurkMedya.Entity.DetailEntities
{
	public class Multimedia
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
    }
}

