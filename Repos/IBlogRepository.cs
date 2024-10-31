using MVCStartApp.Models.Db;

namespace MVCStartApp.Repos
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}
