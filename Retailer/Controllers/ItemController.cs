using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Retailer.Items;
using Retailer.Login;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Retailer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItem<Item> _itemServices;

        public ItemController(IItem<Item> itemServices)
        {
            _itemServices = itemServices;
        }
        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            Item item =new Item();
           // await HttpContext.Session.LoadAsync();
            //if (HttpContext.Session.GetString("UserId") != null)
            //    item.UserID = Guid.Parse(HttpContext.Session.GetString("UserId"));
            //else
            //    return new List<Item>();
            item.IsActive = true;
            var items = await _itemServices.GetService(item);
            return items;
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Item>> Get(string id)
        {
            var item = new Item();
            item.ID = Guid.Parse(id);
            item.IsActive = true;
            //if (HttpContext.Session.GetString("UserId") != null)
            //    item.UserID = Guid.Parse(HttpContext.Session.GetString("UserId"));
            //else
            //    return new List<Item>();
            var items = await _itemServices.GetService(item);
            return items;
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<Boolean> Post(Item input)
        {
            try
            {
                Item item = new Item();
                item.ID = Guid.NewGuid();
                item.UpdatedDate = DateTime.Now;
                item.CreatedDate = DateTime.Now;
                item.IsActive = true;
                item.ItemName = input.ItemName;
                item.ItemCode = input.ItemCode;
                item.Location = input.Location;
                item.PurchasePrice = input.PurchasePrice;
                item.SalePrice = input.SalePrice;
                item.DiscountPrice = input.DiscountPrice;
                item.CGST = input.CGST;
                item.SGST = input.SGST;

                item.UserID = input.UserID;
                /*
                string userId = HttpContext.Session.GetString("UserId").ToString();
                if(!string.IsNullOrEmpty(userId))
                {
                    item.UserID = Guid.Parse(userId);
                } */
               


                var IsSave = await _itemServices.InsertAsynch(item);

                if (IsSave)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<ItemController>
        [HttpPut]
        public async Task<Boolean> Put(Item input)
        {
            Item item = new Item();
            item.ID = input.ID;
            item.UpdatedDate = DateTime.Now;
            item.CreatedDate = input.CreatedDate;
            item.IsActive = true;
            item.ItemName = input.ItemName;
            item.ItemCode = input.ItemCode;
            item.Location = input.Location;
            item.PurchasePrice = input.PurchasePrice;
            item.SalePrice = input.SalePrice;
            item.DiscountPrice = input.DiscountPrice;
            item.CGST = input.CGST;
            item.SGST = input.SGST;
            item.UserID = input.UserID;

            var IsSave = await _itemServices.UpdateAsynch(item);

            if (IsSave)
                return true;
            else
                return false;
        }

        // DELETE api/<ItemController>
        [HttpDelete]
        public async Task<Boolean> Delete(Item input)
        {
            bool IsSave = false;

            Item item =new Item();
            item.ID = input.ID;
            item.IsActive= true;
            item.UserID= input.UserID;
            //if (HttpContext.Session.GetString("UserId") != null)
            //    item.UserID = Guid.Parse(HttpContext.Session.GetString("UserId"));
            //else
            //    return false;
            var items = await _itemServices.GetService(item);
            if (items != null) 
            {
                foreach(var obj in items)
                {
                    obj.IsActive = false;
                    obj.UpdatedDate = DateTime.Now;
                    obj.UserID = input.UserID;
                    IsSave = await _itemServices.DeleteAsynch(obj);
                }                
            }
            
            return IsSave;
        }
    }
}
