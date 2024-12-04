using AutoMapper;
using Domain.Dto;
using Domain.Models;

namespace Application.MappingSetup
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CUSachDto, TblSach>();
            CreateMap<TblSach, SachItem>();
        }
    }
}
