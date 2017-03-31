productModule.component("product", {
    templateUrl: "../products.html",
    bindings: {
        product: "=",
        quantity: "=",
        addProduct: "&"
    }
});