var tableBody = document.getElementById("display_statements");
var totalDebts = document.getElementById("allTotalDebts");
var totalPaids = document.getElementById("allTotalPaids");
var totalRemainders = document.getElementById("allTotalRemainder");
var supplierPayment = document.getElementById("livePay");
var Pay = document.getElementById("pay");
var supplier = document.getElementById("Supplier_Id");


$(document).ready(function () {
    $('#Supplier_Id').on('change', function () {
        console.log($(this).val());
        var SupplierId = $(this).val();
        $.ajax({
            url: '/Supplier/GetAccountStatementBySupplier?id=' + SupplierId,
            success: function (data) {
                console.log(data);

                let table = '';
                for (let i = 0; i < data.length; i++) {


                    table += `
                                                    <tr>
                                                        <td>${data[i].date}</td>
                                                        <td>${data[i].total_Cost}</td>
                                                        <td>${data[i].paid}</td>
                                                        <td>${data[i].remainder}</td>
                                                    </tr>
                                                            `
                }
                tableBody.innerHTML = table;

                const totalDebt = data.reduce((accumulator, object) => {
                    return +accumulator + +object.total_Cost;
                }, 0);
                totalDebts.value = totalDebt;

                const totalPaid = data.reduce((accumulator, object) => {
                    return +accumulator + +object.paid;
                }, 0);
                totalPaids.value = totalPaid;


                totalRemainders.value = totalDebts.value - totalPaids.value;


            }
        });
    })
});

$('#pay').on('click', function () {
    var paymentAmount = supplierPayment.value;
    var supplierValue = supplier.value;
    //console.log(paymentAmount);
    console.log(supplierValue);
    $.post("/Supplier/AddPaymnet", {
        Paid: paymentAmount, SupplierId: supplierValue
    },
        (res) => {
            console.log(res);

            tableBody.innerHTML += `
                                                    <tr>
                                                        <td>${res.date}</td>
                                                        <td>${res.total_Cost}</td>
                                                        <td>${res.paid}</td>
                                                        <td>${res.remainder}</td>
                                                    </tr>
                                                            `

            totalPaids.value = +totalPaids.value + +paymentAmount;
            totalRemainders.value -= paymentAmount;
        }
    );

});