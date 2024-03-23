using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;
using LMS.Entities.Dtos;
using AutoMapper;

namespace LMS.Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public void CreateOneBook(BookDtoForInsertion bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            _manager.Book.CreateOneBook(book);

            List<BookAuthor> bookAuthors = new List<BookAuthor>();
            foreach (var authorId in bookDto.AuthorIds)
            {
                bookAuthors.Add(new BookAuthor() { BookId = book.BookId, AuthorId = authorId });
            }
            book.BookAuthors = bookAuthors;
            _manager.Book.CreateBookAuthor(book);
            _manager.Save();
        }
        public BookDtoForUpdate GetOneBookForUpdate(int bookId, bool trackChanges)
        {
            var book = _manager.Book.GetOneBook(bookId, trackChanges);
            var bookDto = _mapper.Map<BookDtoForUpdate>(book);
            return bookDto;
        }
        public void DeleteOneBook(int id)
        {
            Book? book = GetOneBook(id, false);
            var books = GetAllBooks(false).ToList();
            var bookDtoForDeletes = GetBookDtoForDeletes();
            List<BookDtoForDelete> bookDtoForDeleteList = new List<BookDtoForDelete>();
            var _bookDto = _mapper.Map<BookDtoForDelete>(book);
            int y = 0;
            foreach (var bookDtoForDelete in bookDtoForDeletes)
            {
                if (bookDtoForDelete.Equals(_bookDto))
                {
                    bookDtoForDelete.ID = books[y].BookId;
                    bookDtoForDelete.Copy = books[y].Kopya;
                    bookDtoForDeleteList.Add(bookDtoForDelete);
                }
                y++;
            }
            if (bookDtoForDeleteList.Count() == 1)
            {
                if (book is not null)
                {
                    _manager.Book.DeleteOneBook(book);
                }
            }
            else
            {
                if (bookDtoForDeleteList[bookDtoForDeleteList.Count() - 1].ID.Equals(book.BookId))
                {
                    _manager.Book.DeleteOneBook(book);
                }
                else
                {
                    _manager.Book.DeleteOneBook(book);
                    books = GetAllBooks(true).ToList();
                    int index = 0;
                    for (; index < bookDtoForDeleteList.Count(); index++)
                        if (bookDtoForDeleteList[index].ID.Equals(book.BookId))
                            break;
                    int i = 0, z = 0;
                    foreach (var bookDtoForDelete in bookDtoForDeleteList)
                    {
                        if (index != i)
                        {
                            foreach (var _book in books)
                            {
                                if (_book.BookId.Equals(bookDtoForDelete.ID))
                                {
                                    _book.Kopya = $"k.{z + 1}";
                                    break;
                                }
                            }
                            z++;
                        }
                        i++;
                    }
                    _manager.Save();
                }
            }

        }
        public void UpdateTheCopy(Book book)
        {
            var books = GetAllBooks(true).ToList();
            var bookDtoForDeletes = GetBookDtoForDeletes();
            List<BookDtoForDelete> bookDtoForDeleteList = new List<BookDtoForDelete>();
            var _bookDto = _mapper.Map<BookDtoForDelete>(book);
            int y = 0;
            foreach (var bookDtoForDelete in bookDtoForDeletes)
            {
                if (bookDtoForDelete.Equals(_bookDto))
                {
                    bookDtoForDelete.ID = books[y].BookId;
                    bookDtoForDelete.Copy = books[y].Kopya;
                    bookDtoForDeleteList.Add(bookDtoForDelete);
                }
                y++;
            }
            if (bookDtoForDeleteList.Count() == 1)
            {
                if (book is not null)
                {
                    _manager.Book.DeleteOneBook(book);
                }
            }
            else
            {
                if (bookDtoForDeleteList[bookDtoForDeleteList.Count() - 1].ID.Equals(book.BookId))
                {
                    _manager.Book.DeleteOneBook(book);
                }
                else
                {
                    int index = 0;
                    for (; index < bookDtoForDeleteList.Count(); index++)
                        if (bookDtoForDeleteList[index].ID.Equals(book.BookId))
                            break;
                    int i = 0, z = 0;
                    foreach (var bookDtoForDelete in bookDtoForDeleteList)
                    {
                        if (index != i)
                        {
                            foreach (var _book in books)
                            {
                                if (_book.BookId.Equals(bookDtoForDelete.ID))
                                {
                                    _book.Kopya = $"k.{z + 1}";
                                    break;
                                }
                            }
                            z++;
                        }
                        i++;
                    }
                    _manager.Book.DeleteOneBook(book);
                }
            }
        }
        public void DeleteAllBooksByBookAuthors(IEnumerable<BookAuthor> bookAuthors)
        {
            var _bookAuthors = bookAuthors.ToList();
            for(int i = _bookAuthors.Count() - 1; i >= 0; i--)
            {
                var book = GetOneBook(_bookAuthors[i].BookId, false);
                if (book is not null)
                    DeleteOneBook(book.BookId);
            }
            //foreach (var bookAuthor in bookAuthors)
            //{
            //    var book = GetOneBook(bookAuthor.BookId, false);
            //    if(book is not null)
            //        DeleteOneBook(book.BookId);
            //}
        }
        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }
        public IEnumerable<Book> GetAllBooksByCategory(int categoryId, bool trackChanges)
        {
            var books = _manager.Book.GetAllBooks(trackChanges).Where(b => b.CategoryId.Equals(categoryId));
            return books;
        }
        public Book? GetOneBook(int id, bool trackChanges)
        {
            Book? book = _manager.Book.GetOneBook(id, trackChanges);
            if (book is null)
                throw new Exception("Book Not Found");
            return book;
        }
        public void UpdateOneBook(BookDtoForUpdate bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _manager.Book.UpdateOneBook(book);


            List<BookAuthor> bookAuthors = new List<BookAuthor>();
            foreach (var authorId in bookDto.AuthorIds)
            {
                bookAuthors.Add(new BookAuthor() { BookId = book.BookId, AuthorId = authorId });
            }
            book.BookAuthors = bookAuthors;
            _manager.BookAuthor.DeleteBookAuthorByIds(bookDto.BookAuthorIds);
            _manager.Save();
            _manager.Book.UploadBookAuthor(book);
        }
        public IEnumerable<BookDtoForDelete> GetBookDtoForDeletes()
        {
            List<BookDtoForDelete> bookDtoForDeletes = new List<BookDtoForDelete>();
            var books = GetAllBooks(false);
            foreach(var book in books)
            {
                var bookDtoForDelete = _mapper.Map<BookDtoForDelete>(book);
                bookDtoForDeletes.Add(bookDtoForDelete);
            }
            return bookDtoForDeletes;
        }
        public IEnumerable<BookDtoForAddAsCopy> GetBookDtoForAddAsCopies()
        {
            List<BookDtoForAddAsCopy> bookDtoForAddAsCopies = new List<BookDtoForAddAsCopy>();
            var books = GetAllBooks(false);
            foreach (var book in books)
            {
                var bookDtoForAddAsCopy = _mapper.Map<BookDtoForAddAsCopy>(book);
                bookDtoForAddAsCopies.Add(bookDtoForAddAsCopy);
            }
            return bookDtoForAddAsCopies;

        }
        public void AddAsCopy(Book book)
        {
            var _bookDto = _mapper.Map<BookDtoForAddAsCopy>(book);
            var bookDtoForAddAsCopies = GetBookDtoForAddAsCopies();
            int count = 1;
            foreach(var bookDto in bookDtoForAddAsCopies)
            {
                if (bookDto.Equals(_bookDto))
                    count++;
            }
            Book _book = _mapper.Map<Book>(_bookDto);
            _book.Kopya = $"k.{count}";
            _manager.Book.CreateOneBook(_book);
            var bookAuthors = _manager.BookAuthor.GetAllBookAuthors(false).Where(b => b.BookId.Equals(book.BookId)).ToList();
            List<BookAuthor> bookAuthorList = new List<BookAuthor>();
            foreach (var bookAuthor in bookAuthors)
            {
                bookAuthorList.Add(new BookAuthor()
                {
                    BookId = bookAuthor.BookId,
                    AuthorId = bookAuthor.AuthorId
                });
            }
            _book.BookAuthors = bookAuthorList;
            _manager.Book.CreateBookAuthor(_book);
            _manager.Save();
        }
        public void LossTheBook(int bookId)
        {
            var book = _manager.Book.GetOneBook(bookId, true);
            book.isLoss = true;
            _manager.Save();
        }



    }
}
