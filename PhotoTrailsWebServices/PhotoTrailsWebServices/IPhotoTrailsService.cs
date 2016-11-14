using PhotoTrailsWebServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PhotoTrailsWebServices
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IService1" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IPhotoTrailsService
    {

        [OperationContract]
        List<TrailDTO> GetAllTrails();

        [OperationContract]
        TrailDTO GetTrailById(long id);

    }


    
}
