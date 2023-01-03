using ApiCrud.Models;

namespace ApiCrud.Repository.Interface
{
    public interface IUser
    {
        Task<List<UserModel>> SearchUserFull();
        Task<UserModel> SearchUsersId(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<Boolean> DeteteUser(int id);
    }
}
