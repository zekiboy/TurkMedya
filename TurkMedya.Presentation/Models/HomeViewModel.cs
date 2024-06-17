using System;
using TurkMedya.Entity;

namespace TurkMedya.Presentation.Models
{
	public class HomeViewModel
	{
        public List<Item> NewsItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

    }
}

