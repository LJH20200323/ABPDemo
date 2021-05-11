using Acme.BookStore.Authors;
using Acme.BookStore.BookMarks;
using Acme.BookStore.Books;
using AutoMapper;

namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            /*实体间类型关联*/
            CreateMap<BookDto, CreateUpdateBookDto>();

            CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();
            CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel, UpdateAuthorDto>();

            CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
            CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

            CreateMap<Pages.BookMarks.CreateModalModel.CreateBookMarkViewModel, CreateUpdateBookMarkDto>();
            CreateMap<BookMarkDto, Pages.BookMarks.EditModalModel.EditBookMarkViewModel>();
            CreateMap<Pages.BookMarks.EditModalModel.EditBookMarkViewModel, CreateUpdateBookMarkDto>();
            //Define your AutoMapper configuration here for the Web project.
        }
    }
}
