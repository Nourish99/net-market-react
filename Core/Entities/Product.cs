using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
	public class Product : BaseClass
    {
		public string Name { get; set; }

		public string Description { get; set; }

		public int Stock { get; set; }

		public int BrandId { get; set; }

		public Brand Brand { get; set; }

		public int CategoryId { get; set; }

		public Category Category { get; set; }

		public decimal Price { get; set; }

		public string ImageUrl { get; set; }
	}
}

