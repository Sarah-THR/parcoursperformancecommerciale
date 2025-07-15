using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities.BI;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Contract;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Contracts;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<EcolePerformanceSm, ContractSmsResponse>();
            CreateMap<ContractsRequest, EcolePerformanceSm>();
            CreateMap<EcolePerformanceNewContrat, ContractResponse>();
            CreateMap<GetNbContractsRequest, EcolePerformanceNewContrat>();
            CreateMap<GetContractSaleRequest, VenteOneShot>();
            CreateMap<VenteOneShot, ContractSaleResponse>();
            CreateMap<NexleaseContract, ContractSaleResponse>();
        }
    }
}
