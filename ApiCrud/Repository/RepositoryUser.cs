using ApiCrud.Data;
using ApiCrud.Models;
using ApiCrud.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Repository
{
    public class RepositoryUser : IUser
    {
        private readonly SystemTaskDB _dBContext;
        public RepositoryUser(SystemTaskDB systemTaskDB)
        {
            _dBContext = systemTaskDB;  
        }

        public async Task<List<UserModel>> SearchUserFull() => await _dBContext.User.ToListAsync();


        public async Task<UserModel> SearchUsersId(int id) =>  await _dBContext.User.FirstOrDefaultAsync(x => x.Id == id);


        public async Task<UserModel> AddUser(UserModel user) {
            await _dBContext.User.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            return user;

        }

        public async Task<bool> DeteteUser(int id)
        {
            UserModel userId = await SearchUsersId(id);

            if (userId == null)
            {
                throw new Exception("User não existe");
            }

            _dBContext.User.Remove(userId);
            await _dBContext.SaveChangesAsync();
            return true;
        }

       

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userId = await SearchUsersId(id);

            if ( userId == null)
            {
                throw new Exception("User não existe");
            }
            userId.Name = user.Name;
            userId.Email = user.Email;
            _dBContext.User.Update(userId);
            await _dBContext.SaveChangesAsync();
            return userId;  
           

        }
    }
}
