using BookWorld.DataAccess.Repository.IRepository;
using BookWorld.DataAcess.Data;
using BookWorld.Models;

namespace BookWorld.DataAccess.Repository
{
	public class CompanyRepository : Repository<Company>, ICompanyRepository
	{
		private ApplicationDbContext _db;
		public CompanyRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Company obj)
		{
			_db.Companies.Update(obj);
		}
	}
}
