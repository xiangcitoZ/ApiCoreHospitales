using ApiCoreHospitales.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreHospitales.Data
{
    public class HospitalesContext: DbContext
    {
        public HospitalesContext
            (DbContextOptions<HospitalesContext> options): 
                base(options){ }
        
        public DbSet<Hospital> Hospitales { get; set; }

    }
}
