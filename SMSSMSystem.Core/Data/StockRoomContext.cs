using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSSMSystem.Core.Models;

namespace SMSSMSystem.Core.Data
{
    public class StockRoomContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
    {
        public StockRoomContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=StockRoom;uid=sa;pwd=123456;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public StockRoomContext(DbContextOptions<StockRoomContext> options) : base(options)
        { }
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Category> Category { get; set; } = null!;
        public virtual DbSet<ImportProductInvoice> ImportProductInvoices { get; set; } = null!;
        public virtual DbSet<ImportProductInvoiceDetail> ImportProductInvoiceDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImport> ProductImports { get; set; } = null!;
        public virtual DbSet<ProductPutOut> ProductPutOuts { get; set; } = null!;
        public virtual DbSet<Shelf> Shelfs { get; set; } = null!;
        public virtual DbSet<ShelfColumn> ShelfColumns { get; set; } = null!;
        public virtual DbSet<ShelfRow> ShelfRows { get; set; } = null!;
        public virtual DbSet<StockRoom> StockRooms { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierCriteria> SupplierCriterias { get; set; } = null!;
        public virtual DbSet<Types> Types { get; set; } = null!;
        public virtual DbSet<UnPaidInvoice> UnPaidInvoices { get; set; } = null!;
        public virtual DbSet<UnPaidInvoiceDetail> UnPaidInvoiceDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(category => category.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Category>()
                .Property(category => category.Description)
                .HasMaxLength(100);

            modelBuilder.Entity<Types>()
                .HasKey(type => type.TypeId);

            modelBuilder.Entity<Types>()
                .Property(type => type.TypeName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Types>()
                .Property(type => type.Description)
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .HasKey(product => product.ProductId);

            modelBuilder.Entity<Product>()
                .Property(product => product.ProductName)
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(product => product.ImportPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .Property(product => product.Weight)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(product => product.ExportPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)   
                .WithMany(y => y.Products)   
                .HasForeignKey(product => product.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Type)
                .WithMany(y => y.Products)
                .HasForeignKey(product => product.TypeId);

            modelBuilder.Entity<StockRoom>()
                .HasKey(x => x.StockRoomId);

            modelBuilder.Entity<StockRoom>()
                .Property(stockRoom => stockRoom.Quantity)
                .IsRequired();

            modelBuilder.Entity<StockRoom>()
                .Property(stockRoom => stockRoom.ImportPrice)
                .HasColumnType("decimal(18, 2)"); // Định dạng kiểu dữ liệu cho decimal
                
            modelBuilder.Entity<StockRoom>()
                .Property(stockRoom => stockRoom.ExportPrice)
                .HasColumnType("decimal(18, 2)"); // Định dạng kiểu dữ liệu cho decimal

            modelBuilder.Entity<StockRoom>()
                .Property(stockRoom => stockRoom.ProductionDate)
                .HasColumnType("date"); // Định dạng kiểu dữ liệu cho ngày

            modelBuilder.Entity<StockRoom>()
                .Property(stockRoom => stockRoom.ExpiredDate)
                .HasColumnType("date"); // Định dạng kiểu dữ liệu cho ngày
            modelBuilder.Entity<StockRoom>()
                .HasOne(stockRoom => stockRoom.ImportProductInvoice)
                .WithMany(invoice => invoice.StockRoom)
                .HasForeignKey(stockRoom => stockRoom.ImportProductInvoiceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StockRoom>()
                .HasOne(stockRoom => stockRoom.Product)
                .WithMany(product => product.StockRoom)
                .HasForeignKey(stockRoom => stockRoom.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StockRoom>()
                .HasOne(stockRoom => stockRoom.Supplier)
                .WithMany(supplier => supplier.StockRoom)
                .HasForeignKey(stockRoom => stockRoom.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StockRoom>()
                .HasOne(stockRoom => stockRoom.ShelfColumn)
                .WithMany(column => column.StockRoom)
                .HasForeignKey(stockRoom => stockRoom.ShelfColumnId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Supplier>()
               .HasKey(x => x.SupplierId);
              

            modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.SupplierName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.Phone)
                .HasMaxLength(15);

            modelBuilder.Entity<Supplier>()
                .Property(supplier => supplier.Address)
                .HasMaxLength(100);

            modelBuilder.Entity<SupplierCriteria>()
                .HasKey(x => x.SupplierCriteriaId);

            modelBuilder.Entity<SupplierCriteria>()
                .HasOne(x => x.Supplier)
                .WithMany(y => y.SupplierCriterias)
                .HasForeignKey(c => c.SupplierId);

            modelBuilder.Entity<SupplierCriteria>()
               .Property(criteria => criteria.DeliveryAttitude);

            modelBuilder.Entity<SupplierCriteria>()
               .Property(criteria => criteria.ProductQuality);

            modelBuilder.Entity<SupplierCriteria>()
               .Property(criteria => criteria.DeliveryProgress);


            modelBuilder.Entity<UnPaidInvoiceDetail>()
                .Property(detail => detail.Quantity)
                .IsRequired();

            modelBuilder.Entity<ProductPutOut>()
                .HasKey(putOut => putOut.ProductPutOutId);

            modelBuilder.Entity<ProductPutOut>()
                .Property(putOut => putOut.Quantity)
                .IsRequired();

            modelBuilder.Entity<ProductPutOut>()
                .Property(putOut => putOut.ProductionDate)
                .HasColumnType("date");

            modelBuilder.Entity<ProductPutOut>()
                .Property(putOut => putOut.ExpiredDate)
                .HasColumnType("date");

            modelBuilder.Entity<ProductPutOut>()
                .HasOne(putOut => putOut.Product)
                .WithMany(product => product.ProductPutOuts)
                .HasForeignKey(putOut => putOut.ProductId);

            modelBuilder.Entity<ProductImport>()
                .HasKey(import => import.ProductImportId);

            modelBuilder.Entity<ProductImport>()
                .Property(import => import.Quantity)
                .IsRequired();

            modelBuilder.Entity<ProductImport>()
                .Property(import => import.ProductionDate)
                .HasColumnType("date");

            modelBuilder.Entity<ProductImport>()
                .Property(import => import.ExpiredDate)
                .HasColumnType("date");

            modelBuilder.Entity<ProductImport>()
                .HasOne(import => import.Product)
                .WithMany(product => product.ProductImports)
                .HasForeignKey(import => import.ProductId);


            modelBuilder.Entity<Shelf>()
                .HasKey(x => x.ShelfId);
            modelBuilder.Entity<Shelf>()
                .Property(row => row.ShelfName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<ShelfRow>()
              .HasKey(x => x.ShelfRowId);
            modelBuilder.Entity<ShelfRow>()
                .Property(row => row.ShelfRowName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<ShelfRow>()
                .HasOne(x => x.Shelf)
                .WithMany(y => y.ShelfRows)
                .HasForeignKey(x => x.ShelfId);

            modelBuilder.Entity<ShelfColumn>()
                .HasKey(x => x.ShelfColumnId);
            modelBuilder.Entity<ShelfColumn>()
               .Property(column => column.ShelfColumnName)
               .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<ShelfColumn>()
                .HasOne(x => x.ShelfRow)
                .WithMany(y => y.ShelfColumns)
                .HasForeignKey(x => x.ShelfRowId);
            modelBuilder.Entity<ShelfColumn>()
                .HasOne(column => column.Product)
                .WithMany(product => product.ShelfColumns)
                .HasForeignKey(column => column.ProductId);


            modelBuilder.Entity<UnPaidInvoice>()
                .HasKey(invoice => invoice.UnPaidInvoiceId);

            modelBuilder.Entity<UnPaidInvoice>()
                .Property(invoice => invoice.UnPaidInvoiceName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<UnPaidInvoice>()
                .Property(invoice => invoice.Phone)
                .HasMaxLength(15);

            modelBuilder.Entity<UnPaidInvoice>()
                .Property(invoice => invoice.OrderDate)
                .HasColumnType("date");

            modelBuilder.Entity<UnPaidInvoice>()
                .Property(invoice => invoice.PaymentDate)
                .HasColumnType("date");

            modelBuilder.Entity<UnPaidInvoice>()
                .Property(invoice => invoice.TotalMoney)
                .HasColumnType("decimal(18, 2)");


            modelBuilder.Entity<UnPaidInvoiceDetail>()
                .HasKey(detail => detail.InvoiceDetailId);

            modelBuilder.Entity<UnPaidInvoiceDetail>()
                .Property(detail => detail.Quantity)
                .IsRequired();

            modelBuilder.Entity<UnPaidInvoiceDetail>()
                .HasOne(detail => detail.UnPaidInvoice)
                .WithMany(invoice => invoice.UnPaidInvoiceDetails)
                .HasForeignKey(detail => detail.UnpaidInvoiceId);

            modelBuilder.Entity<UnPaidInvoiceDetail>()
                .HasOne(x => x.Product)
                .WithMany(y => y.UnPaidInvoiceDetails)
                .HasForeignKey(detail => detail.ProductId);

            modelBuilder.Entity<ImportProductInvoice>()
                .HasKey(invoice => invoice.ImportProductInvoiceId);

            modelBuilder.Entity<ImportProductInvoice>()
                .Property(invoice => invoice.TotalMoney)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ImportProductInvoice>()
                .Property(invoice => invoice.Status)
                .HasColumnType("bit");

            modelBuilder.Entity<ImportProductInvoiceDetail>()
                .HasKey(detail => detail.ImportProductInvoiceDetailId);

            modelBuilder.Entity<ImportProductInvoiceDetail>()
                .Property(detail => detail.Quantity)
                .IsRequired();

            modelBuilder.Entity<ImportProductInvoiceDetail>()
                .Property(detail => detail.ProductionDate)
                .HasColumnType("date");

            modelBuilder.Entity<ImportProductInvoiceDetail>()
                .Property(detail => detail.ExpiredDate)
                .HasColumnType("date");

            modelBuilder.Entity<ImportProductInvoiceDetail>()
                .Property(detail => detail.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ImportProductInvoiceDetail>()
                .HasOne(detail => detail.ImportProductInvoice)
                .WithMany(invoice => invoice.InvoiceDetails)
                .HasForeignKey(detail => detail.ImportProductInvoiceId);

            modelBuilder.Entity<ImportProductInvoiceDetail>()
                .HasOne(detail => detail.Product)
                .WithMany(product => product.ImportProductInvoiceDetail)
                .HasForeignKey(detail => detail.ProductId);


            base.OnModelCreating(modelBuilder);
        }
    }









}
