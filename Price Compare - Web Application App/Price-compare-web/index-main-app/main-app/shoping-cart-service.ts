class ShopingCartService {

    constructor(private $http: ng.IHttpService) {
    }

    public getChainNames(): ng.IPromise<Object[]> {
        return this.$http.get("api/serverPriceCompare/getChainNames").then(data => {
            return data.data;
        });
    }

    public getStoreNames(fileIdentifiers: FileIdentifiers, optionalAeraFilter: string): ng.IPromise<Object[]> {
        let info = fileIdentifiers.DirName + ',' + fileIdentifiers.PartialFileName + ',' + optionalAeraFilter;

        return this.$http.get("api/serverPriceCompare/getStoreNames", {
            params: {
                info: info
            }
        }).then(data => {
            return data.data;
        });
    }

    public getProductNames(fileIdentifiers: FileIdentifiers): ng.IPromise<Object[]> {
        let info = fileIdentifiers.DirName + ',' + fileIdentifiers.PartialFileName;

        return this.$http.get("api/serverPriceCompare/getProductItems", {
            params: {
                info: info
            }
        }).then(data => {
            return data.data;
        });
    }

    public getReport(storesToCompare: Object[], products: product[]): ng.IPromise<Report[]> {
        return this.$http.post("api/serverPriceCompare/getReport", {
            storesToCompare: storesToCompare,
            products: products
        }).then(data => {
            return data.data;
        });
    }

    public getProductItemInShopingCart(products: product[], name: string): product {
        for (let i = 0; i < products.length; i++) {
            if (products[i].name === name) {
                return products[i];
            }
        }

        return undefined;
    }
}

app.service("shopingCartService", ShopingCartService);
