﻿using AssignmentWebApi2.Interfaces;
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

        /// <summary>
        /// You can search for Accounts here.
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     POST /Account
        ///     {
        ///        "userId": null,
        ///        "bankId": null,
        ///        "dateCreated": null
        ///     }
        ///     OR
        ///     
        ///     POST /Account
        ///     {
        ///        "userId": null,
        ///        "bankId": 000,
        ///        "dateCreated": null
        ///     } 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>

        //Get All
        [HttpGet]
            public ActionResult<IEnumerable<Book>> GetAllBooks()
            {
                return Ok(_bookServices.GetAllBooks());
            }

            //Get By id
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

            //Add
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

            //Update
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

            //Delete
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
