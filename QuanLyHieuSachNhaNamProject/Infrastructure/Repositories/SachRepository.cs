using AutoMapper;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public interface ISachRepository : IRepository<TblSach>
    {

    }
    public class SachRepository : GenericRepository<TblSach>, ISachRepository
    {
        public SachRepository(QuanLyHieuSachNhaNamContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
