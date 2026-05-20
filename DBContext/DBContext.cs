using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using LibraryManagement.Models;

namespace LibraryManagement.DataAccessLibrary.DBContext;

public class LibraryManagementContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString"));
    }
    public DbSet<MemberType> MemberTypes { get; set; }
    public DbSet<Member> Member { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<BookCategory> BookCategory { get; set; }
    public DbSet<BookISBN> BookISBN { get; set; }
    public DbSet<BookCopy> BookCopy { get; set; }
    public DbSet<BookStatus> BookStatus { get; set; }
    public DbSet<Borrowing> Borrowing { get; set; }
    public DbSet<Fine> Fine {get;set;}
    public DbSet<DamagedBook> DamagedBook {get;set;}
    public DbSet<DamagedLevel> DamagedLevel {get;set;}
    public DbSet<Payment> Payment { get; set; }

    // conditionis and constraint for the table is added for model creation
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(r =>
        {
            r.HasKey(r => r.RoleId).HasName("PK_Role_Id");
            r.HasIndex(r => r.RoleName).IsUnique();
            r.HasData(new Role() { RoleId = 1, RoleName = "Admin" });
            r.HasData(new Role() { RoleId = 2, RoleName = "User" });
        });

        modelBuilder.Entity<MemberType>(mt =>
        {
            mt.HasKey(mt => mt.MemberTypeId).HasName("PK_Member_Type_Id");
            mt.HasData(new MemberType() { MemberTypeId = 1, MemberTypeName = "Basic", NumberOfBooks = 2, LimitDays = 7 },
            new MemberType() { MemberTypeId = 2, MemberTypeName = "Student", NumberOfBooks = 3, LimitDays = 10 },
            new MemberType() { MemberTypeId = 3, MemberTypeName = "Premium", NumberOfBooks = 5, LimitDays = 15 });
        });

        modelBuilder.Entity<BookStatus>(bs =>
        {
            bs.HasKey(bs => bs.BookStatusId).HasName("PK_Book_Status");
            bs.HasIndex(bs => bs.BookStatusName).IsUnique();
            bs.HasData(new BookStatus() { BookStatusId = 1, BookStatusName = "Available" });
            bs.HasData(new BookStatus() { BookStatusId = 2, BookStatusName = "Unavailable" });
            bs.HasData(new BookStatus() { BookStatusId = 3, BookStatusName = "Lost" });
            bs.HasData(new BookStatus() { BookStatusId = 4, BookStatusName = "Damaged" });
        });

        modelBuilder.Entity<BorrowingStatus>(bs =>
        {
            bs.HasKey(bs => bs.BorrowingStatusId).HasName("PK_Borrowing_Status");
            bs.HasIndex(bs => bs.BorrowingStatusName).IsUnique();
            bs.HasData(new BorrowingStatus() { BorrowingStatusId = 1, BorrowingStatusName = "Borrowed" });
            bs.HasData(new BorrowingStatus() { BorrowingStatusId = 2, BorrowingStatusName = "Returned" });
            bs.HasData(new BorrowingStatus() { BorrowingStatusId = 3, BorrowingStatusName = "OverDue" });
        });

        modelBuilder.Entity<FineCategory>(fc =>
        {
            fc.HasKey(fc => fc.FineCategoryId).HasName("PK_Fine_Category");
            fc.HasIndex(fc => fc.FineCategoryName).IsUnique();
            fc.HasData(new FineCategory() { FineCategoryId = 1, FineCategoryName = "Lost" });
            fc.HasData(new FineCategory() { FineCategoryId = 2, FineCategoryName = "Damaged" });
            fc.HasData(new FineCategory() { FineCategoryId = 3, FineCategoryName = "OverDue" });
        });

        modelBuilder.Entity<ModeOfPayment>(mp =>
        {
            mp.HasKey(mp => mp.ModeOfPaymentId).HasName("PK_Mode_Of_Payment");
            mp.HasIndex(mp => mp.ModeOfPaymentName).IsUnique();
            mp.HasData(new ModeOfPayment() { ModeOfPaymentId = 1, ModeOfPaymentName = "Cash" });
            mp.HasData(new ModeOfPayment() { ModeOfPaymentId = 2, ModeOfPaymentName = "UPI" });
            mp.HasData(new ModeOfPayment() { ModeOfPaymentId = 3, ModeOfPaymentName = "Credit_Card" });
            mp.HasData(new ModeOfPayment() { ModeOfPaymentId = 4, ModeOfPaymentName = "Debit_Card" });
        });

        modelBuilder.Entity<DamagedLevel>(dl =>
        {
            dl.HasKey(dl => dl.DamagedLevelId).HasName("PK_Damaged_Level");
            dl.HasIndex(dl => dl.DamagedLevelName).IsUnique();
            dl.HasData(new DamagedLevel() { DamagedLevelId = 1, DamagedLevelName = "Little", FineAmount = 100 });
            dl.HasData(new DamagedLevel() { DamagedLevelId = 2, DamagedLevelName = "Medium", FineAmount = 300 });
            dl.HasData(new DamagedLevel() { DamagedLevelId = 3, DamagedLevelName = "Hard", FineAmount = 500 });
        });

        modelBuilder.Entity<Member>(m =>
        {
            m.HasKey(m => m.MemberId).HasName("PK_Member");
            m.HasIndex(m => m.Email).IsUnique();
            m.HasIndex(m => m.PhoneNumber).IsUnique();
            m.Property(m => m.Email).IsRequired();
            m.Property(m => m.PhoneNumber).IsRequired();
            m.Property(m => m.PhoneNumber).HasMaxLength(10);
            m.Property(m => m.Password).IsRequired();
            m.Property(m => m.isActive).HasDefaultValue(true);
            m.Property(m => m.createdAt).HasColumnType("timestamp without time zone");
            m.Property(m => m.updatedAt).HasColumnType("timestamp without time zone");
            m.HasOne(m => m.MemberType).WithMany(mt => mt.Members).HasForeignKey(m => m.MemberTypeId).HasConstraintName("FK_Member_Type");
            m.HasOne(m => m.Role).WithMany(r => r.Members).HasForeignKey(m => m.RoleId).HasConstraintName("FK_Member_Role");
        });

        modelBuilder.Entity<BookCategory>(bc =>
        {
            bc.HasKey(bc => bc.BookCategoryId).HasName("PK_Book_Category");
            bc.HasIndex(bc => bc.BookCategoryName).IsUnique();
            bc.Property(bc => bc.BookCategoryName).IsRequired();
            bc.HasData(new BookCategory() { BookCategoryId = 1, BookCategoryName = "Science" });
            bc.HasData(new BookCategory() { BookCategoryId = 2, BookCategoryName = "Fiction" });
            bc.HasData(new BookCategory() { BookCategoryId = 3, BookCategoryName = "Non Fiction" });
            bc.HasData(new BookCategory() { BookCategoryId = 4, BookCategoryName = "Horror" });

        });

        modelBuilder.Entity<Book>(b =>
        {
            b.HasKey(b => b.BookId).HasName("PK_Book");
            b.Property(b => b.BookTitle).IsRequired();
            b.Property(b => b.Author).IsRequired();
            b.HasOne(b => b.BookCategory).WithMany(bc => bc.Books).HasForeignKey(b => b.BookCategoryId).HasConstraintName("FK_Book_Category");
        });

        modelBuilder.Entity<BookISBN>(bi =>
        {
            bi.HasKey(bi => bi.BookISBNId).HasName("PK_Book_ISBN");
            bi.Property(bi => bi.ISBN).IsRequired();
            bi.Property(bi => bi.PublishedYear).IsRequired();
            bi.Property(bi => bi.Edition).IsRequired();
            bi.HasIndex(bi => bi.ISBN).IsUnique();
            bi.HasOne(bi => bi.Book).WithMany(b => b.BookISBNs).HasForeignKey(bi => bi.BookId).HasConstraintName("FK_Book_ISBN");
        });

        modelBuilder.Entity<BookCopy>(bc =>
        {
            bc.HasKey(bc => bc.BookCopyId).HasName("PK_Book_Copy");
            bc.Property(bc => bc.CopyNumber).IsRequired();
            bc.HasIndex(bc => bc.CopyNumber).IsUnique();
            bc.HasOne(bc => bc.BookISBN).WithMany(b => b.BookCopies).HasForeignKey(bc => bc.BookISBNId).HasConstraintName("FK_Book_Copy");
            bc.HasOne(bc => bc.BookStatus).WithMany(b => b.BookCopies).HasForeignKey(bc => bc.BookStatusId).HasConstraintName("FK_Book_Status");
        });

        modelBuilder.Entity<Borrowing>(br =>
        {
            br.HasKey(br => br.BorrowingId).HasName("PK_Borrowing");
            br.Property(br => br.createdAt).HasColumnType("timestamp without time zone");
            br.Property(br => br.updatedAt).HasColumnType("timestamp without time zone");
            br.Property(br => br.BorrowedDate).HasColumnType("timestamp without time zone");
            br.Property(br => br.DueDate).HasColumnType("timestamp without time zone");
            br.Property(br => br.ReturnDate).HasColumnType("timestamp without time zone");
            br.HasOne(br => br.Member).WithMany(m => m.Borrowings).HasForeignKey(br => br.MemberId).HasConstraintName("FK_Borrowing_Member");
            br.HasOne(br => br.BookCopy).WithMany(bc => bc.Borrowings).HasForeignKey(br => br.BookCopyId).HasConstraintName("FK_Borrowing_Book_Copy");
            br.HasOne(br => br.BorrowingStatus).WithMany(bc => bc.Borrowings).HasForeignKey(br => br.BorrowingStatusId).HasConstraintName("FK_Borrowing_Status");
        });

        modelBuilder.Entity<Fine>(f =>
        {
            f.HasKey(f => f.FineId).HasName("PK_Fine");
            f.Property(f => f.FineAmount).IsRequired();
            f.Property(f => f.IsPaidFully).HasDefaultValue(false);
            f.Property(f => f.createdAt).HasColumnType("timestamp without time zone");
            f.Property(f => f.updatedAt).HasColumnType("timestamp without time zone");
            f.HasOne(f => f.Borrowing).WithMany(br => br.Fines).HasForeignKey(f => f.BorrowingId).HasConstraintName("FK_Fine_Borrowing");
            f.HasOne(f => f.FineCategory).WithMany(br => br.Fines).HasForeignKey(f => f.FineCategoryId).HasConstraintName("FK_Fine_Category");
            f.HasOne(f => f.DamagedBook).WithOne(br => br.Fines).HasForeignKey<Fine>(f => f.DamagedBookId).HasConstraintName("FK_Fine_Damaged_Book");
        });

        modelBuilder.Entity<Payment>(p =>
        {
            p.HasKey(p => p.PaymentId).HasName("PK_Payment");
            p.Property(p => p.AmountPaid).IsRequired();
            p.Property(p => p.createdAt).HasColumnType("timestamp without time zone");
            p.Property(p => p.PaymentDate).HasColumnType("timestamp without time zone");
            p.HasOne(p => p.Fine).WithMany(f => f.Payments).HasForeignKey(p => p.FineId).HasConstraintName("FK_Payment_Fine");
            p.HasOne(p => p.ModeOfPayment).WithMany(f => f.Payments).HasForeignKey(p => p.ModeOfPaymentId).HasConstraintName("FK_Payment_Mode");

        });

        modelBuilder.Entity<DamagedBook>(db =>
        {
            db.HasKey(db => db.DamagedBookId).HasName("PK_Damaged_Book");
            db.Property(db => db.createdAt).HasColumnType("timestamp without time zone");
            db.HasOne(db => db.Member).WithMany(m => m.DamagedBooks).HasForeignKey(db => db.MemberId).HasConstraintName("FK_Damaged_Book_Member");
            db.HasOne(db => db.BookCopy).WithMany(m => m.DamagedBooks).HasForeignKey(db => db.BookCopyId).HasConstraintName("FK_Damaged_Book_Copy");
            db.HasOne(db => db.DamagedLevel).WithMany(m => m.DamagedBooks).HasForeignKey(db => db.DamagedLevelId).HasConstraintName("FK_Damaged_Book_Level");
        });
    }
}