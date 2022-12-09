var tableBody = document.getElementById("display_statements");
var totalDebts = document.getElementById("allTotalDebts");
var totalPaids = document.getElementById("allTotalPaids");
var totalRemainders = document.getElementById("allTotalRemainder");
var customerPayment = document.getElementById("livePay");
var Pay = document.getElementById("pay");
var customer = document.getElementById("Customer_Id");


$(document).ready(function () {
    $('#Customer_Id').on('change', function () {
        console.log($(this).val());
        var SupplierId = $(this).val();
        $.ajax({
            url: '/Customer/GetAccountStatementByCustomer?id=' + SupplierId,
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
    var paymentAmount = customerPayment.value;
    var customerValue = customer.value;
    //console.log(paymentAmount);
    console.log(customerValue);
    $.post("/Customer/AddPaymnet", {
        Paid: paymentAmount, customerId: customerValue
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

//Handeling Account Tree Statement:-

var Accoumt = document.getElementById("AccTree_Id");
var from = document.getElementById("fromDate");
var to = document.getElementById("toDate");
var search = document.getElementById("search");
var tableBody = document.getElementById("display_accounts");
var creditor = document.getElementById("creditor")
var debtor = document.getElementById("debtor");
var endBalance = document.getElementById("endBalance");

$('#search').on('click', function () {
    var selectedAccount = Accoumt.value;
    var selectedFrom = from.value;
    var selectedTo = to.value;
    console.log(selectedAccount);
    console.log(selectedFrom);
    console.log(selectedTo);

    $.get("/Customer/GetDailyRestrictionByAccountId", {
        Id: selectedAccount, from: selectedFrom, to: selectedTo
    },
        (data) => {
            console.log(data);

            let table = '';
            var dataCreditor = [];
            var dataDebtor = [];
            for (let i = 0; i < data.length; i++) {

                if (data[i].type == "Creditor") {
                    
                    dataCreditor.push(data[i]);
                    const creditors = dataCreditor.reduce((accumulator, object) => {
                        return +accumulator + +object.money_Amount;
                    }, 0);
                    console.log(creditors);
                    creditor.value = creditors;

                    data[i].creditor = data[i].money_Amount;
                    data[i].debtor = 0;

                    data[i].total_Balance = data[i - 1].total_Balance - data[i].creditor;
                }

                else if (data[i].type == "Debtor") {
                    
                    dataDebtor.push(data[i]);
                    const debtors = dataDebtor.reduce((accumulator, object) => {
                        return +accumulator + +object.money_Amount;
                    }, 0);
                    console.log(debtors);

                   
                    debtor.value = debtors;

                    data[i].debtor = data[i].money_Amount;
                    data[i].creditor = 0;
                    if (data[i - 1] == null) {
                        data[i].total_Balance = data[i].debtor;
                    } else {
                        data[i].total_Balance = (data[i].debtor ) + (data[i - 1].total_Balance);
                            }
                    
                }



                table += `
                                                    <tr>
                                                        <td>${data[i].date}</td>
                                                        <td>${data[i].number}</td>
                                                        
                                                        <td>${data[i].creditor}</td>
                                                        <td>${data[i].debtor}</td>
                                                        <td>${data[i].total_Balance}</td>
                                                        <td>${data[i].statement}</td>
                                                        
                                                    </tr>
                                                            `
            }
            tableBody.innerHTML = table;
            if (dataDebtor.length == 0 && dataCreditor.length == 0) {
                debtor.value = 0;
                creditor.value = 0;
            }

            endBalance.value = debtor.value - creditor.value;
        }
    );
});



//Handeling Daily Restrictions Payments:


//var restrictinSaving = document.getElementById("restrictinSaving").value;
console.log("hello");
$('#restrictinSaving').on('click',
    function () {
        var restrictionDate = document.getElementById("restrictionDate").value;
        var restrictionAccount = document.getElementById("AccTreeRes_Id").value;
        var restrictionMoneyValue = document.getElementById("moneyValue").value;
        var restrictionType = document.getElementById("restrictionType").value;
        var restrictionStatement = document.getElementById("restrictionStatement").value;

        $.post("/Customer/SavingDailyRestriction",
            {
                AccountTree_Id: restrictionAccount, Statement: restrictionStatement,
                Date: restrictionDate, Money_Amount: restrictionMoneyValue,
                Type: restrictionType
            },
            (res) => {
                console.log(res);
            }
        )
    }
);