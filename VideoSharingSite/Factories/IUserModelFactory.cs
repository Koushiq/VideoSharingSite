using System.Threading;
using VideoSharingSite.DbModels;
using VideoSharingSite.Models;

namespace VideoSharingSite.Factories
{
    public interface IUserModelFactory
    {
        Task<User> PrepareUserAsync(UserViewModel userViewModel);
    }
}
