using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookCategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Category", x => x.BookCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "BookStatus",
                columns: table => new
                {
                    BookStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookStatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Status", x => x.BookStatusId);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingStatus",
                columns: table => new
                {
                    BorrowingStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BorrowingStatusName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowing_Status", x => x.BorrowingStatusId);
                });

            migrationBuilder.CreateTable(
                name: "DamagedLevel",
                columns: table => new
                {
                    DamagedLevelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DamagedLevelName = table.Column<string>(type: "text", nullable: false),
                    FineAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damaged_Level", x => x.DamagedLevelId);
                });

            migrationBuilder.CreateTable(
                name: "FineCategory",
                columns: table => new
                {
                    FineCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FineCategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fine_Category", x => x.FineCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MemberTypes",
                columns: table => new
                {
                    MemberTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberTypeName = table.Column<string>(type: "text", nullable: false),
                    NumberOfBooks = table.Column<int>(type: "integer", nullable: false),
                    LimitDays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member_Type_Id", x => x.MemberTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ModeOfPayment",
                columns: table => new
                {
                    ModeOfPaymentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModeOfPaymentName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mode_Of_Payment", x => x.ModeOfPaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Id", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookTitle = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    BookCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_Category",
                        column: x => x.BookCategoryId,
                        principalTable: "BookCategory",
                        principalColumn: "BookCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    MemberTypeId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Member_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_Type",
                        column: x => x.MemberTypeId,
                        principalTable: "MemberTypes",
                        principalColumn: "MemberTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookISBN",
                columns: table => new
                {
                    BookISBNId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ISBN = table.Column<string>(type: "text", nullable: false),
                    PublishedYear = table.Column<int>(type: "integer", nullable: false),
                    Edition = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_ISBN", x => x.BookISBNId);
                    table.ForeignKey(
                        name: "FK_Book_ISBN",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopy",
                columns: table => new
                {
                    BookCopyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookISBNId = table.Column<int>(type: "integer", nullable: false),
                    CopyNumber = table.Column<string>(type: "text", nullable: false),
                    BookStatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Copy", x => x.BookCopyId);
                    table.ForeignKey(
                        name: "FK_Book_Copy",
                        column: x => x.BookISBNId,
                        principalTable: "BookISBN",
                        principalColumn: "BookISBNId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Status",
                        column: x => x.BookStatusId,
                        principalTable: "BookStatus",
                        principalColumn: "BookStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrowing",
                columns: table => new
                {
                    BorrowingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    BookCopyId = table.Column<int>(type: "integer", nullable: false),
                    BorrowedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    BorrowingStatusId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowing", x => x.BorrowingId);
                    table.ForeignKey(
                        name: "FK_Borrowing_Book_Copy",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopy",
                        principalColumn: "BookCopyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowing_Member",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrowing_Status",
                        column: x => x.BorrowingStatusId,
                        principalTable: "BorrowingStatus",
                        principalColumn: "BorrowingStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamagedBook",
                columns: table => new
                {
                    DamagedBookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    BookCopyId = table.Column<int>(type: "integer", nullable: false),
                    DamagedLevelId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damaged_Book", x => x.DamagedBookId);
                    table.ForeignKey(
                        name: "FK_Damaged_Book_Copy",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopy",
                        principalColumn: "BookCopyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damaged_Book_Level",
                        column: x => x.DamagedLevelId,
                        principalTable: "DamagedLevel",
                        principalColumn: "DamagedLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damaged_Book_Member",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fine",
                columns: table => new
                {
                    FineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BorrowingId = table.Column<int>(type: "integer", nullable: false),
                    FineCategoryId = table.Column<int>(type: "integer", nullable: false),
                    DamagedBookId = table.Column<int>(type: "integer", nullable: true),
                    FineAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    IsPaidFully = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    createdAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fine", x => x.FineId);
                    table.ForeignKey(
                        name: "FK_Fine_Borrowing",
                        column: x => x.BorrowingId,
                        principalTable: "Borrowing",
                        principalColumn: "BorrowingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fine_Category",
                        column: x => x.FineCategoryId,
                        principalTable: "FineCategory",
                        principalColumn: "FineCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fine_Damaged_Book",
                        column: x => x.DamagedBookId,
                        principalTable: "DamagedBook",
                        principalColumn: "DamagedBookId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FineId = table.Column<int>(type: "integer", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    ModeOfPaymentId = table.Column<int>(type: "integer", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Fine",
                        column: x => x.FineId,
                        principalTable: "Fine",
                        principalColumn: "FineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Mode",
                        column: x => x.ModeOfPaymentId,
                        principalTable: "ModeOfPayment",
                        principalColumn: "ModeOfPaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookStatus",
                columns: new[] { "BookStatusId", "BookStatusName" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "Unavailable" },
                    { 3, "Lost" },
                    { 4, "Damaged" }
                });

            migrationBuilder.InsertData(
                table: "BorrowingStatus",
                columns: new[] { "BorrowingStatusId", "BorrowingStatusName" },
                values: new object[,]
                {
                    { 1, "Borrowed" },
                    { 2, "Returned" },
                    { 3, "OverDue" }
                });

            migrationBuilder.InsertData(
                table: "DamagedLevel",
                columns: new[] { "DamagedLevelId", "DamagedLevelName", "FineAmount" },
                values: new object[,]
                {
                    { 1, "Little", 100m },
                    { 2, "Medium", 300m },
                    { 3, "Hard", 500m }
                });

            migrationBuilder.InsertData(
                table: "FineCategory",
                columns: new[] { "FineCategoryId", "FineCategoryName" },
                values: new object[,]
                {
                    { 1, "Lost" },
                    { 2, "Damaged" },
                    { 3, "OverDue" }
                });

            migrationBuilder.InsertData(
                table: "MemberTypes",
                columns: new[] { "MemberTypeId", "LimitDays", "MemberTypeName", "NumberOfBooks" },
                values: new object[,]
                {
                    { 1, 7, "Basic", 2 },
                    { 2, 10, "Student", 3 },
                    { 3, 15, "Premium", 5 }
                });

            migrationBuilder.InsertData(
                table: "ModeOfPayment",
                columns: new[] { "ModeOfPaymentId", "ModeOfPaymentName" },
                values: new object[,]
                {
                    { 1, "Cash" },
                    { 2, "UPI" },
                    { 3, "Credit_Card" },
                    { 4, "Debit_Card" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookCategoryId",
                table: "Book",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_BookCategoryName",
                table: "BookCategory",
                column: "BookCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_BookISBNId",
                table: "BookCopy",
                column: "BookISBNId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_BookStatusId",
                table: "BookCopy",
                column: "BookStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_CopyNumber",
                table: "BookCopy",
                column: "CopyNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookISBN_BookId",
                table: "BookISBN",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookISBN_ISBN",
                table: "BookISBN",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookStatus_BookStatusName",
                table: "BookStatus",
                column: "BookStatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_BookCopyId",
                table: "Borrowing",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_BorrowingStatusId",
                table: "Borrowing",
                column: "BorrowingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_MemberId",
                table: "Borrowing",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingStatus_BorrowingStatusName",
                table: "BorrowingStatus",
                column: "BorrowingStatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DamagedBook_BookCopyId",
                table: "DamagedBook",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagedBook_DamagedLevelId",
                table: "DamagedBook",
                column: "DamagedLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagedBook_MemberId",
                table: "DamagedBook",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DamagedLevel_DamagedLevelName",
                table: "DamagedLevel",
                column: "DamagedLevelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fine_BorrowingId",
                table: "Fine",
                column: "BorrowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_DamagedBookId",
                table: "Fine",
                column: "DamagedBookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fine_FineCategoryId",
                table: "Fine",
                column: "FineCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FineCategory_FineCategoryName",
                table: "FineCategory",
                column: "FineCategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_Email",
                table: "Member",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_MemberTypeId",
                table: "Member",
                column: "MemberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_PhoneNumber",
                table: "Member",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_RoleId",
                table: "Member",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeOfPayment_ModeOfPaymentName",
                table: "ModeOfPayment",
                column: "ModeOfPaymentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_FineId",
                table: "Payment",
                column: "FineId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ModeOfPaymentId",
                table: "Payment",
                column: "ModeOfPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleName",
                table: "Role",
                column: "RoleName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Fine");

            migrationBuilder.DropTable(
                name: "ModeOfPayment");

            migrationBuilder.DropTable(
                name: "Borrowing");

            migrationBuilder.DropTable(
                name: "FineCategory");

            migrationBuilder.DropTable(
                name: "DamagedBook");

            migrationBuilder.DropTable(
                name: "BorrowingStatus");

            migrationBuilder.DropTable(
                name: "BookCopy");

            migrationBuilder.DropTable(
                name: "DamagedLevel");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "BookISBN");

            migrationBuilder.DropTable(
                name: "BookStatus");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "MemberTypes");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "BookCategory");
        }
    }
}
