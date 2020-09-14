using AbcLearningHub.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbcLearningHub.Data.Repositories
{
    public interface IUserProfileRepository : IDataRepository<UserProfile>
    {

    }
    public class UserProfileRepository : DataRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {
        }
    }
}
