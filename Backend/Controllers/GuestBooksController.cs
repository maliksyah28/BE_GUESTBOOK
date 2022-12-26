using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestBooksController : ControllerBase
    {
        private readonly IRepository repository;
        public GuestBooksController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public virtual ActionResult Get()
        {
            var get = repository.Get();
            if (get.Count() != 0)
            {
                return StatusCode(200, 
                    new
                    {
                        status = HttpStatusCode.OK,
                        message = get.Count() + "Data Ditemukan",
                        Data = get
                    });
            }
            else
            {
                return StatusCode(404,
                    new
                    {
                        status = HttpStatusCode.NotFound,
                        message = get.Count() + "Data tidak ditemukan",
                        Data = get
                    });
            }
        }
        [HttpPost]
        public virtual ActionResult Insert(GuestBookModel guestBookModel)
        {
            var insert = repository.Insert(guestBookModel);
            if (insert >= 1)
            {
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = "Data Berhasil Dimasukkan",
                    Data = insert
                });
            }
            else
            {
                return StatusCode(400, new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Gagal Memasukkan Data",
                    Data = insert
                });
            }
        }
        [HttpGet("{Id}")]
        public virtual ActionResult Get(int Id)
        {
            var get = repository.Get(Id);
            if (get != null)
            {
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = "Data Ditemukan",
                    Data = get
                });
            }
            else
            {
                return StatusCode(400, new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Data Tidak Ditemukan",
                    Data = get
                });
            }
        }
        [HttpPut("{Id}")]
        public virtual ActionResult Update(GuestBookModel guestBookModel, int Id)
        {
            var update = repository.Update(guestBookModel,Id);
            if (update >= 1)
            {
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = "Data Berhasil Mengupdate",
                    Data = update
                });
            }
            else
            {
                return StatusCode(400, new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Gagal Mengupdate Data",
                    Data = update
                });
            }
        }
        [HttpDelete("{Id}")]
        public virtual ActionResult Delete(int Id)
        {
            var delete = repository.Delete(Id);
            if (delete >= 1)
            {
                return StatusCode(200, new
                {
                    status = HttpStatusCode.OK,
                    message = "Data Berhasil Dihapus",
                    Data = delete
                });
            }
            else
            {
                return StatusCode(500, new
                {
                    status = HttpStatusCode.InternalServerError,
                    message = "Gagal Menghapus Data",
                    Data = delete
                });
            }
        }
    }
}
