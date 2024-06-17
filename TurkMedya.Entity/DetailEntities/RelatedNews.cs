using System;
namespace TurkMedya.Entity.DetailEntities
{
	public class RelatedNews
	{
        public bool HasPhotoGallery { get; set; }
        public bool HasVideo { get; set; }
        public string PublishDate { get; set; }
        public string ShortText { get; set; }
        public Category Category { get; set; }
        public string ItemId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string ItemType { get; set; }
        public bool TitleVisible { get; set; }
    }
}

