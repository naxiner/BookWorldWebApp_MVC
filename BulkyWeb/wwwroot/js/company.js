var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/company/getall' },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'streetAdress', "width": "15%" },
            { data: 'city', "width": "15%" },
            { data: 'state', "width": "15%" },
            { data: 'phoneNumber', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-60 btn-group" role="group">
                    <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil"></i> Редагувати</a>
                    <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-primary"> <i class="bi bi-trash3""></i> Видалити</a>
                    <div>
                    `
                },
                "width": "21%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Ви впевнені?",
        text: "Ви не зможене повернути видалений об'єкт!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Так, видалити!",
        cancelButtonText: "Відмінити"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}