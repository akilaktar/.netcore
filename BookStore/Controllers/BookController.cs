﻿using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookrepository = null;
        public BookController() {
            _bookrepository = new BookRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public List<BookModel> GetAllBooks()
        {
            var a = _bookrepository.GetAllBooks();
            return a;
        }

        public BookModel GetBook(int id)
        {
            return _bookrepository.GetBookById(id);
        }
        public List<BookModel> SearchBook(string bookName , string authorName)
        {
            //return $"Book name is ={bookName} & Author = {a}";
            return _bookrepository.SearchBook(bookName, authorName);
        }
    }
}
