using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookBL bookBL;

        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        
        [HttpPost("addbooks")]
        public IActionResult AddBooks(BookModel bookModel)
        {
            {
                try
                {
                    this.bookBL.AddBooks(bookModel);
                    return this.Ok(new { success = true, message = $"Book added Successfully  {bookModel.BookName}" });
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
        [HttpGet("GetAllBooks")]
        public ActionResult GetAllBookModels()
        {
            try
            {
                List<BookModel> bookTables = new List<BookModel>();
                bookTables = this.bookBL.GetAllBookModels().ToList();
                if (bookTables != null)
                {
                    return this.Ok(new { success = true, message = $"Successs :- These are the AllBooks", response = bookTables });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Get AllBooks Data is not Found" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [HttpGet("GetBookBYID")]
        public ActionResult GetBookModel(int? BookId)
        {
            try
            {
                if (BookId != null)
                {
                    var result = this.bookBL.GetBookModel(BookId);
                    return this.Ok(new { success = true, message = $"Successs :- This is the Book by That ID", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Get Book Data by That ID is not Found" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [Authorize]
        [HttpPut("BookUpdate")]
        public ActionResult updateBook(BookModel bookModel)
        {
            try
            {
                this.bookBL.updateBook(bookModel);
                return this.Ok(new { success = true, message = $"Book updated Successfully  {bookModel.BookName}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        [HttpDelete("DeleteBook")]
        public ActionResult deleteBook(int? BookId)
        {
            try
            {
                //if (BookId != null)
                //{
                //    return this.BadRequest(new { success = false, message = "Enter the Book ID" });
                //}
                var Book = this.bookBL.GetBookModel(BookId);
                if (Book != null)
                {
                    this.bookBL.deleteBook(Book);
                    return this.Ok(new { success = true, message = $"Successs :- {Book.BookName} is Deleted" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = $"Fail :- {Book.BookName} is Not Deleted" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
