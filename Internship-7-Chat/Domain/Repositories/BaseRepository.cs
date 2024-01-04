using Data.Entities;
using Domain.Enums;

namespace Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ChatAppDbContext DbContext;

        protected BaseRepository(ChatAppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ResponseResultType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ResponseResultType.Success;
            return ResponseResultType.NoChanges;
        }
    }
}
