using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crud_api.Models;
using crud_api.Data;

namespace crud_api.Controllers
{
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly DbContextBooks _context;

        public BookController(DbContextBooks context)
        {
            _context = context;
        }

       [HttpGet]
       public ActionResult<IEnumerable<Book>> getBooks()
       {
            var result = _context.Books.ToList();
            
            return result;
       }

       [HttpPost]
       public ActionResult createBook([FromBody] Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            
            return Json(book);
        }
       
       [HttpPut]
        public ActionResult updateBook([FromBody] Book book)
        {
            var result = _context.Books.Find(book.id);

            if (result == null)
            {
                return NotFound();
            }

            result.name = book.name;
            result.pages = book.pages;

            try
            {
              _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return NotFound();
            }


            return NoContent();
        }


        [HttpDelete("{id}")]
       public ActionResult deleteBook(int id)
       {
            var result = _context.Books.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            _context.Books.Remove(result);

            _context.SaveChanges();


            return Ok();
       }
        
    }
}
