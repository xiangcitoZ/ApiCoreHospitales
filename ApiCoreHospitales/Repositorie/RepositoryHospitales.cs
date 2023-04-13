using ApiCoreHospitales.Data;
using ApiCoreHospitales.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreHospitales.Repositorie
{
    public class RepositoryHospitales
    {
        private HospitalesContext context;

        public RepositoryHospitales(HospitalesContext context)
        {
            this.context = context; 
        }

        public async Task<List<Hospital>> GetHospitalsAsync()
        {
            return await this.context.Hospitales.ToListAsync();

        }

        public async Task<Hospital> FindHospitalAsync(int id)
        {
            return await 
                this.context.Hospitales.FirstOrDefaultAsync
                (x => x.IdHospital == id);

        }



    }
}
