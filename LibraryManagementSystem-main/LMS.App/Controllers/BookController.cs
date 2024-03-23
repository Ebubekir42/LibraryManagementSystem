using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.Entities.RequestParameters;
using LMS.App.Models;
using LMS.Entities.Models;

namespace LMS.App.Controllers
{
    public class BookController : Controller
    {
        private readonly IServiceManager _manager;
        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index(BookListViewModel b)
        {
            ViewData["Title"] = "Kitaplar";
            IEnumerable<Book> books;
            List<Book> lBook;
            if (b.languageId is null )
                books = _manager.BookService.GetAllBooks(false);            
            else
            {
                if(b.languageId.Count() > 1)
                {
                    var dizi = b.languageId.Split(',');
                    books = _manager.BookService.GetAllBooks(false);
                    lBook = new List<Book>();
                    foreach(Book book in books)
                    {
                        foreach(var d in dizi)
                        {
                            if (book.LanguageId.Equals(int.Parse(d)))
                            {
                                lBook.Add(book);
                                break;
                            }
                        }
                    }
                    books = lBook;
                }
                else
                    books = _manager.BookService.GetAllBooks(false).Where(x => x.LanguageId.Equals(int.Parse(b.languageId)));
            }
            if (b.categoryId is null)
                books = books;
            else
            {
                if(b.categoryId.Count() > 1)
                {
                    var dizi = b.categoryId.Split(',');
                    lBook = new List<Book>();
                    foreach(var book in books)
                    {
                        foreach(var d in dizi)
                        {
                            if (book.CategoryId.ToString().Equals(d))
                            {
                                lBook.Add(book);
                                break;
                            }
                        }
                    }
                    books = lBook;
                }
                else
                {
                    books = books.Where(x => x.CategoryId.ToString().Equals(b.categoryId));
                }
            }
            if (b.authorId is null)
                books = books;
            else
            {
                if (b.authorId.Count() > 1)
                {
                    var dizi = b.authorId.Split(',');
                    lBook = new List<Book>();
                    foreach (var book in books)
                    {
                        var bookAuthor = _manager.BookAuthorService.GetOneBookAuthorsByBook(book.BookId, false);

                        foreach (var author in bookAuthor)
                        {
                            foreach (var d in dizi)
                            {
                                if (author.AuthorId.ToString().Equals(d))
                                {
                                    if (!lBook.Contains(book))
                                    {
                                        lBook.Add(book);
                                    }
                                }
                            }
                        }
                        
                    }
                    books = lBook;
                }
                else
                {
                    lBook = new List<Book>();
                    foreach(var book in books)
                    {
                        var bookAuthor = _manager.BookAuthorService.GetOneBookAuthorsByBook(book.BookId, false);
                        foreach(var author in bookAuthor)
                        {
                            if (author.AuthorId.ToString().Equals(b.authorId))
                            {
                                if (!lBook.Contains(book))
                                {
                                    lBook.Add(book);
                                }
                            }
                        }
                    }
                    books = lBook;
                }
            }
            if (b.formatId is null)
                books = books;
            else
            {
                if (b.formatId.Count() > 1)
                {
                    var dizi = b.formatId.Split(',');
                    lBook = new List<Book>();
                    foreach (var book in books)
                    {
                        foreach (var d in dizi)
                        {
                            if (book.FormatId.ToString().Equals(d))
                            {
                                lBook.Add(book);
                                break;
                            }
                        }
                    }
                    books = lBook;
                }
                else
                {
                    books = books.Where(x => x.FormatId.ToString().Equals(b.formatId));
                }
            }
            if (b.contentTypeId is null)
                books = books;
            else
            {
                if (b.contentTypeId.Count() > 1)
                {
                    var dizi = b.contentTypeId.Split(',');
                    lBook = new List<Book>();
                    foreach (var book in books)
                    {
                        foreach (var d in dizi)
                        {
                            if (book.ContentTypeId.ToString().Equals(d))
                            {
                                lBook.Add(book);
                                break;
                            }
                        }
                    }
                    books = lBook;
                }
                else
                {
                    books = books.Where(x => x.ContentTypeId.ToString().Equals(b.contentTypeId));
                }
            }
            if (b.carrierTypeId is null)
                books = books;
            else
            {
                if (b.carrierTypeId.Count() > 1)
                {
                    var dizi = b.carrierTypeId.Split(',');
                    lBook = new List<Book>();
                    foreach (var book in books)
                    {
                        foreach (var d in dizi)
                        {
                            if (book.CarrierTypeId.ToString().Equals(d))
                            {
                                lBook.Add(book);
                                break;
                            }
                        }
                    }
                    books = lBook;
                }
                else
                {
                    books = books.Where(x => x.CarrierTypeId.ToString().Equals(b.carrierTypeId));
                }
            }
            if (b.mediaTypeId is null)
                books = books;
            else
            {
                if (b.mediaTypeId.Count() > 1)
                {
                    var dizi = b.mediaTypeId.Split(',');
                    lBook = new List<Book>();
                    foreach (var book in books)
                    {
                        foreach (var d in dizi)
                        {
                            var carrierType = _manager.CarrierTypeService.GetCarrierType(book.CarrierTypeId, false);
                            if (carrierType.MediaTypeId.ToString().Equals(d))
                            {
                                lBook.Add(book);
                                break;
                            }
                        }
                    }
                    books = lBook;
                }
                else
                {
                    lBook = new List<Book>();
                    foreach(var book in books)
                    {
                        var carrierType = _manager.CarrierTypeService.GetCarrierType(book.CarrierTypeId, false);
                        if(carrierType.MediaTypeId.ToString().Equals(b.mediaTypeId))
                            lBook.Add(book);
                    }
                    books = lBook;
                    //books = books.Where(x => x.FormatId.ToString().Equals(b.formatId));
                }
            }

            if (b.yayin_Yeri is null)
                books = books;
            else
            {
                var list = b.yayin_Yeri.Split(',');
                if (list.Count() > 1)
                {
                    IEnumerable<Book> books_ = new List<Book>();
                    foreach (var book in books)
                    {
                        foreach (var d in list)
                        {
                            if (d.Equals(book.Yayin_Yeri))
                            {
                                books_.Append(book);
                                break;
                            }
                        }
                    }
                    books = books_;
                }
                else
                {
                    books = books.Where(x => x.Yayin_Yeri.Equals(b.yayin_Yeri));
                }
            }
            if (b.yayin_layan is null)
                books = books;
            else
            {
                var list = b.yayin_layan.Split(',');
                if (list.Count() > 1)
                {
                    IEnumerable<Book> books_ = new List<Book>();
                    foreach (var book in books)
                    {
                        foreach (var d in list)
                        {
                            if (d.Equals(book.Yayinlayan))
                            {
                                books_.Append(book);
                                break;
                            }
                        }
                    }
                    books = books_;
                }
                else
                {
                    books = books.Where(x => x.Yayinlayan.Equals(b.yayin_layan));
                }
            }
            b.TotalCount = books.Count();
            List<Category> categories = new List<Category>();
            foreach(var book in books)
            {
                int durum = 1;
                foreach(var category in categories)
                {
                    if (category.CategoryId.Equals(book.CategoryId))
                    {
                        durum = 0;
                        break;
                    }
                }
                if(durum == 1)
                    categories.Add(_manager.CategoryService.GetOneCategory(book.CategoryId, false));
                
            }
            List<Format> formats = new List<Format>();
            foreach(var book in books)
            {
                int durum = 1;
                foreach(var format in formats)
                {
                    if (format.FormatId.Equals(book.FormatId))
                    {
                        durum = 0;
                        break;
                    }
                }
                if(durum == 1)
                    formats.Add(_manager.FormatService.GetFormat(book.FormatId, false));
            }
            List<ContentType> contentTypes = new List<ContentType>();
            foreach (var book in books)
            {
                int durum = 1;
                foreach (var format in contentTypes)
                {
                    if (format.ContentTypeId.Equals(book.ContentTypeId))
                    {
                        durum = 0;
                        break;
                    }
                }
                if (durum == 1)
                    contentTypes.Add(_manager.ContentTypeService.GetContentType(book.ContentTypeId, false));
            }
            List<CarrierType> carrierTypes = new List<CarrierType>();
            foreach (var book in books)
            {
                int durum = 1;
                foreach (var format in carrierTypes)
                {
                    if (format.CarrierTypeId.Equals(book.CarrierTypeId))
                    {
                        durum = 0;
                        break;
                    }
                }
                if (durum == 1)
                    carrierTypes.Add(_manager.CarrierTypeService.GetCarrierType(book.CarrierTypeId, false));
            }
            List<MediaType> mediaTypes= new List<MediaType>();
            foreach (var book in books)
            {
                int durum = 1;
                foreach (var mediaType in mediaTypes)
                {
                    var carrierType = _manager.CarrierTypeService.GetCarrierType(book.CarrierTypeId, false);

                    if (mediaType.MediaTypeId.Equals(carrierType.MediaTypeId))
                    {
                        durum = 0;
                        break;
                    }
                }
                if (durum == 1)
                {
                    var carrierType = _manager.CarrierTypeService.GetCarrierType(book.CarrierTypeId, false);
                    mediaTypes.Add(_manager.MediaTypeService.GetMediaType(carrierType.MediaTypeId, false));
                }
            }
            List<Language> languages = new List<Language>();
            foreach(var book in books)
            {
                int durum = 1;
                foreach(var language in languages)
                {
                    if (language.LanguageId.Equals(book.LanguageId))
                    {
                        durum = 0;
                        break;
                    }
                }
                if(durum == 1)
                    languages.Add(_manager.LanguageService.GetLanguage(book.LanguageId, false));
                
            }
            List<Author> authors_ = new List<Author>();
            foreach(var book in books)
            {
                int durum = 1;
                foreach(var author in authors_)
                {
                    var bookAuthors = _manager.BookAuthorService.GetOneBookAuthorsByBook(book.BookId, false);
                    foreach(var authorAuthor in bookAuthors)
                    {
                        if (author.AuthorId.Equals(authorAuthor.AuthorId))
                        {
                            durum = 0;
                            break;
                        }
                    }
                    if (durum == 0)
                        break;
                }
                if(durum == 1)
                {
                    var bookAuthors = _manager.BookAuthorService.GetOneBookAuthorsByBook(book.BookId, false);
                    foreach(var authorAuthor in bookAuthors)
                    {
                        authors_.Add(_manager.AuthorService.GetOneAuthor(authorAuthor.AuthorId, false));
                    }
                }
                    
            }
            var authors = authors_;
            List<String> YayinYeri = new List<String>();
            foreach (var book in books)
            {
                if(!YayinYeri.Contains(book.Yayin_Yeri))
                    YayinYeri.Add(book.Yayin_Yeri);
            }
            List<String> Yayinlayan = new List<String>();
            foreach (var book in books)
            {
                if (!Yayinlayan.Contains(book.Yayinlayan))
                    Yayinlayan.Add(book.Yayinlayan);
            }
            books = books.Skip((b.PageNumber - 1) * b.PageSize).Take(b.PageSize);

            return View(new BookListViewModel()
            {
                contentTypeId = b.contentTypeId,
                carrierTypeId = b.carrierTypeId,
                mediaTypeId = b.mediaTypeId,
                categoryId = b.categoryId,
                formatId = b.formatId,
                languageId = b.languageId,
                authorId = b.authorId,
                yayin_Yeri = b.yayin_Yeri,
                yayin_layan = b.yayin_layan,
                filter = b.filter,
                value = b.value,
                Books = books,
                ContentTypes = contentTypes,
                CarrierTypes = carrierTypes,
                MediaTypes = mediaTypes,
                Categories = categories,
                Languages = languages,
                Formats = formats,
                Authors = authors,
                YayinYeri = YayinYeri,
                Yayinlayan = Yayinlayan,
                Pagination = new Pagination() { CurrentPage = b.PageNumber, ItemsPerPage = b.PageSize, TotalItems = b.TotalCount, TotalPages = (int)Math.Ceiling((decimal)b.TotalCount / b.PageSize) }
            });
        }
    }
}
