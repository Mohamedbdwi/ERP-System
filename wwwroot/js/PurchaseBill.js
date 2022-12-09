$(document).ready(function () {
    $('#billItem_Name').on('change', function () {
        //console.log($(this).val());
        var itemId = $(this).val();
        $.ajax({
            url: '/Invoice/GetItemPrice?id=' + itemId,
            success: function (Price) {
                //console.log(Price);
                $('#billItem_Price').val(Price.selling_Price);
            }
        });
    })
});

let Supplier = document.getElementById("Supplier_Id");
let itemSelected = document.getElementById("billItem_Name");
let itemPrice = document.getElementById("billItem_Price");
let itemQuantity = document.getElementById("billQuantity");
const tableEl = document.getElementById("billTableGrid");
let itemsGrid = document.getElementById("billItemGrid");
let total = document.getElementById("billTotal_Cost");
let paidMoney = document.getElementById("billPaid");
let remainderMoney = document.getElementById("billRemainder");

let dataItems;
if (localStorage.item != null) {
    dataItems = JSON.parse(localStorage.item);
} else {
    dataItems = [];
}



function AddItemToGrid() {
    let itemCost = itemPrice.value * itemQuantity.value;
    let newItem = {
        Item_Id: itemSelected.value,
        Item_Name: itemSelected.options[itemSelected.selectedIndex].text,
        price: itemPrice.value,
        Quantity: itemQuantity.value,
        Item_Cost: itemCost
    }
    dataItems.push(newItem);
    localStorage.setItem('item', JSON.stringify(dataItems));
    //console.log(dataItems);
    CalculateTotalCost();
    //console.log(sum);

    ShowData();



    /*debugger*/
    /*$("#form").serialize()*/

}

function CalculateTotalCost() {
    const sum = dataItems.reduce((accumulator, object) => {
        return +accumulator + +object.Item_Cost;
    }, 0);

    total.value = sum;
    remainderMoney.value = sum - paidMoney.value;

    paidMoney.addEventListener('keyup', function () {
        remainderMoney.value = sum - paidMoney.value;
        if (total.value == 0) {
            remainderMoney.value = 0;
        }
    })
}
CalculateTotalCost()


function ShowData() {
    let table = '';

    for (let i = 0; i < dataItems.length; i++) {
        table += `
                    <tr>
                        <td>${i + 1}</td>
                        <td>${dataItems[i].Item_Name}</td>
                        <td>${dataItems[i].price}</td>
                        <td>${dataItems[i].Quantity}</td>
                        <td>
                                <div class="form-group col-2">
                                   <input value="${dataItems[i].Item_Cost}" class="form-control" readonly/>
                                   
                                </div>
                        </td>
                        <td><a onclick="DeleteItem(${i})" id="delete" class="btn btn-purple">Delete</a></td>
                    </tr>
                 `
        //console.log(table);
    }

    itemsGrid.innerHTML = table;
}

ShowData();


//Delete From Grid

function DeleteItem(i) {
    //console.log(i);
    dataItems.splice(i, 1);
    localStorage.item = JSON.stringify(dataItems);

    CalculateTotalCost();
    ShowData();
}

$('#billSaveItem').on('click', function () {

    var invoiceNumber = $('#billNumber').val();
    var invoiceDate = $('#billDate').val();
    var selectedSupplier = Supplier.value;


    var totalCost = total.value;
    var paid = paidMoney.value;
    var reminder = remainderMoney.value;


    $.post("/PurchaseBill/InsertPurchaseBill",
        {  //property from class : value from input
            Number: invoiceNumber, Date: invoiceDate, Supplier_Id: selectedSupplier,
            Total_Cost: totalCost, Paid: paid, Remainder: reminder, PurchasesBillDetails: dataItems

        },
        (res) => {
            console.log(res);

        });
});




  







                                   
