using PhotoTrailsWebServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTrailsWebServices.DataAccessService
{
    public interface ITrailDataAccess
    {
        List<TrailDTO> GetAllTrails();

        Task<List<TrailDTO>> GetAllTrailsAsync();

        TrailDTO GetTrailById(long id);

        Task<TrailDTO> GetTrailByIdAsync(long id);
    }
}
