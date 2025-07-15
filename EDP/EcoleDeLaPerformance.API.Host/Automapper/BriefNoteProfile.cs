using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.BriefNotes;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class BriefNoteProfile : Profile
    {
        public BriefNoteProfile()
        {
            CreateMap<BriefNote, BriefNoteResponse>();
            CreateMap<BriefNoteRequest, BriefNote>();
        }
    }
}
