using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Irimia_web.Models;

namespace Irimia_web.Data
{
    public class Irimia_webContext : DbContext
    {
        public Irimia_webContext(DbContextOptions<Irimia_webContext> options)
            : base(options)
        {
        }

        public DbSet<Irimia_web.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Irimia_web.Models.Orar> Orar { get; set; }

        public DbSet<Irimia_web.Models.Medic> Medic { get; set; }

        public DbSet<Irimia_web.Models.Specialitate> Specialitate { get; set; }

        public DbSet<Irimia_web.Models.Pacient> Pacient { get; set; }

        public DbSet<Irimia_web.Models.Programare> Programare { get; set; }
    }
}
