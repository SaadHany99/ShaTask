using AccountSystem.Models;
using AccountSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountSystem.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService service;

        public InvoiceController(IInvoiceService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var Invoices = await service.GetAll();
            return View("ShowAll",Invoices);
        }
        public async Task<IActionResult> Details(int id)
        {
            var invoice= await service.GetInvoiceById(id);
            return View("Details", invoice);
        }

        //Handel link Open Empty View 
        public IActionResult New()
        {
            return View("New");//Model =Null
        }
        //Handel Submit requets (Method Post)
        [HttpPost]
        public async Task<IActionResult> SaveNew(InvoiceDetail invoice)//request method Post
        {
            if (ModelState.IsValid)
            {
                await service.AddInvoice(invoice);
                return RedirectToAction("Index");//return to the index action in the same controller
            }
            return View("New", invoice);

        }
        public async Task<IActionResult> Edit(int id)
        {
            InvoiceDetail invoice =await service.GetInvoiceById(id);
            return View("Edit", invoice);
        }
        [HttpPost]
        public async Task<IActionResult> SaveEdit(InvoiceDetail invoice)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateInvoice(invoice);
                return RedirectToAction("Index");//return to the index action in the same controller
            }
            return View("Edit", invoice);
        }
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            await service.DeleteInvoice(id);
            return RedirectToAction("Index");
        }

    }
}
