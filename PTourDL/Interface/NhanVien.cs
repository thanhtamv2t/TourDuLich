using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTourDL.Interface
{
    public class NhanVien
    {
        public int nv_id { get; set; }
        public string nv_ten { get; set; }
        public string nv_sdt { get; set; }
        public DateTime nv_ngaysinh { get; set; }
        public string nv_email { get; set; }
        public string nv_nhiemvu { get; set; }
    }
}