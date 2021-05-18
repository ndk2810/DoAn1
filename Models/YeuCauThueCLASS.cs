using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HeThongThueXe.Models
{
    public class YeuCauThueCLASS
    {
        //public int IDKhach { get; set; }
        public string TenKhach { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public int IDHieuXe { get; set; }
        public int IDLoaiXe { get; set; }
        public System.DateTime NgayTao { get; set; }

        public System.DateTime ThoiGianThue { get; set; }
        public System.DateTime ThoiGianTra { get; set; }
        public decimal TongTien { get; set; }
        public string YeuCauKhac { get; set; }
    }
}