using BookWorld.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookWorld.DataAccess.Repository.IRepository
{
	public interface IApplicationUserRepository : IRepository<ApplicationUser>
	{
		public void Update(ApplicationUser applicationUser);
	}
}
