var Item = document.getElementById("Item_Id");
var from = document.getElementById("fromDate");
var to = document.getElementById("toDate");
var search = document.getElementById("search");
var tableBody = document.getElementById("display_movements");

$('#search').on('click', function () {
    var selectedItem = Item.value;
    var selectedFrom = from.value;
    var selectedTo = to.value;
    //console.log(selectedItem);
    //console.log(selectedFrom);
    //console.log(selectedTo);

    $.get("/Item/GetItemMovement", {
        itemId: selectedItem, from: selectedFrom, to: selectedTo
    },
        (data) => {
            console.log(data);

            let table = '';
            for (let i = 0; i < data.length; i++) {


                table += `
                                                    <tr>
                                                        <td>${data[i].movement_Type}</td>
                                                        <td>${data[i].quantity}</td>
                                                        <td>${data[i].bill_Number}</td>
                                                        <td>${data[i].date}</td>
                                                    </tr>
                                                            `
            }
            tableBody.innerHTML = table;
        }
    );
});