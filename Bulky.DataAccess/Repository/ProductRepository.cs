﻿using BookWorld.DataAccess.Repository.IRepository;
using BookWorld.DataAcess.Data;
using BookWorld.Models;

namespace BookWorld.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Product obj)
		{
			var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Title = obj.Title;
				objFromDb.Description = obj.Description;
				objFromDb.ISBN = obj.ISBN;
				objFromDb.Author = obj.Author;
				objFromDb.ListPrice = obj.ListPrice;
				objFromDb.Price = obj.Price;
				objFromDb.Price50 = obj.Price50;
				objFromDb.Price100 = obj.Price100;
				objFromDb.CategoryId = obj.CategoryId;
				objFromDb.ProductImages = obj.ProductImages;
			}
		}
	}
}
