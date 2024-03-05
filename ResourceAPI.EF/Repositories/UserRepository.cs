using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceAPI.EF.DbContexts;
using ResourceAPI.EF.Models;
namespace ResourceAPI.EF.Repositories
{
    public class UserRepository
    {
        private readonly PaymentsContext _paymentsContext;
        public UserRepository(PaymentsContext dbContext) 
        {
            _paymentsContext = dbContext;
        }

        public int Create(User user) {
            _paymentsContext.Add(user);
            _paymentsContext.SaveChanges();

            return user.UserId;
        }
        public int Update(User user) 
        {
            User updatedUser = _paymentsContext.Users.Find(user.UserId)!;

            updatedUser.Username = user.Username;
            updatedUser.Email = user.Email;
            updatedUser.Password = user.Password;
            updatedUser.FirstName = user.FirstName;
            updatedUser.MiddleName = user.MiddleName;
            updatedUser.LastName = user.LastName;
            updatedUser.Status = user.Status;

            _paymentsContext.SaveChanges();

            return updatedUser.UserId;
        }
        public bool Delete(int userId) 
        {
            User user = _paymentsContext.Users.Find(userId)!;
            _paymentsContext.Remove(user);
            _paymentsContext.SaveChanges();

            return true;
        }
        public List<User> GetAllUser() 
        {
            List<User> getUsers = _paymentsContext.Users.ToList();
            return getUsers;    
        }
        public User GetUserById(int userId)
        {
            User getUser = _paymentsContext.Users.Find()!;
            return getUser;
        }
    }
}
