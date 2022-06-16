using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
    }
}
