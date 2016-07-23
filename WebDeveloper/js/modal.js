function getModal(url) {
    $.get(url, function (data) {
        $('.modal-body').html(data);
        $('#modal-container').modal('show');
    });
}
