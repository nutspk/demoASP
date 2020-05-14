namespace demoASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        category_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.category_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        company_name = c.String(nullable: false, maxLength: 150),
                        contact_name = c.String(nullable: false, maxLength: 30),
                        contact_title = c.String(maxLength: 30),
                        address = c.String(nullable: false, maxLength: 60),
                        city = c.String(maxLength: 15),
                        region = c.String(maxLength: 15),
                        postal_code = c.String(nullable: false, maxLength: 10),
                        country = c.String(nullable: false, maxLength: 15),
                        phone = c.String(nullable: false, maxLength: 24),
                        fax = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.customer_id)
                .Index(t => t.customer_id);
            
            CreateTable(
                "dbo.order",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        employee_id = c.Int(),
                        order_date = c.DateTime(nullable: false),
                        required_date = c.DateTime(nullable: false),
                        shipped_date = c.DateTime(nullable: false),
                        ship_via = c.Int(nullable: false),
                        freight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ship_name = c.String(nullable: false, maxLength: 150),
                        ship_Address = c.String(nullable: false, maxLength: 200),
                        ship_city = c.String(maxLength: 200),
                        ship_region = c.String(maxLength: 50),
                        ship_postal_code = c.String(nullable: false, maxLength: 10),
                        ship_country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.customers", t => t.customer_id, cascadeDelete: true)
                .ForeignKey("dbo.employees", t => t.employee_id)
                .ForeignKey("dbo.shippers", t => t.ship_via, cascadeDelete: true)
                .Index(t => t.order_id)
                .Index(t => t.customer_id)
                .Index(t => t.employee_id)
                .Index(t => t.ship_via);
            
            CreateTable(
                "dbo.employees",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        last_name = c.String(nullable: false, maxLength: 50),
                        first_name = c.String(nullable: false, maxLength: 50),
                        title = c.String(nullable: false, maxLength: 30),
                        title_of_courtesy = c.String(maxLength: 30),
                        birth_date = c.DateTime(),
                        hire_date = c.DateTime(),
                        address = c.String(maxLength: 60),
                        city = c.String(maxLength: 15),
                        region = c.String(maxLength: 15),
                        postal_code = c.String(maxLength: 10),
                        country = c.String(maxLength: 15),
                        home_phone = c.String(maxLength: 24),
                        extension = c.String(maxLength: 4),
                        notes = c.String(),
                        report_to = c.Int(),
                    })
                .PrimaryKey(t => t.employee_id)
                .ForeignKey("dbo.employees", t => t.report_to)
                .Index(t => t.report_to);
            
            CreateTable(
                "dbo.order_details",
                c => new
                    {
                        order_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.order_id, t.product_id })
                .ForeignKey("dbo.order", t => t.order_id, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.order_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        product_name = c.String(nullable: false, maxLength: 150),
                        supplier_id = c.Int(),
                        category_id = c.Int(),
                        quantity_per_unit = c.Int(nullable: false),
                        unit_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        units_in_stock = c.Int(nullable: false),
                        units_on_order = c.Int(nullable: false),
                        reorder_level = c.Int(nullable: false),
                        discontinued = c.String(),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.categories", t => t.category_id)
                .ForeignKey("dbo.suppliers", t => t.supplier_id)
                .Index(t => t.product_id)
                .Index(t => t.supplier_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.suppliers",
                c => new
                    {
                        supplier_id = c.Int(nullable: false, identity: true),
                        company_name = c.String(nullable: false, maxLength: 150),
                        contact_name = c.String(nullable: false, maxLength: 30),
                        contact_title = c.String(maxLength: 30),
                        address = c.String(maxLength: 60),
                        city = c.String(nullable: false, maxLength: 15),
                        region = c.String(maxLength: 15),
                        postal_code = c.String(nullable: false, maxLength: 10),
                        country = c.String(nullable: false, maxLength: 15),
                        phone = c.String(nullable: false, maxLength: 24),
                        fax = c.String(maxLength: 24),
                        homepage = c.String(),
                    })
                .PrimaryKey(t => t.supplier_id)
                .Index(t => t.supplier_id)
                .Index(t => t.company_name);
            
            CreateTable(
                "dbo.shippers",
                c => new
                    {
                        shipper_id = c.Int(nullable: false, identity: true),
                        company_name = c.String(nullable: false, maxLength: 150),
                        phone = c.String(nullable: false, maxLength: 24),
                    })
                .PrimaryKey(t => t.shipper_id)
                .Index(t => t.shipper_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.order", "ship_via", "dbo.shippers");
            DropForeignKey("dbo.order_details", "product_id", "dbo.products");
            DropForeignKey("dbo.products", "supplier_id", "dbo.suppliers");
            DropForeignKey("dbo.products", "category_id", "dbo.categories");
            DropForeignKey("dbo.order_details", "order_id", "dbo.order");
            DropForeignKey("dbo.employees", "report_to", "dbo.employees");
            DropForeignKey("dbo.order", "employee_id", "dbo.employees");
            DropForeignKey("dbo.order", "customer_id", "dbo.customers");
            DropIndex("dbo.shippers", new[] { "shipper_id" });
            DropIndex("dbo.suppliers", new[] { "company_name" });
            DropIndex("dbo.suppliers", new[] { "supplier_id" });
            DropIndex("dbo.products", new[] { "category_id" });
            DropIndex("dbo.products", new[] { "supplier_id" });
            DropIndex("dbo.products", new[] { "product_id" });
            DropIndex("dbo.order_details", new[] { "product_id" });
            DropIndex("dbo.order_details", new[] { "order_id" });
            DropIndex("dbo.employees", new[] { "report_to" });
            DropIndex("dbo.order", new[] { "ship_via" });
            DropIndex("dbo.order", new[] { "employee_id" });
            DropIndex("dbo.order", new[] { "customer_id" });
            DropIndex("dbo.order", new[] { "order_id" });
            DropIndex("dbo.customers", new[] { "customer_id" });
            DropIndex("dbo.categories", new[] { "category_id" });
            DropTable("dbo.shippers");
            DropTable("dbo.suppliers");
            DropTable("dbo.products");
            DropTable("dbo.order_details");
            DropTable("dbo.employees");
            DropTable("dbo.order");
            DropTable("dbo.customers");
            DropTable("dbo.categories");
        }
    }
}
