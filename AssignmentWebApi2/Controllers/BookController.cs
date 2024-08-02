using AssignmentWebApi2.Interfaces;
using AssignmentWebApi2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApi2.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
            private readonly IBookServices _bookServices;

            public BookController(IBookServices bookServices)
            {
                _bookServices = bookServices;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Book>> GetAllBooks()
            {
                return Ok(_bookServices.GetAllBooks());
            }

            [HttpGet("{id}")]
            public ActionResult<Book> GetBookById(int id)
            {
                var book = _bookServices.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }

            [HttpPost]
            public ActionResult AddBook([FromBody] Book book)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _bookServices.AddBook(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }

            [HttpPut("{id}")]
            public ActionResult UpdateBook(int id, [FromBody] Book updatedBook)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var book = _bookServices.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }
                _bookServices.UpdateBook(id, updatedBook);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public ActionResult DeleteBook(int id)
            {
                var book = _bookServices.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }
                _bookServices.DeleteBook(id);
                return NoContent();
            }
    }
}
