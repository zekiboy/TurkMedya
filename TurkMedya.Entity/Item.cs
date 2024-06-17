using System;
namespace TurkMedya.Entity
{
	public class Item
	{
        public bool HasPhotoGallery { get; set; }
        public bool HasVideo { get; set; }
        public bool TitleVisible { get; set; }
        public string FLike { get; set; }
        public string PublishDate { get; set; }
        public string ShortText { get; set; }
        public string FullPath { get; set; }
        public Category Category { get; set; }
        public string VideoUrl { get; set; }
        public string ExternalUrl { get; set; }
        public string ColumnistName { get; set; }
        public string ItemId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string ItemType { get; set; }

        public string BodyText { get; set; }

    }
}

