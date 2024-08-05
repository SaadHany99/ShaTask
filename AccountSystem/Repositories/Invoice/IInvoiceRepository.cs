using AccountSystem.Models;

namespace AccountSystem.Repositories.Invoice
{
    public interface IInvoiceRepository
    {
        public Task<List<InvoiceDetail>> GetAll();
        public Task<InvoiceDetail> GetInvoiceById(int id);
        public Task AddInvoice(InvoiceDetail invoice);
        public Task UpdateInvoice(InvoiceDetail invoice);
        public Task DeleteInvoice(long id);

    }
}
