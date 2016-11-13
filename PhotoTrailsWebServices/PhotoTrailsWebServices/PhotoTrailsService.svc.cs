using PhotoTrailsWebServices.DataAccessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PhotoTrailsWebServices.DataTransferObject;
using AutoMapper;

namespace PhotoTrailsWebServices
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "Service1" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare Service1.svc o Service1.svc.cs in Esplora soluzioni e avviare il debug.
    public class PhotoTrailsService : IPhotoTrailsService
    {
        /// <summary>
        /// Il metodo viene chiamato automaticamente quando il servizio viene avviato.
        /// Contiene il codice per configurare il servizio allo startup.
        /// </summary>
        /// <param name="config"></param>
        public static void Configure(ServiceConfiguration config)
        {
            config.LoadFromConfiguration();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<trail, TrailDTO>();
                cfg.CreateMap<trackpoint, TrackPointDTO>();
            });
        }

        public List<TrailDTO> GetAllTrails()
        {
            return new List<TrailDTO>();
        }

    }
}
