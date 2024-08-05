using AccountSystem.Models;

namespace AccountSystem.Services
{
    public interface IInvoiceService
    {
        public Task<List<InvoiceDetail>> GetAll();
        public Task<InvoiceDetail> GetInvoiceById(int id);
        public Task AddInvoice (InvoiceDetail invoice);
        public Task UpdateInvoice (InvoiceDetail invoice);
        public Task DeleteInvoice (int id);

    }
}
