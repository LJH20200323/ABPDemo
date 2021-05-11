using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            /*权限组*/
            var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName, L("Permission:BookStore"));

            var booksPermission = bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
            booksPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books.Create"));
            booksPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
            booksPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books.Delete"));

            var authorsPermission = bookStoreGroup.AddPermission(BookStorePermissions.Authors.Default, L("Permission:Authors"));
            authorsPermission.AddChild(BookStorePermissions.Authors.Create, L("Permission:Authors.Create"));
            authorsPermission.AddChild(BookStorePermissions.Authors.Edit, L("Permission:Authors.Edit"));
            authorsPermission.AddChild(BookStorePermissions.Authors.Delete, L("Permission:Authors.Delete"));
            authorsPermission.AddChild(BookStorePermissions.Authors.Update, L("Permission:Authors.Update"));

            var BookMarksPermission = bookStoreGroup.AddPermission(BookStorePermissions.BookMarks.Default, L("Permission:BookMarks"));
            BookMarksPermission.AddChild(BookStorePermissions.BookMarks.Create, L("Permission:BookMarks.Create"));
            BookMarksPermission.AddChild(BookStorePermissions.BookMarks.Edit, L("Permission:BookMarks.Edit"));
            BookMarksPermission.AddChild(BookStorePermissions.BookMarks.Delete, L("Permission:BookMarks.Delete"));
            BookMarksPermission.AddChild(BookStorePermissions.BookMarks.Update, L("Permission:BookMarks.Update"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreResource>(name);
        }
    }
}
