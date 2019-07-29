namespace MovieRentalMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataInUsersTables : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5610e5b2-5fc0-4a47-b5fc-9c66953727a6', N'abc@gmail.com', 0, N'AKR3caQpInRASQuQp5UubLIU2trIzROtyfOFLFth7x6XRSZwxzkqmrWbGBEW+ZAyOw==', N'16504681-b0b4-48d7-bde9-5cad9b1d681c', NULL, 0, 0, NULL, 1, 0, N'abc@gmail.com')
");
            
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8fe08962-c2ae-486d-a761-ef2dc7a880f9', N'Admin')
");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5610e5b2-5fc0-4a47-b5fc-9c66953727a6', N'8fe08962-c2ae-486d-a761-ef2dc7a880f9')
");

        }
        
        public override void Down()
        {
        }
    }
}
