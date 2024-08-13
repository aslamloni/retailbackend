using EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retailer.Bill
{
    public interface IBill<Bills>
    {
        Task<bool> InsertAsynch(Bills Obj);
        Task<IEnumerable<Bills>> GetService(Bills Obj);
        Task<Boolean> UpdateAsynch(Bills Obj);
        Task<Boolean> DeleteAsynch(Bills Obj);
    }
}
