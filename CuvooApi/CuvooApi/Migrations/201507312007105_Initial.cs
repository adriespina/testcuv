namespace CuvooApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaValidez = c.DateTime(nullable: false),
                        Bateria = c.Int(nullable: false),
                        Genre = c.String(),
                        URLCallback = c.String(),
                        Perfil = c.Int(nullable: false),
                        Configuracion = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoraMsg = c.DateTime(nullable: false),
                        ValorMsgDouble = c.Double(nullable: false),
                        ValorMsgString = c.String(),
                        ValorMsgHex = c.String(),
                        ValorMsgPosition = c.Geography(),
                        SigFoxId = c.Int(nullable: false),
                        SensorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoSensor = c.Int(nullable: false),
                        DeviceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sigfoxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Email = c.String(),
                        Contraseña = c.String(),
                        UltimoAcceso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Sigfoxes");
            DropTable("dbo.Sensors");
            DropTable("dbo.Medidas");
            DropTable("dbo.Devices");
        }
    }
}
