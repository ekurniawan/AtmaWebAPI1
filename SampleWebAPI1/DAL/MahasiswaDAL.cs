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

        public Mahasiswa GetById(string nim)
        {

        }
    }

}