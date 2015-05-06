var CartApp = CartApp || {};

CartApp.Page = function () {
    var self = this;
    self.Cart = new CartApp.Cart();
    self.BitProducts = ko.observableArray([]);
    self.TUserId = "";
};

CartApp.Cart = function () {
    var self = this;

    self.items = ko.observableArray([]);
    self.add = function (item) {
        if (item.selectedQuantity() <= item.quantity && item.selectedQuantity() > 0) {
            self.items.remove(function (p) { return p.id === item.id; });
            self.items.push(new CartApp.CartItem(item));
        }
    };

    self.remove = function (item) {
        self.items.remove(function (p) { return p.id === item.id; });
    };

    self.checkOut = function () {
        var dataToSave = { UserId: viewModel.TUserId, OrderTotal: self.grandTotal() };
        dataToSave.BitProducts = [];
        $.each(self.items(), function (idx, item) {
            var dataItem = ko.toJS(item.product);
            dataToSave.BitProducts.push(dataItem);
        });

        $.ajax({
            url: "/api/order",
            data: JSON.stringify(dataToSave),
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function () {
            self.items.removeAll();
            $.each(viewModel.BitProducts(), function (idx, bitProduct) {
                console.log(bitProduct);
                bitProduct.selectedQuantity(0);
            });
            toastr.success("Your order has been submitted!");
        }).error(function (data) {
            toastr.error("Your order is invalid!");
        });
    };

    self.grandTotal = ko.computed(function () {
        var total = 0;
        $.each(self.items(), function () { total += this.subtotal(); });
        return total;
    });
};

CartApp.CartItem = function (bitProduct) {
    var self = this;

    self.id = bitProduct.id;
    self.product = bitProduct;
    self.quantity = ko.observable(bitProduct.selectedQuantity());
    self.subtotal = ko.computed(function () {
        return self.product ? self.product.price * parseInt("0" + self.quantity(), 10) : 0;
    });
};

var viewModel;
$(function () {
    viewModel = new CartApp.Page();
    hub = $.connection.cart;

    ko.applyBindings(viewModel);

    hub.client.updateProductCount = function (bitProduct) {
        var match = ko.utils.arrayFirst(viewModel.BitProducts(), function (item) {
            return bitProduct.Id === item.id;
        });
        toastr.info("Product (" + bitProduct.Id + ") stock count changed!");
        match.quantity(bitProduct.Quantity);
    };

    hub.client.orderApproved = function (approval) {
        if (approval.Approved) {
            toastr.success("Your order " + approval.id + " has been approved!");
        } else {
            toastr.error("Your order " + approval.id + " has been rejected!");
        }
    };

    $.connection.hub.start().done(function () {
        viewModel.UserId = $.connection.hub.id;
    });

    $.get("/api/bitProduct", function (items) {
        $.each(items, function (idx, item) {
            viewModel.BitProducts.push(new CartApp.BitProduct(item));
        });
    }, "json");
});