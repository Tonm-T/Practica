using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticaEN;

namespace PracticaDAL.cs
{
    public class ContextoBD : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(@"Data Source=DESKTOP-3IPN15V\SQLEXPRESS;Initial Catalog=PracticaCrud;Integrated Security=True; trust Server Certificate=True");

        }
    }
}
