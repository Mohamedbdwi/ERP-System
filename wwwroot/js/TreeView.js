$.fn.extend({
    treed: function (o) {

        var openedClass = 'glyphicon-minus-sign';
        var closedClass = 'glyphicon-plus-sign';

        if (typeof o != 'undefined') {
            if (typeof o.openedClass != 'undefined') {
                openedClass = o.openedClass;
            }
            if (typeof o.closedClass != 'undefined') {
                closedClass = o.closedClass;
            }
        };

        //initialize each of the top levels
        var tree = $(this);
        tree.addClass("tree");
        tree.find('li').has("ul").each(function () {
            var branch = $(this); //li with children ul
            branch.prepend("<i class='indicator glyphicon " + closedClass + "'></i>");
            branch.addClass('branch');
            branch.on('click', function (e) {
                if (this == e.target) {
                    var icon = $(this).children('i:first');
                    icon.toggleClass(openedClass + " " + closedClass);
                    $(this).children().children().toggle();
                }
            })
            branch.children().children().toggle();
        });
        //fire event from the dynamically added icon
        tree.find('.branch .indicator').each(function () {
            $(this).on('click', function () {
                $(this).closest('li').click();
            });
        });
        //fire event to open branch if the li contains an anchor instead of text
        tree.find('.branch>a').each(function () {
            $(this).on('click', function (e) {
                $(this).closest('li').click();
                e.preventDefault();
            });
        });
        //fire event to open branch if the li contains a button instead of text
        tree.find('.branch>button').each(function () {
            $(this).on('click', function (e) {
                $(this).closest('li').click();
                e.preventDefault();
            });
        });
    }
});

//Initialization of treeviews

$('#tree1').treed();

var customerList = document.getElementById("viewCustomers");
$('#getCustomers').on('click', function () {
    $.get("/Customer/GetCustomers",
        (res) => {
            //console.log(res);
            let customers = '';
            for (let i = 0; i < res.length; i++) {
                customers += `
                                                <li>${res[i].name}</li>
                                                  `
                //console.log(customers);
                customerList.innerHTML = customers;
            }

            if (customerList.style.display === "none") {
                customerList.style.display = "block";
            } else {
                customerList.style.display = "none";
            }

        }

    );
});


var supplierList = document.getElementById("viewSuppliers");
$('#getSuppliers').on('click', function () {
    $.get("/Supplier/GetAllSuppliers",
        (res) => {
            //console.log(res);
            let suppliers = '';
            for (let i = 0; i < res.length; i++) {
                suppliers += `
                         <li>${res[i].name}</li>
                             `
                //console.log(customers);
                supplierList.innerHTML = suppliers;
            }

            if (supplierList.style.display === "none") {
                supplierList.style.display = "block";
            } else {
                supplierList.style.display = "none";
            }

        }

    );
});