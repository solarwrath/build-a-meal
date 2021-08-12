using Application.Common.ExternalInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}