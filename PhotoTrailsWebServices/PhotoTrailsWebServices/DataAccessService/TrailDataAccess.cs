using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PhotoTrailsWebServices.DataAccessService
{
    public class TrailDataAccess
    {
        private phototrailsEntities _context;

        public TrailDataAccess(phototrailsEntities context)
        {
            _context = context;
        }

        public List<trail> GetAllTrails()
        {
            var query = from trail in _context.trail
                        orderby trail.name
                        select trail;
            return query.ToList();
        }

        public async Task<List<trail>> GetAllTrailsAsync()
        {
            var query = from trail in _context.trail
                        orderby trail.name
                        select trail;
            return await query.ToListAsync();
        }
    }
}