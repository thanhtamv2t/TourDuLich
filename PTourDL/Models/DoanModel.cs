using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class DoanModel
    {
        public int doan_id { get; set; }
        public int tour_id { get; set; }
        public string doan_ten { get; set; }
        public DateTime doan_ngaydi { get; set; }
        public DateTime doan_ngayve { get; set; }
        public string doan_chitietchuongtrinh { get; set; }
        public static List<DoanModel> getAll()
        {
            List<DoanModel> list = new List<DoanModel>();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_doan";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    DoanModel doan = new DoanModel();
                    doan.doan_id = reader.GetInt32(0);
                    doan.tour_id = reader.GetInt32(1);
                    doan.doan_ten = reader.GetString(2);
                    doan.doan_ngaydi = reader.GetDateTime(3);
                    doan.doan_ngayve = reader.GetDateTime(4);
                    doan.doan_chitietchuongtrinh = reader.GetString(5);
                    list.Add(doan);
                }
                reader.NextResult();
            }
            return list;
        }
        public static DoanModel getDetail(int id)
        {
            DoanModel doan = new DoanModel();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_doan WHERE doan_id=id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                doan.doan_id = reader.GetInt32(0);
                doan.tour_id = reader.GetInt32(1);
                doan.doan_ten = reader.GetString(2);
                doan.doan_ngaydi = reader.GetDateTime(3);
                doan.doan_ngayve = reader.GetDateTime(4);
                doan.doan_chitietchuongtrinh = reader.GetString(5);
            }
            return doan;
        }
        public static void Insert(DoanModel doan)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "INSERT INTO tour_doan(tour_id, doan_ten, doan_ngaydi, doan_ngayve, doan_chitietchuongtrinh) VALUES @tourid, @ten, @ngaydi, @ngayve, @chitiet";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@tourid", doan.tour_id);
            cmd.Parameters.AddWithValue("@ten", doan.doan_ten);
            cmd.Parameters.AddWithValue("@ngaydi", doan.doan_ngaydi);
            cmd.Parameters.AddWithValue("@ngayve", doan.doan_ngayve);
            cmd.Parameters.AddWithValue("@chitiet", doan.doan_chitietchuongtrinh);

            cmd.ExecuteNonQuery();
        }

        public static void Update(DoanModel doan)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "UPDATE tour_doan SET tour_id = @tourid, doan_ten = @ten, doan_ngaydi = @ngaydi, doan_ngayve = @ngayve, doan_chitietchuongtrinh = @chitiet WHERE doan_id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", doan.doan_id);
            cmd.Parameters.AddWithValue("@tourid", doan.tour_id);
            cmd.Parameters.AddWithValue("@ten", doan.doan_ten);
            cmd.Parameters.AddWithValue("@ngaydi", doan.doan_ngaydi);
            cmd.Parameters.AddWithValue("@ngayve", doan.doan_ngayve);
            cmd.Parameters.AddWithValue("@chitiet", doan.doan_chitietchuongtrinh);

            cmd.ExecuteNonQuery();
        }
    }
}
