using Application.Services;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BooksController : BaseController
    {
        private readonly ISachService _sachService;
        public BooksController(ISachService sachService, INotyfService notyfService, IHttpContextAccessor httpContextAccessor, ILogger<BaseController> logger, IMapper mapper) : base(notyfService, httpContextAccessor, logger, mapper)
        {
            _sachService = sachService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? keySearch, int? pageIndex = 0, int? pageSize = 10)
        {
            var bookPage = await _sachService.GetSachGrid(keySearch, pageIndex, pageSize);
            return View(bookPage);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("SMasach,STensach,STenTg,IDongia,ISoluong,SNxb,STheloai")] CUSachDto book)
        {
            if (ModelState.IsValid)
            {
                if (await IsExistBookId(book.SMasach))
                {
                    _notyfService.Error("Mã sách đã tồn tại");
                    return View(book);
                }

                var createRs = await _sachService.AddSach(book);
                if (createRs != null)
                {
                    _notyfService.Success("Thêm dữ liệu thành công");
                    return RedirectToAction("Index", "Books");
                }
                _notyfService.Error("Thêm dữ liệu thất bại");
                return View(book);
            }
            _notyfService.Error("Vui lòng nhập đầy đủ dữ liệu");
            return View(book);
        }

        // GET: Brand/Edit/Id
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var data = _mapper.Map<CUSachDto>(await _sachService.GetSachs(id));
            if (data == null)
            {
                _notyfService.Error("Không tìm thấy sách");
                return RedirectToAction("Index", "Books");
            }
            return View(data);
        }

        // POST: Brand/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("SMasach,STensach,STenTg,IDongia,ISoluong,SNxb,STheloai")] CUSachDto book)
        {
            if (ModelState.IsValid)
            {
                var updateRs = await _sachService.UpdateSach(book);
                if (updateRs != null)
                {
                    _notyfService.Success("Cập nhật dữ liệu thành công");
                    return RedirectToAction("Index", "Books");
                }
                _notyfService.Error("Thêm dữ liệu thất bại");
                return View(book);
            }
            _notyfService.Error("Vui lòng nhập đầy đủ dữ liệu");
            return View(book);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                await _sachService.DeleteSach(id);
                _notyfService.Success("Xóa dữ liệu thành công");
            }
            catch (Exception ex)
            {
                _notyfService.Error("Đã có lỗi xảy ra!");
            }
            return RedirectToAction("Index", "Books");
        }

        private async Task<bool> IsExistBookId(string bookId)
        {
            return await _sachService.GetSachs(bookId) != null;
        }
    }
}
