using Acme.BookStore.Authors;
using Acme.BookStore.BookMarks;
using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        //private readonly IBookRepository _bookRepository;
        private readonly IRepository<Book,Guid> _bookRepository;

        private readonly IAuthorRepository _authorRepository;

        private readonly AuthorManager _authorManager;

        private readonly IRepository<BookMark, Guid> _bookMarkRepository;


        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository, IAuthorRepository authorRepository, AuthorManager authorManager,
            IRepository<BookMark, Guid> bookMarkRepository)
        {
            _bookMarkRepository = bookMarkRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        /// <summary>
        /// 初始化数据处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _bookRepository.GetCountAsync() > 0)
                return;
            if (await _authorRepository.GetCountAsync() <= 0)
            {
                var authorLi = await _authorRepository.InsertAsync(
                    await _authorManager.CreateAsync(
                        "Li", new DateTime(1993, 08, 25),
                        "qwertyuiopasdfghjkl")
                    );

                var authorJun = await _authorRepository.InsertAsync(
                   await _authorManager.CreateAsync(
                       "Jun", new DateTime(1993, 08, 25),
                       "sadfkjsdfsaoisdadgfsagdjskssgdladsgafjsfjlskdejfjsfjsaklfjserdofisjdfklsjdfoisdjflskdfjsdhsofjsldkfjsodfisjdkfsiodfjskfsjlgsgijgsagsgsdgsagwgehrtntvsvdsdavvsfbsbsbsfabbsfgsagsdagsadg")
                   );

                if (await _bookRepository.GetCountAsync() <= 0)
                {
                   var bookHD= await _bookRepository.InsertAsync(
                        new Book()
                        {
                            AuthorId = authorLi.Id,
                            Name = "2021荒岛日记",
                            Type = BookType.Adventure,
                            PublishDate = new DateTime(2021, 5, 6),
                            Price = 19.84f,
                            IsTrue = BookIsTrue.True
                        },
                        autoSave: true
                        ) ;

                   var bookKB =  await _bookRepository.InsertAsync(
                        new Book()
                        {
                            AuthorId = authorJun.Id,
                            Name = "2021恐怖小船",
                            Type = BookType.Horror,
                            PublishDate = new DateTime(2021, 5, 6),
                            Price = 42.0f,
                            IsTrue = BookIsTrue.True
                        },
                        autoSave: true
                        );
                    if (await _bookMarkRepository.GetCountAsync() <= 0)
                    {

                        await _bookMarkRepository.InsertAsync(
                            new BookMark()
                            {
                                Name = "testBookMark",
                                BookId = bookHD.Id,
                                PageNum = 1,
                                RowNum = 10,
                                BookMarkContent = "123456",
                                ContentLength = 6,
                                StartingWordNum = 5

                            },
                            autoSave: true);

                        await _bookMarkRepository.InsertAsync(
                            new BookMark()
                            {
                                Name = "testBookMark2",
                                BookId = bookKB.Id,
                                PageNum = 1,
                                RowNum = 10,
                                BookMarkContent = "1234567",
                                ContentLength = 7,
                                StartingWordNum = 5

                            },
                            autoSave: true);
                    }
                }
            }

        }
    }
}
