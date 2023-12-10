$(document).ready(function () {
    loadDataTable();
});

var dataTable;
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'email', "width": "15%" },
            { data: 'phoneNumber', "width": "10%" },
            { data: 'company.name', "width": "10%" },
            { data: 'role', "width": "10%" },
            {
                data: { id: 'id', lockoutEnd: 'lockoutEnd' },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `
                        <div class="text-center">
                            <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:205px">
                                <i class="bi bi-lock-fill"></i> Заблоковано
                            </a>
                            <a href="/admin/user/RoleManagment?userId=${data.id}" class="btn btn-success text-white" style="cursor:pointer; width:135px">
                                <i class="bi bi-pencil-square"></i> Дозвіл
                            </a>
                        </div>
                        `
                    }
                    else {
                        return `
                        <div class="text-center">
                            <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer; width:205px">
                                <i class="bi bi-unlock-fill"></i> Розблоковано
                            </a>
                            <a href="/admin/user/RoleManagment?userId=${data.id}" class="btn btn-danger text-white" style="cursor:pointer; width:135px">
                                <i class="bi bi-pencil-square"></i> Дозвіл
                            </a>
                        </div>
                        `
                    }
                },
                "width": "27%"
            }
        ]
    });
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: (data) => {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            } else {
                toastr.error(success.message);
            }
        }
    })
}