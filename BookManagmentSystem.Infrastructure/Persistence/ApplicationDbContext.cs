using BookManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BookManagmentSystem.Infrastructure.Persistence;

namespace BookManagmentSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Username).IsUnique();
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                
            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(b => b.Price)
                    .HasColumnType("decimal(18,2)");
                entity.Property(b => b.ImageUrl)
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
            });



        }
    }
}
