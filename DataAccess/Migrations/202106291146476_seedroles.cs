namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedroles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7cfc2484-c255-4d1b-bc05-a7a8bd184e44', N'admin@vidly.com', 0, N'AFzosl/33u7Ic25/9zgR4mcfS2ZrNFCMAOhGgt5Wkuc5zjvtOfze2kg0i+fAwolFJg==', N'64beed7f-c3c8-4b4a-8ca5-79de181c32e8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f7674210-38dd-409a-a170-d2adb19064b5', N'guest@vidly.com', 0, N'AON/kmZ+IP1Dz2JckQuOH5az2UTeJax9GhVWfSpxLg4J7tDQjYzJJy3cXMgg8ivnMA==', N'f65e91c9-2143-400c-af78-c8cd85c27d07', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a205ad1e-0fac-468b-89e0-8dcb8eda6f4f', N'CanMangeMovie')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7cfc2484-c255-4d1b-bc05-a7a8bd184e44', N'a205ad1e-0fac-468b-89e0-8dcb8eda6f4f')



");
        }
        
        public override void Down()
        {
        }
    }
}
