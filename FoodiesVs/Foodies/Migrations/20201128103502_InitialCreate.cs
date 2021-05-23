using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodies.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Foodies");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Foodies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Foodies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Foodies",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Foodies",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                schema: "Foodies",
                columns: table => new
                {
                    IngredientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    EnergyKcal = table.Column<int>(nullable: false),
                    EnergyKj = table.Column<int>(nullable: true),
                    Water = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EggWhite = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbohydrates = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sugar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaturatedFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SingleSaturatedFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MultiSaturatedFat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cholesterol = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fiber = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientID);
                });

            migrationBuilder.CreateTable(
                name: "LevelPreperation",
                schema: "Foodies",
                columns: table => new
                {
                    LevelPreperationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelPreperation", x => x.LevelPreperationId);
                });

            migrationBuilder.CreateTable(
                name: "Preperationtime",
                schema: "Foodies",
                columns: table => new
                {
                    PreperationTimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeMinutes = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preperationtime", x => x.PreperationTimeId);
                });

            migrationBuilder.CreateTable(
                name: "Shoppinglist",
                schema: "Foodies",
                columns: table => new
                {
                    ShoppinglistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoppinglist", x => x.ShoppinglistId);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                schema: "Foodies",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Weekschedule",
                schema: "Foodies",
                columns: table => new
                {
                    WeekscheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Week = table.Column<int>(nullable: false),
                    Day = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "dateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weekschedule", x => x.WeekscheduleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Foodies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Foodies",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Foodies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Foodies",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Foodies",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Foodies",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Foodies",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Foodies",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Foodies",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Foodies",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Foodies",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndUser",
                schema: "Foodies",
                columns: table => new
                {
                    EndUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    NickName = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(maxLength: 2083, nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndUser", x => x.EndUserId);
                    table.ForeignKey(
                        name: "FK_EndUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "Foodies",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                schema: "Foodies",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ShortDiscription = table.Column<string>(maxLength: 200, nullable: false),
                    PreperationDiscribtion = table.Column<string>(nullable: false),
                    NumberOfPeople = table.Column<int>(nullable: false),
                    LevelPreperationId = table.Column<int>(nullable: false),
                    PreperationTimeId = table.Column<int>(nullable: false),
                    PictureMeal = table.Column<string>(maxLength: 2083, nullable: false),
                    EndUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meal_EndUser_EndUserId",
                        column: x => x.EndUserId,
                        principalSchema: "Foodies",
                        principalTable: "EndUser",
                        principalColumn: "EndUserId");
                    table.ForeignKey(
                        name: "FK_Meal_LevelPreperation_LevelPreperationId",
                        column: x => x.LevelPreperationId,
                        principalSchema: "Foodies",
                        principalTable: "LevelPreperation",
                        principalColumn: "LevelPreperationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meal_Preperationtime_PreperationTimeId",
                        column: x => x.PreperationTimeId,
                        principalSchema: "Foodies",
                        principalTable: "Preperationtime",
                        principalColumn: "PreperationTimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserShoppinglist",
                schema: "Foodies",
                columns: table => new
                {
                    UserShoppinglistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ShoppinglistId = table.Column<int>(nullable: false),
                    EndUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShoppinglist", x => x.UserShoppinglistId);
                    table.ForeignKey(
                        name: "FK_UserShoppinglist_EndUser_EndUserId",
                        column: x => x.EndUserId,
                        principalSchema: "Foodies",
                        principalTable: "EndUser",
                        principalColumn: "EndUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserShoppinglist_Shoppinglist_ShoppinglistId",
                        column: x => x.ShoppinglistId,
                        principalSchema: "Foodies",
                        principalTable: "Shoppinglist",
                        principalColumn: "ShoppinglistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteMeal",
                schema: "Foodies",
                columns: table => new
                {
                    FavoriteMealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteMeal", x => x.FavoriteMealId);
                    table.ForeignKey(
                        name: "FK_FavoriteMeal_Meal_MealId",
                        column: x => x.MealId,
                        principalSchema: "Foodies",
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteMeal_EndUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Foodies",
                        principalTable: "EndUser",
                        principalColumn: "EndUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealCategory",
                schema: "Foodies",
                columns: table => new
                {
                    MealCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealCategory", x => x.MealCategoryId);
                    table.ForeignKey(
                        name: "FK_MealCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Foodies",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealCategory_Meal_MealId",
                        column: x => x.MealId,
                        principalSchema: "Foodies",
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealIngredient",
                schema: "Foodies",
                columns: table => new
                {
                    MealIngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealIngredient", x => x.MealIngredientId);
                    table.ForeignKey(
                        name: "FK_MealIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "Foodies",
                        principalTable: "Ingredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealIngredient_Meal_MealId",
                        column: x => x.MealId,
                        principalSchema: "Foodies",
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealIngredient_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Foodies",
                        principalTable: "Unit",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealWeekScheduleUser",
                schema: "Foodies",
                columns: table => new
                {
                    MealWeekScheduleUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekscheduleId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    EndUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealWeekScheduleUser", x => x.MealWeekScheduleUserId);
                    table.ForeignKey(
                        name: "FK_MealWeekScheduleUser_EndUser_EndUserId",
                        column: x => x.EndUserId,
                        principalSchema: "Foodies",
                        principalTable: "EndUser",
                        principalColumn: "EndUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealWeekScheduleUser_Meal_MealId",
                        column: x => x.MealId,
                        principalSchema: "Foodies",
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealWeekScheduleUser_Weekschedule_WeekscheduleId",
                        column: x => x.WeekscheduleId,
                        principalSchema: "Foodies",
                        principalTable: "Weekschedule",
                        principalColumn: "WeekscheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                schema: "Foodies",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    Number = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rating_EndUser_EndUserId",
                        column: x => x.EndUserId,
                        principalSchema: "Foodies",
                        principalTable: "EndUser",
                        principalColumn: "EndUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Meal_MealId",
                        column: x => x.MealId,
                        principalSchema: "Foodies",
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppinglistIngredient",
                schema: "Foodies",
                columns: table => new
                {
                    ShoppinglistIngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppinglistId = table.Column<int>(nullable: false),
                    MealIngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppinglistIngredient", x => x.ShoppinglistIngredientId);
                    table.ForeignKey(
                        name: "FK_ShoppinglistIngredient_MealIngredient_MealIngredientId",
                        column: x => x.MealIngredientId,
                        principalSchema: "Foodies",
                        principalTable: "MealIngredient",
                        principalColumn: "MealIngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppinglistIngredient_Shoppinglist_ShoppinglistId",
                        column: x => x.ShoppinglistId,
                        principalSchema: "Foodies",
                        principalTable: "Shoppinglist",
                        principalColumn: "ShoppinglistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Foodies",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Foodies",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Foodies",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Foodies",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Foodies",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Foodies",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Foodies",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                schema: "Foodies",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EndUser_ApplicationUserId",
                schema: "Foodies",
                table: "EndUser",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EndUser_NickName",
                schema: "Foodies",
                table: "EndUser",
                column: "NickName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMeal_MealId",
                schema: "Foodies",
                table: "FavoriteMeal",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMeal_UserId",
                schema: "Foodies",
                table: "FavoriteMeal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_EndUserId",
                schema: "Foodies",
                table: "Meal",
                column: "EndUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_LevelPreperationId",
                schema: "Foodies",
                table: "Meal",
                column: "LevelPreperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_PreperationTimeId",
                schema: "Foodies",
                table: "Meal",
                column: "PreperationTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealCategory_CategoryId",
                schema: "Foodies",
                table: "MealCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MealCategory_MealId",
                schema: "Foodies",
                table: "MealCategory",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredient_IngredientId",
                schema: "Foodies",
                table: "MealIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredient_MealId",
                schema: "Foodies",
                table: "MealIngredient",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredient_UnitId",
                schema: "Foodies",
                table: "MealIngredient",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MealWeekScheduleUser_EndUserId",
                schema: "Foodies",
                table: "MealWeekScheduleUser",
                column: "EndUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealWeekScheduleUser_MealId",
                schema: "Foodies",
                table: "MealWeekScheduleUser",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealWeekScheduleUser_WeekscheduleId",
                schema: "Foodies",
                table: "MealWeekScheduleUser",
                column: "WeekscheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_EndUserId",
                schema: "Foodies",
                table: "Rating",
                column: "EndUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_MealId",
                schema: "Foodies",
                table: "Rating",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppinglistIngredient_MealIngredientId",
                schema: "Foodies",
                table: "ShoppinglistIngredient",
                column: "MealIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppinglistIngredient_ShoppinglistId",
                schema: "Foodies",
                table: "ShoppinglistIngredient",
                column: "ShoppinglistId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShoppinglist_EndUserId",
                schema: "Foodies",
                table: "UserShoppinglist",
                column: "EndUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShoppinglist_ShoppinglistId",
                schema: "Foodies",
                table: "UserShoppinglist",
                column: "ShoppinglistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "FavoriteMeal",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "MealCategory",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "MealWeekScheduleUser",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "Rating",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "ShoppinglistIngredient",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "UserShoppinglist",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "Weekschedule",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "MealIngredient",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "Shoppinglist",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "Ingredient",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "Meal",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "Unit",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "EndUser",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "LevelPreperation",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "Preperationtime",
                schema: "Foodies");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Foodies");
        }
    }
}
