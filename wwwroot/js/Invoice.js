//Selling Invoice Handle

$(document).ready(function () {
    $('#Item_Name').on('change', function () {
        //console.log($(this).val());
        var itemId = $(this).val();
        $.ajax({
            url: '/Invoice/GetItemPrice?id=' + itemId,
            success: function (Price) {
                //console.log(Price);
                $('#Item_Price').val(Price.selling_Price);
            }
        });
    })
});


let invoiceCustomer = document.getElementById("Customer_Id");
let itemSelected = document.getElementById("Item_Name");
let itemPrice = document.getElementById("Item_Price");
let itemQuantity = document.getElementById("Quantity");
const tableEl = document.getElementById("tableGrid");
let itemsGrid = document.getElementById("itemGrid");
let total = document.getElementById("Total_Cost");
let paidMoney = document.getElementById("Paid");
let remainderMoney = document.getElementById("Remainder");
let quantityWarning = document.getElementById("quantity-warning");

//Add to grid

$('#adding-btn').on('click', function () {
    var selectedItem = itemSelected.value;
    var neededQuantity = itemQuantity.value;
    
    $.ajax({
        url: '/Store/GetStoreById?id=' + selectedItem,
        success: function (data) {
            var storedQuantity = data.quantity;
            if (neededQuantity <= storedQuantity) {
                AddItemToGrid()
                quantityWarning.textContent = " ";
            }
            else if (storedQuantity = 0) {
                quantityWarning.textContent = "The item run out and no item available";
            }
            else if (neededQuantity > storedQuantity) {
                quantityWarning.textContent = "The needed quantity is more than the available";
            }

        }
    });
});





let dataItem;
if (localStorage.item != null) {
    dataItem = JSON.parse(localStorage.item);
} else {
    dataItem = [];
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
    dataItem.push(newItem);
    localStorage.setItem('item', JSON.stringify(dataItem));
    //console.log(dataItem);
    CalculateTotalCost();
    //console.log(sum);

    ShowData();



    /*debugger*/
    /*$("#form").serialize()*/

}

function CalculateTotalCost() {
    const sum = dataItem.reduce((accumulator, object) => {
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

    for (let i = 0; i < dataItem.length; i++) {
        table += `
                    <tr>
                        <td>${i + 1}</td>
                        <td>${dataItem[i].Item_Name}</td>
                        <td>${dataItem[i].price}</td>
                        <td>${dataItem[i].Quantity}</td>
                        <td>
                                <div class="form-group col-2">
                                   <input value="${dataItem[i].Item_Cost}" class="form-control" readonly/>
                                   
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
    dataItem.splice(i, 1);
    localStorage.item = JSON.stringify(dataItem);

    CalculateTotalCost();
    ShowData();
}



$('#saveItem').on('click', function () {

    var invoiceNumber = $('#Number').val();
    var invoiceDate = $('#Date').val();
    var selectedCustomer = invoiceCustomer.value;


    var totalCost = total.value;
    var paid = paidMoney.value;
    var reminder = remainderMoney.value;


    $.post("/Invoice/InsertInvoice",
        {  //property from class : value from input
            Number: invoiceNumber, Date: invoiceDate, Customer_Id: selectedCustomer,
            Total_Cost: totalCost, Paid: paid, Remainder: reminder, InvoiceDetails: dataItem

        },
        (res) => {
            console.log(res);

        });
    

});