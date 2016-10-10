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
        public IHttpActionResult Post(Mahasiswa mahasiswa)
        {
            MahasiswaDAL mhsDAL = new MahasiswaDAL();
            try
            {
                mhsDAL.Insert(mahasiswa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Mahasiswa/5
        public IHttpActionResult Put(string id,Mahasiswa mhs)
        {
            MahasiswaDAL mhsDAL = new MahasiswaDAL();
            Mahasiswa result = mhsDAL.GetById(id);

            try
            {
                if(result!=null)
                {
                    mhsDAL.Update(mhs);
                    return Ok();
                }
                else
                {
                    return BadRequest("Data not found !");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Mahasiswa/5
        public IHttpActionResult Delete(string id)
        {
            MahasiswaDAL mhsDAL = new MahasiswaDAL();
            Mahasiswa result = mhsDAL.GetById(id);

            try
            {
                if (result != null)
                {
                    mhsDAL.Delete(id);
                    return Ok();
                }
                else
                {
                    return BadRequest("Data not found !");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
