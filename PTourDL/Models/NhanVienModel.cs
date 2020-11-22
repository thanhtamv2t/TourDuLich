using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PTourDL.Interface;
using PTourDL.Models;

namespace TourDL.Models
{
    public class NhanVienModel
    {
        // Tạo mấy cái Object = Interface trong thư mục Interface như thế này nha em
        public static List<NhanVien> getAll()
        {
            // Connect db thay = cai nay het nha 
            Connection.connectDB();

            List<NhanVien> list = new List<NhanVien>();

            string sql = "SELECT * FROM tour_nhanvien";

            SqlCommand cmd = new SqlCommand(sql, Connection.cnn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    NhanVien nv = new NhanVien();
                    nv.nv_id = reader.GetInt32(0);
                    nv.nv_ten = reader.GetString(1);
                    nv.nv_sdt = reader.GetString(2);
                    nv.nv_ngaysinh = reader.GetDateTime(3);
                    nv.nv_email = reader.GetString(4);
                    nv.nv_nhiemvu = reader.GetString(5);
                    list.Add(nv);
                }

                reader.NextResult();
            }
            return list;
        }


        public static NhanVien GetNhanVien(int id)
        {
            // Connect db thay = cai nay het nha 
            Connection.connectDB();

            List<NhanVien> list = new List<NhanVien>();

            string sql = "SELECT * FROM tour_nhanvien WHERE nv_id = @id";

            SqlCommand cmd = new SqlCommand(sql, Connection.cnn);

            cmd.Parameters.AddWithValue("@id", id.ToString());

            SqlDataReader reader = cmd.ExecuteReader();

            NhanVien nv = new NhanVien();

            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    nv.nv_id = reader.GetInt32(0);
                    nv.nv_ten = reader.GetString(1);
                    nv.nv_sdt = reader.GetString(2);
                    nv.nv_ngaysinh = reader.GetDateTime(3);
                    nv.nv_email = reader.GetString(4);
                    nv.nv_nhiemvu = reader.GetString(5);
                    
                }

                reader.NextResult();
            }
            return nv;
        }

        public static NhanVien Insert(NhanVien nv)

        {
            Connection.connectDB();

            string sql = "INSERT INTO tour_nhanvien (nv_ten, nv_sdt, nv_ngaysinh, nv_email, nv_nhiemvu) " +
                " VALUES(@tennv, @sdt, @ngaysinh, @email, @nhiemvu)";


            SqlCommand cmd = new SqlCommand(sql, Connection.cnn);

            cmd.Parameters.AddWithValue("@tennv", nv.nv_ten);
            cmd.Parameters.AddWithValue("@sdt", nv.nv_sdt);
            cmd.Parameters.AddWithValue("@ngaysinh", nv.nv_ngaysinh);
            cmd.Parameters.AddWithValue("@email", nv.nv_email);
            cmd.Parameters.AddWithValue("@nhiemvu", nv.nv_nhiemvu);
            cmd.ExecuteNonQuery();

            return nv;
        }

        public static NhanVien Update(int id, NhanVien nv)

        {
            Connection.connectDB();

            string sql = "UPDATE tour_nhanvien SET nv_ten = @tennv, nv_sdt = @sdt, nv_ngaysinh = @ngaysinh, nv_email = @email, nv_nhiemvu = @nhiemvu WHERE nv_id = @id";

            SqlCommand cmd = new SqlCommand(sql, Connection.cnn);
            cmd.Parameters.AddWithValue("@id", nv.nv_id);
            cmd.Parameters.AddWithValue("@tennv", nv.nv_ten);
            cmd.Parameters.AddWithValue("@sdt", nv.nv_sdt);
            cmd.Parameters.AddWithValue("@ngaysinh", nv.nv_ngaysinh);
            cmd.Parameters.AddWithValue("@email", nv.nv_email);
            cmd.Parameters.AddWithValue("@nhiemvu", nv.nv_nhiemvu);
            cmd.ExecuteNonQuery();

            return nv;
        }

        public static bool Delete(int id)
        {
            Connection.connectDB();

            string sql = "DELETE FROM tour_nhanvien WHERE nv_id = @id";

            SqlCommand cmd = new SqlCommand(sql, Connection.cnn);
            cmd.Parameters.AddWithValue("@id", id.ToString());

            return cmd.ExecuteNonQuery() == 1;
        }

        // Thiếu cái DELETE
    }
}
