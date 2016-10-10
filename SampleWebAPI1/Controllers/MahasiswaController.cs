using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SampleWebAPI1.Models;
using SampleWebAPI1.DAL;

namespace SampleWebAPI1.Controllers
{
    public class MahasiswaController : ApiController
    {
        // GET: api/Mahasiswa
        public IEnumerable<Mahasiswa> Get()
        {
            MahasiswaDAL mhsDAL = new MahasiswaDAL();
            return mhsDAL.GetAll();
        }

        // GET: api/Mahasiswa/5
        public Mahasiswa Get(string id)
        {
            MahasiswaDAL mhsDAL = new MahasiswaDAL();
            return mhsDAL.GetById(id);
        }

        [Route("api/Mahasiswa/GetByName/{nama}")]
        public IEnumerable<Mahasiswa> GetByName(string nama)
        {
            MahasiswaDAL mhsDAL = new MahasiswaDAL();
            return mhsDAL.GetAllByName(nama);
        }

        // POST: api/Mahasiswa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mahasiswa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mahasiswa/5
        public void Delete(int id)
        {
        }
    }
}
