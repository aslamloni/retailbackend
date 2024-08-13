using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailer.Bill
{
    public class BillServices : IBill<Bills>
    {
        RetailerDbContext _dbContext;
        public BillServices(RetailerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteAsynch(Bills Obj)
        {
            try
            {
                _dbContext.Bill.Update(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Bills>> GetService(Bills Obj)
        {
            try
            {
                var list = _dbContext.Bill.Where(x => (x.ID == Obj.ID && x.IsActive == Obj.IsActive)// && x.UserID == Obj.UserID)
                                                  || (Obj.ID == Guid.Empty && x.IsActive == Obj.IsActive)// && x.UserID == Obj.UserID)
                                                 ).ToList();
                return (IEnumerable<Bills>)list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> InsertAsynch(Bills Obj)
        {
            try
            {
                _dbContext.Bill.Add(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsynch(Bills Obj)
        {
            try
            {
                _dbContext.Update(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
