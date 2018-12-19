﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrbit.wsapi.ticket.Data.Converter;
using vrbit.wsapi.ticket.Data.VO;
using vrbit.wsapi.ticket.Model;

namespace vrbit.wsapi.ticket.Data.ConvertersImpl
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null)
                return new Book();

            return new Book
            {
                Id = origin.Id.Value,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null)
                return new BookVO();

            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                Price = origin.Price,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<Book> ParseList(List<BookVO> origin)
        {
            if (origin == null)
                return new List<Book>();

            return origin.Select(i => Parse(i)).ToList();
        }

        public List<BookVO> ParseList(List<Book> origin)
        {
            if (origin == null)
                return new List<BookVO>();

            return origin.Select(i => Parse(i)).ToList();
        }
    }
}
