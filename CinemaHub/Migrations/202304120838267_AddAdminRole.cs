namespace CinemaHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0e8b61bb-e99a-4cc6-945e-03e1b2496faa', N'antonabdalla30@gmail.com', 0, N'ABT9A7v4Pvw413mY6yUHoxEv93iVyccOInTubcNip1REG0g3gVbVgEEwDhrRH16O8A==', N'336041f3-f8cf-4692-b58e-b53d06915110', NULL, 0, 0, NULL, 1, 0, N'antonabdalla30@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7425c06f-97a2-423f-b535-a32b02845fae', N'admin@cinemahub.com', 0, N'AOWrFxNEhQ1LuOtuERj2JwqA/LkAjQdc/z4GDjXz3TCGsI1B1cU14wUIaOjrzjNFpg==', N'5287a807-4615-44a1-9125-f1d4360270f0', NULL, 0, 0, NULL, 1, 0, N'admin@cinemahub.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ea5081bc-9da6-4c45-b096-ff60820833f6', N'Admin')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7425c06f-97a2-423f-b535-a32b02845fae', N'ea5081bc-9da6-4c45-b096-ff60820833f6')


");
        }
        
        public override void Down()
        {
        }
    }
}
