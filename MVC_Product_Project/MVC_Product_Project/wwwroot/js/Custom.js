
//Delete function
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
        function (isConfirmed) {
             // Redirect to the Delete action with the productId parameter
            if (isConfirmed) {
                window.location.href = "/Product/Delete?productId=" + productId;
                swal("Deleted!", "Product has been deleted successfully.", "success"
                );        
            }
    });
}


////Pagination function
//var currentPage = 1;
//var pageSize = 5;  // Number of items displayed per page
//var table = document.getElementById("myTable").getElementsByTagName('tbody')[0];

//// Sort table by column index and order
//function sortTable(columnIndex, sortOrder) {
//    var rows, switching, i, x, y, shouldSwitch;
//    switching = true;

//    while (switching) {
//        switching = false;
//        rows = table.rows;

//        for (i = 1; i < (rows.length - 1); i++) {
//            shouldSwitch = false;
//            x = rows[i].getElementsByTagName("td")[columnIndex];
//            y = rows[i + 1].getElementsByTagName("td")[columnIndex];

//            if (sortOrder === "asc") {
//                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
//                    shouldSwitch = true;
//                    break;
//                }
//            } else if (sortOrder === "desc") {
//                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
//                    shouldSwitch = true;
//                    break;
//                }
//            }
//        }

//        if (shouldSwitch) {
//            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
//            switching = true;
//        }
//    }
//}

//// Paginate the table
//function paginate() {
//    var rows = table.rows;
//    var totalRows = rows.length;
//    var totalPages = Math.ceil(totalRows / pageSize);

//    for (var i = 0; i < totalRows; i++) {
//        if (i < (currentPage - 1) * pageSize || i >= currentPage * pageSize) {
//            rows[i].style.display = 'none';
//        } else {
//            rows[i].style.display = '';
//        }
//    }

//    // Update pagination buttons (assuming you have pagination buttons with class "pagination-btn")
//    var paginationButtons = document.querySelectorAll(".pagination-btn");
//    for (var i = 0; i < totalPages; i++) {
//        paginationButtons[i].textContent = i + 1;
//    }
//}

//// Set up event listeners for sorting (assuming you have sorting elements with class "sortable")
//var sortableColumns = document.querySelectorAll(".sortable");
//sortableColumns.forEach(function (column, index) {
//    column.addEventListener("click", function () {
//        sortTable(index, "asc");  // Default sort order is ascending
//        paginate();
//    });
//});

//// Set up event listeners for pagination buttons (assuming you have pagination buttons with class "pagination-btn")
//var paginationButtons = document.querySelectorAll(".pagination-btn");
//paginationButtons.forEach(function (button) {
//    button.addEventListener("click", function () {
//        currentPage = parseInt(button.textContent);
//        paginate();
//    });
//});

//// Initial sort and pagination when the page is loaded
//sortTable(0, "asc");  // Sort by the first column in ascending order initially
//paginate();
