$(document).ready(function () {

    $(".addtocart").click(function (event) {
        event.preventDefault();

        // $(this).siblings().each(function () {
        //     if ($(this).hasClass("productId")) {
        //         var productId = $(this).val();
        //         console.log(productId);
        //     }
        //     if ($(this).hasClass("name")) {
        //         var name = $(this).val();
        //         console.log(name);
        //     }
        //     if ($(this).hasClass("price")) {
        //         var price = $(this).val();
        //         console.log(price);
        //     }
        // })

        var form = $(this).parent();

        var productId = form.find("input[name='productId']").val();
        var name = form.find("input[name='name']").val();
        var price = form.find("input[name='price']").val();
        var image = form.find("input[name='image']").val();
        var description = form.find("input[name='description']").val();
        var rated = form.find("input[name='rated']").val();
        var categoryName = form.find("input[name='categoryName']").val();
        var quantity = form.find("input[name='quantity']").val();

        console.log(productId, quantity, name, price, image, description, rated, categoryName);

        $.post(`/order/${productId}`, { name, price, image, description, rated, categoryName, quantity }, function (e) {
            if (e.length !== undefined && e.length > 0) {
                console.log(e);
                var total = 0;
                var count = 0;

                $.each(e, function (i, val) {
                    count += val.quantity;
                    total += val.quantity * val.product.price;
                });

                console.log(total, count);

                $("#cart_total").empty();

                $("#cart_total").append(`<div>${count} <span>- ${total} $</span></div>`);
            }
        })

    });

    console.log(buys);

    $("#buy").submit(function (event) {
        event.preventDefault();
        console.log(event);
        console.log($('#buy').serializeArray());

        var dataFrom = $('#buy').serializeArray();

        var productId = dataFrom.find(data => data.name === 'productId').value;
        var name = dataFrom.find(data => data.name === 'name').value;
        var price = dataFrom.find(data => data.name === 'price').value;
        var image = dataFrom.find(data => data.name === 'image').value;
        var description = dataFrom.find(data => data.name === 'description').value;
        var rated = dataFrom.find(data => data.name === 'rated').value;
        var categoryName = dataFrom.find(data => data.name === 'categoryname').value;
        var quantity = dataFrom.find(data => data.name === 'quantity').value;

        console.log(productId, quantity, name, price, image, description, rated, categoryName);

        $.post(`/order/${productId}`, { name, price, image, description, rated, categoryName, quantity }, function (e) {
            if (e.length !== undefined && e.length > 0) {
                console.log(e);
                var total = 0;
                var count = 0;

                $.each(e, function (i, val) {
                    count += val.quantity;
                    total += val.quantity * val.product.price;
                });

                console.log(total, count);

                $("#cart_total").empty();

                $("#cart_total").append(`<div>${count} <span>- ${total} $</span></div>`);
            }
        })
    });
});
