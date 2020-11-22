using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class ChiTietModel
    {
        public int ct_id { get; set; }
        public int tour_id { get; set; }
        public int dd_id { get; set; }
        public int ct_thutu { get; set; }
        public static List<ChiTietModel> getAll()
        {
            List<ChiTietModel> list = new List<ChiTietModel>();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_chitiet";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    ChiTietModel ct = new ChiTietModel();
                    ct.ct_id = reader.GetInt32(0);
                    ct.tour_id = reader.GetInt32(1);
                    ct.dd_id= reader.GetInt32(2);
                    ct.ct_thutu = reader.GetInt32(3);
                    list.Add(ct);
                }
                reader.NextResult();
            }
            return list;
        }
        public static ChiTietModel getDetail(int id)
        {
            ChiTietModel ct = new ChiTietModel();
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tour_chiphi WHERE ct_id=id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                ct.ct_id = reader.GetInt32(0);
                ct.tour_id = reader.GetInt32(1);
                ct.dd_id = reader.GetInt32(2);
                ct.ct_thutu = reader.GetInt32(3);
            }
            return ct;
        }
        public static void Insert(ChiTietModel ct)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "INSERT INTO tour_chitiet(tour_id, dd_id, ct_thutu) VALUES @tourid, @ddid, @thutu";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@tourid", ct.tour_id);
            cmd.Parameters.AddWithValue("@ddid", ct.dd_id);
            cmd.Parameters.AddWithValue("@thutu", ct.ct_thutu);

            cmd.ExecuteNonQuery();
        }

        public static void Update(ChiTietModel ct)
        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "UPDATE tour_chitiet SET tour_id = @tourid, dd_id = @ddid, ct_thutu = @thutu WHERE ct_id = @id";

            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@id", ct.ct_id);
            cmd.Parameters.AddWithValue("@tourid", ct.tour_id);
            cmd.Parameters.AddWithValue("@ddid", ct.dd_id);
            cmd.Parameters.AddWithValue("@thutu", ct.ct_thutu);

            cmd.ExecuteNonQuery();
        }
    }
}
