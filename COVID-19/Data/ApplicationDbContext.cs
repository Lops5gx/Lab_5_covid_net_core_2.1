using System;
using System.Collections.Generic;
using System.Text;
using COVID19.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COVID_19.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DadoCovid> DadosCovid { get; set; }

        public DbSet<Pais> Paises{ get; set; }
    }
}
