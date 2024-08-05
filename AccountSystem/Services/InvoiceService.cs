using AccountSystem.Models;
using AccountSystem.Repositories.Invoice;

namespace AccountSystem.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository repository;

        public InvoiceService(IInvoiceRepository repository)
        {
            this.repository = repository;
        }
        public async Task AddInvoice(InvoiceDetail invoice)
        {
            await repository.AddInvoice(invoice);
        }

        public async Task DeleteInvoice(int id)
        {
            await repository.DeleteInvoice(id);
        }

        public async Task<List<InvoiceDetail>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<InvoiceDetail> GetInvoiceById(int id)
        {
            return await repository.GetInvoiceById(id);
        }

        public async Task UpdateInvoice(InvoiceDetail invoice)
        {
            await repository.UpdateInvoice(invoice);
        }
    }
}
