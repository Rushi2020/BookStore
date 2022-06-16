using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL:IBookBL
    {
        IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public string AddBooks(BookModel addBook)
        {
            try
            {
                return bookRL.AddBooks(addBook);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
