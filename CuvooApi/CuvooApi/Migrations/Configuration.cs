namespace CuvooApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CuvooApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CuvooApi.Models.CuvooApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CuvooApi.Models.CuvooApiContext context)
        {
            //Inicializo un usuario
            context.Usuarios.AddOrUpdate(x => x.Id,
                new Usuario() { Id = 1, Nombre = "Adrian", Apellidos = "Espina Viella", Email = "adrian.espina@cuvoo.es", Contraseña = "mafalda", UltimoAcceso = DateTime.Now.AddMonths(-1) });

            //Inicializo un dispositivo
            context.Devices.AddOrUpdate(x => x.Id,
                new Device() { Id = 0, Nombre = "Cuvoo de Adrian", UsuarioId = 1, FechaAlta = DateTime.Now.AddMonths(-1).AddDays(-1), FechaValidez = DateTime.Now.AddYears(1).AddMonths(-1).AddDays(-1), Bateria=90 });

            //Inicializo unas lecturas del sensor
            context.Devices.AddOrUpdate(x => x.Id,
               new Device() { Id = 0, Nombre = "Cuvoo de Adrian", UsuarioId = 1, FechaAlta = DateTime.Now.AddMonths(-1).AddDays(-1), FechaValidez = DateTime.Now.AddYears(1).AddMonths(-1).AddDays(-1), Bateria = 90 });
        }
    }
}
