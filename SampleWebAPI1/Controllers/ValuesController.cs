using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SampleWebAPI1.Models;

namespace SampleWebAPI1.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private static List<Mahasiswa> lstMhs = new List<Mahasiswa>
        {
            new Mahasiswa
            {
                Nim ="99887788",Nama="Erick",
                Email ="erick@gmail.com",IPK=3.4
            },
            new Mahasiswa
            {
                Nim="98876345",Nama="Bambang",
                Email="bambang@gmail.com",IPK=3.2
            },
            new Mahasiswa
            {
                Nim="99332233",Nama="Budi",
                Email="budi@gmail.com",IPK=3.3
            }
        };

        // GET api/values
        public List<Mahasiswa> Get()
        {
            return lstMhs;
        }

        // GET api/values/99332233
        public Mahasiswa Get(string id)
        {
            var result = lstMhs.Find(m => m.Nim == id);
            return result;
        }

        //custom route
        [Route("api/Values/GetByName/{nama}")]
        public List<Mahasiswa> GetByName(string nama)
        {
            var results = from m in lstMhs
                         where m.Nama.Contains(nama)
                         select m;

            return results.ToList();
        }

        // POST api/values
        public void Post(Mahasiswa mhs)
        {
            lstMhs.Add(mhs);
        }

        // PUT api/values/5
        public void Put(string id,Mahasiswa mhs)
        {
            var result = lstMhs.Find(m => m.Nim == id);
            if(result!=null)
            {
                result.Nama = mhs.Nama;
                result.Email = mhs.Email;
                result.IPK = mhs.IPK;
            }
            else
            {
                throw new Exception("Data not found !");
            }

            
        }

        // DELETE api/values/nim
        public void Delete(string id)
        {
            var result = lstMhs.Find(m => m.Nim == id);
            if(result!=null)
            {
                lstMhs.Remove(result);
            }
            else
            {
                throw new Exception("Data not found !");
            }
        }
    }
}
