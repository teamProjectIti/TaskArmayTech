using ArmyTechTask.interfaces;
using ArmyTechTask.Models;
using ArmyTechTask.Models.ModelView;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArmyTechTask.Controllers
{
    public class CardController : Controller
    {
        private readonly IRepositeryInvoiceDetail repositeryInvoiceDetail;
        private readonly IRepositeryInvoiceHeader repositeryInvoiceHeader;

        public CardController(IRepositeryInvoiceDetail repositeryInvoiceDetail, IRepositeryInvoiceHeader repositeryInvoiceHeader)
        {
            this.repositeryInvoiceDetail = repositeryInvoiceDetail;
            this.repositeryInvoiceHeader = repositeryInvoiceHeader;
        }
        public async Task<ActionResult> Index(int id)
        {
            if (id==null)
            {
                return NotFound();
            }
            details_header_viewModel model = new details_header_viewModel();

            model.InvoiceHeader = await repositeryInvoiceHeader.GetByIDUser(id);
            model.InvoiceDetailList = await repositeryInvoiceDetail.GetByIDTolist(id);
            
            foreach (var item in model.InvoiceDetailList)
	        {
                model.SumTotal += item.ItemPrice * item.ItemCount;
            }

            return View(model);
        }
    }
}
