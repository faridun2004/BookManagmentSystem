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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Books)
                      .HasForeignKey(e => e.CategoryId);
                entity.HasOne(e => e.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(e => e.AuthorId);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Items)
                      .WithOne()
                      .HasForeignKey(e => e.CartItemId);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Quantity).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(e => e.Customer)
                      .WithMany()
                      .HasForeignKey(e => e.CustomerId);
                entity.HasMany(e => e.OrderItems)
                      .WithOne(oi => oi.Order)
                      .HasForeignKey(oi => oi.OrderId);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.BookId });
                entity.Property(e => e.Quantity).IsRequired();
                entity.HasOne(e => e.Book)
                      .WithMany()
                      .HasForeignKey(e => e.BookId);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.Username).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.RefreshToken).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
            });
        }
    }
}
