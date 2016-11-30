using AutoMapper;
using PhotoTrailsWebServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PhotoTrailsWebServices.DataAccessService
{
    public class TrailDataAccess : ITrailDataAccess
    {
        private readonly phototrailsEntities _context;
        private readonly IMapper _mapper;

        public TrailDataAccess(phototrailsEntities context)
        {
            _context = context;
            _mapper = Mapper.Configuration.CreateMapper();
        }

        public List<TrailDTO> GetAllTrails()
        {
            var query = from trail in _context.trail
                        orderby trail.name
                        select trail;
            List<TrailDTO> trailList = new List<TrailDTO>();
            query.ToList<trail>().ForEach(trail => trailList.Add(_mapper.Map<TrailDTO>(trail)));
            return trailList;
        }

        public async Task<List<TrailDTO>> GetAllTrailsAsync()
        {
            var query = from trail in _context.trail
                        orderby trail.name
                        select trail;
            return await query.ProjectToListAsync<TrailDTO>();
        }

        public TrailDTO GetTrailById(long id)
        {
            trail trail = _context.trail.Find(id);
            return _mapper.Map<TrailDTO>(trail);
        }

        public async Task<TrailDTO> GetTrailByIdAsync(long id)
        {
            var trail = await _context.trail.FindAsync(id);
            return _mapper.Map<TrailDTO>(trail);
        }
    }
}