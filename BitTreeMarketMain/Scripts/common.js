var CartApp = CartApp || {};

CartApp.BitProduct = function (item) {
    var self = this;
    self.id = item.Id;
    self.name = item.Name;
    self.details = item.Details;
    self.quantity = ko.observable(item.Quantity);
    self.price = item.Price;
    self.selectedQuantity = ko.observable(item.SelectedQuantity);
};

CartApp.Order = function(item) {
    var self = this;
    self.id = item.Id;
    self.approved = ko.observable(item.Approved);
    self.UserId = item.UserId;
    self.orderTotal = item.OrderTotal;
    self.bitProducts = [];
    $.each(item.BitProducts, function(idx, bitProduct) {
        self.bitProducts.push(new CartApp.Product(bitProduct));
    });
};