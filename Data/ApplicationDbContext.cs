using Microsoft.EntityFrameworkCore;
using SamsungStore.Models; // تأكد أن اسم الـ Namespace هنا يطابق اسم مشروعك

namespace SamsungStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}