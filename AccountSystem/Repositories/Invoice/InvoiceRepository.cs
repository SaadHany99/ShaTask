using AccountSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Repositories.Invoice
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddInvoice(InvoiceDetail invoice)
        {
            context.InvoiceDetails.Add(invoice);
            await context.SaveChangesAsync();
        }

        public async Task DeleteInvoice(long id)
        {
            var invoice = await context.InvoiceDetails.FindAsync(id);
            if(invoice != null)
            {
                context.InvoiceDetails.Remove(invoice);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<InvoiceDetail>> GetAll()
        {
            return await context.InvoiceDetails
                .Include(ih=>ih.InvoiceHeader).ToListAsync();
        }

        public async Task<InvoiceDetail> GetInvoiceById(int id)
        {
            return await context.InvoiceDetails
                .Include(ih => ih.InvoiceHeader).FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task UpdateInvoice(InvoiceDetail invoice)
        {
            context.InvoiceDetails.Update(invoice);
            await context.SaveChangesAsync();
        }
    }
}
