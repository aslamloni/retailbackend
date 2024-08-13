using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Retailer.Items
{
    public class ItemService : IItem<Item>
    {
        RetailerDbContext _dbContext;
        public ItemService(RetailerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteAsynch(Item Obj)
        {
            try
            {
                _dbContext.Item.Update(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Item>> GetService(Item Obj)
        {
            try
            {
                var list = _dbContext.Item.Where(x => (x.ID == Obj.ID && x.IsActive == Obj.IsActive)// && x.UserID == Obj.UserID)
                                                  || (Obj.ID == Guid.Empty && x.IsActive == Obj.IsActive)// && x.UserID == Obj.UserID)
                                                 ).ToList();
                return (IEnumerable<Item>)list;
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        public async Task<bool> InsertAsynch(Item Obj)
        {
            try
            {
                _dbContext.Item.Add(Obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsynch(Item Obj)
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
