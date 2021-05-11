using Acme.BookStore.Authors;
using Acme.BookStore.BookMarks;
using Acme.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.BookStore.EntityFrameworkCore
{
    public static class BookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            /*书籍表数据库设置*/
            builder.Entity<Book>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Books",
                          BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                /*书籍外键AuthorId*/
                b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
            });
            /*作者表数据库设置*/
            builder.Entity<Author>(b => {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Authors", BookStoreConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).HasMaxLength(AuthorConsts.MaxNameLength).IsRequired();
                b.HasIndex(x => x.Name);
            });
            /*书签表数据库设置*/
            builder.Entity<BookMark>(b => {
                b.ToTable(BookStoreConsts.DbTablePrefix + "BookMarks", BookStoreConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.BookMarkContent).IsRequired();
                /*书签外键BookId*/
                b.HasOne<Book>().WithMany().HasForeignKey(x => x.BookId).IsRequired();
            });

          
        }
    }
}