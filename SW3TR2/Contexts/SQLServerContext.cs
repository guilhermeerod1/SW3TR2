using SW3TR2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SW3TR2.Contexts
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext() : base("SqlServerConn")
        {
            Database.SetInitializer<SQLServerContext>
            (
                new DropCreateDatabaseIfModelChanges<SQLServerContext>()
            );
        }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Plano> Planos { get; set; }
        
        public DbSet<Caso> Casos { get; set; }
    }
}