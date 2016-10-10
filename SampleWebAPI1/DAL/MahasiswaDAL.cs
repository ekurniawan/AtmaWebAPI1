using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using SampleWebAPI1.Models;
using System.Data.SqlClient;

namespace SampleWebAPI1.DAL
{
    public class MahasiswaDAL 
    {
        private string GetConnectionString()
        {
            return 
                ConfigurationManager
                .ConnectionStrings["SampleKSIDbConnectionString"]
                .ConnectionString;
        }

        public IEnumerable<Mahasiswa> GetAll()
        {
            List<Mahasiswa> lstMhs = new List<Mahasiswa>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Mahasiswa order by Nim";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        lstMhs.Add(new Mahasiswa
                        {
                            Nim = dr["Nim"].ToString(),
                            Nama = dr["Nama"].ToString(),
                            Email = dr["Email"].ToString(),
                            IPK = Convert.ToDouble(dr["IPK"])
                        });
                    }
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstMhs;
        }


        public IEnumerable<Mahasiswa> GetAllByName(string nama)
        {
            List<Mahasiswa> lstMhs = new List<Mahasiswa>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Mahasiswa 
                                  where Nama like @Nama 
                                  order by Nim";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nama", "%" + nama + "%");
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstMhs.Add(new Mahasiswa
                        {
                            Nim = dr["Nim"].ToString(),
                            Nama = dr["Nama"].ToString(),
                            Email = dr["Email"].ToString(),
                            IPK = Convert.ToDouble(dr["IPK"])
                        });
                    }
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstMhs;
        }

        public Mahasiswa GetById(string nim)
        {
            Mahasiswa mhs = new Mahasiswa();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Mahasiswa 
                                  where Nim=@Nim";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nim", nim);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        mhs.Nim = dr["Nim"].ToString();
                        mhs.Nama = dr["Nama"].ToString();
                        mhs.Email = dr["Email"].ToString();
                        mhs.IPK = Convert.ToDouble(dr["IPK"]);
                    }
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return mhs;
        }


        public void Insert(Mahasiswa mhs)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"insert into Mahasiswa(Nim,Nama,Email,IPK) 
                                  values(@Nim,@Nama,@Email,@IPK)";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nim", mhs.Nim);
                cmd.Parameters.AddWithValue("@Nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@Email", mhs.Email);
                cmd.Parameters.AddWithValue("@IPK", mhs.IPK);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public void Update(Mahasiswa mhs)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"update Mahasiswa set Nama=@Nama,Email=@Email,IPK=@IPK 
                                  where Nim=@Nim";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nim", mhs.Nim);
                cmd.Parameters.AddWithValue("@Nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@Email", mhs.Email);
                cmd.Parameters.AddWithValue("@IPK", mhs.IPK);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public void Delete(string nim)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"delete Mahasiswa where Nim=@Nim";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Nim", nim);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
    }

}