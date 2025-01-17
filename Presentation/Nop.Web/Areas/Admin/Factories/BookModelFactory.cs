﻿using DocumentFormat.OpenXml.Wordprocessing;
using Nop.Core.Domain.Books;
using Nop.Services.Books;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Books;
using Nop.Web.Framework.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the Book model factory implementation
    /// </summary>
    public partial class BookModelFactory : IBookModelFactory
    {
        #region Fields

        private readonly IBookService _BookService;

        #endregion

        #region Ctor

        public BookModelFactory( IBookService BookService )
        {
            _BookService = BookService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare Book search model
        /// </summary>
        /// <param name="searchModel">Book search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Book search model
        /// </returns>
        public virtual Task<BookSearchModel> PrepareBookSearchModelAsync(BookSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return Task.FromResult(searchModel);
        }

        /// <summary>
        /// Prepare paged Book list model
        /// </summary>
        /// <param name="searchModel">Book search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Book list model
        /// </returns>
        public virtual async Task<BookListModel> PrepareBookListModelAsync(BookSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get Books
            var Books = await _BookService.GetAllBooksAsync(showHidden: true,
                name: searchModel.SearchName,
                author: searchModel.SearchAuthor,
                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare list model
            var model = new BookListModel().PrepareToGrid(searchModel, Books, () =>
            {
                //fill in model values from the entity
                return Books.Select( Book =>
                {
                    var BookModel =  Book.ToModel<BookModel>();
                    return BookModel;
                });
            });

            return await Task.FromResult(model);
        }

        /// <summary>
        /// Prepare Book model
        /// </summary>
        /// <param name="model">Book model</param>
        /// <param name="Book">Book</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the Book model
        /// </returns>
        public virtual async Task<BookModel> PrepareBookModelAsync(BookModel model, Book book, bool excludeProperties = false)
        {
            if (book != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = book.ToModel<BookModel>();                      
                }
            }

            return await Task.FromResult(model);
        }
        public virtual async Task<List<BookModel>> GetAllBookList()
        {
            //var books = _BookRepository.GetAllAsync(book);

            var books = await _BookService.GetAllBookList(new Book());
            var bookList = new List<BookModel>();

            foreach (var item in books)
            {
                var model = new BookModel() {
                Name = item.Name,
                Author = item.Author,
                PublishDate = item.PublishDate
                };

                bookList.Add(model);
            }

            return bookList;
        }


        #endregion
    }
}