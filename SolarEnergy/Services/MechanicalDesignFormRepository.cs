using Domain.Models;
using SolarEnergy.DbContext;

namespace SolarEnergy.Services
{
    public class MechanicalDesignFormRepository : GenericRepository<MechanicalDesignForm>,IMechanicalDesignForm
    {

        private readonly ApplicationDbContext _context;
        public MechanicalDesignFormRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
