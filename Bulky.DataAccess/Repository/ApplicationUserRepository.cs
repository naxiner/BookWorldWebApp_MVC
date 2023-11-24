using BookWorld.DataAccess.Repository.IRepository;
using BookWorld.DataAcess.Data;
using BookWorld.Models;

namespace BookWorld.DataAccess.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
		private ApplicationDbContext _db;
		public ApplicationUserRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
	}
}
