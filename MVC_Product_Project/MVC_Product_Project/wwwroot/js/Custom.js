
//function confirmDelete(productId) {
//            swal({
//                title: "Are you sure?",
//                text: "Your will not be able to recover this Product!",
//                type: "warning",
//                showCancelButton: true,
//                confirmButtonClass: "btn-danger",
//                confirmButtonText: "Yes, delete it!",
//                closeOnConfirm: true
//                url: '/Product/Delete?productId=' + productId,
//            },
//            function () {
//                // Redirect to the Delete action with the productId parameter
//                window.location.href = "/Product/Delete?productId=" + productId;
//            });
//        }

function confirmDelete(productId) {
    swal({
        title: "Are you sure?",
        text: "Your will not be able to recover this Product!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: true
    },
    function () {
            // Redirect to the Delete action with the productId parameter
            window.location.href = "/Product/Delete?productId=" + productId;
    });
}

