$(document).ready(function () {
    $.ajax({
        url: "/Home/getUsers",
        dataSrc: "",
        datatype: "JSON",
        type: "GET",
        success: function (data) {
            var s = '<option value="-1">Please Select a User Name --</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Id + '">' + data[i].FirstName + '</option>';
                console.log(data[i]);
            }
            $("#idUserName").html(s);
        }
    });
});

$(document).ready(function () {
    $('#idUserName').change(function () {
        var idUser = $('#idUserName').val();
        updateTableProjects(idUser);
    });
});

function updateTableProjects(idUser) {
    $('#tableProjects').dataTable().fnClearTable();
    $('#tableProjects').dataTable().fnDraw();
    $('#tableProjects').dataTable().fnDestroy();
    $('#tableProjects').dataTable({
        destroy: true,
        retrieve: true,
        paging: false,
        searching: false,
        processing: true,
        serverSide: true,
        filter: true,
        orderMulti: false,
        ajax: {
            url: "/Home/DetailsUserProjects/" + idUser,
            dataSrc: "",
            type: "GET",
            datatype: "json",
        },
        columns: [
            { "data": "ProjectId", "name": "Project ID" },
            { "data": "StartDate" },
            { "data": "TimeToStart" },
            { "data": "EndDate" },
            { "data": "Credits" },
            { "data": "Status" }
        ]
    });
}