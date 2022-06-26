using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        string AddBooks(BookModel bookModel);
        List<BookModel> GetAllBookModels();
        BookModel GetBookModel(int? id);
        void updateBook(BookModel bookModel);
        void deleteBook(BookModel bookModel);
    }
}
