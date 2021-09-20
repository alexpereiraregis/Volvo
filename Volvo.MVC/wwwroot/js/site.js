function atribuirIdCaminhao(Id) {

    $("#truckRequest_Id").attr("value", Id);

};

function editTruck(Id) {


    $.ajax(
        {
            type: 'GET',
            url: '/Home/Edit/' + Id,
            dataType: 'HTML',
            cache: true,
            async: true,
            success: function (data) {

                $('#formEdit').html(data);
                $('#edit').modal('show');

            },
            error: function (request, status, error) {
                console("erro:" + request.responseText);
            }

        });
}