using EntityFramework;
using Retailer.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class UserServices : IUsers<Users>
    {
        RetailerDbContext _dbContext;
        public UserServices(RetailerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsynch(Users Obj)
        {
            bool isDeleted = false;
            try
            {
                _dbContext.Users.Remove(Obj);
                await _dbContext.SaveChangesAsync();
                isDeleted = true;
                return isDeleted;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Users>> GetService(Users Obj)
        {
            try
            {
                var list = _dbContext.Users.Where(x => (x.Id == Obj.Id
                                                  || Obj.Id == Guid.Empty
                                                  || x.UserName == Obj.UserName && x.Password == Obj.Password)
                                                 ).ToList();
                return  (IEnumerable<Users>)list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> InsertAsynch(Users Obj)
        {
            try
            {
                _dbContext.Users.Add(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsynch(Users Obj)
        {
            try
            {
                _dbContext.Users.Update(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
