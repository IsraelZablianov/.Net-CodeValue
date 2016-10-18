var ProductController = (function () {
    function ProductController() {
        this.product = undefined;
        this.quantity = 1;
    }
    return ProductController;
}());
productModule.controller("productController", ProductController);
