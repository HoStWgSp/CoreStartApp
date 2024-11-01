using MVCStartUpp.Models.Db;

namespace MVCStartUpp.Blog
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}
