using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;

namespace Retailer.Items
{
    public interface IItem<Item>
    {
        Task<bool> InsertAsynch(Item Obj);
        Task<IEnumerable<Item>> GetService(Item Obj);
        Task<Boolean> UpdateAsynch(Item Obj);
        Task<Boolean> DeleteAsynch(Item Obj);
    }
}
