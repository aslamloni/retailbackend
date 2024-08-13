using EntityFramework;
using Login;
using Microsoft.AspNetCore.Mvc;
using Retailer.Items;
using Retailer.Login;
using Retailer.Bill;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Retailer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {   
        private readonly IBill<Bills> _billServices;
        public BillController(IBill<Bills> billServices)
        {
            _billServices = billServices;
        }
        // GET: api/<BillController>
        [HttpGet]
        public async Task<IEnumerable<Bills>> Get()
        {
            Bills bill =new Bills();
            bill.IsActive = true;
            var bills = await _billServices.GetService(bill);
            return bills;
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Bills>> Get(string id)
        {
            Bills bill = new Bills();
            bill.ID = Guid.Parse(id);
            bill.IsActive = true;
            var bills = await _billServices.GetService(bill);
            return bills;
        }

        // POST api/<BillController>
        [HttpPost]
        public async Task<Boolean> Post(Bills input)
        {
            bool IsSave = false;
            try
            {                
                Bills bill = new Bills();
                bill.ID = Guid.NewGuid();
                bill.BillType = input.BillType;
                bill.Name = input.Name;
                bill.ContactNo = input.ContactNo;
                bill.Address = input.Address;
                bill.PaymentMode = input.PaymentMode;
                bill.PaymentStatus = input.PaymentStatus;
                bill.ItemID = input.ItemID;
                bill.UserId = input.UserId;
                bill.IsActive = true;
                bill.CreatedDate = input.CreatedDate;
                bill.UpdatedDate = input.UpdatedDate;

                IsSave = await _billServices.InsertAsynch(bill);
            }
            catch (Exception ex)
            {
                IsSave = false;
                throw ex;
            }
            

            return IsSave;
        }

        // PUT api/<BillController>
        [HttpPut]
        public async Task<Boolean> Put(Bills input)
        {
            bool IsSave = false;
            try
            {
                Bills bill = new Bills();
                bill.ID = input.ID;
                bill.BillType = input.BillType;
                bill.Name = input.Name;
                bill.ContactNo = input.ContactNo;
                bill.Address = input.Address;
                bill.PaymentMode = input.PaymentMode;
                bill.PaymentStatus = input.PaymentStatus;
                bill.ItemID = input.ItemID;
                bill.UserId = input.UserId;
                bill.IsActive = input.IsActive;
                bill.CreatedDate = input.CreatedDate;
                bill.UpdatedDate = DateTime.Now;

                IsSave = await _billServices.UpdateAsynch(bill);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsSave;
        }

        // DELETE api/<BillController>
        [HttpDelete]
        public async Task<Boolean> Delete(Bills input)
        {
            bool IsSave = false;
            try
            {
                Bills bill = new Bills();
                bill.ID = input.ID;
                bill.IsActive = true;
                bill.UserId = input.UserId;
                var items = await _billServices.GetService(bill);
                if (items != null)
                {
                    foreach (var obj in items)
                    {
                        obj.IsActive = false;
                        obj.UpdatedDate = DateTime.Now;
                        obj.UserId = input.UserId;
                        IsSave = await _billServices.DeleteAsynch(obj);
                    }
                }

                return IsSave;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
