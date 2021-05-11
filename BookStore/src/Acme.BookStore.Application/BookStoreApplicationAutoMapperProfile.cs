﻿using Acme.BookStore.Authors;
using Acme.BookStore.BookMarks;
using Acme.BookStore.Books;
using AutoMapper;

namespace Acme.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            /*实体间类型关联*/
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
            CreateMap<Book,BookLookUpDto>();

            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorLookupDto>();

            CreateMap<BookMark, BookMarkDto>();
            CreateMap<CreateUpdateBookMarkDto,BookMark>();
        }
    }
}