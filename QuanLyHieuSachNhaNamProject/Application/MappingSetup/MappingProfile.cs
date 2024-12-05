using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Domain.ModelViews;

namespace Application.MappingSetup
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CUSachDto, TblSach>();
            CreateMap<SachItem, CUSachDto>();
            CreateMap<TblSach, SachItem>();

            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
        }
    }
}
