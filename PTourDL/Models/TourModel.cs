using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TourDL.Models
{
    public class TourModel
    {
        public int tour_id { get; set; }
        public string tour_ten { get; set; }
        public string tour_mota { get; set; }
        public int loai_id { get; set; }
        public int gia_id { get; set; }
        public static List<TourModel> getAll()
        {
            List<TourModel> list = new List<TourModel>();

            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();
            string sql = "SELECT * FROM tours";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    TourModel tour = new TourModel();
                    tour.tour_id = reader.GetInt32(0);
                    tour.tour_ten = reader.GetString(1);
                    tour.tour_mota = reader.GetString(2);
                    tour.loai_id = reader.GetInt32(3);
                    tour.gia_id = reader.GetInt32(4);
                    list.Add(tour);
                }

                reader.NextResult();


            }
            return list;
        }

        public static void Insert(TourModel tour)

        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();

            string sql = "INSERT INTO tours (tour_ten, tour_mota, loai_id, gia_id) " +
                " VALUES(@tentour, @mota, @loaiid, @giaid)";


            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@tentour", tour.tour_ten);
            cmd.Parameters.AddWithValue("@mota", tour.tour_mota);
            cmd.Parameters.AddWithValue("@loaiid", tour.loai_id);
            cmd.Parameters.AddWithValue("@giaid", tour.gia_id);
            cmd.ExecuteNonQuery();
        }

        public static void Update(TourModel tour)

        {
            string cnnstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cnnstring);
            cnn.Open();

            string sql = "UPDATE tours SET tour_ten = @tentour, tour_mota = @mota, loai_id = @loaiid, gia_id = @giaid WHERE tour_id = @id";


            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", tour.tour_id);
            cmd.Parameters.AddWithValue("@tentour", tour.tour_ten);
            cmd.Parameters.AddWithValue("@mota", tour.tour_mota);
            cmd.Parameters.AddWithValue("@loaiid", tour.loai_id);
            cmd.Parameters.AddWithValue("@giaid", tour.gia_id);
            cmd.ExecuteNonQuery();
        }
    }
}

