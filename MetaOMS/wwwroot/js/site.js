// This method for getting the parameter value of url
// www.example.com/page=1;
$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results == null) {
        //return null;///Actual value should same
        return 1;///My  Requiered Value
    }
    return decodeURI(results[1]) || 0;
}

showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,

        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-body #CurrentPage').val($.urlParam('page'));
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {

                    $('#mainRenderBody').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}
deleteData = (url,data) => {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            try {
                $.ajax({
                    type: 'GET',
                    url: url,
                    data: { id: data, page: $.urlParam('page') },
                    success: function (res) {
                        if (res.data == true) {
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success'
                            )
                            $('#mainRenderBody').html(res.html)
                        }

                    }
                })
            } catch (ex) {
                console.log(ex)
            }


        }
    })
}

//edited newly for cancelling order
//cancelOrder = (url, data) => {
//    Swal.fire({
//        title: 'Are you sure?',
//        text: "You won't be able to revert this!",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, cancel this order!'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            try {
//                $.ajax({
//                    type: 'GET',
//                    url: url,
//                    data: { id: data, page: $.urlParam('page') },
//                    success: function (res) {
//                        if (res.data == true) {
//                            Swal.fire(
//                                'Cancelled!',
//                                'This order has been cancelled.',
//                                'success'
//                            )
//                            $('#mainRenderBody').html(res.html)
//                        }
//                    }
//                })
//            } catch (ex) {
//                console.log(ex)
//            }
//        }
//    })
//}