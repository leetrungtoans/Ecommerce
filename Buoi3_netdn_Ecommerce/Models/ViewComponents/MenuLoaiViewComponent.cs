using Buoi3_netdn_Ecommerce.Data;
using Buoi3_netdn_Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Thêm using này

namespace Buoi3_netdn_Ecommerce.Models.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly Hshop2023Context db;
        public MenuLoaiViewComponent(Hshop2023Context context)
        {
            db = context;
        }

        // Đổi tên thành InvokeAsync và trả về Task<IViewComponentResult>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,
                SoLuong = lo.HangHoas.Count
            }).OrderBy(p => p.TenLoai);

            return View(data);
        }
    }
}