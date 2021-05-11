$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'BookMarks/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'BookMarks/EditModal');

    var dataTable = $('#BookMarksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.bookMarks.bookMark.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('BookStore.BookMarks.Edit'),/*abp.auth.isGranted("按钮名称") 判断是否存在操作权限*/
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('BookStore.BookMarks.Delete'),/*abp.auth.isGranted("按钮名称") 判断是否存在操作权限*/
                                    confirmMessage: function (data) {
                                        return l('BookMarkDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        acme.bookStore.bookMarks.bookMark
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data:"name"
                },
                {
                    title: l('Book'),
                    data: "bookName"
                },
                {
                    title: l('BookMarkContent'),
                    data: "bookMarkContent"
                },
                {
                    title: l('ContentLength'),
                    data: "contentLength"
                },
                {
                    title: l('PageNum'),
                    data: "pageNum"
                },
                {
                    title: l('RowNum'),
                    data: "rowNum"
                },
                {
                    title: l('StartingWordNum'),
                    data: "startingWordNum"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewBookMarkButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});