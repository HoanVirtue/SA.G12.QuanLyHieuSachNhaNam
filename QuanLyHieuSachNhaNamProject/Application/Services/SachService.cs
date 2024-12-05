using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Domain.ModelViews;
using Infrastructure.Repositories;

namespace Application.Services
{
    public interface ISachService
    {
        Task<Pagination<SachItem>> GetSachGrid(string? keySearch = "", int? pageIndex = 0, int? pageSize = 10);
        Task<List<SachItem>> GetSachs();
        Task<SachItem> GetSachs(string id);
        Task<TblSach> AddSach(CUSachDto model);
        Task<TblSach> UpdateSach(CUSachDto model);
        Task DeleteSach(string id);
    }
    public class SachService : ISachService
    {
        private readonly ISachRepository _sachRepository;
        private readonly IMapper _mapper;
        public SachService(ISachRepository sachRepository, IMapper mapper)
        {
            _sachRepository = sachRepository;
            _mapper = mapper;
        }

        public async Task<TblSach> AddSach(CUSachDto model)
        {
            var sach = _mapper.Map<TblSach>(model);
            await _sachRepository.AddAsync(sach);
            return sach;
        }

        public async Task DeleteSach(string id)
        {
            await _sachRepository.DeleteAsync(id);
        }

        public async Task<Pagination<SachItem>> GetSachGrid(string? keySearch = "", int? pageIndex = 0, int? pageSize = 10)
        {
            if (string.IsNullOrEmpty(keySearch))
                keySearch = "";
            var sachPage = await _sachRepository.GetGridAsync(
                filter: s => s.STensach.ToLower().Contains(keySearch.ToLower()) ||
                            s.STenTg.ToLower().Contains(keySearch.ToLower()) ||
                            s.SNxb.ToLower().Contains(keySearch.ToLower()) ||
                            s.STheloai.ToLower().Contains(keySearch.ToLower()),
                pageIndex: pageIndex,
                pageSize: pageSize
                );

            //var sachPage = await _sachRepository.GetGridAsync(
            //    pageIndex: pageIndex,
            //    pageSize: pageSize
            //    );
            return _mapper.Map<Pagination<SachItem>>(sachPage);
        }

        public async Task<List<SachItem>> GetSachs()
        {
            var sachs = await _sachRepository.GetAllAsync();
            return _mapper.Map<List<SachItem>>(sachs);
        }

        public async Task<SachItem> GetSachs(string id)
        {
            return _mapper.Map<SachItem>(await _sachRepository.GetByIdAsync(id));
        }

        public async Task<TblSach> UpdateSach(CUSachDto model)
        {
            var sach = _mapper.Map<TblSach>(model);
            await _sachRepository.UpdateAsync(sach);
            return sach;
        }
    }
}
