using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PTourDL.Interface;
using TourDL.Models;

namespace PTourDL.Controllers
{
    public class NhanVienController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<NhanVien> Get()
        {
            NhanVien[] nvs = NhanVienModel.getAll().ToArray();

            return nvs;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            NhanVien nv = NhanVienModel.GetNhanVien(id);
            return Ok(nv);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] NhanVien nv)
        {
            NhanVien resNV = NhanVienModel.Insert(nv);

            return Ok(resNV);

        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] NhanVien nv)
        {
            NhanVien resNV = NhanVienModel.Update(id, nv);

            return Ok(resNV);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            //Thêm hàm delete rồi gọi vào đ
            NhanVienModel.Delete(id);
        }
    }
}