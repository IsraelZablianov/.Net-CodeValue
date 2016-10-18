class ProductController {
    public product: Object = undefined;
    public addProduct: Function;
    public quantity: number = 1;
}

productModule.controller("productController", ProductController);