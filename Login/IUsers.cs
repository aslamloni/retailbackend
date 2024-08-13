using EntityFramework;
namespace Retailer.Login
{
    public interface IUsers<Users>
    {
        Task<bool> InsertAsynch(Users Obj);
        Task<IEnumerable<Users>> GetService(Users Obj);
        Task<Boolean> UpdateAsynch(Users Obj);
        Task<Boolean> DeleteAsynch(Users Obj);
    }
}
