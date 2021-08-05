namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertintosql : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes(Id,SignUpFee,DurationInMonths,DiscountReate)VALUES(1,0,0,0)");
            Sql("INSERT INTO MemberShipTypes(Id,SignUpFee,DurationInMonths,DiscountReate)VALUES(2,30,1,10)");
            Sql("INSERT INTO MemberShipTypes(Id,SignUpFee,DurationInMonths,DiscountReate)VALUES(3,90,3,15)");
        }
        
        public override void Down()
        {
        }
    }
}
