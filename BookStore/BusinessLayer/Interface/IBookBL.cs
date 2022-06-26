using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        string AddBooks(BookModel bookModel);
        List<BookModel> GetAllBookModels();
        BookModel GetBookModel(int? id);
        void updateBook(BookModel bookModel);
        void deleteBook(BookModel bookModel);
    }
}
