using AutoMapper;
using TenderManagement.DataAccess;
using TenderManagement.Models;

namespace TenderManagement.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
            CreateMap<Tender, TenderDTO>().ReverseMap();
            CreateMap<Tender, CreateTenderDTO>().ReverseMap();
            CreateMap<Tender, UpdateTenderDTO>().ReverseMap();
        }
    }
}
