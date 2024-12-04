using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Domain.ModelViews;
using Infrastructure.Repositories;

namespace Application.Services
{
    public interface ISachService
    {
        Task<Pagination<SachItem>> GetSachGrid(int pageIndex, int pageSize);
        Task<List<SachItem>> GetSachs();
        Task<TblSach> AddSach(CUSachDto model);
        Task<TblSach> UpdateSach(CUSachDto model);
        Task DeleteSach(int id);
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

        public async Task DeleteSach(int id)
        {
            await _sachRepository.DeleteAsync(id);
        }

        public Task<Pagination<SachItem>> GetSachGrid(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SachItem>> GetSachs()
        {
            var sachs = await _sachRepository.GetAllAsync();
            return _mapper.Map<List<SachItem>>(sachs);
        }

        public async Task<TblSach> UpdateSach(CUSachDto model)
        {
            var sach = _mapper.Map<TblSach>(model);
            await _sachRepository.UpdateAsync(sach);
            return sach;
        }
    }
}
