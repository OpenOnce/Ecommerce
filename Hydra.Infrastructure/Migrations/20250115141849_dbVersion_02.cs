using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hydra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dbVersion_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sale");

            migrationBuilder.EnsureSchema(
                name: "Cms");

            migrationBuilder.EnsureSchema(
                name: "Crm");

            migrationBuilder.EnsureSchema(
                name: "FS");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    ShowOnHomepage = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.ParentCategoryId,
                        principalSchema: "Sale",
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TwoLetterIsoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ThreeLetterIsoCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AllowsBilling = table.Column<bool>(type: "bit", nullable: false),
                    AllowsShipping = table.Column<bool>(type: "bit", nullable: false),
                    NumericIsoCode = table.Column<int>(type: "int", nullable: false),
                    SubjectToVat = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    LimitedToStores = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DisplayLocale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomFormatting = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LimitedToStores = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    RoundingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDate",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdminComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: false),
                    UsePercentage = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MaximumDiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    StartDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    EndDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    RequiresCouponCode = table.Column<bool>(type: "bit", nullable: false),
                    DiscountLimitationId = table.Column<int>(type: "int", nullable: false),
                    LimitationTimes = table.Column<int>(type: "int", nullable: false),
                    MaximumDiscountedQuantity = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailInbox",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsPin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInbox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileUpload",
                schema: "FS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Directory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileUpload_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkSection",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PreviewImageId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Cms",
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FromUserId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_User_FromUserId",
                        column: x => x.FromUserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Page",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_User_EditorId",
                        column: x => x.EditorId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Page_User_WriterId",
                        column: x => x.WriterId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AttributeType = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchTerm",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keyword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchTerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slideshow",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PreviewImageId = table.Column<int>(type: "int", nullable: true),
                    PreviewImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slideshow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slideshow_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscribeLabel",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribeLabel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCategory",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Topic_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Cms",
                        principalTable: "Topic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StateProvince",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateProvince_Country",
                        column: x => x.CountryId,
                        principalSchema: "Sale",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCategory",
                schema: "Sale",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_AppliedToCategories", x => new { x.DiscountId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_DiscountCategory_Category",
                        column: x => x.CategoryId,
                        principalSchema: "Sale",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCategory_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailInboxAttachment",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailInboxId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInboxAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailInboxAttachment_EmailInbox_EmailInboxId",
                        column: x => x.EmailInboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailInbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailInboxFromAddress",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailInboxId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInboxFromAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailInboxFromAddress_EmailInbox_EmailInboxId",
                        column: x => x.EmailInboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailInbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailInboxToAddress",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailInboxId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailInboxToAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailInboxToAddress_EmailInbox_EmailInboxId",
                        column: x => x.EmailInboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailInbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailOutbox",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplayToId = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOutbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailOutbox_EmailInbox_ReplayToId",
                        column: x => x.ReplayToId,
                        principalSchema: "Crm",
                        principalTable: "EmailInbox",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Article",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviewImageId = table.Column<int>(type: "int", nullable: true),
                    PreviewImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPinned = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_FileUpload_PreviewImageId",
                        column: x => x.PreviewImageId,
                        principalSchema: "FS",
                        principalTable: "FileUpload",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Article_User_EditorId",
                        column: x => x.EditorId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Article_User_WriterId",
                        column: x => x.WriterId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ImagePreviewId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LinkSectionId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_LinkSection_LinkSectionId",
                        column: x => x.LinkSectionId,
                        principalSchema: "Cms",
                        principalTable: "LinkSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Link_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountManufacturer",
                schema: "Sale",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_AppliedToManufacturers", x => new { x.DiscountId, x.ManufacturerId });
                    table.ForeignKey(
                        name: "FK_DiscountManufacturer_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountManufacturer_Manufacturer",
                        column: x => x.ManufacturerId,
                        principalSchema: "Sale",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageAttachment",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageAttachment_Message_MessageId",
                        column: x => x.MessageId,
                        principalSchema: "Crm",
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageUser",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    ToUserId = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsPin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageUser_Message_MessageId",
                        column: x => x.MessageId,
                        principalSchema: "Crm",
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageUser_User_ToUserId",
                        column: x => x.ToUserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscribe",
                schema: "Cms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscribeLabelId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribe_SubscribeLabel",
                        column: x => x.SubscribeLabelId,
                        principalSchema: "Cms",
                        principalTable: "SubscribeLabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageTag",
                schema: "Cms",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTag", x => new { x.TagId, x.PageId });
                    table.ForeignKey(
                        name: "FK_PageTag_Page_PageId",
                        column: x => x.PageId,
                        principalSchema: "Cms",
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "Cms",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminComment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DeliveryDateId = table.Column<int>(type: "int", nullable: false),
                    TaxCategoryId = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    MinStockQuantity = table.Column<int>(type: "int", nullable: false),
                    NotifyAdminForQuantityBelow = table.Column<bool>(type: "bit", nullable: false),
                    OrderMinimumQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderMaximumQuantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    AvailableStartDateTimeUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    AvailableEndDateTimeUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ApprovedRatingSum = table.Column<int>(type: "int", nullable: false),
                    NotApprovedRatingSum = table.Column<int>(type: "int", nullable: false),
                    ApprovedTotalReviews = table.Column<int>(type: "int", nullable: false),
                    NotApprovedTotalReviews = table.Column<int>(type: "int", nullable: false),
                    HasDiscountsApplied = table.Column<bool>(type: "bit", nullable: false),
                    MarkAsNew = table.Column<bool>(type: "bit", nullable: false),
                    MarkAsNewStartDateTimeUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    MarkAsNewEndDateTimeUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    NotReturnable = table.Column<bool>(type: "bit", nullable: false),
                    AllowedQuantities = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxExempt = table.Column<bool>(type: "bit", nullable: false),
                    ShowOnHomepage = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeShipping = table.Column<bool>(type: "bit", nullable: false),
                    AllowCustomerReviews = table.Column<bool>(type: "bit", nullable: false),
                    DisplayStockQuantity = table.Column<bool>(type: "bit", nullable: false),
                    DisableBuyButton = table.Column<bool>(type: "bit", nullable: false),
                    DisableWishlistButton = table.Column<bool>(type: "bit", nullable: false),
                    AvailableForPreOrder = table.Column<bool>(type: "bit", nullable: false),
                    CallForPrice = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_CreateUser",
                        column: x => x.CreateUserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Currency",
                        column: x => x.CurrencyId,
                        principalSchema: "Sale",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_DeliveryDate",
                        column: x => x.DeliveryDateId,
                        principalSchema: "Sale",
                        principalTable: "DeliveryDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_TaxCategory",
                        column: x => x.TaxCategoryId,
                        principalSchema: "Sale",
                        principalTable: "TaxCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UpdateUser",
                        column: x => x.UpdateUserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateProvinceId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    County = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ZipPostalCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Country",
                        column: x => x.CountryId,
                        principalSchema: "Sale",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_StateProvince",
                        column: x => x.StateProvinceId,
                        principalSchema: "Sale",
                        principalTable: "StateProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxRate",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxCategoryId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateProvinceId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxRate_Country",
                        column: x => x.CountryId,
                        principalSchema: "Sale",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxRate_StateProvince",
                        column: x => x.StateProvinceId,
                        principalSchema: "Sale",
                        principalTable: "StateProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxRate_TaxCategory",
                        column: x => x.TaxCategoryId,
                        principalSchema: "Sale",
                        principalTable: "TaxCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailOutboxAttachment",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOutboxId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOutboxAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailOutboxAttachment_EmailOutbox_EmailOutboxId",
                        column: x => x.EmailOutboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailOutbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailOutboxFromAddress",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOutboxId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOutboxFromAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailOutboxFromAddress_EmailOutbox_EmailOutboxId",
                        column: x => x.EmailOutboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailOutbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailOutboxToAddress",
                schema: "Crm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailOutboxId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailOutboxToAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailOutboxToAddress_EmailOutbox_EmailOutboxId",
                        column: x => x.EmailOutboxId,
                        principalSchema: "Crm",
                        principalTable: "EmailOutbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                schema: "Cms",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => new { x.TagId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleTag_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "Cms",
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "Cms",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTopic",
                schema: "Cms",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTopic", x => new { x.TopicId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleTopic_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalSchema: "Cms",
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Cms",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProduct",
                schema: "Sale",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_AppliedToProducts", x => new { x.DiscountId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Category_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category",
                        column: x => x.CategoryId,
                        principalSchema: "Sale",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AttributeId = table.Column<int>(type: "int", nullable: true),
                    StockType = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ReservedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarehouseInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Attribute",
                        column: x => x.AttributeId,
                        principalSchema: "Sale",
                        principalTable: "ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductManufacturer",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Manufacturer_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductManufacturer_Manufacturer",
                        column: x => x.ManufacturerId,
                        principalSchema: "Sale",
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductManufacturer_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Picture_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_FileUpload_PictureId",
                        column: x => x.PictureId,
                        principalSchema: "FS",
                        principalTable: "FileUpload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductAttribute",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Attribute_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_Attribute",
                        column: x => x.AttributeId,
                        principalSchema: "Sale",
                        principalTable: "ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductTag",
                schema: "Sale",
                columns: table => new
                {
                    ProductTagId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductTag", x => new { x.ProductId, x.ProductTagId });
                    table.ForeignKey(
                        name: "FK_ProductProductTag_ProductTag_ProductTagId",
                        column: x => x.ProductTagId,
                        principalSchema: "Sale",
                        principalTable: "ProductTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductTag_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ReplyText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CustomerNotifiedOfReply = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    HelpfulYesTotal = table.Column<int>(type: "int", nullable: false),
                    HelpfulNoTotal = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReview_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatedProduct",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId1 = table.Column<int>(type: "int", nullable: false),
                    ProductId2 = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedProduct_Product",
                        column: x => x.ProductId1,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelatedProduct_Product1",
                        column: x => x.ProductId2,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Product",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviewHelpfulness",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductReviewId = table.Column<int>(type: "int", nullable: false),
                    WasHelpful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviewHelpfulness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviewHelpfulness_ProductReview",
                        column: x => x.ProductReviewId,
                        principalSchema: "Sale",
                        principalTable: "ProductReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReviewHelpfulness_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ShippingMethodId = table.Column<int>(type: "int", nullable: true),
                    OrderStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    ShippingStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentMethodId = table.Column<byte>(type: "tinyint", nullable: true),
                    UserCurrencyId = table.Column<int>(type: "int", nullable: true),
                    ShippingTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ShippingAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ShippingAmountTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    RefundedAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CustomerIp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    AllowStoringCreditCardNumber = table.Column<bool>(type: "bit", nullable: false),
                    PaidDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Address",
                        column: x => x.AddressId,
                        principalSchema: "Sale",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Currency",
                        column: x => x.UserCurrencyId,
                        principalSchema: "Sale",
                        principalTable: "Currency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_ShippingMethod",
                        column: x => x.ShippingMethodId,
                        principalSchema: "Sale",
                        principalTable: "ShippingMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDiscount",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDiscount_Discount",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDiscount_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalPriceTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalSchema: "Sale",
                        principalTable: "Discount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_ProductId_Product_Id",
                        column: x => x.ProductId,
                        principalSchema: "Sale",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNote",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNote_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderNote_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TransactionTrackingCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PaymentTrackingCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PaymentDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    PaymentTypeId = table.Column<byte>(type: "tinyint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaskedCreditCardNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardCvv2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CardExpirationMonth = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CardExpirationYear = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ShippedDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    DeliveryDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    ReadyForPickupDateUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: true),
                    AdminComment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2(6)", precision: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipment_Order",
                        column: x => x.OrderId,
                        principalSchema: "Sale",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItem",
                schema: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentItem_OrderItem",
                        column: x => x.OrderItemId,
                        principalSchema: "Sale",
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipmentItem_Shipment",
                        column: x => x.ShipmentId,
                        principalSchema: "Sale",
                        principalTable: "Shipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Category",
                columns: new[] { "Id", "CreatedOnUtc", "Deleted", "Description", "DisplayOrder", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "ParentCategoryId", "PictureId", "Published", "ShowOnHomepage", "UpdatedOnUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), false, "Description of Category 1", 1, "MetaDescription", "MetaKeywords", "Title", "Category 1", null, null, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), false, "Description of Category 2", 2, "MetaDescription", "MetaKeywords", "Title", "Category 2", null, null, true, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Country",
                columns: new[] { "Id", "AllowsBilling", "AllowsShipping", "DisplayOrder", "LimitedToStores", "Name", "NumericIsoCode", "Published", "SubjectToVat", "ThreeLetterIsoCode", "TwoLetterIsoCode" },
                values: new object[,]
                {
                    { 1, true, true, 100, false, "Afghanistan", 4, true, false, "AFG", "AF" },
                    { 2, true, true, 100, false, "Åland Islands", 248, true, false, "ALA", "AX" },
                    { 3, true, true, 100, false, "Albania", 8, true, false, "ALB", "AL" },
                    { 4, true, true, 100, false, "Algeria", 12, true, false, "DZA", "DZ" },
                    { 5, true, true, 100, false, "American Samoa", 16, true, false, "ASM", "AS" },
                    { 6, true, true, 100, false, "Andorra", 20, true, false, "AND", "AD" },
                    { 7, true, true, 100, false, "Angola", 24, true, false, "AGO", "AO" },
                    { 8, true, true, 100, false, "Anguilla", 660, true, false, "AIA", "AI" },
                    { 9, true, true, 100, false, "Antarctica", 10, true, false, "ATA", "AQ" },
                    { 10, true, true, 100, false, "Antigua and Barbuda", 28, true, false, "ATG", "AG" },
                    { 11, true, true, 100, false, "Argentina", 32, true, false, "ARG", "AR" },
                    { 12, true, true, 100, false, "Armenia", 51, true, false, "ARM", "AM" },
                    { 13, true, true, 100, false, "Aruba", 533, true, false, "ABW", "AW" },
                    { 14, true, true, 100, false, "Australia", 36, true, false, "AUS", "AU" },
                    { 15, true, true, 100, false, "Austria", 40, true, true, "AUT", "AT" },
                    { 16, true, true, 100, false, "Azerbaijan", 31, true, false, "AZE", "AZ" },
                    { 17, true, true, 100, false, "Bahamas", 44, true, false, "BHS", "BS" },
                    { 18, true, true, 100, false, "Bahrain", 48, true, false, "BHR", "BH" },
                    { 19, true, true, 100, false, "Bangladesh", 50, true, false, "BGD", "BD" },
                    { 20, true, true, 100, false, "Barbados", 52, true, false, "BRB", "BB" },
                    { 21, true, true, 100, false, "Belarus", 112, true, false, "BLR", "BY" },
                    { 22, true, true, 100, false, "Belgium", 56, true, true, "BEL", "BE" },
                    { 23, true, true, 100, false, "Belize", 84, true, false, "BLZ", "BZ" },
                    { 24, true, true, 100, false, "Benin", 204, true, false, "BEN", "BJ" },
                    { 25, true, true, 100, false, "Bermuda", 60, true, false, "BMU", "BM" },
                    { 26, true, true, 100, false, "Bhutan", 64, true, false, "BTN", "BT" },
                    { 27, true, true, 100, false, "Bolivia (Plurinational State of)", 68, true, false, "BOL", "BO" },
                    { 28, true, true, 100, false, "Bonaire, Sint Eustatius and Saba", 535, true, false, "BES", "BQ" },
                    { 29, true, true, 100, false, "Bosnia and Herzegovina", 70, true, false, "BIH", "BA" },
                    { 30, true, true, 100, false, "Botswana", 72, true, false, "BWA", "BW" },
                    { 31, true, true, 100, false, "Bouvet Island", 74, true, false, "BVT", "BV" },
                    { 32, true, true, 100, false, "Brazil", 76, true, false, "BRA", "BR" },
                    { 33, true, true, 100, false, "British Indian Ocean Territory", 86, true, false, "IOT", "IO" },
                    { 34, true, true, 100, false, "Brunei Darussalam", 96, true, false, "BRN", "BN" },
                    { 35, true, true, 100, false, "Bulgaria", 100, true, true, "BGR", "BG" },
                    { 36, true, true, 100, false, "Burkina Faso", 854, true, false, "BFA", "BF" },
                    { 37, true, true, 100, false, "Burundi", 108, true, false, "BDI", "BI" },
                    { 38, true, true, 100, false, "Cabo Verde", 132, true, false, "CPV", "CV" },
                    { 39, true, true, 100, false, "Cambodia", 116, true, false, "KHM", "KH" },
                    { 40, true, true, 100, false, "Cameroon", 120, true, false, "CMR", "CM" },
                    { 41, true, true, 100, false, "Canada", 124, true, false, "CAN", "CA" },
                    { 42, true, true, 100, false, "Cayman Islands", 136, true, false, "CYM", "KY" },
                    { 43, true, true, 100, false, "Central African Republic", 140, true, false, "CAF", "CF" },
                    { 44, true, true, 100, false, "Chad", 148, true, false, "TCD", "TD" },
                    { 45, true, true, 100, false, "Chile", 152, true, false, "CHL", "CL" },
                    { 46, true, true, 100, false, "China", 156, true, false, "CHN", "CN" },
                    { 47, true, true, 100, false, "Christmas Island", 162, true, false, "CXR", "CX" },
                    { 48, true, true, 100, false, "Cocos (Keeling) Islands", 166, true, false, "CCK", "CC" },
                    { 49, true, true, 100, false, "Colombia", 170, true, false, "COL", "CO" },
                    { 50, true, true, 100, false, "Comoros", 174, true, false, "COM", "KM" },
                    { 51, true, true, 100, false, "Congo", 178, true, false, "COG", "CG" },
                    { 52, true, true, 100, false, "Congo (Democratic Republic of the)", 180, true, false, "COD", "CD" },
                    { 53, true, true, 100, false, "Cook Islands", 184, true, false, "COK", "CK" },
                    { 54, true, true, 100, false, "Costa Rica", 188, true, false, "CRI", "CR" },
                    { 55, true, true, 100, false, "Côte d'Ivoire", 384, true, false, "CIV", "CI" },
                    { 56, true, true, 100, false, "Croatia", 191, true, true, "HRV", "HR" },
                    { 57, true, true, 100, false, "Cuba", 192, true, false, "CUB", "CU" },
                    { 58, true, true, 100, false, "Curaçao", 531, true, false, "CUW", "CW" },
                    { 59, true, true, 100, false, "Cyprus", 196, true, true, "CYP", "CY" },
                    { 60, true, true, 100, false, "Czechia", 203, true, true, "CZE", "CZ" },
                    { 61, true, true, 100, false, "Denmark", 208, true, true, "DNK", "DK" },
                    { 62, true, true, 100, false, "Djibouti", 262, true, false, "DJI", "DJ" },
                    { 63, true, true, 100, false, "Dominica", 212, true, false, "DMA", "DM" },
                    { 64, true, true, 100, false, "Dominican Republic", 214, true, false, "DOM", "DO" },
                    { 65, true, true, 100, false, "Ecuador", 218, true, false, "ECU", "EC" },
                    { 66, true, true, 100, false, "Egypt", 818, true, false, "EGY", "EG" },
                    { 67, true, true, 100, false, "El Salvador", 222, true, false, "SLV", "SV" },
                    { 68, true, true, 100, false, "Equatorial Guinea", 226, true, false, "GNQ", "GQ" },
                    { 69, true, true, 100, false, "Eritrea", 232, true, false, "ERI", "ER" },
                    { 70, true, true, 100, false, "Estonia", 233, true, true, "EST", "EE" },
                    { 71, true, true, 100, false, "Eswatini", 748, true, false, "SWZ", "SZ" },
                    { 72, true, true, 100, false, "Ethiopia", 231, true, false, "ETH", "ET" },
                    { 73, true, true, 100, false, "Falkland Islands (Malvinas)", 238, true, false, "FLK", "FK" },
                    { 74, true, true, 100, false, "Faroe Islands", 234, true, false, "FRO", "FO" },
                    { 75, true, true, 100, false, "Fiji", 242, true, false, "FJI", "FJ" },
                    { 76, true, true, 100, false, "Finland", 246, true, true, "FIN", "FI" },
                    { 77, true, true, 100, false, "France", 250, true, true, "FRA", "FR" },
                    { 78, true, true, 100, false, "French Guiana", 254, true, false, "GUF", "GF" },
                    { 79, true, true, 100, false, "French Polynesia", 258, true, false, "PYF", "PF" },
                    { 80, true, true, 100, false, "French Southern Territories", 260, true, false, "ATF", "TF" },
                    { 81, true, true, 100, false, "Gabon", 266, true, false, "GAB", "GA" },
                    { 82, true, true, 100, false, "Gambia", 270, true, false, "GMB", "GM" },
                    { 83, true, true, 100, false, "Georgia", 268, true, false, "GEO", "GE" },
                    { 84, true, true, 100, false, "Germany", 276, true, true, "DEU", "DE" },
                    { 85, true, true, 100, false, "Ghana", 288, true, false, "GHA", "GH" },
                    { 86, true, true, 100, false, "Gibraltar", 292, true, false, "GIB", "GI" },
                    { 87, true, true, 100, false, "Greece", 300, true, true, "GRC", "GR" },
                    { 88, true, true, 100, false, "Greenland", 304, true, false, "GRL", "GL" },
                    { 89, true, true, 100, false, "Grenada", 308, true, false, "GRD", "GD" },
                    { 90, true, true, 100, false, "Guadeloupe", 312, true, false, "GLP", "GP" },
                    { 91, true, true, 100, false, "Guam", 316, true, false, "GUM", "GU" },
                    { 92, true, true, 100, false, "Guatemala", 320, true, false, "GTM", "GT" },
                    { 93, true, true, 100, false, "Guernsey", 831, true, false, "GGY", "GG" },
                    { 94, true, true, 100, false, "Guinea", 324, true, false, "GIN", "GN" },
                    { 95, true, true, 100, false, "Guinea-Bissau", 624, true, false, "GNB", "GW" },
                    { 96, true, true, 100, false, "Guyana", 328, true, false, "GUY", "GY" },
                    { 97, true, true, 100, false, "Haiti", 332, true, false, "HTI", "HT" },
                    { 98, true, true, 100, false, "Heard Island and McDonald Islands", 334, true, false, "HMD", "HM" },
                    { 99, true, true, 100, false, "Holy See", 336, true, false, "VAT", "VA" },
                    { 100, true, true, 100, false, "Honduras", 340, true, false, "HND", "HN" },
                    { 101, true, true, 100, false, "Hong Kong", 344, true, false, "HKG", "HK" },
                    { 102, true, true, 100, false, "Hungary", 348, true, true, "HUN", "HU" },
                    { 103, true, true, 100, false, "Iceland", 352, true, false, "ISL", "IS" },
                    { 104, true, true, 100, false, "India", 356, true, false, "IND", "IN" },
                    { 105, true, true, 100, false, "Indonesia", 360, true, false, "IDN", "ID" },
                    { 106, true, true, 100, false, "Iran (Islamic Republic of)", 364, true, false, "IRN", "IR" },
                    { 107, true, true, 100, false, "Iraq", 368, true, false, "IRQ", "IQ" },
                    { 108, true, true, 100, false, "Ireland", 372, true, true, "IRL", "IE" },
                    { 109, true, true, 100, false, "Isle of Man", 833, true, false, "IMN", "IM" },
                    { 110, true, true, 100, false, "Israel", 376, true, false, "ISR", "IL" },
                    { 111, true, true, 100, false, "Italy", 380, true, true, "ITA", "IT" },
                    { 112, true, true, 100, false, "Jamaica", 388, true, false, "JAM", "JM" },
                    { 113, true, true, 100, false, "Japan", 392, true, false, "JPN", "JP" },
                    { 114, true, true, 100, false, "Jersey", 832, true, false, "JEY", "JE" },
                    { 115, true, true, 100, false, "Jordan", 400, true, false, "JOR", "JO" },
                    { 116, true, true, 100, false, "Kazakhstan", 398, true, false, "KAZ", "KZ" },
                    { 117, true, true, 100, false, "Kenya", 404, true, false, "KEN", "KE" },
                    { 118, true, true, 100, false, "Kiribati", 296, true, false, "KIR", "KI" },
                    { 119, true, true, 100, false, "Korea (Democratic People's Republic of)", 408, true, false, "PRK", "KP" },
                    { 120, true, true, 100, false, "Korea (Republic of)", 410, true, false, "KOR", "KR" },
                    { 121, true, true, 100, false, "Kuwait", 414, true, false, "KWT", "KW" },
                    { 122, true, true, 100, false, "Kyrgyzstan", 417, true, false, "KGZ", "KG" },
                    { 123, true, true, 100, false, "Lao People's Democratic Republic", 418, true, false, "LAO", "LA" },
                    { 124, true, true, 100, false, "Latvia", 428, true, true, "LVA", "LV" },
                    { 125, true, true, 100, false, "Lebanon", 422, true, false, "LBN", "LB" },
                    { 126, true, true, 100, false, "Lesotho", 426, true, false, "LSO", "LS" },
                    { 127, true, true, 100, false, "Liberia", 430, true, false, "LBR", "LR" },
                    { 128, true, true, 100, false, "Libya", 434, true, false, "LBY", "LY" },
                    { 129, true, true, 100, false, "Liechtenstein", 438, true, false, "LIE", "LI" },
                    { 130, true, true, 100, false, "Lithuania", 440, true, true, "LTU", "LT" },
                    { 131, true, true, 100, false, "Luxembourg", 442, true, true, "LUX", "LU" },
                    { 132, true, true, 100, false, "Macao", 446, true, false, "MAC", "MO" },
                    { 133, true, true, 100, false, "North Macedonia", 807, true, false, "MKD", "MK" },
                    { 134, true, true, 100, false, "Madagascar", 450, true, false, "MDG", "MG" },
                    { 135, true, true, 100, false, "Malawi", 454, true, false, "MWI", "MW" },
                    { 136, true, true, 100, false, "Malaysia", 458, true, false, "MYS", "MY" },
                    { 137, true, true, 100, false, "Maldives", 462, true, false, "MDV", "MV" },
                    { 138, true, true, 100, false, "Mali", 466, true, false, "MLI", "ML" },
                    { 139, true, true, 100, false, "Malta", 470, true, true, "MLT", "MT" },
                    { 140, true, true, 100, false, "Marshall Islands", 584, true, false, "MHL", "MH" },
                    { 141, true, true, 100, false, "Martinique", 474, true, false, "MTQ", "MQ" },
                    { 142, true, true, 100, false, "Mauritania", 478, true, false, "MRT", "MR" },
                    { 143, true, true, 100, false, "Mauritius", 480, true, false, "MUS", "MU" },
                    { 144, true, true, 100, false, "Mayotte", 175, true, false, "MYT", "YT" },
                    { 145, true, true, 100, false, "Mexico", 484, true, false, "MEX", "MX" },
                    { 146, true, true, 100, false, "Micronesia (Federated States of)", 583, true, false, "FSM", "FM" },
                    { 147, true, true, 100, false, "Moldova (Republic of)", 498, true, false, "MDA", "MD" },
                    { 148, true, true, 100, false, "Monaco", 492, true, false, "MCO", "MC" },
                    { 149, true, true, 100, false, "Mongolia", 496, true, false, "MNG", "MN" },
                    { 150, true, true, 100, false, "Montenegro", 499, true, false, "MNE", "ME" },
                    { 151, true, true, 100, false, "Montserrat", 500, true, false, "MSR", "MS" },
                    { 152, true, true, 100, false, "Morocco", 504, true, false, "MAR", "MA" },
                    { 153, true, true, 100, false, "Mozambique", 508, true, false, "MOZ", "MZ" },
                    { 154, true, true, 100, false, "Myanmar", 104, true, false, "MMR", "MM" },
                    { 155, true, true, 100, false, "Namibia", 516, true, false, "NAM", "NA" },
                    { 156, true, true, 100, false, "Nauru", 520, true, false, "NRU", "NR" },
                    { 157, true, true, 100, false, "Nepal", 524, true, false, "NPL", "NP" },
                    { 158, true, true, 100, false, "Netherlands", 528, true, true, "NLD", "NL" },
                    { 159, true, true, 100, false, "New Caledonia", 540, true, false, "NCL", "NC" },
                    { 160, true, true, 100, false, "New Zealand", 554, true, false, "NZL", "NZ" },
                    { 161, true, true, 100, false, "Nicaragua", 558, true, false, "NIC", "NI" },
                    { 162, true, true, 100, false, "Niger", 562, true, false, "NER", "NE" },
                    { 163, true, true, 100, false, "Nigeria", 566, true, false, "NGA", "NG" },
                    { 164, true, true, 100, false, "Niue", 570, true, false, "NIU", "NU" },
                    { 165, true, true, 100, false, "Norfolk Island", 574, true, false, "NFK", "NF" },
                    { 166, true, true, 100, false, "Northern Mariana Islands", 580, true, false, "MNP", "MP" },
                    { 167, true, true, 100, false, "Norway", 578, true, false, "NOR", "NO" },
                    { 168, true, true, 100, false, "Oman", 512, true, false, "OMN", "OM" },
                    { 169, true, true, 100, false, "Pakistan", 586, true, false, "PAK", "PK" },
                    { 170, true, true, 100, false, "Palau", 585, true, false, "PLW", "PW" },
                    { 171, true, true, 100, false, "Palestine, State of", 275, true, false, "PSE", "PS" },
                    { 172, true, true, 100, false, "Panama", 591, true, false, "PAN", "PA" },
                    { 173, true, true, 100, false, "Papua New Guinea", 598, true, false, "PNG", "PG" },
                    { 174, true, true, 100, false, "Paraguay", 600, true, false, "PRY", "PY" },
                    { 175, true, true, 100, false, "Peru", 604, true, false, "PER", "PE" },
                    { 176, true, true, 100, false, "Philippines", 608, true, false, "PHL", "PH" },
                    { 177, true, true, 100, false, "Pitcairn", 612, true, false, "PCN", "PN" },
                    { 178, true, true, 100, false, "Poland", 616, true, true, "POL", "PL" },
                    { 179, true, true, 100, false, "Portugal", 620, true, true, "PRT", "PT" },
                    { 180, true, true, 100, false, "Puerto Rico", 630, true, false, "PRI", "PR" },
                    { 181, true, true, 100, false, "Qatar", 634, true, false, "QAT", "QA" },
                    { 182, true, true, 100, false, "Réunion", 638, true, false, "REU", "RE" },
                    { 183, true, true, 100, false, "Romania", 642, true, true, "ROU", "RO" },
                    { 184, true, true, 100, false, "Russian Federation", 643, true, false, "RUS", "RU" },
                    { 185, true, true, 100, false, "Rwanda", 646, true, false, "RWA", "RW" },
                    { 186, true, true, 100, false, "Saint Barthélemy", 652, true, false, "BLM", "BL" },
                    { 187, true, true, 100, false, "Saint Helena, Ascension and Tristan da Cunha", 654, true, false, "SHN", "SH" },
                    { 188, true, true, 100, false, "Saint Kitts and Nevis", 659, true, false, "KNA", "KN" },
                    { 189, true, true, 100, false, "Saint Lucia", 662, true, false, "LCA", "LC" },
                    { 190, true, true, 100, false, "Saint Martin (French part)", 663, true, false, "MAF", "MF" },
                    { 191, true, true, 100, false, "Saint Pierre and Miquelon", 666, true, false, "SPM", "PM" },
                    { 192, true, true, 100, false, "Saint Vincent and the Grenadines", 670, true, false, "VCT", "VC" },
                    { 193, true, true, 100, false, "Samoa", 882, true, false, "WSM", "WS" },
                    { 194, true, true, 100, false, "San Marino", 674, true, false, "SMR", "SP" },
                    { 195, true, true, 100, false, "Sao Tome and Principe", 678, true, false, "STP", "ST" },
                    { 196, true, true, 100, false, "Saudi Arabia", 682, true, false, "SAU", "SA" },
                    { 197, true, true, 100, false, "Senegal", 686, true, false, "SEN", "SN" },
                    { 198, true, true, 100, false, "Serbia", 688, true, false, "SRB", "RS" },
                    { 199, true, true, 100, false, "Seychelles", 690, true, false, "SYC", "SC" },
                    { 200, true, true, 100, false, "Sierra Leone", 694, true, false, "SLE", "SL" },
                    { 201, true, true, 100, false, "Singapore", 702, true, false, "SGP", "SG" },
                    { 202, true, true, 100, false, "Sint Maarten (Dutch part)", 534, true, false, "SXM", "SX" },
                    { 203, true, true, 100, false, "Slovakia", 703, true, true, "SVK", "SK" },
                    { 204, true, true, 100, false, "Slovenia", 705, true, true, "SVN", "SI" },
                    { 205, true, true, 100, false, "Solomon Islands", 90, true, false, "SLB", "SB" },
                    { 206, true, true, 100, false, "Somalia", 706, true, false, "SOM", "SO" },
                    { 207, true, true, 100, false, "South Africa", 710, true, false, "ZAF", "ZA" },
                    { 208, true, true, 100, false, "South Georgia and the South Sandwich Islands", 239, true, false, "SGS", "GS" },
                    { 209, true, true, 100, false, "South Sudan", 728, true, false, "SSD", "SS" },
                    { 210, true, true, 100, false, "Spain", 724, true, true, "ESP", "ES" },
                    { 211, true, true, 100, false, "Sri Lanka", 144, true, false, "LKA", "LK" },
                    { 212, true, true, 100, false, "Sudan", 729, true, false, "SDN", "SD" },
                    { 213, true, true, 100, false, "Suriname", 740, true, false, "SUR", "SR" },
                    { 214, true, true, 100, false, "Svalbard and Jan Mayen", 744, true, false, "SJM", "SJ" },
                    { 215, true, true, 100, false, "Sweden", 752, true, true, "SWE", "SE" },
                    { 216, true, true, 100, false, "Switzerland", 756, true, false, "CHE", "CH" },
                    { 217, true, true, 100, false, "Syrian Arab Republic", 760, true, false, "SYR", "SY" },
                    { 218, true, true, 100, false, "Taiwan, Province of China", 158, true, false, "TWN", "TW" },
                    { 219, true, true, 100, false, "Tajikistan", 762, true, false, "TJK", "TJ" },
                    { 220, true, true, 100, false, "Tanzania, United Republic of", 834, true, false, "TZA", "TZ" },
                    { 221, true, true, 100, false, "Thailand", 764, true, false, "THA", "TH" },
                    { 222, true, true, 100, false, "Timor-Leste", 626, true, false, "TLS", "TL" },
                    { 223, true, true, 100, false, "Togo", 768, true, false, "TGO", "TG" },
                    { 224, true, true, 100, false, "Tokelau", 772, true, false, "TKL", "TK" },
                    { 225, true, true, 100, false, "Tonga", 776, true, false, "TON", "TO" },
                    { 226, true, true, 100, false, "Trinidad and Tobago", 780, true, false, "TTO", "TT" },
                    { 227, true, true, 100, false, "Tunisia", 788, true, false, "TUN", "TN" },
                    { 228, true, true, 100, false, "Turkey", 792, true, false, "TUR", "TR" },
                    { 229, true, true, 100, false, "Turkmenistan", 795, true, false, "TKM", "TM" },
                    { 230, true, true, 100, false, "Turks and Caicos Islands", 796, true, false, "TCA", "TC" },
                    { 231, true, true, 100, false, "Tuvalu", 798, true, false, "TUV", "TV" },
                    { 232, true, true, 100, false, "Uganda", 800, true, false, "UGA", "UG" },
                    { 233, true, true, 100, false, "Ukraine", 804, true, false, "UKR", "UA" },
                    { 234, true, true, 100, false, "United Arab Emirates", 784, true, false, "ARE", "AE" },
                    { 235, true, true, 100, false, "United Kingdom of Great Britain and Northern Ireland", 826, true, false, "GBR", "GB" },
                    { 236, true, true, 100, false, "United States Minor Outlying Islands", 581, true, false, "UMI", "UM" },
                    { 237, true, true, 1, false, "United States of America", 840, true, false, "USA", "US" },
                    { 238, true, true, 100, false, "Uruguay", 858, true, false, "URY", "UY" },
                    { 239, true, true, 100, false, "Uzbekistan", 860, true, false, "UZB", "UZ" },
                    { 240, true, true, 100, false, "Vanuatu", 548, true, false, "VUT", "VU" },
                    { 241, true, true, 100, false, "Venezuela (Bolivarian Republic of)", 862, true, false, "VEN", "VE" },
                    { 242, true, true, 100, false, "Vietnam", 704, true, false, "VNM", "VN" },
                    { 243, true, true, 100, false, "Virgin Islands (British)", 92, true, false, "VGB", "VG" },
                    { 244, true, true, 100, false, "Virgin Islands (U.S.)", 850, true, false, "VIR", "VI" },
                    { 245, true, true, 100, false, "Wallis and Futuna", 876, true, false, "WLF", "WF" },
                    { 246, true, true, 100, false, "Western Sahara", 732, true, false, "ESH", "EH" },
                    { 247, true, true, 100, false, "Yemen", 887, true, false, "YEM", "YE" },
                    { 248, true, true, 100, false, "Zambia", 894, true, false, "ZMB", "ZM" },
                    { 249, true, true, 100, false, "Zimbabwe", 716, true, false, "ZWE", "ZW" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Currency",
                columns: new[] { "Id", "CreatedOnUtc", "CurrencyCode", "CustomFormatting", "DisplayLocale", "DisplayOrder", "LimitedToStores", "Name", "Published", "Rate", "RoundingTypeId", "UpdatedOnUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), "USD", "", "en-US", 1, false, "US Dollar", true, 1m, 0, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970) },
                    { 2, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), "EUR", "€0.00", "", 2, false, "Euro", true, 0.86m, 0, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970) },
                    { 3, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), "Rial", "", "fa-IR", 3, false, "Iranian", true, 1m, 0, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970) }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "DeliveryDate",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "1-2 days" },
                    { 2, 2, "3-5 days" },
                    { 3, 3, "1 week" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Discount",
                columns: new[] { "Id", "AdminComment", "CouponCode", "DiscountAmount", "DiscountLimitationId", "DiscountPercentage", "DiscountTypeId", "EndDateUtc", "IsActive", "LimitationTimes", "MaximumDiscountAmount", "MaximumDiscountedQuantity", "Name", "RequiresCouponCode", "StartDateUtc", "UsePercentage" },
                values: new object[,]
                {
                    { 1, "AdminComment", "CoponCode1", 0m, 0, 4m, 5, null, true, 1, null, null, "Discount 1", true, null, true },
                    { 2, "AdminComment", "CoponCode2", 0m, 15, 6m, 5, null, true, 1, null, null, "Discount 2", true, null, true }
                });

            migrationBuilder.InsertData(
                schema: "Cms",
                table: "LinkSection",
                columns: new[] { "Id", "IsVisible", "Key", "Title" },
                values: new object[,]
                {
                    { 1, true, "Categories", "Categories" },
                    { 2, true, "RecentPosts", "Recent Post" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "Manufacturer",
                columns: new[] { "Id", "CreatedOnUtc", "Deleted", "Description", "DisplayOrder", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "PictureId", "Published", "UpdatedOnUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), false, "Description of Category 1", 1, "MetaDescription", "MetaKeywords", "Title", "Manufacturer 1", null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 10, 10, 58, 14, 739, DateTimeKind.Unspecified).AddTicks(8970), false, "Description of Category 2", 2, "MetaDescription", "MetaKeywords", "Title", "Manufacturer 2", null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "Cms",
                table: "Menu",
                columns: new[] { "Id", "Order", "ParentId", "PreviewImageId", "Title", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 0, null, null, "About", "/About", 1 },
                    { 2, 1, null, null, "Service", "/Service", 1 },
                    { 3, 2, null, null, "Pricing", "/Pricing", 1 },
                    { 4, 3, null, null, "Contact", "/Contact", 1 },
                    { 5, 4, null, null, "Blog", "/Blog", 1 }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "ProductAttribute",
                columns: new[] { "Id", "AttributeType", "Description", "DisplayOrder", "Name", "PictureId", "Value" },
                values: new object[,]
                {
                    { 1, 0, null, 1, "Blue", null, "blue" },
                    { 2, 0, null, 2, "Red", null, "red" },
                    { 3, 0, null, 3, "White", null, "#fff" },
                    { 4, 0, null, 4, "Black", null, "#000" },
                    { 5, 1, "Small Means S US Size", 5, "Small size", null, "#Small" },
                    { 6, 1, "Small Means M US Size", 6, "Medium", null, "#Medium" },
                    { 7, 1, "Small Means XL US Size", 7, "Large", null, "#Large" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "ProductTag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tag 1" },
                    { 2, "Tag 2" },
                    { 3, "Tag 3" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "ShippingMethod",
                columns: new[] { "Id", "Description", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, "Shipping by land transport", 1, "Ground" },
                    { 2, "The one day air shipping", 2, "Next Day Air" },
                    { 3, "The two day air shipping", 3, "2nd Day Air" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "TaxCategory",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "5% Tax" },
                    { 2, 2, "9% Tax" },
                    { 3, 3, "20% Tax" }
                });

            migrationBuilder.InsertData(
                schema: "Sale",
                table: "StateProvince",
                columns: new[] { "Id", "Abbreviation", "CountryId", "DisplayOrder", "Name", "Published" },
                values: new object[,]
                {
                    { 1, "", 12, 0, "Երևան", true },
                    { 2, "", 12, 1, "Արարատի մարզ", true },
                    { 3, "", 12, 2, "Արմավիրի մարզ", true },
                    { 4, "", 12, 3, "Կոտայքի մարզ", true },
                    { 5, "", 12, 4, "Արագածոտնի մարտ", true },
                    { 6, "", 12, 5, "Գեղարքունիքի մարզ", true },
                    { 7, "", 12, 6, "Շիրակի մարզ", true },
                    { 8, "", 12, 7, "Լոռու մարզ", true },
                    { 9, "", 12, 8, "Վայոց ձորի մարզ", true },
                    { 10, "", 12, 9, "Սյունիքի մարզ", true },
                    { 11, "", 12, 10, "Տավուշի մարզ", true },
                    { 12, "CABA", 11, 1, "Ciudad Autonoma de Buenos Aires", true },
                    { 13, "BA", 11, 2, "Buenos Aires", true },
                    { 14, "CA", 11, 3, "Catamarca", true },
                    { 15, "CH", 11, 3, "Chaco", true },
                    { 16, "CT", 11, 3, "Chubut", true },
                    { 17, "CB", 11, 3, "Cordoba", true },
                    { 18, "CR", 11, 3, "Corrientes", true },
                    { 19, "ER", 11, 3, "Entre Rios", true },
                    { 20, "FO", 11, 3, "Formosa", true },
                    { 21, "JY", 11, 3, "Jujuy", true },
                    { 22, "LP", 11, 3, "La Pampa", true },
                    { 23, "LR", 11, 3, "La Rioja", true },
                    { 24, "MZ", 11, 3, "Mendoza", true },
                    { 25, "MI", 11, 3, "Misiones", true },
                    { 26, "NQ", 11, 3, "Neuquen", true },
                    { 27, "RN", 11, 3, "Rio Negro", true },
                    { 28, "SA", 11, 3, "Salta", true },
                    { 29, "SJ", 11, 3, "San Juan", true },
                    { 30, "SL", 11, 3, "San Luis", true },
                    { 31, "SC", 11, 3, "Santa Cruz", true },
                    { 32, "SF", 11, 3, "Santa Fe", true },
                    { 33, "SE", 11, 3, "Santiago del Estero", true },
                    { 34, "TF", 11, 3, "Tierra del Fuego", true },
                    { 35, "TU", 11, 3, "Tucuman", true },
                    { 36, "W", 15, 1, "Wien", true },
                    { 37, "NÖ", 15, 2, "Niederösterreich", true },
                    { 38, "OÖ", 15, 3, "Oberösterreich", true },
                    { 39, "S", 15, 4, "Salzburg", true },
                    { 40, "T", 15, 5, "Tirol", true },
                    { 41, "V", 15, 6, "Vorarlberg", true },
                    { 42, "B", 15, 7, "Burgenland", true },
                    { 43, "ST", 15, 8, "Steiermark", true },
                    { 44, "K", 15, 9, "Kärnten", true },
                    { 45, "", 14, 0, "Australian Capital Territory", true },
                    { 46, "", 14, 0, "New South Wales", true },
                    { 47, "", 14, 0, "Northern Territory", true },
                    { 48, "", 14, 0, "Queensland", true },
                    { 49, "", 14, 0, "South Australia", true },
                    { 50, "", 14, 0, "Tasmania", true },
                    { 51, "", 14, 0, "Victoria", true },
                    { 52, "", 14, 0, "Western Australia", true },
                    { 53, "", 19, 2, "বরগুনা", true },
                    { 54, "", 19, 2, "বরিশাল", true },
                    { 55, "", 19, 2, "ভোলা", true },
                    { 56, "", 19, 2, "ঝালকাঠি", true },
                    { 57, "", 19, 2, "পটুয়াখালী", true },
                    { 58, "", 19, 2, "পিরোজপুর", true },
                    { 59, "", 19, 2, "বান্দরবান", true },
                    { 60, "", 19, 2, "ব্রাহ্মণবাড়ীয়া", true },
                    { 61, "", 19, 2, "চাঁদপুর", true },
                    { 62, "", 19, 2, "চট্টগ্রাম", true },
                    { 63, "", 19, 2, "কুমিল্লা", true },
                    { 64, "", 19, 2, "কক্সবাজার", true },
                    { 65, "", 19, 2, "ফেনী", true },
                    { 66, "", 19, 2, "খাগড়াছড়ি", true },
                    { 67, "", 19, 2, "লক্ষ্মীপুর", true },
                    { 68, "", 19, 2, "নোয়াখালী", true },
                    { 69, "", 19, 2, "রাঙ্গামাটি", true },
                    { 70, "", 19, 1, "ঢাকা", true },
                    { 71, "", 19, 2, "ফরিদপুর", true },
                    { 72, "", 19, 2, "গাজীপুর", true },
                    { 73, "", 19, 2, "গোপালগঞ্জ", true },
                    { 74, "", 19, 2, "কিশোরগঞ্জ", true },
                    { 75, "", 19, 2, "মাদারীপুর", true },
                    { 76, "", 19, 2, "মানিকগঞ্জ", true },
                    { 77, "", 19, 2, "মুন্সীগঞ্জ", true },
                    { 78, "", 19, 2, "নারায়ণগঞ্জ", true },
                    { 79, "", 19, 2, "নরসিংদী", true },
                    { 80, "", 19, 2, "রাজবাড়ী", true },
                    { 81, "", 19, 2, "শরীয়তপুর", true },
                    { 82, "", 19, 2, "টাঙ্গাইল", true },
                    { 83, "", 19, 2, "বাগেরহাট", true },
                    { 84, "", 19, 2, "চুয়াডাঙ্গা", true },
                    { 85, "", 19, 2, "যশোর", true },
                    { 86, "", 19, 2, "ঝিনাইদহ", true },
                    { 87, "", 19, 2, "খুলনা", true },
                    { 88, "", 19, 2, "কুষ্টিয়া", true },
                    { 89, "", 19, 2, "মাগুরা", true },
                    { 90, "", 19, 2, "মেহেরপুর", true },
                    { 91, "", 19, 2, "নড়াইল", true },
                    { 92, "", 19, 2, "সাতক্ষিরা", true },
                    { 93, "", 19, 2, "জামালপুর", true },
                    { 94, "", 19, 2, "ময়মনসিংহ", true },
                    { 95, "", 19, 2, "নেত্রকোনা", true },
                    { 96, "", 19, 2, "শেরপুর", true },
                    { 97, "", 19, 2, "বগুড়া", true },
                    { 98, "", 19, 2, "জয়পুরহাট", true },
                    { 99, "", 19, 2, "নওগাঁ", true },
                    { 100, "", 19, 2, "নাটোর", true },
                    { 101, "", 19, 2, "চাঁপাই নবাবগঞ্জ", true },
                    { 102, "", 19, 2, "পাবনা", true },
                    { 103, "", 19, 2, "রাজশাহী", true },
                    { 104, "", 19, 2, "সিরাজগঞ্জ", true },
                    { 105, "", 19, 2, "দিনাজপুর", true },
                    { 106, "", 19, 2, "গাইবান্ধা", true },
                    { 107, "", 19, 2, "কুড়িগ্রাম", true },
                    { 108, "", 19, 2, "লালমনিরহাট", true },
                    { 109, "", 19, 2, "নীলফামারী", true },
                    { 110, "", 19, 2, "পঞ্চগড়", true },
                    { 111, "", 19, 2, "রংপুর", true },
                    { 112, "", 19, 2, "ঠাকুরগাঁও", true },
                    { 113, "", 19, 2, "হবিগঞ্জ", true },
                    { 114, "", 19, 2, "মৌলভীবাজার", true },
                    { 115, "", 19, 2, "সুনামগঞ্জ", true },
                    { 116, "", 19, 2, "সিলেট", true },
                    { 117, "ANT", 22, 0, "Antwerpen", true },
                    { 118, "VBR", 22, 0, "Brabant wallon", true },
                    { 119, "HAI", 22, 0, "Hainaut", true },
                    { 120, "LIE", 22, 0, "Liège", true },
                    { 121, "LIM", 22, 0, "Limburg", true },
                    { 122, "LUX", 22, 0, "Luxembourg", true },
                    { 123, "NAM", 22, 0, "Namur", true },
                    { 124, "OVL", 22, 0, "Oost-Vlaanderen", true },
                    { 125, "VBR", 22, 0, "Vlaams-Brabant", true },
                    { 126, "WVL", 22, 0, "West-Vlaanderen", true },
                    { 127, "", 35, 0, "Blagoevgrad", true },
                    { 128, "", 35, 0, "Burgas", true },
                    { 129, "", 35, 0, "Dobrich", true },
                    { 130, "", 35, 0, "Gabrovo", true },
                    { 131, "", 35, 0, "Haskovo", true },
                    { 132, "", 35, 0, "Kardzhali", true },
                    { 133, "", 35, 0, "Kyustendil", true },
                    { 134, "", 35, 0, "Lovech", true },
                    { 135, "", 35, 0, "Montana", true },
                    { 136, "", 35, 0, "Pazardzhik", true },
                    { 137, "", 35, 0, "Pernik", true },
                    { 138, "", 35, 0, "Pleven", true },
                    { 139, "", 35, 0, "Plovdiv", true },
                    { 140, "", 35, 0, "Razgrad", true },
                    { 141, "", 35, 0, "Ruse", true },
                    { 142, "", 35, 0, "Shumen", true },
                    { 143, "", 35, 0, "Silistra", true },
                    { 144, "", 35, 0, "Sliven", true },
                    { 145, "", 35, 0, "Smolyan", true },
                    { 146, "", 35, 0, "Sofia", true },
                    { 147, "", 35, 0, "Sofia city", true },
                    { 148, "", 35, 0, "Stara Zagora", true },
                    { 149, "", 35, 0, "Targovishte", true },
                    { 150, "", 35, 0, "Varna", true },
                    { 151, "", 35, 0, "Veliko Tarnovo", true },
                    { 152, "", 35, 0, "Vidin", true },
                    { 153, "", 35, 0, "Vratsa", true },
                    { 154, "", 35, 0, "Yambol", true },
                    { 155, "", 34, 1, "Belait", true },
                    { 156, "", 34, 2, "Brunei-Muara", true },
                    { 157, "", 34, 3, "Temburong", true },
                    { 158, "", 34, 4, "Tutong", true },
                    { 159, "AC", 32, 0, "Acre", true },
                    { 160, "AL", 32, 0, "Alagoas", true },
                    { 161, "AP", 32, 0, "Amapá", true },
                    { 162, "AM", 32, 0, "Amazonas", true },
                    { 163, "BA", 32, 0, "Bahia", true },
                    { 164, "CE", 32, 0, "Ceará", true },
                    { 165, "DF", 32, 0, "Distrito Federal", true },
                    { 166, "ES", 32, 0, "Espírito Santo", true },
                    { 167, "GO", 32, 0, "Goiás", true },
                    { 168, "MA", 32, 0, "Maranhão", true },
                    { 169, "MT", 32, 0, "Mato Grosso", true },
                    { 170, "MS", 32, 0, "Mato Grosso do Sul", true },
                    { 171, "MG", 32, 0, "Minas Gerais", true },
                    { 172, "PA", 32, 0, "Pará", true },
                    { 173, "PB", 32, 0, "Paraíba", true },
                    { 174, "PR", 32, 0, "Paraná", true },
                    { 175, "PE", 32, 0, "Pernambuco", true },
                    { 176, "PI", 32, 0, "Piauí", true },
                    { 177, "RJ", 32, 0, "Rio de Janeiro", true },
                    { 178, "RN", 32, 0, "Rio Grande do Norte", true },
                    { 179, "RS", 32, 0, "Rio Grande do Sul", true },
                    { 180, "RO", 32, 0, "Rondônia", true },
                    { 181, "RR", 32, 0, "Roraima", true },
                    { 182, "SC", 32, 0, "Santa Catarina", true },
                    { 183, "SP", 32, 0, "São Paulo", true },
                    { 184, "SE", 32, 0, "Sergipe", true },
                    { 185, "TO", 32, 0, "Tocantins", true },
                    { 186, "1", 21, 1, "Брестская область", true },
                    { 187, "2", 21, 1, "Витебская область", true },
                    { 188, "3", 21, 1, "Гомельская область", true },
                    { 189, "4", 21, 1, "Гродненская область", true },
                    { 190, "5", 21, 1, "Минская область", true },
                    { 191, "6", 21, 1, "Могилёвская область", true },
                    { 192, "7", 21, 1, "Минск", true },
                    { 193, "AB", 41, 1, "Alberta", true },
                    { 194, "BC", 41, 1, "British Columbia", true },
                    { 195, "MB", 41, 1, "Manitoba", true },
                    { 196, "NB", 41, 1, "New Brunswick", true },
                    { 197, "NL", 41, 1, "Newfoundland and Labrador", true },
                    { 198, "NT", 41, 1, "Northwest Territories", true },
                    { 199, "NS", 41, 1, "Nova Scotia", true },
                    { 200, "NU", 41, 1, "Nunavut", true },
                    { 201, "ON", 41, 1, "Ontario", true },
                    { 202, "PE", 41, 1, "Prince Edward Island", true },
                    { 203, "QC", 41, 1, "Quebec", true },
                    { 204, "SK", 41, 1, "Saskatchewan", true },
                    { 205, "YU", 41, 1, "Yukon Territory", true },
                    { 206, "AG", 216, 0, "Aargau", true },
                    { 207, "AR", 216, 0, "Appenzell Ausserrhoden", true },
                    { 208, "AI", 216, 0, "Appenzell Innerrhoden", true },
                    { 209, "BL", 216, 0, "Basel-Landschaft", true },
                    { 210, "BS", 216, 0, "Basel-Stadt", true },
                    { 211, "BE", 216, 0, "Bern", true },
                    { 212, "FR", 216, 0, "Fribourg/Freiburg", true },
                    { 213, "GE", 216, 0, "Genève", true },
                    { 214, "GL", 216, 0, "Glarus", true },
                    { 215, "GR", 216, 0, "Graubünden/Grischun", true },
                    { 216, "JU", 216, 0, "Jura", true },
                    { 217, "LU", 216, 0, "Luzern", true },
                    { 218, "NE", 216, 0, "Neuchâtel", true },
                    { 219, "NW", 216, 0, "Nidwalden", true },
                    { 220, "OW", 216, 0, "Obwalden", true },
                    { 221, "SH", 216, 0, "Schaffhausen", true },
                    { 222, "SZ", 216, 0, "Schwyz", true },
                    { 223, "SO", 216, 0, "Solothurn", true },
                    { 224, "SG", 216, 0, "St. Gallen", true },
                    { 225, "TI", 216, 0, "Ticino", true },
                    { 226, "TG", 216, 0, "Thurgau", true },
                    { 227, "UR", 216, 0, "Uri", true },
                    { 228, "VD", 216, 0, "Vaud", true },
                    { 229, "VS", 216, 0, "Valais/Wallis", true },
                    { 230, "ZG", 216, 0, "Zug", true },
                    { 231, "ZH", 216, 0, "Zürich", true },
                    { 232, "北京市", 46, 1, "北京市", true },
                    { 233, "天津市", 46, 2, "天津市", true },
                    { 234, "河北省", 46, 3, "河北省", true },
                    { 235, "山西省", 46, 4, "山西省", true },
                    { 236, "内蒙古自治区", 46, 5, "内蒙古自治区", true },
                    { 237, "辽宁省", 46, 6, "辽宁省", true },
                    { 238, "吉林省", 46, 7, "吉林省", true },
                    { 239, "黑龙江省", 46, 8, "黑龙江省", true },
                    { 240, "上海市", 46, 9, "上海市", true },
                    { 241, "江苏省", 46, 10, "江苏省", true },
                    { 242, "浙江省", 46, 11, "浙江省", true },
                    { 243, "安徽省", 46, 12, "安徽省", true },
                    { 244, "福建省", 46, 13, "福建省", true },
                    { 245, "江西省", 46, 14, "江西省", true },
                    { 246, "山东省", 46, 15, "山东省", true },
                    { 247, "河南省", 46, 16, "河南省", true },
                    { 248, "湖北省", 46, 17, "湖北省", true },
                    { 249, "湖南省", 46, 18, "湖南省", true },
                    { 250, "广东省", 46, 19, "广东省", true },
                    { 251, "广西壮族自治区", 46, 20, "广西壮族自治区", true },
                    { 252, "海南省", 46, 21, "海南省", true },
                    { 253, "重庆市", 46, 22, "重庆市", true },
                    { 254, "四川省", 46, 23, "四川省", true },
                    { 255, "贵州省", 46, 24, "贵州省", true },
                    { 256, "云南省", 46, 25, "云南省", true },
                    { 257, "西藏自治区", 46, 26, "西藏自治区", true },
                    { 258, "陕西省", 46, 27, "陕西省", true },
                    { 259, "甘肃省", 46, 28, "甘肃省", true },
                    { 260, "青海省", 46, 29, "青海省", true },
                    { 261, "宁夏回族自治区", 46, 30, "宁夏回族自治区", true },
                    { 262, "新疆维吾尔自治区", 46, 31, "新疆维吾尔自治区", true },
                    { 263, "香港特别行政区", 46, 32, "香港特别行政区", true },
                    { 264, "澳门特别行政区", 46, 33, "澳门特别行政区", true },
                    { 265, "台湾省", 46, 34, "台湾省", true },
                    { 266, "", 49, 0, "Amazonas", true },
                    { 267, "", 49, 0, "Antioquia", true },
                    { 268, "", 49, 0, "Arauca", true },
                    { 269, "", 49, 0, "Atlántico", true },
                    { 270, "", 49, 0, "Bolívar", true },
                    { 271, "", 49, 0, "Boyacá", true },
                    { 272, "", 49, 0, "Caldas", true },
                    { 273, "", 49, 0, "Caquetá", true },
                    { 274, "", 49, 0, "Casanare", true },
                    { 275, "", 49, 0, "Cauca", true },
                    { 276, "", 49, 0, "Cesar", true },
                    { 277, "", 49, 0, "Chocó", true },
                    { 278, "", 49, 0, "Córdoba", true },
                    { 279, "", 49, 0, "Cundinamarca", true },
                    { 280, "", 49, 0, "Guainía", true },
                    { 281, "", 49, 0, "Guaviare", true },
                    { 282, "", 49, 0, "Huila", true },
                    { 283, "", 49, 0, "La Guajira", true },
                    { 284, "", 49, 0, "Magdalena", true },
                    { 285, "", 49, 0, "Meta", true },
                    { 286, "", 49, 0, "Nariño", true },
                    { 287, "", 49, 0, "Norte de Santander", true },
                    { 288, "", 49, 0, "Putumayo", true },
                    { 289, "", 49, 0, "Quindío", true },
                    { 290, "", 49, 0, "Risaralda", true },
                    { 291, "", 49, 0, "San Andrés y Providencia", true },
                    { 292, "", 49, 0, "Santander", true },
                    { 293, "", 49, 0, "Sucre", true },
                    { 294, "", 49, 0, "Tolima", true },
                    { 295, "", 49, 0, "Valle del Cauca", true },
                    { 296, "", 49, 0, "Vaupés", true },
                    { 297, "", 49, 0, "Vichada", true },
                    { 298, "CR-A", 54, 1, "Alajuela", true },
                    { 299, "CR-C", 54, 1, "Cartago", true },
                    { 300, "CR-G", 54, 1, "Guanacaste", true },
                    { 301, "CR-H", 54, 1, "Heredia", true },
                    { 302, "CR-L", 54, 1, "Limón", true },
                    { 303, "CR-P", 54, 1, "Puntarenas", true },
                    { 304, "CR-SJ", 54, 1, "San José", true },
                    { 305, "", 57, 1, "Pinar del Río", true },
                    { 306, "", 57, 2, "Artemisa", true },
                    { 307, "", 57, 3, "La Habana", true },
                    { 308, "", 57, 4, "Mayabeque", true },
                    { 309, "", 57, 5, "Matanzas", true },
                    { 310, "", 57, 6, "Cienfuegos", true },
                    { 311, "", 57, 7, "Villa Clara", true },
                    { 312, "", 57, 8, "Sancti Spíritus", true },
                    { 313, "", 57, 9, "Ciego de Ávila", true },
                    { 314, "", 57, 10, "Camagüey", true },
                    { 315, "", 57, 11, "Las Tunas", true },
                    { 316, "", 57, 12, "Holguín", true },
                    { 317, "", 57, 13, "Granma", true },
                    { 318, "", 57, 14, "Santiago de Cuba", true },
                    { 319, "", 57, 15, "Guantánamo", true },
                    { 320, "", 57, 16, "Isla de la Juventud", true },
                    { 321, "", 59, 0, "Famagusta district", true },
                    { 322, "", 59, 0, "Kyrenia district", true },
                    { 323, "", 59, 0, "Limassol district", true },
                    { 324, "", 59, 0, "Larnaca district", true },
                    { 325, "", 59, 0, "Nicosia district", true },
                    { 326, "", 59, 0, "Paphos district", true },
                    { 327, "", 60, 0, "Hlavní město Praha", true },
                    { 328, "", 60, 0, "Středočeský kraj", true },
                    { 329, "", 60, 0, "Jihočeský kraj", true },
                    { 330, "", 60, 0, "Plzeňský kraj", true },
                    { 331, "", 60, 0, "Karlovarský kraj", true },
                    { 332, "", 60, 0, "Ústecký kraj", true },
                    { 333, "", 60, 0, "Liberecký kraj", true },
                    { 334, "", 60, 0, "Královéhradecký kraj", true },
                    { 335, "", 60, 0, "Pardubický kraj", true },
                    { 336, "", 60, 0, "Kraj Vysočina", true },
                    { 337, "", 60, 0, "Jihomoravský kraj", true },
                    { 338, "", 60, 0, "Olomoucký kraj", true },
                    { 339, "", 60, 0, "Zlínský kraj", true },
                    { 340, "", 60, 0, "Moravskoslezský kraj", true },
                    { 341, "84", 61, 1, "Hovedstaden", true },
                    { 342, "82", 61, 2, "Midtjylland", true },
                    { 343, "81", 61, 3, "Nordjylland", true },
                    { 344, "85", 61, 4, "Sjælland", true },
                    { 345, "83", 61, 5, "Syddanmark", true },
                    { 346, "BW", 84, 0, "Baden-Württemberg", true },
                    { 347, "BY", 84, 0, "Bayern", true },
                    { 348, "BE", 84, 0, "Berlin", true },
                    { 349, "BB", 84, 0, "Brandenburg", true },
                    { 350, "HB", 84, 0, "Bremen", true },
                    { 351, "HH", 84, 0, "Hamburg", true },
                    { 352, "HE", 84, 0, "Hessen", true },
                    { 353, "MV", 84, 0, "Mecklenburg-Vorpommern", true },
                    { 354, "NI", 84, 0, "Niedersachsen", true },
                    { 355, "NW", 84, 0, "Nordrhein-Westfalen", true },
                    { 356, "RP", 84, 0, "Rheinland-Pfalz", true },
                    { 357, "SL", 84, 0, "Saarland", true },
                    { 358, "SN", 84, 0, "Sachsen", true },
                    { 359, "ST", 84, 0, "Sachsen-Anhalt", true },
                    { 360, "SH", 84, 0, "Schleswig-Holstein", true },
                    { 361, "TH", 84, 0, "Thüringen", true },
                    { 362, "37", 70, 1, "Harjumaa", true },
                    { 363, "39", 70, 2, "Hiiumaa", true },
                    { 364, "44", 70, 3, "Ida-Virumaa", true },
                    { 365, "49", 70, 4, "Jõgevamaa", true },
                    { 366, "51", 70, 5, "Järvamaa", true },
                    { 367, "57", 70, 6, "Läänemaa", true },
                    { 368, "59", 70, 7, "Lääne-Virumaa", true },
                    { 369, "65", 70, 8, "Põlvamaa", true },
                    { 370, "67", 70, 9, "Pärnumaa", true },
                    { 371, "70", 70, 10, "Raplamaa", true },
                    { 372, "74", 70, 11, "Saaremaa", true },
                    { 373, "78", 70, 12, "Tartumaa", true },
                    { 374, "82", 70, 13, "Valgamaa", true },
                    { 375, "84", 70, 14, "Viljandimaa", true },
                    { 376, "86", 70, 15, "Võrumaa", true },
                    { 377, "", 66, 1, "Cairo", true },
                    { 378, "", 66, 2, "Alexandria", true },
                    { 379, "", 66, 3, "Ismailia", true },
                    { 380, "", 66, 4, "Aswan", true },
                    { 381, "", 66, 5, "Asyut", true },
                    { 382, "", 66, 6, "Beheira", true },
                    { 383, "", 66, 7, "Beni Suef", true },
                    { 384, "", 66, 8, "Dakahlia", true },
                    { 385, "", 66, 9, "Damietta", true },
                    { 386, "", 66, 10, "Faiyum", true },
                    { 387, "", 66, 11, "Gharbia", true },
                    { 388, "", 66, 12, "Giza", true },
                    { 389, "", 66, 13, "Kafr El Sheikh", true },
                    { 390, "", 66, 14, "Luxor", true },
                    { 391, "", 66, 15, "Matruh", true },
                    { 392, "", 66, 16, "Minya", true },
                    { 393, "", 66, 17, "Monufia", true },
                    { 394, "", 66, 18, "New Valley", true },
                    { 395, "", 66, 19, "North Sinai", true },
                    { 396, "", 66, 20, "Port Said", true },
                    { 397, "", 66, 21, "Qalyubia", true },
                    { 398, "", 66, 22, "Qena", true },
                    { 399, "", 66, 23, "Red Sea", true },
                    { 400, "", 66, 24, "Sharqia", true },
                    { 401, "", 66, 25, "Sohag", true },
                    { 402, "", 66, 26, "South Sinai", true },
                    { 403, "", 66, 27, "Suez", true },
                    { 404, "", 210, 1, "Álava", true },
                    { 405, "", 210, 2, "Albacete", true },
                    { 406, "", 210, 3, "Alicante", true },
                    { 407, "", 210, 4, "Almería", true },
                    { 408, "", 210, 5, "Ávila", true },
                    { 409, "", 210, 6, "Badajoz", true },
                    { 410, "", 210, 7, "Baleares (Illes)", true },
                    { 411, "", 210, 8, "Barcelona", true },
                    { 412, "", 210, 9, "Burgos", true },
                    { 413, "", 210, 10, "Cáceres", true },
                    { 414, "", 210, 11, "Cádiz", true },
                    { 415, "", 210, 12, "Castellón", true },
                    { 416, "", 210, 13, "Ciudad Real", true },
                    { 417, "", 210, 14, "Córdoba", true },
                    { 418, "", 210, 15, "A Coruña", true },
                    { 419, "", 210, 16, "Cuenca", true },
                    { 420, "", 210, 17, "Girona", true },
                    { 421, "", 210, 18, "Granada", true },
                    { 422, "", 210, 19, "Guadalajara", true },
                    { 423, "", 210, 20, "Guipúzcoa", true },
                    { 424, "", 210, 21, "Huelva", true },
                    { 425, "", 210, 22, "Huesca", true },
                    { 426, "", 210, 23, "Jaén", true },
                    { 427, "", 210, 24, "León", true },
                    { 428, "", 210, 25, "Lleida", true },
                    { 429, "", 210, 26, "La Rioja", true },
                    { 430, "", 210, 27, "Lugo", true },
                    { 431, "", 210, 28, "Madrid", true },
                    { 432, "", 210, 29, "Málaga", true },
                    { 433, "", 210, 30, "Murcia", true },
                    { 434, "", 210, 31, "Navarra", true },
                    { 435, "", 210, 32, "Ourense", true },
                    { 436, "", 210, 33, "Asturias", true },
                    { 437, "", 210, 34, "Palencia", true },
                    { 438, "", 210, 35, "Las Palmas", true },
                    { 439, "", 210, 36, "Pontevedra", true },
                    { 440, "", 210, 37, "Salamanca", true },
                    { 441, "", 210, 38, "Santa Cruz de Tenerife", true },
                    { 442, "", 210, 39, "Cantabria", true },
                    { 443, "", 210, 40, "Segovia", true },
                    { 444, "", 210, 41, "Sevilla", true },
                    { 445, "", 210, 42, "Soria", true },
                    { 446, "", 210, 43, "Tarragona", true },
                    { 447, "", 210, 44, "Teruel", true },
                    { 448, "", 210, 45, "Toledo", true },
                    { 449, "", 210, 46, "Valencia", true },
                    { 450, "", 210, 47, "Valladolid", true },
                    { 451, "", 210, 48, "Vizcaya", true },
                    { 452, "", 210, 49, "Zamora", true },
                    { 453, "", 210, 50, "Zaragoza", true },
                    { 454, "", 210, 51, "Ceuta", true },
                    { 455, "", 210, 52, "Melilla", true },
                    { 456, "01", 76, 1, "Ahvenanmaan maakunta/Landskapet Åland", true },
                    { 457, "02", 76, 2, "Etelä-Karjala/Södra Karelen", true },
                    { 458, "03", 76, 3, "Etelä-Pohjanmaa/Södra Österbotten", true },
                    { 459, "04", 76, 4, "Etelä-Savo/Södra Savolax", true },
                    { 460, "05", 76, 5, "Kainuu/Kajanaland", true },
                    { 461, "06", 76, 6, "Kanta-Häme/Egentliga Tavastland", true },
                    { 462, "07", 76, 7, "Keski-Pohjanmaa/Mellersta Österbotten", true },
                    { 463, "08", 76, 8, "Keski-Suomi/Mellersta Finland", true },
                    { 464, "09", 76, 9, "Kymenlaakso/Kymmenedalen", true },
                    { 465, "10", 76, 10, "Lappi/Lappland", true },
                    { 466, "11", 76, 11, "Pirkanmaa/Birkaland", true },
                    { 467, "12", 76, 12, "Pohjanmaa/Österbotten", true },
                    { 468, "13", 76, 13, "Pohjois-Karjala/Norra Karelen", true },
                    { 469, "14", 76, 14, "Pohjois-Pohjanmaa/Norra Österbotten", true },
                    { 470, "15", 76, 15, "Pohjois-Savo/Norra Savolax", true },
                    { 471, "16", 76, 16, "Päijät-Häme/Päijänne-Tavastland", true },
                    { 472, "17", 76, 17, "Satakunta/Satakunda", true },
                    { 473, "18", 76, 18, "Uusimaa/Nyland", true },
                    { 474, "19", 76, 19, "Varsinais-Suomi/Egentliga Finland", true },
                    { 475, "01", 77, 1, "Ain", true },
                    { 476, "02", 77, 2, "Aisne", true },
                    { 477, "03", 77, 3, "Allier", true },
                    { 478, "04", 77, 4, "Alpes de Hautes-Provence", true },
                    { 479, "05", 77, 5, "Alpes (Hautes)", true },
                    { 480, "06", 77, 6, "Alpes Maritimes", true },
                    { 481, "07", 77, 7, "Ardèche", true },
                    { 482, "08", 77, 8, "Ardennes", true },
                    { 483, "09", 77, 9, "Ariège", true },
                    { 484, "10", 77, 10, "Aube", true },
                    { 485, "11", 77, 11, "Aude", true },
                    { 486, "12", 77, 12, "Aveyron", true },
                    { 487, "13", 77, 13, "Bouches du Rhône", true },
                    { 488, "14", 77, 14, "Calvados", true },
                    { 489, "15", 77, 15, "Cantal", true },
                    { 490, "16", 77, 16, "Charente", true },
                    { 491, "17", 77, 17, "Charente Maritime", true },
                    { 492, "18", 77, 18, "Cher", true },
                    { 493, "19", 77, 19, "Corrèze", true },
                    { 494, "2A", 77, 20, "Corse du sud", true },
                    { 495, "2B", 77, 21, "Haute corse", true },
                    { 496, "21", 77, 22, "Côte-d'Or", true },
                    { 497, "22", 77, 24, "Côtes d'Armor", true },
                    { 498, "23", 77, 26, "Creuse", true },
                    { 499, "24", 77, 27, "Dordogne", true },
                    { 500, "25", 77, 28, "Doubs", true },
                    { 501, "26", 77, 29, "Drôme", true },
                    { 502, "27", 77, 30, "Eure", true },
                    { 503, "28", 77, 31, "Eure et Loir", true },
                    { 504, "29", 77, 32, "Finistère", true },
                    { 505, "30", 77, 33, "Gard", true },
                    { 506, "31", 77, 34, "Garonne (Haute)", true },
                    { 507, "32", 77, 35, "Gers", true },
                    { 508, "33", 77, 36, "Gironde", true },
                    { 509, "34", 77, 37, "Hérault", true },
                    { 510, "35", 77, 38, "Ille et Vilaine", true },
                    { 511, "36", 77, 39, "Indre", true },
                    { 512, "37", 77, 40, "Indre et Loire", true },
                    { 513, "38", 77, 41, "Isère", true },
                    { 514, "39", 77, 42, "Jura", true },
                    { 515, "40", 77, 43, "Landes", true },
                    { 516, "41", 77, 44, "Loir et Cher", true },
                    { 517, "42", 77, 45, "Loire", true },
                    { 518, "43", 77, 46, "Loire (Haute)", true },
                    { 519, "44", 77, 47, "Loire Atlantique", true },
                    { 520, "45", 77, 48, "Loiret", true },
                    { 521, "46", 77, 49, "Lot", true },
                    { 522, "47", 77, 50, "Lot et Garonne", true },
                    { 523, "48", 77, 51, "Lozère", true },
                    { 524, "49", 77, 52, "Maine et Loire", true },
                    { 525, "50", 77, 53, "Manche", true },
                    { 526, "51", 77, 54, "Marne", true },
                    { 527, "52", 77, 55, "Marne (Haute)", true },
                    { 528, "53", 77, 56, "Mayenne", true },
                    { 529, "54", 77, 57, "Meurthe et Moselle", true },
                    { 530, "55", 77, 58, "Meuse", true },
                    { 531, "56", 77, 59, "Morbihan", true },
                    { 532, "57", 77, 60, "Moselle", true },
                    { 533, "58", 77, 61, "Nièvre", true },
                    { 534, "59", 77, 62, "Nord", true },
                    { 535, "60", 77, 63, "Oise", true },
                    { 536, "61", 77, 64, "Orne", true },
                    { 537, "62", 77, 65, "Pas de Calais", true },
                    { 538, "63", 77, 66, "Puy de Dôme", true },
                    { 539, "64", 77, 67, "Pyrénées Atlantiques", true },
                    { 540, "65", 77, 68, "Pyrénées (Hautes)", true },
                    { 541, "66", 77, 69, "Pyrénées Orientales", true },
                    { 542, "67", 77, 70, "Rhin (Bas)", true },
                    { 543, "68", 77, 71, "Rhin (Haut)", true },
                    { 544, "69", 77, 72, "Rhône", true },
                    { 545, "70", 77, 73, "Saône (Haute)", true },
                    { 546, "71", 77, 74, "Saône et Loire", true },
                    { 547, "72", 77, 75, "Sarthe", true },
                    { 548, "73", 77, 76, "Savoie", true },
                    { 549, "74", 77, 77, "Savoie (Haute)", true },
                    { 550, "75", 77, 78, "Paris", true },
                    { 551, "76", 77, 79, "Seine Maritime", true },
                    { 552, "77", 77, 80, "Seine et Marne", true },
                    { 553, "78", 77, 81, "Yvelines", true },
                    { 554, "79", 77, 82, "Sèvres (Deux)", true },
                    { 555, "80", 77, 83, "Somme", true },
                    { 556, "81", 77, 84, "Tarn", true },
                    { 557, "82", 77, 85, "Tarn et Garonne", true },
                    { 558, "83", 77, 86, "Var", true },
                    { 559, "84", 77, 87, "Vaucluse", true },
                    { 560, "85", 77, 88, "Vendée", true },
                    { 561, "86", 77, 89, "Vienne", true },
                    { 562, "87", 77, 90, "Vienne (Haute)", true },
                    { 563, "88", 77, 91, "Vosges", true },
                    { 564, "89", 77, 92, "Yonne", true },
                    { 565, "90", 77, 93, "Belfort (Territoire de)", true },
                    { 566, "91", 77, 94, "Essonne", true },
                    { 567, "92", 77, 95, "Hauts de Seine", true },
                    { 568, "93", 77, 96, "Seine Saint Denis", true },
                    { 569, "94", 77, 97, "Val de Marne", true },
                    { 570, "95", 77, 98, "Val d'oise", true },
                    { 571, "971", 77, 99, "Guadeloupe", true },
                    { 572, "972", 77, 100, "Martinique", true },
                    { 573, "973", 77, 101, "Guyane", true },
                    { 574, "974", 77, 102, "Réunion", true },
                    { 575, "975", 77, 103, "Saint-Pierre-et-Miquelon", true },
                    { 576, "976", 77, 104, "Mayotte", true },
                    { 577, "984", 77, 105, "Terres Australes et Antarctiques", true },
                    { 578, "986", 77, 106, "Wallis et futuna", true },
                    { 579, "987", 77, 107, "Polynésie Française", true },
                    { 580, "988", 77, 108, "Nouvelle-Calédonie", true },
                    { 581, "", 235, 1, "Aberdeenshire", true },
                    { 582, "", 235, 1, "Anglesey/Sir Fon", true },
                    { 583, "", 235, 1, "Angus", true },
                    { 584, "", 235, 1, "Argyll and Bute", true },
                    { 585, "", 235, 1, "Ayrshire", true },
                    { 586, "", 235, 1, "Berkshire", true },
                    { 587, "", 235, 1, "Blaenau Gwent", true },
                    { 588, "", 235, 1, "Bridgend", true },
                    { 589, "", 235, 1, "Bristol", true },
                    { 590, "", 235, 1, "Buckinghamshire", true },
                    { 591, "", 235, 1, "Caerphilly", true },
                    { 592, "", 235, 1, "Cambridgeshire", true },
                    { 593, "", 235, 1, "Cardiff", true },
                    { 594, "", 235, 1, "Carmarthenshire", true },
                    { 595, "", 235, 1, "Ceredigion", true },
                    { 596, "", 235, 1, "Cheshire", true },
                    { 597, "", 235, 1, "Clackmannanshire", true },
                    { 598, "", 235, 1, "Conwy", true },
                    { 599, "", 235, 1, "Cornwall", true },
                    { 600, "", 235, 1, "County Antrim", true },
                    { 601, "", 235, 1, "County Armagh", true },
                    { 602, "", 235, 1, "County Down", true },
                    { 603, "", 235, 1, "County Fermanagh", true },
                    { 604, "", 235, 1, "County Londonderry", true },
                    { 605, "", 235, 1, "County Tyrone", true },
                    { 606, "", 235, 1, "Cumbria", true },
                    { 607, "", 235, 1, "Denbighshire", true },
                    { 608, "", 235, 1, "Derbyshire", true },
                    { 609, "", 235, 1, "Devon", true },
                    { 610, "", 235, 1, "Dorset", true },
                    { 611, "", 235, 1, "Dumfries and Galloway", true },
                    { 612, "", 235, 1, "Dunbartonshire", true },
                    { 613, "", 235, 1, "Dundee", true },
                    { 614, "", 235, 1, "Durham", true },
                    { 615, "", 235, 1, "East Lothian", true },
                    { 616, "", 235, 1, "East Riding of Yorkshire", true },
                    { 617, "", 235, 1, "East Sussex", true },
                    { 618, "", 235, 1, "Edinburgh", true },
                    { 619, "", 235, 1, "Essex", true },
                    { 620, "", 235, 1, "Falkirk", true },
                    { 621, "", 235, 1, "Fife", true },
                    { 622, "", 235, 1, "Flintshire", true },
                    { 623, "", 235, 1, "Glamorgan", true },
                    { 624, "", 235, 1, "Glasgow", true },
                    { 625, "", 235, 1, "Gloucestershire", true },
                    { 626, "", 235, 1, "Greater Manchester", true },
                    { 627, "", 235, 1, "Gwynedd", true },
                    { 628, "", 235, 1, "Hampshire", true },
                    { 629, "", 235, 1, "Hereford and Worcester", true },
                    { 630, "", 235, 1, "Hertfordshire", true },
                    { 631, "", 235, 1, "Highland", true },
                    { 632, "", 235, 1, "Inverclyde", true },
                    { 633, "", 235, 1, "Isle of Man", true },
                    { 634, "", 235, 1, "Isle of Wight", true },
                    { 635, "", 235, 1, "Kent", true },
                    { 636, "", 235, 1, "Lanarkshire", true },
                    { 637, "", 235, 1, "Lancashire", true },
                    { 638, "", 235, 1, "Leicestershire", true },
                    { 639, "", 235, 1, "Lincolnshire", true },
                    { 640, "", 235, 1, "London", true },
                    { 641, "", 235, 1, "Merseyside", true },
                    { 642, "", 235, 1, "Merthyr Tydfil", true },
                    { 643, "", 235, 1, "Middlesex", true },
                    { 644, "", 235, 1, "Midlothian", true },
                    { 645, "", 235, 1, "Monmouthshire", true },
                    { 646, "", 235, 1, "Moray", true },
                    { 647, "", 235, 1, "Neath Port Talbot", true },
                    { 648, "", 235, 1, "Newport", true },
                    { 649, "", 235, 1, "Norfolk", true },
                    { 650, "", 235, 1, "North Yorkshire", true },
                    { 651, "", 235, 1, "Northamptonshire", true },
                    { 652, "", 235, 1, "Northumberland", true },
                    { 653, "", 235, 1, "Nottinghamshire", true },
                    { 654, "", 235, 1, "Orkney", true },
                    { 655, "", 235, 1, "Oxfordshire", true },
                    { 656, "", 235, 1, "Pembrokeshire", true },
                    { 657, "", 235, 1, "Perth and Kinross", true },
                    { 658, "", 235, 1, "Powys", true },
                    { 659, "", 235, 1, "Renfrewshire", true },
                    { 660, "", 235, 1, "Rhondda Cynon Taff", true },
                    { 661, "", 235, 1, "Rutland", true },
                    { 662, "", 235, 1, "Scottish Borders", true },
                    { 663, "", 235, 1, "Shetland Isles", true },
                    { 664, "", 235, 1, "Shropshire", true },
                    { 665, "", 235, 1, "Somerset", true },
                    { 666, "", 235, 1, "South Yorkshire", true },
                    { 667, "", 235, 1, "Staffordshire", true },
                    { 668, "", 235, 1, "Stirlingshire", true },
                    { 669, "", 235, 1, "Suffolk", true },
                    { 670, "", 235, 1, "Surrey", true },
                    { 671, "", 235, 1, "Swansea", true },
                    { 672, "", 235, 1, "Torfaen", true },
                    { 673, "", 235, 1, "Tyne and Wear", true },
                    { 674, "", 235, 1, "Warwickshire", true },
                    { 675, "", 235, 1, "West Lothian", true },
                    { 676, "", 235, 1, "West Midlands", true },
                    { 677, "", 235, 1, "West Sussex", true },
                    { 678, "", 235, 1, "West Yorkshire", true },
                    { 679, "", 235, 1, "Western Isles", true },
                    { 680, "", 235, 1, "Wiltshire", true },
                    { 681, "", 235, 1, "Wrexham", true },
                    { 682, "ΑΙΤ", 87, 1, "ΑΙΤΩΛΟΑΚΑΡΝΑΝΙΑΣ", true },
                    { 683, "ΑΡΓ", 87, 2, "ΑΡΓΟΛΙΔΑΣ", true },
                    { 684, "ΑΡΚ", 87, 3, "ΑΡΚΑΔΙΑΣ", true },
                    { 685, "ΑΡΤ", 87, 4, "ΑΡΤΑΣ", true },
                    { 686, "ΑΤΤ", 87, 5, "ΑΤΤΙΚΗΣ", true },
                    { 687, "ΑΧΑ", 87, 6, "ΑΧΑΙΑΣ", true },
                    { 688, "ΒΟΙ", 87, 7, "ΒΟΙΩΤΙΑΣ", true },
                    { 689, "ΓΡΕ", 87, 8, "ΓΡΕΒΕΝΩΝ", true },
                    { 690, "ΔΡΑ", 87, 9, "ΔΡΑΜΑΣ", true },
                    { 691, "ΔΩΔ", 87, 10, "ΔΩΔΕΚΑΝΗΣΟΥ", true },
                    { 692, "ΕΒΡ", 87, 11, "ΕΒΡΟΥ", true },
                    { 693, "ΕΥΒ", 87, 12, "ΕΥΒΟΙΑΣ", true },
                    { 694, "ΕΥΡ", 87, 13, "ΕΥΡΥΤΑΝΙΑΣ", true },
                    { 695, "ΖΑΚ", 87, 14, "ΖΑΚΥΝΘΟΥ", true },
                    { 696, "ΗΛΕ", 87, 15, "ΗΛΕΙΑΣ", true },
                    { 697, "ΗΜΑ", 87, 16, "ΗΜΑΘΙΑΣ", true },
                    { 698, "ΗΡΑ", 87, 17, "ΗΡΑΚΛΕΙΟΥ", true },
                    { 699, "ΘΕΣ", 87, 18, "ΘΕΣΠΡΩΤΙΑΣ", true },
                    { 700, "ΘΕΣ", 87, 19, "ΘΕΣΣΑΛΟΝΙΚΗΣ", true },
                    { 701, "ΙΩΑ", 87, 20, "ΙΩΑΝΝΙΝΩΝ", true },
                    { 702, "ΚΑΒ", 87, 21, "ΚΑΒΑΛΑΣ", true },
                    { 703, "ΚΑΡ", 87, 22, "ΚΑΡΔΙΤΣΑΣ", true },
                    { 704, "ΚΑΣ", 87, 23, "ΚΑΣΤΟΡΙΑΣ", true },
                    { 705, "ΚΕΡ", 87, 24, "ΚΕΡΚΥΡΑΣ", true },
                    { 706, "ΚΕΦ", 87, 25, "ΚΕΦΑΛΛΗΝΙΑΣ", true },
                    { 707, "ΚΙΛ", 87, 26, "ΚΙΛΚΙΣ", true },
                    { 708, "ΚΟΖ", 87, 27, "ΚΟΖΑΝΗΣ", true },
                    { 709, "ΚΟΡ", 87, 28, "ΚΟΡΙΝΘΙΑΣ", true },
                    { 710, "ΚΥΚ", 87, 29, "ΚΥΚΛΑΔΩΝ", true },
                    { 711, "ΛΑΚ", 87, 30, "ΛΑΚΩΝΙΑΣ", true },
                    { 712, "ΛΑΡ", 87, 31, "ΛΑΡΙΣΑΣ", true },
                    { 713, "ΛΑΣ", 87, 32, "ΛΑΣΙΘΙΟΥ", true },
                    { 714, "ΛΕΣ", 87, 33, "ΛΕΣΒΟΥ", true },
                    { 715, "ΛΕΥ", 87, 34, "ΛΕΥΚΑΔΑΣ", true },
                    { 716, "ΜΑΓ", 87, 35, "ΜΑΓΝΗΣΙΑΣ", true },
                    { 717, "ΜΕΣ", 87, 36, "ΜΕΣΣΗΝΙΑΣ", true },
                    { 718, "ΞΑΝ", 87, 37, "ΞΑΝΘΗΣ", true },
                    { 719, "ΠΕΛ", 87, 38, "ΠΕΛΛΗΣ", true },
                    { 720, "ΠΙΕ", 87, 39, "ΠΙΕΡΙΑΣ", true },
                    { 721, "ΠΡΕ", 87, 40, "ΠΡΕΒΕΖΑΣ", true },
                    { 722, "ΡΕΘ", 87, 41, "ΡΕΘΥΜΝΗΣ", true },
                    { 723, "ΡΟΔ", 87, 42, "ΡΟΔΟΠΗΣ", true },
                    { 724, "ΣΑΜ", 87, 43, "ΣΑΜΟΥ", true },
                    { 725, "ΣΕΡ", 87, 44, "ΣΕΡΡΩΝ", true },
                    { 726, "ΤΡΙ", 87, 45, "ΤΡΙΚΑΛΩΝ", true },
                    { 727, "ΦΘΙ", 87, 46, "ΦΘΙΩΤΙΔΑΣ", true },
                    { 728, "ΦΛΩ", 87, 47, "ΦΛΩΡΙΝΑΣ", true },
                    { 729, "ΦΩΚ", 87, 48, "ΦΩΚΙΔΑΣ", true },
                    { 730, "ΧΑΛ", 87, 49, "ΧΑΛΚΙΔΙΚΗΣ", true },
                    { 731, "ΧΑΝ", 87, 50, "ΧΑΝΙΩΝ", true },
                    { 732, "ΧΙΟ", 87, 51, "ΧΙΟΥ", true },
                    { 733, "GZG", 56, 0, "Grad Zagreb", true },
                    { 734, "BBŽ", 56, 1, "Bjelovarsko-bilogorska", true },
                    { 735, "BPŽ", 56, 1, "Brodsko-posavska", true },
                    { 736, "DNŽ", 56, 1, "Dubrovačko-neretvanska", true },
                    { 737, "IŽ", 56, 1, "Istarska", true },
                    { 738, "KŽ", 56, 1, "Karlovačka", true },
                    { 739, "KKŽ", 56, 1, "Koprivničko-križevačka", true },
                    { 740, "KZŽ", 56, 1, "Krapinsko-zagorska", true },
                    { 741, "LSŽ", 56, 1, "Ličko-senjska", true },
                    { 742, "MŽ", 56, 1, "Međimurska", true },
                    { 743, "OBŽ", 56, 1, "Osječko-baranjska", true },
                    { 744, "PSŽ", 56, 1, "Požeško-slavonska", true },
                    { 745, "PGŽ", 56, 1, "Primorsko-goranska", true },
                    { 746, "SMŽ", 56, 1, "Sisačko-moslavačka", true },
                    { 747, "SDŽ", 56, 1, "Splitsko-dalmatinska", true },
                    { 748, "ŠKŽ", 56, 1, "Šibensko-kninska", true },
                    { 749, "VŽ", 56, 1, "Varaždinska", true },
                    { 750, "VPŽ", 56, 1, "Virovitičko-podravska", true },
                    { 751, "VSŽ", 56, 1, "Vukovarsko-srijemska", true },
                    { 752, "ZDŽ", 56, 1, "Zadarska", true },
                    { 753, "ZGŽ", 56, 1, "Zagrebačka", true },
                    { 754, "BU", 102, 1, "Budapest", true },
                    { 755, "BK", 102, 2, "Bács-Kiskun", true },
                    { 756, "BA", 102, 3, "Baranya", true },
                    { 757, "BE", 102, 4, "Békés", true },
                    { 758, "BZ", 102, 5, "Borsod-Abaúj-Zemplén", true },
                    { 759, "CS", 102, 6, "Csongrád", true },
                    { 760, "FE", 102, 7, "Fejér", true },
                    { 761, "GS", 102, 8, "Győr-Moson-Sopron", true },
                    { 762, "HB", 102, 9, "Hajdú-Bihar", true },
                    { 763, "HE", 102, 10, "Heves", true },
                    { 764, "JN", 102, 11, "Jász-Nagykun-Szolnok", true },
                    { 765, "KE", 102, 12, "Komárom-Esztergom", true },
                    { 766, "NO", 102, 13, "Nógrád", true },
                    { 767, "PE", 102, 14, "Pest", true },
                    { 768, "SO", 102, 15, "Somogy", true },
                    { 769, "SZ", 102, 16, "Szabolcs-Szatmár-Bereg", true },
                    { 770, "TO", 102, 17, "Tolna", true },
                    { 771, "VA", 102, 18, "Vas", true },
                    { 772, "VE", 102, 19, "Veszprém", true },
                    { 773, "ZA", 102, 20, "Zala", true },
                    { 774, "", 105, 1, "Aceh", true },
                    { 775, "", 105, 2, "Bali", true },
                    { 776, "", 105, 3, "Banten", true },
                    { 777, "", 105, 4, "Bengkulu", true },
                    { 778, "", 105, 5, "Gorontalo", true },
                    { 779, "", 105, 6, "Jakarta", true },
                    { 780, "", 105, 7, "Jambi", true },
                    { 781, "", 105, 8, "Jawa Barat", true },
                    { 782, "", 105, 9, "Jawa Tengah", true },
                    { 783, "", 105, 10, "Jawa Timur", true },
                    { 784, "", 105, 11, "Kalimantan Barat", true },
                    { 785, "", 105, 12, "Kalimantan Selatan", true },
                    { 786, "", 105, 13, "Kalimantan Tengah", true },
                    { 787, "", 105, 14, "Kalimantan Timur", true },
                    { 788, "", 105, 15, "Kalimantan Utara", true },
                    { 789, "", 105, 16, "Kepulauan Bangka Belitung", true },
                    { 790, "", 105, 17, "Kepulauan Riau", true },
                    { 791, "", 105, 18, "Lampung", true },
                    { 792, "", 105, 19, "Maluku", true },
                    { 793, "", 105, 20, "Maluku Utara", true },
                    { 794, "", 105, 21, "Nusa Tenggara Barat", true },
                    { 795, "", 105, 22, "Nusa Tenggara Timur", true },
                    { 796, "", 105, 23, "Papua", true },
                    { 797, "", 105, 24, "Papua Barat", true },
                    { 798, "", 105, 25, "Riau", true },
                    { 799, "", 105, 26, "Sulawesi Barat", true },
                    { 800, "", 105, 27, "Sulawesi Selatan", true },
                    { 801, "", 105, 28, "Sulawesi Tengah", true },
                    { 802, "", 105, 29, "Sulawesi Tenggara", true },
                    { 803, "", 105, 30, "Sulawesi Utara", true },
                    { 804, "", 105, 31, "Sumatera Barat", true },
                    { 805, "", 105, 32, "Sumatera Selatan", true },
                    { 806, "", 105, 33, "Sumatera Utara", true },
                    { 807, "", 105, 34, "Yogyakarta", true },
                    { 808, "", 108, 1, "County Carlow", true },
                    { 809, "", 108, 2, "County Cavan", true },
                    { 810, "", 108, 3, "County Clare", true },
                    { 811, "", 108, 4, "County Cork", true },
                    { 812, "", 108, 5, "County Donegal", true },
                    { 813, "", 108, 6, "County Dublin", true },
                    { 814, "", 108, 7, "County Galway", true },
                    { 815, "", 108, 8, "County Kerry", true },
                    { 816, "", 108, 9, "County Kildare", true },
                    { 817, "", 108, 10, "County Kilkenny", true },
                    { 818, "", 108, 11, "County Laois", true },
                    { 819, "", 108, 12, "County Leitrim", true },
                    { 820, "", 108, 13, "County Limerick", true },
                    { 821, "", 108, 14, "County Longford", true },
                    { 822, "", 108, 15, "County Louth", true },
                    { 823, "", 108, 16, "County Mayo", true },
                    { 824, "", 108, 17, "County Meath", true },
                    { 825, "", 108, 18, "County Monaghan", true },
                    { 826, "", 108, 19, "County Offaly", true },
                    { 827, "", 108, 20, "County Roscommon", true },
                    { 828, "", 108, 21, "County Sligo", true },
                    { 829, "", 108, 22, "County Tipperary", true },
                    { 830, "", 108, 23, "County Waterford", true },
                    { 831, "", 108, 24, "County Westmeath", true },
                    { 832, "", 108, 25, "County Wexford", true },
                    { 833, "", 108, 26, "County Wicklow", true },
                    { 834, "AP", 104, 1, "Andhra Pradesh", true },
                    { 835, "AR", 104, 1, "Arunachal Pradesh", true },
                    { 836, "AS", 104, 1, "Assam", true },
                    { 837, "BR", 104, 1, "Bihar", true },
                    { 838, "CT", 104, 1, "Chhattisgarh", true },
                    { 839, "GA", 104, 1, "Goa", true },
                    { 840, "GJ", 104, 1, "Gujarat", true },
                    { 841, "HR", 104, 1, "Haryana", true },
                    { 842, "HP", 104, 1, "Himachal Pradesh", true },
                    { 843, "JK", 104, 1, "Jammu and Kashmir", true },
                    { 844, "JH", 104, 1, "Jharkhand", true },
                    { 845, "KA", 104, 1, "Karnataka", true },
                    { 846, "KL", 104, 1, "Kerala", true },
                    { 847, "MP", 104, 1, "Madhya Pradesh", true },
                    { 848, "MH", 104, 1, "Maharashtra", true },
                    { 849, "MN", 104, 1, "Manipur", true },
                    { 850, "ML", 104, 1, "Meghalaya", true },
                    { 851, "MZ", 104, 1, "Mizoram", true },
                    { 852, "NL", 104, 1, "Nagaland", true },
                    { 853, "OR", 104, 1, "Odisha", true },
                    { 854, "PB", 104, 1, "Punjab", true },
                    { 855, "RJ", 104, 1, "Rajasthan", true },
                    { 856, "SK", 104, 1, "Sikkim", true },
                    { 857, "TN", 104, 1, "Tamil Nadu", true },
                    { 858, "TG", 104, 1, "Telangana", true },
                    { 859, "TR", 104, 1, "Tripura", true },
                    { 860, "UT", 104, 1, "Uttarakhand", true },
                    { 861, "UP", 104, 1, "Uttar Pradesh", true },
                    { 862, "WB", 104, 1, "West Bengal", true },
                    { 863, "AN", 104, 1, "Andaman and Nicobar Islands", true },
                    { 864, "CH", 104, 1, "Chandigarh", true },
                    { 865, "DN", 104, 1, "Dadra and Nagar Haveli", true },
                    { 866, "DD", 104, 1, "Daman and Diu", true },
                    { 867, "DL", 104, 1, "Delhi", true },
                    { 868, "LD", 104, 1, "Lakshadweep", true },
                    { 869, "PY", 104, 1, "Puducherry", true },
                    { 870, "", 106, 0, "آذربایجان شرقی", true },
                    { 871, "", 106, 0, "آذربایجان غربی", true },
                    { 872, "", 106, 0, "اردبیل", true },
                    { 873, "", 106, 0, "اصفهان", true },
                    { 874, "", 106, 0, "البرز", true },
                    { 875, "", 106, 0, "ایلام", true },
                    { 876, "", 106, 0, "بوشهر", true },
                    { 877, "", 106, 0, "تهران", true },
                    { 878, "", 106, 0, "چهارمحال و بختیاری", true },
                    { 879, "", 106, 0, "خراسان جنوبی", true },
                    { 880, "", 106, 0, "خراسان رضوی", true },
                    { 881, "", 106, 0, "خراسان شمالی", true },
                    { 882, "", 106, 0, "خوزستان", true },
                    { 883, "", 106, 0, "زنجان", true },
                    { 884, "", 106, 0, "سمنان", true },
                    { 885, "", 106, 0, "سیستان و بلوچستان", true },
                    { 886, "", 106, 0, "فارس", true },
                    { 887, "", 106, 0, "قزوین", true },
                    { 888, "", 106, 0, "قم", true },
                    { 889, "", 106, 0, "کردستان", true },
                    { 890, "", 106, 0, "کرمان", true },
                    { 891, "", 106, 0, "کرمانشاه", true },
                    { 892, "", 106, 0, "کهگیلویه و بویراحمد", true },
                    { 893, "", 106, 0, "گلستان", true },
                    { 894, "", 106, 0, "گیلان", true },
                    { 895, "", 106, 0, "لرستان", true },
                    { 896, "", 106, 0, "مازندران", true },
                    { 897, "", 106, 0, "مرکزی", true },
                    { 898, "", 106, 0, "هرمزگان", true },
                    { 899, "", 106, 0, "همدان", true },
                    { 900, "", 106, 0, "یزد", true },
                    { 901, "", 103, 0, "Höfuðborgarsvæðið", true },
                    { 902, "", 103, 0, "Suðurnes", true },
                    { 903, "", 103, 0, "Vesturland", true },
                    { 904, "", 103, 0, "Vestfirðir", true },
                    { 905, "", 103, 0, "Norðurland vestra", true },
                    { 906, "", 103, 0, "Norðurland eystra", true },
                    { 907, "", 103, 0, "Austurland", true },
                    { 908, "", 103, 0, "Suðurland", true },
                    { 909, "AG", 111, 1, "Agrigento", true },
                    { 910, "AL", 111, 1, "Alessandria", true },
                    { 911, "AN", 111, 1, "Ancona", true },
                    { 912, "AO", 111, 1, "Aosta", true },
                    { 913, "AR", 111, 1, "Arezzo", true },
                    { 914, "AP", 111, 1, "Ascoli Piceno", true },
                    { 915, "AT", 111, 1, "Asti", true },
                    { 916, "AV", 111, 1, "Avellino", true },
                    { 917, "BA", 111, 1, "Bari", true },
                    { 918, "BT", 111, 1, "Barletta-Andria-Trani", true },
                    { 919, "BL", 111, 1, "Belluno", true },
                    { 920, "BN", 111, 1, "Benevento", true },
                    { 921, "BG", 111, 1, "Bergamo", true },
                    { 922, "BI", 111, 1, "Biella", true },
                    { 923, "BO", 111, 1, "Bologna", true },
                    { 924, "BZ", 111, 1, "Bolzano", true },
                    { 925, "BS", 111, 1, "Brescia", true },
                    { 926, "BR", 111, 1, "Brindisi", true },
                    { 927, "CA", 111, 1, "Cagliari", true },
                    { 928, "CL", 111, 1, "Caltanissetta", true },
                    { 929, "CB", 111, 1, "Campobasso", true },
                    { 930, "CI", 111, 1, "Carbonia-Iglesias", true },
                    { 931, "CE", 111, 1, "Caserta", true },
                    { 932, "CT", 111, 1, "Catania", true },
                    { 933, "CZ", 111, 1, "Catanzaro", true },
                    { 934, "CH", 111, 1, "Chieti", true },
                    { 935, "CO", 111, 1, "Como", true },
                    { 936, "CS", 111, 1, "Cosenza", true },
                    { 937, "CR", 111, 1, "Cremona", true },
                    { 938, "KR", 111, 1, "Crotone", true },
                    { 939, "CN", 111, 1, "Cuneo", true },
                    { 940, "EN", 111, 1, "Enna", true },
                    { 941, "FM", 111, 1, "Fermo", true },
                    { 942, "FE", 111, 1, "Ferrara", true },
                    { 943, "FI", 111, 1, "Firenze", true },
                    { 944, "FG", 111, 1, "Foggia", true },
                    { 945, "FC", 111, 1, "Forlì-Cesena", true },
                    { 946, "FR", 111, 1, "Frosinone", true },
                    { 947, "GE", 111, 1, "Genova", true },
                    { 948, "GO", 111, 1, "Gorizia", true },
                    { 949, "GR", 111, 1, "Grosseto", true },
                    { 950, "IM", 111, 1, "Imperia", true },
                    { 951, "IS", 111, 1, "Isernia", true },
                    { 952, "SP", 111, 1, "La Spezia", true },
                    { 953, "AQ", 111, 1, "L'Aquila", true },
                    { 954, "LT", 111, 1, "Latina", true },
                    { 955, "LE", 111, 1, "Lecce", true },
                    { 956, "LC", 111, 1, "Lecco", true },
                    { 957, "LI", 111, 1, "Livorno", true },
                    { 958, "LO", 111, 1, "Lodi", true },
                    { 959, "LU", 111, 1, "Lucca", true },
                    { 960, "MC", 111, 1, "Macerata", true },
                    { 961, "MN", 111, 1, "Mantova", true },
                    { 962, "MS", 111, 1, "Massa-Carrara", true },
                    { 963, "MT", 111, 1, "Matera", true },
                    { 964, "VS", 111, 1, "Medio Campidano", true },
                    { 965, "ME", 111, 1, "Messina", true },
                    { 966, "MI", 111, 1, "Milano", true },
                    { 967, "MO", 111, 1, "Modena", true },
                    { 968, "MB", 111, 1, "Monza e della Brianza", true },
                    { 969, "NA", 111, 1, "Napoli", true },
                    { 970, "NO", 111, 1, "Novara", true },
                    { 971, "NU", 111, 1, "Nuoro", true },
                    { 972, "OG", 111, 1, "Ogliastra", true },
                    { 973, "OT", 111, 1, "Olbia-Tempio", true },
                    { 974, "OR", 111, 1, "Oristano", true },
                    { 975, "PD", 111, 1, "Padova", true },
                    { 976, "PA", 111, 1, "Palermo", true },
                    { 977, "PR", 111, 1, "Parma", true },
                    { 978, "PV", 111, 1, "Pavia", true },
                    { 979, "PG", 111, 1, "Perugia", true },
                    { 980, "PU", 111, 1, "Pesaro e Urbino", true },
                    { 981, "PE", 111, 1, "Pescara", true },
                    { 982, "PC", 111, 1, "Piacenza", true },
                    { 983, "PI", 111, 1, "Pisa", true },
                    { 984, "PT", 111, 1, "Pistoia", true },
                    { 985, "PN", 111, 1, "Pordenone", true },
                    { 986, "PZ", 111, 1, "Potenza", true },
                    { 987, "PO", 111, 1, "Prato", true },
                    { 988, "RG", 111, 1, "Ragusa", true },
                    { 989, "RA", 111, 1, "Ravenna", true },
                    { 990, "RC", 111, 1, "Reggio Calabria", true },
                    { 991, "RE", 111, 1, "Reggio Emilia", true },
                    { 992, "RI", 111, 1, "Rieti", true },
                    { 993, "RN", 111, 1, "Rimini", true },
                    { 994, "RM", 111, 1, "Roma", true },
                    { 995, "RO", 111, 1, "Rovigo", true },
                    { 996, "SA", 111, 1, "Salerno", true },
                    { 997, "SS", 111, 1, "Sassari", true },
                    { 998, "SV", 111, 1, "Savona", true },
                    { 999, "SI", 111, 1, "Siena", true },
                    { 1000, "SR", 111, 1, "Siracusa", true },
                    { 1001, "SO", 111, 1, "Sondrio", true },
                    { 1002, "TA", 111, 1, "Taranto", true },
                    { 1003, "TE", 111, 1, "Teramo", true },
                    { 1004, "TR", 111, 1, "Terni", true },
                    { 1005, "TO", 111, 1, "Torino", true },
                    { 1006, "TP", 111, 1, "Trapani", true },
                    { 1007, "TN", 111, 1, "Trento", true },
                    { 1008, "TV", 111, 1, "Treviso", true },
                    { 1009, "TS", 111, 1, "Trieste", true },
                    { 1010, "UD", 111, 1, "Udine", true },
                    { 1011, "VA", 111, 1, "Varese", true },
                    { 1012, "VE", 111, 1, "Venezia", true },
                    { 1013, "VB", 111, 1, "Verbano-Cusio-Ossola", true },
                    { 1014, "VC", 111, 1, "Vercelli", true },
                    { 1015, "VR", 111, 1, "Verona", true },
                    { 1016, "VV", 111, 1, "Vibo Valentia", true },
                    { 1017, "VI", 111, 1, "Vicenza", true },
                    { 1018, "VT", 111, 1, "Viterbo", true },
                    { 1019, "", 121, 0, "Al Asimah", true },
                    { 1020, "", 121, 0, "Hawalli", true },
                    { 1021, "", 121, 0, "Al Farwaniya", true },
                    { 1022, "", 121, 0, "Mubarak Al Kabeer", true },
                    { 1023, "", 121, 0, "Al Ahmadi", true },
                    { 1024, "", 121, 0, "Al Jahraa", true },
                    { 1025, "", 130, 0, "Alytaus apskritis", true },
                    { 1026, "", 130, 0, "Kauno apskritis", true },
                    { 1027, "", 130, 0, "Klaipėdos apskritis", true },
                    { 1028, "", 130, 0, "Marijampolės apskritis", true },
                    { 1029, "", 130, 0, "Panevėžio apskritis", true },
                    { 1030, "", 130, 0, "Šiaulių apskritis", true },
                    { 1031, "", 130, 0, "Tauragės apskritis", true },
                    { 1032, "", 130, 0, "Telšių apskritis", true },
                    { 1033, "", 130, 0, "Utenos apskritis", true },
                    { 1034, "", 130, 0, "Vilniaus apskritis", true },
                    { 1035, "", 131, 0, "Capellen", true },
                    { 1036, "", 131, 0, "Clerveaux", true },
                    { 1037, "", 131, 0, "Diekirch", true },
                    { 1038, "", 131, 0, "Echternach", true },
                    { 1039, "", 131, 0, "Esch-Sur-Azette", true },
                    { 1040, "", 131, 0, "Greven-Macher", true },
                    { 1041, "", 131, 0, "Luxembourg Campagne", true },
                    { 1042, "", 131, 0, "Mersch", true },
                    { 1043, "", 131, 0, "Redange", true },
                    { 1044, "", 131, 0, "Remich", true },
                    { 1045, "", 131, 0, "Vianden", true },
                    { 1046, "", 131, 0, "Wiltz", true },
                    { 1047, "", 152, 0, "Agadir", true },
                    { 1048, "", 152, 0, "Beni mellal", true },
                    { 1049, "", 152, 0, "Berkane", true },
                    { 1050, "", 152, 0, "Casablanca", true },
                    { 1051, "", 152, 0, "El jadida", true },
                    { 1052, "", 152, 0, "Fes", true },
                    { 1053, "", 152, 0, "Inezgane", true },
                    { 1054, "", 152, 0, "Kenitra", true },
                    { 1055, "", 152, 0, "Khemisset", true },
                    { 1056, "", 152, 0, "Khenifra", true },
                    { 1057, "", 152, 0, "Khouribga", true },
                    { 1058, "", 152, 0, "Laayoune", true },
                    { 1059, "", 152, 0, "Marrakech", true },
                    { 1060, "", 152, 0, "Meknes", true },
                    { 1061, "", 152, 0, "Mohammedia", true },
                    { 1062, "", 152, 0, "Nador", true },
                    { 1063, "", 152, 0, "Oujda", true },
                    { 1064, "", 152, 0, "Rabat", true },
                    { 1065, "", 152, 0, "Safi", true },
                    { 1066, "", 152, 0, "Sale", true },
                    { 1067, "", 152, 0, "Tanger", true },
                    { 1068, "", 152, 0, "Taza", true },
                    { 1069, "", 152, 0, "Temara", true },
                    { 1070, "", 152, 0, "Tetouan", true },
                    { 1071, "БН", 149, 1, "Улаанбаатар хот - Багануур дүүрэг", true },
                    { 1072, "БХ", 149, 1, "Улаанбаатар хот - Багахангай дүүрэг", true },
                    { 1073, "БГ", 149, 1, "Улаанбаатар хот - Баянгол дүүрэг", true },
                    { 1074, "БЗ", 149, 1, "Улаанбаатар хот - Баянзүрх дүүрэг", true },
                    { 1075, "НА", 149, 1, "Улаанбаатар хот - Налайх дүүрэг", true },
                    { 1076, "СХ", 149, 1, "Улаанбаатар хот - Сонгино хайрхан дүүрэг", true },
                    { 1077, "СБ", 149, 1, "Улаанбаатар хот - Сүхбаатар дүүрэг", true },
                    { 1078, "ХУ", 149, 1, "Улаанбаатар хот - Хан-Уул дүүрэг", true },
                    { 1079, "ЧИ", 149, 1, "Улаанбаатар хот - Чингэлтэй дүүрэг", true },
                    { 1080, "АР", 149, 2, "Архангай аймаг", true },
                    { 1081, "БӨ", 149, 2, "Баян-Өлгий аймаг", true },
                    { 1082, "БХ", 149, 2, "Баянхонгор аймаг", true },
                    { 1083, "БУ", 149, 2, "Булган аймаг", true },
                    { 1084, "ӨВ", 149, 2, "Өвөрхангай аймаг", true },
                    { 1085, "ГА", 149, 2, "Говь-Алтай аймаг", true },
                    { 1086, "ГС", 149, 2, "Говьсүмбэр аймаг", true },
                    { 1087, "ДА", 149, 2, "Дархан-Уул аймаг", true },
                    { 1088, "ДГ", 149, 2, "Дорноговь аймаг", true },
                    { 1089, "ДО", 149, 2, "Дорнод аймаг", true },
                    { 1090, "ДУ", 149, 2, "Дундговь аймаг", true },
                    { 1091, "ЗА", 149, 2, "Завхан аймаг", true },
                    { 1092, "ӨМ", 149, 2, "Өмнөговь аймаг", true },
                    { 1093, "ОР", 149, 2, "Орхон аймаг", true },
                    { 1094, "СҮ", 149, 2, "Сүхбаатар аймаг", true },
                    { 1095, "СЭ", 149, 2, "Сэлэнгэ аймаг", true },
                    { 1096, "ТӨ", 149, 2, "Төв аймаг", true },
                    { 1097, "УВ", 149, 2, "Увс аймаг", true },
                    { 1098, "ХӨ", 149, 2, "Хөвсгөл аймаг", true },
                    { 1099, "ХО", 149, 2, "Ховд аймаг", true },
                    { 1100, "ХЭ", 149, 2, "Хэнтий аймаг", true },
                    { 1101, "", 145, 0, "Aguascalientes", true },
                    { 1102, "", 145, 0, "Baja California", true },
                    { 1103, "", 145, 0, "Baja California Sur", true },
                    { 1104, "", 145, 0, "Campeche", true },
                    { 1105, "", 145, 0, "Chiapas", true },
                    { 1106, "", 145, 0, "Chihuahua", true },
                    { 1107, "", 145, 0, "Coahuila", true },
                    { 1108, "", 145, 0, "Colima", true },
                    { 1109, "", 145, 0, "Distrito Federal", true },
                    { 1110, "", 145, 0, "Durango", true },
                    { 1111, "", 145, 0, "Estado de México", true },
                    { 1112, "", 145, 0, "Guanajuato", true },
                    { 1113, "", 145, 0, "Guerrero", true },
                    { 1114, "", 145, 0, "Hidalgo", true },
                    { 1115, "", 145, 0, "Jalisco", true },
                    { 1116, "", 145, 0, "Michoacán", true },
                    { 1117, "", 145, 0, "Morelos", true },
                    { 1118, "", 145, 0, "Nayarit", true },
                    { 1119, "", 145, 0, "Nuevo León", true },
                    { 1120, "", 145, 0, "Oaxaca", true },
                    { 1121, "", 145, 0, "Puebla", true },
                    { 1122, "", 145, 0, "Querétaro", true },
                    { 1123, "", 145, 0, "Quintana Roo", true },
                    { 1124, "", 145, 0, "San Luis Potosí", true },
                    { 1125, "", 145, 0, "Sinaloa", true },
                    { 1126, "", 145, 0, "Sonora", true },
                    { 1127, "", 145, 0, "Tabasco", true },
                    { 1128, "", 145, 0, "Tamaulipas", true },
                    { 1129, "", 145, 0, "Tlaxcala", true },
                    { 1130, "", 145, 0, "Veracruz", true },
                    { 1131, "", 145, 0, "Yucatán", true },
                    { 1132, "", 145, 0, "Zacatecas", true },
                    { 1133, "JHR", 136, 0, "Johor", true },
                    { 1134, "KDH", 136, 0, "Kedah", true },
                    { 1135, "KTN", 136, 0, "Kelantan", true },
                    { 1136, "KUL", 136, 0, "Kuala Lumpur", true },
                    { 1137, "LBN", 136, 0, "Labuan", true },
                    { 1138, "MLK", 136, 0, "Melaka", true },
                    { 1139, "NSN", 136, 0, "Negeri Sembilan", true },
                    { 1140, "PHG", 136, 0, "Pahang", true },
                    { 1141, "PRK", 136, 0, "Perak", true },
                    { 1142, "PLS", 136, 0, "Perlis", true },
                    { 1143, "PNG", 136, 0, "Pulau Pinang", true },
                    { 1144, "PJY", 136, 0, "Putrajaya", true },
                    { 1145, "SBH", 136, 0, "Sabah", true },
                    { 1146, "SWK", 136, 0, "Sarawak", true },
                    { 1147, "SGR", 136, 0, "Selangor", true },
                    { 1148, "TRG", 136, 0, "Terengganu", true },
                    { 1149, "", 163, 0, "Abia", true },
                    { 1150, "", 163, 0, "Adamawa", true },
                    { 1151, "", 163, 0, "Akwa Ibom", true },
                    { 1152, "", 163, 0, "Anambra", true },
                    { 1153, "", 163, 0, "Bauchi", true },
                    { 1154, "", 163, 0, "Bayelsa", true },
                    { 1155, "", 163, 0, "Benue", true },
                    { 1156, "", 163, 0, "Borno", true },
                    { 1157, "", 163, 0, "Cross River", true },
                    { 1158, "", 163, 0, "Delta", true },
                    { 1159, "", 163, 0, "Ebonyi", true },
                    { 1160, "", 163, 0, "Edo", true },
                    { 1161, "", 163, 0, "Enugu", true },
                    { 1162, "", 163, 0, "Ekiti", true },
                    { 1163, "", 163, 0, "FCT", true },
                    { 1164, "", 163, 0, "Gombe", true },
                    { 1165, "", 163, 0, "Imo", true },
                    { 1166, "", 163, 0, "Jigawa", true },
                    { 1167, "", 163, 0, "Kaduna", true },
                    { 1168, "", 163, 0, "Kano", true },
                    { 1169, "", 163, 0, "Katsina", true },
                    { 1170, "", 163, 0, "Kebbi", true },
                    { 1171, "", 163, 0, "Kogi", true },
                    { 1172, "", 163, 0, "Kwara", true },
                    { 1173, "", 163, 0, "Lagos", true },
                    { 1174, "", 163, 0, "Nasarawa", true },
                    { 1175, "", 163, 0, "Niger", true },
                    { 1176, "", 163, 0, "Ogun", true },
                    { 1177, "", 163, 0, "Ondo", true },
                    { 1178, "", 163, 0, "Osun", true },
                    { 1179, "", 163, 0, "Oyo", true },
                    { 1180, "", 163, 0, "Plateau", true },
                    { 1181, "", 163, 0, "Rivers", true },
                    { 1182, "", 163, 0, "Sokoto", true },
                    { 1183, "", 163, 0, "Taraba", true },
                    { 1184, "", 163, 0, "Yobe", true },
                    { 1185, "", 163, 0, "Zamafara", true },
                    { 1186, "DR", 158, 0, "Drenthe", true },
                    { 1187, "FL", 158, 0, "Flevoland", true },
                    { 1188, "FR", 158, 0, "Friesland", true },
                    { 1189, "GD", 158, 0, "Gelderland", true },
                    { 1190, "GR", 158, 0, "Groningen", true },
                    { 1191, "LB", 158, 0, "Limburg", true },
                    { 1192, "NB", 158, 0, "Noord-Brabant", true },
                    { 1193, "NH", 158, 0, "Noord-Holland", true },
                    { 1194, "OV", 158, 0, "Overijssel", true },
                    { 1195, "UT", 158, 0, "Utrecht", true },
                    { 1196, "ZL", 158, 0, "Zeeland", true },
                    { 1197, "ZH", 158, 0, "Zuid-Holland", true },
                    { 1198, "01", 167, 1, "Østfold", true },
                    { 1199, "02", 167, 2, "Akershus", true },
                    { 1200, "03", 167, 3, "Oslo", true },
                    { 1201, "04", 167, 4, "Hedmark", true },
                    { 1202, "05", 167, 5, "Oppland", true },
                    { 1203, "06", 167, 6, "Buskerud", true },
                    { 1204, "07", 167, 7, "Vestfold", true },
                    { 1205, "08", 167, 8, "Telemark", true },
                    { 1206, "09", 167, 9, "Aust-Agder", true },
                    { 1207, "10", 167, 10, "Vest-Agder", true },
                    { 1208, "11", 167, 11, "Rogaland", true },
                    { 1209, "12", 167, 12, "Hordaland", true },
                    { 1210, "14", 167, 14, "Sogn og Fjordane", true },
                    { 1211, "15", 167, 15, "Møre og Romsdal", true },
                    { 1212, "16", 167, 16, "Sør-Trøndelag", true },
                    { 1213, "17", 167, 17, "Nord-Trøndelag", true },
                    { 1214, "18", 167, 18, "Nordland", true },
                    { 1215, "19", 167, 19, "Troms", true },
                    { 1216, "20", 167, 20, "Finnmark", true },
                    { 1217, "21", 167, 21, "Svalbard", true },
                    { 1218, "22", 167, 22, "Jan Mayen", true },
                    { 1219, "", 157, 1, "Province No. 1", true },
                    { 1220, "", 157, 2, "Province No. 2", true },
                    { 1221, "", 157, 3, "Province No. 3", true },
                    { 1222, "", 157, 4, "Gandaki Pradesh", true },
                    { 1223, "", 157, 5, "Province No. 5", true },
                    { 1224, "", 157, 6, "Karnali Pradesh", true },
                    { 1225, "", 157, 7, "Sudurpashchim Pradesh", true },
                    { 1226, "", 160, 0, "Northland", true },
                    { 1227, "", 160, 0, "Auckland", true },
                    { 1228, "", 160, 0, "Waikato", true },
                    { 1229, "", 160, 0, "Waitomo", true },
                    { 1230, "", 160, 0, "Bay of Plenty", true },
                    { 1231, "", 160, 0, "Taupo", true },
                    { 1232, "", 160, 0, "King Country", true },
                    { 1233, "", 160, 0, "Taranaki", true },
                    { 1234, "", 160, 0, "Wanganui", true },
                    { 1235, "", 160, 0, "Manawatu", true },
                    { 1236, "", 160, 0, "Horowhenua", true },
                    { 1237, "", 160, 0, "Kapiti", true },
                    { 1238, "", 160, 0, "Gisborne", true },
                    { 1239, "", 160, 0, "Hawkes Bay", true },
                    { 1240, "", 160, 0, "Wairarapa", true },
                    { 1241, "", 160, 0, "Wellington", true },
                    { 1242, "", 160, 0, "Nelson", true },
                    { 1243, "", 160, 0, "Marlborough", true },
                    { 1244, "", 160, 0, "Buller", true },
                    { 1245, "", 160, 0, "West Coast", true },
                    { 1246, "", 160, 0, "Canterbury", true },
                    { 1247, "", 160, 0, "Otago", true },
                    { 1248, "", 160, 0, "Southland", true },
                    { 1249, "", 176, 1, "Abra", true },
                    { 1250, "", 176, 2, "Agusan del Norte", true },
                    { 1251, "", 176, 3, "Agusan del Sur", true },
                    { 1252, "", 176, 4, "Aklan", true },
                    { 1253, "", 176, 5, "Albay", true },
                    { 1254, "", 176, 6, "Antique", true },
                    { 1255, "", 176, 7, "Apayao", true },
                    { 1256, "", 176, 8, "Aurora", true },
                    { 1257, "", 176, 9, "Basilan", true },
                    { 1258, "", 176, 10, "Bataan", true },
                    { 1259, "", 176, 11, "Batanes", true },
                    { 1260, "", 176, 12, "Batangas", true },
                    { 1261, "", 176, 13, "Benguet", true },
                    { 1262, "", 176, 14, "Biliran", true },
                    { 1263, "", 176, 15, "Bohol", true },
                    { 1264, "", 176, 16, "Bukidnon", true },
                    { 1265, "", 176, 17, "Bulacan", true },
                    { 1266, "", 176, 18, "Cagayan", true },
                    { 1267, "", 176, 19, "Camarines Norte", true },
                    { 1268, "", 176, 20, "Camarines Sur", true },
                    { 1269, "", 176, 21, "Camiguin", true },
                    { 1270, "", 176, 22, "Capiz", true },
                    { 1271, "", 176, 23, "Catanduanes", true },
                    { 1272, "", 176, 24, "Cavite", true },
                    { 1273, "", 176, 25, "Cebu", true },
                    { 1274, "", 176, 26, "Compostela Valley", true },
                    { 1275, "", 176, 27, "Cotabato", true },
                    { 1276, "", 176, 28, "Davao del Norte", true },
                    { 1277, "", 176, 29, "Davao del Sur", true },
                    { 1278, "", 176, 30, "Davao Occidental", true },
                    { 1279, "", 176, 31, "Davao Oriental", true },
                    { 1280, "", 176, 32, "Dinagat Islands", true },
                    { 1281, "", 176, 33, "Eastern Samar", true },
                    { 1282, "", 176, 34, "Guimaras", true },
                    { 1283, "", 176, 35, "Ifugao", true },
                    { 1284, "", 176, 36, "Ilocos Norte", true },
                    { 1285, "", 176, 37, "Ilocos Sur", true },
                    { 1286, "", 176, 38, "Iloilo", true },
                    { 1287, "", 176, 39, "Isabela", true },
                    { 1288, "", 176, 40, "Kalinga", true },
                    { 1289, "", 176, 41, "La Union", true },
                    { 1290, "", 176, 42, "Laguna", true },
                    { 1291, "", 176, 43, "Lanao del Norte", true },
                    { 1292, "", 176, 44, "Lanao del Sur", true },
                    { 1293, "", 176, 45, "Leyte", true },
                    { 1294, "", 176, 46, "Maguindanao", true },
                    { 1295, "", 176, 47, "Marinduque", true },
                    { 1296, "", 176, 48, "Masbate", true },
                    { 1297, "", 176, 49, "Misamis Occidental", true },
                    { 1298, "", 176, 50, "Misamis Oriental", true },
                    { 1299, "", 176, 51, "Mountain Province", true },
                    { 1300, "", 176, 52, "Negros Occidental", true },
                    { 1301, "", 176, 53, "Negros Oriental", true },
                    { 1302, "", 176, 54, "Northern Samar", true },
                    { 1303, "", 176, 55, "Nueva Ecija", true },
                    { 1304, "", 176, 56, "Nueva Vizcaya", true },
                    { 1305, "", 176, 57, "Occidental Mindoro", true },
                    { 1306, "", 176, 58, "Oriental Mindoro", true },
                    { 1307, "", 176, 59, "Palawan", true },
                    { 1308, "", 176, 60, "Pampanga", true },
                    { 1309, "", 176, 61, "Pangasinan", true },
                    { 1310, "", 176, 62, "Quezon", true },
                    { 1311, "", 176, 63, "Quirino", true },
                    { 1312, "", 176, 64, "Rizal", true },
                    { 1313, "", 176, 65, "Romblon", true },
                    { 1314, "", 176, 66, "Samar", true },
                    { 1315, "", 176, 67, "Sarangani", true },
                    { 1316, "", 176, 68, "Siquijor", true },
                    { 1317, "", 176, 69, "Sorsogon", true },
                    { 1318, "", 176, 70, "South Cotabato", true },
                    { 1319, "", 176, 71, "Southern Leyte", true },
                    { 1320, "", 176, 72, "Sultan Kudarat", true },
                    { 1321, "", 176, 73, "Sulu", true },
                    { 1322, "", 176, 74, "Surigao del Norte", true },
                    { 1323, "", 176, 75, "Surigao del Sur", true },
                    { 1324, "", 176, 76, "Tarlac", true },
                    { 1325, "", 176, 77, "Tawi-Tawi", true },
                    { 1326, "", 176, 78, "Zambales", true },
                    { 1327, "", 176, 79, "Zamboanga del Norte", true },
                    { 1328, "", 176, 80, "Zamboanga del Sur", true },
                    { 1329, "", 176, 81, "Zamboanga Sibugay", true },
                    { 1330, "", 176, 82, "Metro Manila", true },
                    { 1331, "", 169, 0, "Azad Kashmir", true },
                    { 1332, "", 169, 0, "Balochistan", true },
                    { 1333, "", 169, 0, "Capital Territory", true },
                    { 1334, "", 169, 0, "Gilgit–Baltistan", true },
                    { 1335, "", 169, 0, "Khyber Pakhtunkhwa", true },
                    { 1336, "", 169, 0, "Punjab", true },
                    { 1337, "", 169, 0, "Sindh", true },
                    { 1338, "", 169, 0, "Tribal Areas", true },
                    { 1339, "", 178, 0, "Dolnośląskie", true },
                    { 1340, "", 178, 0, "Kujawsko-pomorskie", true },
                    { 1341, "", 178, 0, "Lubelskie", true },
                    { 1342, "", 178, 0, "Lubuskie", true },
                    { 1343, "", 178, 0, "Łódzkie", true },
                    { 1344, "", 178, 0, "Małopolskie", true },
                    { 1345, "", 178, 0, "Mazowieckie", true },
                    { 1346, "", 178, 0, "Opolskie", true },
                    { 1347, "", 178, 0, "Podkarpackie", true },
                    { 1348, "", 178, 0, "Podlaskie", true },
                    { 1349, "", 178, 0, "Pomorskie", true },
                    { 1350, "", 178, 0, "Śląskie", true },
                    { 1351, "", 178, 0, "Świętokrzyskie", true },
                    { 1352, "", 178, 0, "Warmińsko-mazurskie", true },
                    { 1353, "", 178, 0, "Wielkopolskie", true },
                    { 1354, "", 178, 0, "Zachodniopomorskie", true },
                    { 1355, "01", 179, 1, "Aveiro", true },
                    { 1356, "02", 179, 2, "Beja", true },
                    { 1357, "03", 179, 3, "Braga", true },
                    { 1358, "04", 179, 4, "Bragança", true },
                    { 1359, "05", 179, 5, "Castelo Branco", true },
                    { 1360, "06", 179, 6, "Coimbra", true },
                    { 1361, "07", 179, 7, "Évora", true },
                    { 1362, "08", 179, 8, "Faro", true },
                    { 1363, "09", 179, 9, "Guarda", true },
                    { 1364, "10", 179, 10, "Leiria", true },
                    { 1365, "11", 179, 11, "Lisboa", true },
                    { 1366, "12", 179, 12, "Portalegre", true },
                    { 1367, "13", 179, 13, "Porto", true },
                    { 1368, "14", 179, 14, "Santarém", true },
                    { 1369, "15", 179, 15, "Setúbal", true },
                    { 1370, "16", 179, 16, "Viana do Castelo", true },
                    { 1371, "17", 179, 17, "Vila Real", true },
                    { 1372, "18", 179, 18, "Viseu", true },
                    { 1373, "20", 179, 19, "Região Autónoma dos Açores", true },
                    { 1374, "30", 179, 20, "Região Autónoma da Madeira", true },
                    { 1375, "AB", 183, 1, "Alba", true },
                    { 1376, "AR", 183, 2, "Arad", true },
                    { 1377, "AG", 183, 3, "Argeș", true },
                    { 1378, "BC", 183, 4, "Bacău", true },
                    { 1379, "BH", 183, 5, "Bihor", true },
                    { 1380, "BN", 183, 6, "Bistrița-Năsăud", true },
                    { 1381, "BT", 183, 7, "Botoșani", true },
                    { 1382, "BV", 183, 8, "Brașov", true },
                    { 1383, "BR", 183, 9, "Brăila", true },
                    { 1384, "B", 183, 10, "București Sector 1", true },
                    { 1385, "B", 183, 11, "București Sector 2", true },
                    { 1386, "B", 183, 12, "București Sector 3", true },
                    { 1387, "B", 183, 13, "București Sector 4", true },
                    { 1388, "B", 183, 14, "București Sector 5", true },
                    { 1389, "B", 183, 15, "București Sector 6", true },
                    { 1390, "BZ", 183, 16, "Buzău", true },
                    { 1391, "CS", 183, 17, "Caraș-Severin", true },
                    { 1392, "CL", 183, 18, "Călărași", true },
                    { 1393, "CJ", 183, 19, "Cluj", true },
                    { 1394, "CT", 183, 20, "Constanța", true },
                    { 1395, "CV", 183, 21, "Covasna", true },
                    { 1396, "DB", 183, 22, "Dâmbovița", true },
                    { 1397, "DJ", 183, 23, "Dolj", true },
                    { 1398, "GL", 183, 24, "Galați", true },
                    { 1399, "GR", 183, 25, "Giurgiu", true },
                    { 1400, "GJ", 183, 26, "Gorj", true },
                    { 1401, "HR", 183, 27, "Harghita", true },
                    { 1402, "HD", 183, 28, "Hunedoara", true },
                    { 1403, "IL", 183, 29, "Ialomița", true },
                    { 1404, "IS", 183, 30, "Iași", true },
                    { 1405, "IF", 183, 31, "Ilfov", true },
                    { 1406, "MM", 183, 32, "Maramureș", true },
                    { 1407, "MH", 183, 33, "Mehedinți", true },
                    { 1408, "MS", 183, 34, "Mureș", true },
                    { 1409, "NT", 183, 35, "Neamț", true },
                    { 1410, "OT", 183, 36, "Olt", true },
                    { 1411, "PH", 183, 37, "Prahova", true },
                    { 1412, "SM", 183, 38, "Satu Mare", true },
                    { 1413, "SJ", 183, 39, "Sălaj", true },
                    { 1414, "SB", 183, 40, "Sibiu", true },
                    { 1415, "SV", 183, 41, "Suceava", true },
                    { 1416, "TR", 183, 42, "Teleorman", true },
                    { 1417, "TM", 183, 43, "Timiș", true },
                    { 1418, "TL", 183, 44, "Tulcea", true },
                    { 1419, "VS", 183, 45, "Vaslui", true },
                    { 1420, "VL", 183, 46, "Vâlcea", true },
                    { 1421, "VN", 183, 47, "Vrancea", true },
                    { 1422, "", 198, 0, "Serbia", true },
                    { 1423, "", 198, 0, "Kosovo", true },
                    { 1424, "", 198, 0, "Vojvodina", true },
                    { 1425, "01", 184, 1, "Адыгея", true },
                    { 1426, "04", 184, 1, "Алтай", true },
                    { 1427, "22", 184, 1, "Алтайский край", true },
                    { 1428, "28", 184, 1, "Амурская область", true },
                    { 1429, "29", 184, 1, "Архангельская область", true },
                    { 1430, "30", 184, 1, "Астраханская область", true },
                    { 1431, "02", 184, 1, "Башкортостан", true },
                    { 1432, "31", 184, 1, "Белгородская область", true },
                    { 1433, "32", 184, 1, "Брянская область", true },
                    { 1434, "03", 184, 1, "Бурятия", true },
                    { 1435, "33", 184, 1, "Владимирская область", true },
                    { 1436, "34", 184, 1, "Волгоградская область", true },
                    { 1437, "35", 184, 1, "Вологодская область", true },
                    { 1438, "36", 184, 1, "Воронежская область", true },
                    { 1439, "05", 184, 1, "Дагестан", true },
                    { 1440, "79", 184, 1, "Еврейская автономная область", true },
                    { 1441, "75", 184, 1, "Забайкальский край", true },
                    { 1442, "37", 184, 1, "Ивановская область", true },
                    { 1443, "06", 184, 1, "Ингушетия", true },
                    { 1444, "38", 184, 1, "Иркутская область", true },
                    { 1445, "7", 184, 1, "Кабардино-Балкарская Республика", true },
                    { 1446, "39", 184, 1, "Калининградская область", true },
                    { 1447, "08", 184, 1, "Калмыкия", true },
                    { 1448, "40", 184, 1, "Калужская область", true },
                    { 1449, "41", 184, 1, "Камчатский край", true },
                    { 1450, "09", 184, 1, "Карачаево-Черкесская Республика", true },
                    { 1451, "10", 184, 1, "Карелия", true },
                    { 1452, "42", 184, 1, "Кемеровская область", true },
                    { 1453, "43", 184, 1, "Кировская область", true },
                    { 1454, "11", 184, 1, "Коми", true },
                    { 1455, "44", 184, 1, "Костромская область", true },
                    { 1456, "23", 184, 1, "Краснодарский край", true },
                    { 1457, "24", 184, 1, "Красноярский край", true },
                    { 1458, "45", 184, 1, "Курганская область", true },
                    { 1459, "46", 184, 1, "Курская область", true },
                    { 1460, "47", 184, 1, "Ленинградская область", true },
                    { 1461, "48", 184, 1, "Липецкая область", true },
                    { 1462, "49", 184, 1, "Магаданская область", true },
                    { 1463, "12", 184, 1, "Марий Эл", true },
                    { 1464, "13", 184, 1, "Мордовия", true },
                    { 1465, "77", 184, 1, "Москва", true },
                    { 1466, "50", 184, 1, "Московская область", true },
                    { 1467, "51", 184, 1, "Мурманская область", true },
                    { 1468, "83", 184, 1, "Ненецкий автономный округ", true },
                    { 1469, "52", 184, 1, "Нижегородская область", true },
                    { 1470, "53", 184, 1, "Новгородская область", true },
                    { 1471, "54", 184, 1, "Новосибирская область", true },
                    { 1472, "55", 184, 1, "Омская область", true },
                    { 1473, "56", 184, 1, "Оренбургская область", true },
                    { 1474, "57", 184, 1, "Орловская область", true },
                    { 1475, "58", 184, 1, "Пензенская область", true },
                    { 1476, "59", 184, 1, "Пермский край", true },
                    { 1477, "25", 184, 1, "Приморский край", true },
                    { 1478, "60", 184, 1, "Псковская область", true },
                    { 1479, "61", 184, 1, "Ростовская область", true },
                    { 1480, "62", 184, 1, "Рязанская область", true },
                    { 1481, "63", 184, 1, "Самарская область", true },
                    { 1482, "78", 184, 1, "Санкт-Петербург", true },
                    { 1483, "64", 184, 1, "Саратовская область", true },
                    { 1484, "14", 184, 1, "Саха (Якутия)", true },
                    { 1485, "65", 184, 1, "Сахалинская область", true },
                    { 1486, "66", 184, 1, "Свердловская область", true },
                    { 1487, "92", 184, 1, "Севастополь", true },
                    { 1488, "15", 184, 1, "Северная Осетия-Алания", true },
                    { 1489, "67", 184, 1, "Смоленская область", true },
                    { 1490, "26", 184, 1, "Ставропольский край", true },
                    { 1491, "68", 184, 1, "Тамбовская область", true },
                    { 1492, "16", 184, 1, "Татарстан", true },
                    { 1493, "69", 184, 1, "Тверская область", true },
                    { 1494, "70", 184, 1, "Томская область", true },
                    { 1495, "71", 184, 1, "Тульская область", true },
                    { 1496, "17", 184, 1, "Тыва", true },
                    { 1497, "72", 184, 1, "Тюменская область", true },
                    { 1498, "18", 184, 1, "Удмуртская Республика", true },
                    { 1499, "73", 184, 1, "Ульяновская область", true },
                    { 1500, "27", 184, 1, "Хабаровский край", true },
                    { 1501, "19", 184, 1, "Хакасия", true },
                    { 1502, "86", 184, 1, "Ханты-Мансийский автономный округ-Югра", true },
                    { 1503, "74", 184, 1, "Челябинская область", true },
                    { 1504, "95", 184, 1, "Чеченская Республика", true },
                    { 1505, "21", 184, 1, "Чувашская Республика", true },
                    { 1506, "87", 184, 1, "Чукотский автономный округ", true },
                    { 1507, "89", 184, 1, "Ямало-Ненецкий автономный округ", true },
                    { 1508, "76", 184, 1, "Ярославская область", true },
                    { 1509, "", 196, 0, "Eastern Cape", true },
                    { 1510, "", 196, 1, "Al Bahah", true },
                    { 1511, "", 196, 2, "Al Jawf", true },
                    { 1512, "", 196, 3, "Al Madinah", true },
                    { 1513, "", 196, 4, "Al Qasim", true },
                    { 1514, "", 196, 5, "Al Riyadh", true },
                    { 1515, "", 196, 6, "Asir", true },
                    { 1516, "", 196, 7, "Eastern Province", true },
                    { 1517, "", 196, 8, "Ha'il", true },
                    { 1518, "", 196, 9, "Jizan", true },
                    { 1519, "", 196, 10, "Makkah", true },
                    { 1520, "", 196, 11, "Najran", true },
                    { 1521, "", 196, 12, "Northern Borders", true },
                    { 1522, "", 196, 13, "Tabuk", true },
                    { 1523, "01", 215, 1, "Stockholms län", true },
                    { 1524, "03", 215, 3, "Uppsala län", true },
                    { 1525, "04", 215, 4, "Södermanlands län", true },
                    { 1526, "05", 215, 5, "Östergötlands län", true },
                    { 1527, "06", 215, 6, "Jönköpings län", true },
                    { 1528, "07", 215, 7, "Kronobergs län", true },
                    { 1529, "08", 215, 8, "Kalmar län", true },
                    { 1530, "09", 215, 9, "Gotlands län", true },
                    { 1531, "11", 215, 11, "Blekinge län", true },
                    { 1532, "12", 215, 12, "Skåne län", true },
                    { 1533, "14", 215, 14, "Hallands län", true },
                    { 1534, "15", 215, 15, "Västra Götalands län", true },
                    { 1535, "17", 215, 17, "Värmlands län", true },
                    { 1536, "18", 215, 18, "Örebro län", true },
                    { 1537, "19", 215, 19, "Västmanlands län", true },
                    { 1538, "20", 215, 20, "Dalarnas län", true },
                    { 1539, "21", 215, 21, "Gävleborgs län", true },
                    { 1540, "22", 215, 22, "Jämtlands län", true },
                    { 1541, "23", 215, 23, "Västernorrlands län", true },
                    { 1542, "24", 215, 24, "Västerbottens län", true },
                    { 1543, "25", 215, 25, "Norbottens län", true },
                    { 1544, "", 204, 0, "Pomurska", true },
                    { 1545, "", 204, 0, "Podravska", true },
                    { 1546, "", 204, 0, "Koroška", true },
                    { 1547, "", 204, 0, "Savinjska", true },
                    { 1548, "", 204, 0, "Zasavska", true },
                    { 1549, "", 204, 0, "Posavska", true },
                    { 1550, "", 204, 0, "Jugovzhodna Slovenija", true },
                    { 1551, "", 204, 0, "Primorsko-notranjska", true },
                    { 1552, "", 204, 0, "Osrednjeslovenska", true },
                    { 1553, "", 204, 0, "Gorenjska", true },
                    { 1554, "", 204, 0, "Goriška", true },
                    { 1555, "", 204, 0, "Obalno-kraška", true },
                    { 1556, "", 203, 0, "Bratislavský kraj", true },
                    { 1557, "", 203, 0, "Trnavský kraj", true },
                    { 1558, "", 203, 0, "Nitrianský kraj", true },
                    { 1559, "", 203, 0, "Trenčianský kraj", true },
                    { 1560, "", 203, 0, "Žilinský kraj", true },
                    { 1561, "", 203, 0, "Banskobystrický kraj", true },
                    { 1562, "", 203, 0, "Košický kraj", true },
                    { 1563, "", 203, 0, "Prešovský kraj", true },
                    { 1564, "", 228, 0, "Adana", true },
                    { 1565, "", 228, 0, "Adıyaman", true },
                    { 1566, "", 228, 0, "Afyonkarahisar", true },
                    { 1567, "", 228, 0, "Ağrı", true },
                    { 1568, "", 228, 0, "Aksaray", true },
                    { 1569, "", 228, 0, "Amasya", true },
                    { 1570, "", 228, 0, "Ankara", true },
                    { 1571, "", 228, 0, "Antalya", true },
                    { 1572, "", 228, 0, "Ardahan", true },
                    { 1573, "", 228, 0, "Artvin", true },
                    { 1574, "", 228, 0, "Aydın", true },
                    { 1575, "", 228, 0, "Balıkesir", true },
                    { 1576, "", 228, 0, "Bartın", true },
                    { 1577, "", 228, 0, "Batman", true },
                    { 1578, "", 228, 0, "Bayburt", true },
                    { 1579, "", 228, 0, "Bilecik", true },
                    { 1580, "", 228, 0, "Bingöl", true },
                    { 1581, "", 228, 0, "Bitlis", true },
                    { 1582, "", 228, 0, "Bolu", true },
                    { 1583, "", 228, 0, "Burdur", true },
                    { 1584, "", 228, 0, "Bursa", true },
                    { 1585, "", 228, 0, "Çanakkale", true },
                    { 1586, "", 228, 0, "Çankırı", true },
                    { 1587, "", 228, 0, "Çorum", true },
                    { 1588, "", 228, 0, "Denizli", true },
                    { 1589, "", 228, 0, "Diyarbakır", true },
                    { 1590, "", 228, 0, "Düzce", true },
                    { 1591, "", 228, 0, "Edirne", true },
                    { 1592, "", 228, 0, "Elazığ", true },
                    { 1593, "", 228, 0, "Erzincan", true },
                    { 1594, "", 228, 0, "Erzurum", true },
                    { 1595, "", 228, 0, "Eskişehir", true },
                    { 1596, "", 228, 0, "Gaziantep", true },
                    { 1597, "", 228, 0, "Giresun", true },
                    { 1598, "", 228, 0, "Gümüşhane", true },
                    { 1599, "", 228, 0, "Hakkari", true },
                    { 1600, "", 228, 0, "Hatay", true },
                    { 1601, "", 228, 0, "Iğdır", true },
                    { 1602, "", 228, 0, "Isparta", true },
                    { 1603, "", 228, 0, "İstanbul", true },
                    { 1604, "", 228, 0, "İzmir", true },
                    { 1605, "", 228, 0, "Kahramanmaraş", true },
                    { 1606, "", 228, 0, "Karabük", true },
                    { 1607, "", 228, 0, "Karaman", true },
                    { 1608, "", 228, 0, "Kars", true },
                    { 1609, "", 228, 0, "Kastamonu", true },
                    { 1610, "", 228, 0, "Kayseri", true },
                    { 1611, "", 228, 0, "Kırıkkale", true },
                    { 1612, "", 228, 0, "Kırklareli", true },
                    { 1613, "", 228, 0, "Kırşehir", true },
                    { 1614, "", 228, 0, "Kilis", true },
                    { 1615, "", 228, 0, "Kocaeli", true },
                    { 1616, "", 228, 0, "Konya", true },
                    { 1617, "", 228, 0, "Kütahya", true },
                    { 1618, "", 228, 0, "Malatya", true },
                    { 1619, "", 228, 0, "Manisa", true },
                    { 1620, "", 228, 0, "Mardin", true },
                    { 1621, "", 228, 0, "Mersin", true },
                    { 1622, "", 228, 0, "Muğla", true },
                    { 1623, "", 228, 0, "Muş", true },
                    { 1624, "", 228, 0, "Nevşehir", true },
                    { 1625, "", 228, 0, "Niğde", true },
                    { 1626, "", 228, 0, "Ordu", true },
                    { 1627, "", 228, 0, "Osmaniye", true },
                    { 1628, "", 228, 0, "Rize", true },
                    { 1629, "", 228, 0, "Sakarya", true },
                    { 1630, "", 228, 0, "Samsun", true },
                    { 1631, "", 228, 0, "Siirt", true },
                    { 1632, "", 228, 0, "Sinop", true },
                    { 1633, "", 228, 0, "Sivas", true },
                    { 1634, "", 228, 0, "Şanlıurfa", true },
                    { 1635, "", 228, 0, "Şırnak", true },
                    { 1636, "", 228, 0, "Tekirdağ", true },
                    { 1637, "", 228, 0, "Tokat", true },
                    { 1638, "", 228, 0, "Trabzon", true },
                    { 1639, "", 228, 0, "Tunceli", true },
                    { 1640, "", 228, 0, "Uşak", true },
                    { 1641, "", 228, 0, "Van", true },
                    { 1642, "", 228, 0, "Yalova", true },
                    { 1643, "", 228, 0, "Yozgat", true },
                    { 1644, "", 228, 0, "Zonguldak", true },
                    { 1645, "Вінн. обл.", 233, 2, "Вінницька область", true },
                    { 1646, "Волин. обл.", 233, 3, "Волинська область", true },
                    { 1647, "Дніпроп. обл.", 233, 4, "Дніпропетровська область", true },
                    { 1648, "Донец. обл.", 233, 5, "Донецька область", true },
                    { 1649, "Житом. обл.", 233, 6, "Житомирська область", true },
                    { 1650, "Закарп. обл.", 233, 7, "Закарпатська область", true },
                    { 1651, "Запоріз. обл.", 233, 8, "Запорізька область", true },
                    { 1652, "Івано-Фр. обл.", 233, 9, "Івано-Франківська область", true },
                    { 1653, "Київ. обл.", 233, 10, "Київська область", true },
                    { 1654, "Кіровогр. обл.", 233, 11, "Кіровоградська область", true },
                    { 1655, "Луган. обл.", 233, 12, "Луганська область", true },
                    { 1656, "Львів. обл.", 233, 13, "Львівська область", true },
                    { 1657, "Микол. обл.", 233, 14, "Миколаївська область", true },
                    { 1658, "Одес. обл.", 233, 15, "Одеська область", true },
                    { 1659, "Полтав. обл.", 233, 16, "Полтавська область", true },
                    { 1660, "Рівн. обл.", 233, 17, "Рівненська область", true },
                    { 1661, "Сумськ. обл.", 233, 18, "Сумська область", true },
                    { 1662, "Терноп. обл.", 233, 19, "Тернопільська область", true },
                    { 1663, "Харк. обл.", 233, 20, "Харківська область", true },
                    { 1664, "Херсон. обл.", 233, 20, "Херсонська область", true },
                    { 1665, "Хмельн. обл.", 233, 21, "Хмельницька область", true },
                    { 1666, "Черкас. обл.", 233, 22, "Черкаська область", true },
                    { 1667, "Чернів. обл.", 233, 23, "Чернівецька область", true },
                    { 1668, "Черніг. обл.", 233, 24, "Чернігівська область", true },
                    { 1669, "AA", 237, 1, "AA (Armed Forces Americas)", true },
                    { 1670, "AE", 237, 1, "AE (Armed Forces Europe)", true },
                    { 1671, "AL", 237, 1, "Alabama", true },
                    { 1672, "AK", 237, 1, "Alaska", true },
                    { 1673, "AS", 237, 1, "American Samoa", true },
                    { 1674, "AP", 237, 1, "AP (Armed Forces Pacific)", true },
                    { 1675, "AZ", 237, 1, "Arizona", true },
                    { 1676, "AR", 237, 1, "Arkansas", true },
                    { 1677, "CA", 237, 1, "California", true },
                    { 1678, "CO", 237, 1, "Colorado", true },
                    { 1679, "CT", 237, 1, "Connecticut", true },
                    { 1680, "DE", 237, 1, "Delaware", true },
                    { 1681, "DC", 237, 1, "District of Columbia", true },
                    { 1682, "FM", 237, 1, "Federated States of Micronesia", true },
                    { 1683, "FL", 237, 1, "Florida", true },
                    { 1684, "GA", 237, 1, "Georgia", true },
                    { 1685, "GU", 237, 1, "Guam", true },
                    { 1686, "HI", 237, 1, "Hawaii", true },
                    { 1687, "ID", 237, 1, "Idaho", true },
                    { 1688, "IL", 237, 1, "Illinois", true },
                    { 1689, "IN", 237, 1, "Indiana", true },
                    { 1690, "IA", 237, 1, "Iowa", true },
                    { 1691, "KS", 237, 1, "Kansas", true },
                    { 1692, "KY", 237, 1, "Kentucky", true },
                    { 1693, "LA", 237, 1, "Louisiana", true },
                    { 1694, "ME", 237, 1, "Maine", true },
                    { 1695, "MH", 237, 1, "Marshall Islands", true },
                    { 1696, "MD", 237, 1, "Maryland", true },
                    { 1697, "MA", 237, 1, "Massachusetts", true },
                    { 1698, "MI", 237, 1, "Michigan", true },
                    { 1699, "MN", 237, 1, "Minnesota", true },
                    { 1700, "MS", 237, 1, "Mississippi", true },
                    { 1701, "MO", 237, 1, "Missouri", true },
                    { 1702, "MT", 237, 1, "Montana", true },
                    { 1703, "NE", 237, 1, "Nebraska", true },
                    { 1704, "NV", 237, 1, "Nevada", true },
                    { 1705, "NH", 237, 1, "New Hampshire", true },
                    { 1706, "NJ", 237, 1, "New Jersey", true },
                    { 1707, "NM", 237, 1, "New Mexico", true },
                    { 1708, "NY", 237, 1, "New York", true },
                    { 1709, "NC", 237, 1, "North Carolina", true },
                    { 1710, "ND", 237, 1, "North Dakota", true },
                    { 1711, "MP", 237, 1, "Northern Mariana Islands", true },
                    { 1712, "OH", 237, 1, "Ohio", true },
                    { 1713, "OK", 237, 1, "Oklahoma", true },
                    { 1714, "OR", 237, 1, "Oregon", true },
                    { 1715, "PW", 237, 1, "Palau", true },
                    { 1716, "PA", 237, 1, "Pennsylvania", true },
                    { 1717, "PR", 237, 1, "Puerto Rico", true },
                    { 1718, "RI", 237, 1, "Rhode Island", true },
                    { 1719, "SC", 237, 1, "South Carolina", true },
                    { 1720, "SD", 237, 1, "South Dakota", true },
                    { 1721, "TN", 237, 1, "Tennessee", true },
                    { 1722, "TX", 237, 1, "Texas", true },
                    { 1723, "UT", 237, 1, "Utah", true },
                    { 1724, "VT", 237, 1, "Vermont", true },
                    { 1725, "VI", 237, 1, "Virgin Islands", true },
                    { 1726, "VA", 237, 1, "Virginia", true },
                    { 1727, "WA", 237, 1, "Washington", true },
                    { 1728, "WV", 237, 1, "West Virginia", true },
                    { 1729, "WI", 237, 1, "Wisconsin", true },
                    { 1730, "WY", 237, 1, "Wyoming", true },
                    { 1731, "", 241, 1, "Amazonas", true },
                    { 1732, "", 241, 2, "Anzoategui", true },
                    { 1733, "", 241, 3, "Apure", true },
                    { 1734, "", 241, 4, "Aragua", true },
                    { 1735, "", 241, 5, "Barinas", true },
                    { 1736, "", 241, 6, "Bolívar", true },
                    { 1737, "", 241, 7, "Carabobo", true },
                    { 1738, "", 241, 8, "Cojedes", true },
                    { 1739, "", 241, 9, "Delta Amacuro", true },
                    { 1740, "", 241, 10, "Distrito Capital", true },
                    { 1741, "", 241, 11, "Falcón", true },
                    { 1742, "", 241, 12, "Guárico", true },
                    { 1743, "", 241, 13, "Lara", true },
                    { 1744, "", 241, 14, "Mérida", true },
                    { 1745, "", 241, 15, "Miranda", true },
                    { 1746, "", 241, 16, "Monagas", true },
                    { 1747, "", 241, 17, "Nueva Esparta", true },
                    { 1748, "", 241, 18, "Portuguesa", true },
                    { 1749, "", 241, 19, "Sucre", true },
                    { 1750, "", 241, 20, "Táchira", true },
                    { 1751, "", 241, 21, "Trujillo", true },
                    { 1752, "", 241, 22, "Vargas", true },
                    { 1753, "", 241, 23, "Yaracuy", true },
                    { 1754, "", 241, 24, "Zulia", true },
                    { 1755, "HN", 242, 1, "Hà Nội", true },
                    { 1756, "HCM", 242, 2, "Hồ Chí Minh", true },
                    { 1757, "ĐN", 242, 3, "Đà Nẵng", true },
                    { 1758, "HP", 242, 4, "Hải Phòng", true },
                    { 1759, "CT", 242, 5, "Cần Thơ", true },
                    { 1760, "HG", 242, 6, "Hà Giang", true },
                    { 1761, "CB", 242, 6, "Cao Bằng", true },
                    { 1762, "BK", 242, 6, "Bắc Kạn", true },
                    { 1763, "TQ", 242, 6, "Tuyên Quang", true },
                    { 1764, "LC", 242, 6, "Lào Cai", true },
                    { 1765, "ĐB", 242, 6, "Điện Biên", true },
                    { 1766, "LC", 242, 6, "Lai Châu", true },
                    { 1767, "SL", 242, 6, "Sơn La", true },
                    { 1768, "YB", 242, 6, "Yên Bái", true },
                    { 1769, "HB", 242, 6, "Hòa Bình", true },
                    { 1770, "TN", 242, 6, "Thái Nguyên", true },
                    { 1771, "LS", 242, 6, "Lạng Sơn", true },
                    { 1772, "QN", 242, 6, "Quảng Ninh", true },
                    { 1773, "BG", 242, 6, "Bắc Giang", true },
                    { 1774, "PT", 242, 6, "Phú Thọ", true },
                    { 1775, "VP", 242, 6, "Vĩnh Phúc", true },
                    { 1776, "BN", 242, 6, "Bắc Ninh", true },
                    { 1777, "HD", 242, 6, "Hải Dương", true },
                    { 1778, "HY", 242, 6, "Hưng Yên", true },
                    { 1779, "TB", 242, 6, "Thái Bình", true },
                    { 1780, "HN", 242, 6, "Hà Nam", true },
                    { 1781, "NĐ", 242, 6, "Nam Định", true },
                    { 1782, "NB", 242, 6, "Ninh Bình", true },
                    { 1783, "TH", 242, 6, "Thanh Hóa", true },
                    { 1784, "NA", 242, 6, "Nghệ An", true },
                    { 1785, "HT", 242, 6, "Hà Tĩnh", true },
                    { 1786, "QB", 242, 6, "Quảng Bình", true },
                    { 1787, "QT", 242, 6, "Quảng Trị", true },
                    { 1788, "TTH", 242, 6, "Thừa Thiên Huế", true },
                    { 1789, "QN", 242, 6, "Quảng Nam", true },
                    { 1790, "QN", 242, 6, "Quảng Ngãi", true },
                    { 1791, "BĐ", 242, 6, "Bình Định", true },
                    { 1792, "PY", 242, 6, "Phú Yên", true },
                    { 1793, "KH", 242, 6, "Khánh Hòa", true },
                    { 1794, "NT", 242, 6, "Ninh Thuận", true },
                    { 1795, "BT", 242, 6, "Bình Thuận", true },
                    { 1796, "KT", 242, 6, "Kon Tum", true },
                    { 1797, "GL", 242, 6, "Gia Lai", true },
                    { 1798, "ĐL", 242, 6, "Đắk Lắk", true },
                    { 1799, "ĐN", 242, 6, "Đắk Nông", true },
                    { 1800, "LĐ", 242, 6, "Lâm Đồng", true },
                    { 1801, "BP", 242, 6, "Bình Phước", true },
                    { 1802, "TN", 242, 6, "Tây Ninh", true },
                    { 1803, "BD", 242, 6, "Bình Dương", true },
                    { 1804, "ĐN", 242, 6, "Đồng Nai", true },
                    { 1805, "BR", 242, 6, "Bà Rịa - Vũng Tàu", true },
                    { 1806, "LA", 242, 6, "Long An", true },
                    { 1807, "TG", 242, 6, "Tiền Giang", true },
                    { 1808, "BT", 242, 6, "Bến Tre", true },
                    { 1809, "TV", 242, 6, "Trà Vinh", true },
                    { 1810, "VL", 242, 6, "Vĩnh Long", true },
                    { 1811, "ĐT", 242, 6, "Đồng Tháp", true },
                    { 1812, "AG", 242, 6, "An Giang", true },
                    { 1813, "KG", 242, 6, "Kiên Giang", true },
                    { 1814, "HG", 242, 6, "Hậu Giang", true },
                    { 1815, "ST", 242, 6, "Sóc Trăng", true },
                    { 1816, "BL", 242, 6, "Bạc Liêu", true },
                    { 1817, "CM", 242, 6, "Cà Mau", true },
                    { 1818, "EC", 207, 0, "Eastern Cape", true },
                    { 1819, "FS", 207, 0, "Free State", true },
                    { 1820, "GP", 207, 0, "Gauteng", true },
                    { 1821, "KZN", 207, 0, "KwaZulu-Natal", true },
                    { 1822, "LP", 207, 0, "Limpopo", true },
                    { 1823, "MP", 207, 0, "Mpumalanga", true },
                    { 1824, "NC", 207, 0, "Northern Cape", true },
                    { 1825, "NW", 207, 0, "North West", true },
                    { 1826, "WC", 207, 0, "Western Cape", true },
                    { 1827, "BU", 249, 0, "Bulawayo", true },
                    { 1828, "HA", 249, 0, "Harare", true },
                    { 1829, "MA", 249, 0, "Manicaland", true },
                    { 1830, "MC", 249, 0, "Mashonaland Central", true },
                    { 1831, "ME", 249, 0, "Mashonaland East", true },
                    { 1832, "MW", 249, 0, "Mashonaland West", true },
                    { 1833, "MV", 249, 0, "Masvingo", true },
                    { 1834, "MN", 249, 0, "Matabeleland North", true },
                    { 1835, "MS", 249, 0, "Matabeleland South", true },
                    { 1836, "MI", 249, 0, "Midlands", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                schema: "Sale",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvinceId",
                schema: "Sale",
                table: "Address",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                schema: "Sale",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_EditorId",
                schema: "Cms",
                table: "Article",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_PreviewImageId",
                schema: "Cms",
                table: "Article",
                column: "PreviewImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_WriterId",
                schema: "Cms",
                table: "Article",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleId",
                schema: "Cms",
                table: "ArticleTag",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTopic_ArticleId",
                schema: "Cms",
                table: "ArticleTopic",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_DisplayOrder",
                schema: "Sale",
                table: "Category",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                schema: "Sale",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_DisplayOrder",
                schema: "Sale",
                table: "Country",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_DisplayOrder",
                schema: "Sale",
                table: "Currency",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToCategories_Category_Id",
                schema: "Sale",
                table: "DiscountCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToCategories_Discount_Id",
                schema: "Sale",
                table: "DiscountCategory",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToManufacturers_Discount_Id",
                schema: "Sale",
                table: "DiscountManufacturer",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToManufacturers_Manufacturer_Id",
                schema: "Sale",
                table: "DiscountManufacturer",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToProducts_Discount_Id",
                schema: "Sale",
                table: "DiscountProduct",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_AppliedToProducts_Product_Id",
                schema: "Sale",
                table: "DiscountProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailInboxAttachment_EmailInboxId",
                schema: "Crm",
                table: "EmailInboxAttachment",
                column: "EmailInboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailInboxFromAddress_EmailInboxId",
                schema: "Crm",
                table: "EmailInboxFromAddress",
                column: "EmailInboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailInboxToAddress_EmailInboxId",
                schema: "Crm",
                table: "EmailInboxToAddress",
                column: "EmailInboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOutbox_ReplayToId",
                schema: "Crm",
                table: "EmailOutbox",
                column: "ReplayToId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOutboxAttachment_EmailOutboxId",
                schema: "Crm",
                table: "EmailOutboxAttachment",
                column: "EmailOutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOutboxFromAddress_EmailOutboxId",
                schema: "Crm",
                table: "EmailOutboxFromAddress",
                column: "EmailOutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailOutboxToAddress_EmailOutboxId",
                schema: "Crm",
                table: "EmailOutboxToAddress",
                column: "EmailOutboxId");

            migrationBuilder.CreateIndex(
                name: "IX_FileUpload_UserId",
                schema: "FS",
                table: "FileUpload",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_LinkSectionId",
                schema: "Cms",
                table: "Link",
                column: "LinkSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_UserId",
                schema: "Cms",
                table: "Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_DisplayOrder",
                schema: "Sale",
                table: "Manufacturer",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                schema: "Cms",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FromUserId",
                schema: "Crm",
                table: "Message",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageAttachment_MessageId",
                schema: "Crm",
                table: "MessageAttachment",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUser_MessageId",
                schema: "Crm",
                table: "MessageUser",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageUser_ToUserId",
                schema: "Crm",
                table: "MessageUser",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                schema: "Sale",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedOnUtc",
                schema: "Sale",
                table: "Order",
                column: "CreatedOnUtc",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                schema: "Sale",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingAddressId",
                schema: "Sale",
                table: "Order",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingMethodId",
                schema: "Sale",
                table: "Order",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserCurrencyId",
                schema: "Sale",
                table: "Order",
                column: "UserCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                schema: "Sale",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscount",
                schema: "Sale",
                table: "OrderDiscount",
                columns: new[] { "DiscountId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscount_OrderId",
                schema: "Sale",
                table: "OrderDiscount",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_DiscountId",
                schema: "Sale",
                table: "OrderItem",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "Sale",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "Sale",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNote_OrderId",
                schema: "Sale",
                table: "OrderNote",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNote_UserId",
                schema: "Sale",
                table: "OrderNote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_EditorId",
                schema: "Cms",
                table: "Page",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_WriterId",
                schema: "Cms",
                table: "Page",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_PageTag_PageId",
                schema: "Cms",
                table: "PageTag",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringPayment_InitialOrderId",
                schema: "Sale",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreateUserId",
                schema: "Sale",
                table: "Product",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CurrencyId",
                schema: "Sale",
                table: "Product",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Deleted_and_Published",
                schema: "Sale",
                table: "Product",
                columns: new[] { "Published", "Deleted", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_DeliveryDateId",
                schema: "Sale",
                table: "Product",
                column: "DeliveryDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TaxCategoryId",
                schema: "Sale",
                table: "Product",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdateUserId",
                schema: "Sale",
                table: "Product",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_AttributeType",
                schema: "Sale",
                table: "ProductAttribute",
                column: "AttributeType");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_DisplayOrder",
                schema: "Sale",
                table: "ProductAttribute",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_PCM_Product_and_Category",
                schema: "Sale",
                table: "ProductCategory",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Mapping_CategoryId",
                schema: "Sale",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Mapping_ProductId",
                schema: "Sale",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_AttributeId",
                schema: "Sale",
                table: "ProductInventory",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarehouseInventory_ProductId",
                schema: "Sale",
                table: "ProductInventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PMM_Product_and_Manufacturer",
                schema: "Sale",
                table: "ProductManufacturer",
                columns: new[] { "ManufacturerId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Manufacturer_Mapping_ManufacturerId",
                schema: "Sale",
                table: "ProductManufacturer",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Manufacturer_Mapping_ProductId",
                schema: "Sale",
                table: "ProductManufacturer",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Picture_Mapping_PictureId",
                schema: "Sale",
                table: "ProductPicture",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Picture_Mapping_ProductId",
                schema: "Sale",
                table: "ProductPicture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PCM_Product_and_Attribute",
                schema: "Sale",
                table: "ProductProductAttribute",
                columns: new[] { "AttributeId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Attribute_Mapping_AttributeId",
                schema: "Sale",
                table: "ProductProductAttribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Attribute_Mapping_ProductId",
                schema: "Sale",
                table: "ProductProductAttribute",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductTag_ProductTagId",
                schema: "Sale",
                table: "ProductProductTag",
                column: "ProductTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_CustomerId",
                schema: "Sale",
                table: "ProductReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                schema: "Sale",
                table: "ProductReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewHelpfulness_ProductReviewId",
                schema: "Sale",
                table: "ProductReviewHelpfulness",
                column: "ProductReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewHelpfulness_UserId",
                schema: "Sale",
                table: "ProductReviewHelpfulness",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_Name",
                schema: "Sale",
                table: "ProductTag",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProduct_ProductId1",
                schema: "Sale",
                table: "RelatedProduct",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProduct_ProductId2",
                schema: "Sale",
                table: "RelatedProduct",
                column: "ProductId2");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_OrderId",
                schema: "Sale",
                table: "Shipment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItem_OrderItemId",
                schema: "Sale",
                table: "ShipmentItem",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItem_ShipmentId",
                schema: "Sale",
                table: "ShipmentItem",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem",
                schema: "Sale",
                table: "ShoppingCartItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductId",
                schema: "Sale",
                table: "ShoppingCartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_UserId",
                schema: "Sale",
                table: "ShoppingCartItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Slideshow_UserId",
                schema: "Cms",
                table: "Slideshow",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_CountryId",
                schema: "Sale",
                table: "StateProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribe_SubscribeLabelId",
                schema: "Cms",
                table: "Subscribe",
                column: "SubscribeLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_CountryId",
                schema: "Sale",
                table: "TaxRate",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_StateProvinceId",
                schema: "Sale",
                table: "TaxRate",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRate_TaxCategoryId",
                schema: "Sale",
                table: "TaxRate",
                column: "TaxCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ParentId",
                schema: "Cms",
                table: "Topic",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_PaymentId",
                schema: "Sale",
                table: "Order",
                column: "PaymentId",
                principalSchema: "Sale",
                principalTable: "Payment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Country",
                schema: "Sale",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_StateProvince_Country",
                schema: "Sale",
                table: "StateProvince");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_StateProvince",
                schema: "Sale",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address",
                schema: "Sale",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Currency",
                schema: "Sale",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_PaymentId",
                schema: "Sale",
                table: "Order");

            migrationBuilder.DropTable(
                name: "ArticleTag",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "ArticleTopic",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "DiscountCategory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "DiscountManufacturer",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "DiscountProduct",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "EmailInboxAttachment",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailInboxFromAddress",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailInboxToAddress",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailOutboxAttachment",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailOutboxFromAddress",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "EmailOutboxToAddress",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "Link",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "MessageAttachment",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "MessageUser",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "OrderDiscount",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "OrderNote",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "PageTag",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductInventory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductManufacturer",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductPicture",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductProductAttribute",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductProductTag",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductReviewHelpfulness",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "RelatedProduct",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "SearchTerm",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ShipmentItem",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Slideshow",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Subscribe",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "TaxRate",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Article",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Topic",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "EmailOutbox",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "LinkSection",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "Page",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Manufacturer",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductAttribute",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductTag",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ProductReview",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Shipment",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "SubscribeLabel",
                schema: "Cms");

            migrationBuilder.DropTable(
                name: "FileUpload",
                schema: "FS");

            migrationBuilder.DropTable(
                name: "EmailInbox",
                schema: "Crm");

            migrationBuilder.DropTable(
                name: "Discount",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "DeliveryDate",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "TaxCategory",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "StateProvince",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Sale");

            migrationBuilder.DropTable(
                name: "ShippingMethod",
                schema: "Sale");
        }
    }
}
