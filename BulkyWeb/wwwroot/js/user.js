var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'email', "width": "15%" },
            { data: 'phoneNumber', "width": "15%" },
            { data: 'company.name', "width": "15%" },
            { data: '', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-60 btn-group" role="group">
                    <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil"></i> Edit</a>
                    <a onClick=Delete('/admin/company/delete/${data}') class="btn btn-primary"> <i class="bi bi-trash3""></i> Delete</a>
                    <div>
                    `
                },
                "width": "21%"
            }
        ]
    });
}