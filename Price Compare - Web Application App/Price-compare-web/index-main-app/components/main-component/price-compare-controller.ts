class PriceCompareController {

    public chainNames: Object[] = [];
    public storeNames: Object[] = [];
    public productNames: Object[] = [];
    public selectedStoresToCompare: Object[] = [];
    public shopingCartItems: product[] = [];
    public report: Report[] = [];

    public selectedChain: Object = undefined;
    public selectedStore: Object = undefined;
    public selectedItem: Object = undefined;
    public selectedStoreToCompare: Object = undefined;
    public selectedShopingCartItem: Object = undefined;
    public selectedStoreToReport: Object = undefined;

    public checkBoxSelectBranch: boolean = false;
    public filterAreaName: string = "";
    public selectedStoreReport: string = "";

    constructor(private shopingCartService: ShopingCartService) {
        this.shopingCartService.getChainNames().then(chainNames => { this.chainNames = chainNames });
    }

    public addStores() {
        if (this.selectedChain != undefined) {
            let fileIdentifiers = new FileIdentifiers();
            fileIdentifiers.DirName = this.selectedChain.toString();
            fileIdentifiers.PartialFileName = "Stores";
            this.shopingCartService.getStoreNames(fileIdentifiers, this.filterAreaName).then(storeNames => {
                this.storeNames = storeNames
                this.selectedStore = undefined;
            });
        }
        this.filterAreaName = "";
    }

    public addProducts() {
        let fileIdentifiers = new FileIdentifiers();
        if (this.selectedStore != undefined) {
            fileIdentifiers.DirName = this.selectedChain.toString();
            fileIdentifiers.PartialFileName = this.selectedStore.toString();
            this.shopingCartService.getProductNames(fileIdentifiers).then(productNames => {
                this.productNames = productNames;
            });

            let selectedBranch = fileIdentifiers.DirName + "," + fileIdentifiers.PartialFileName;
            if (this.checkBoxSelectBranch === true && this.selectedStoresToCompare.indexOf(selectedBranch) < 0) {
                this.selectedStoresToCompare.push(selectedBranch);
            }
        }
    }

    public removeSelectedStore() {
        if (this.selectedStoreToCompare != undefined) {
            this.selectedStoresToCompare.splice(this.selectedStoresToCompare.indexOf(this.selectedStoreToCompare), 1);
            this.selectedStoreToCompare = undefined;
        }
    }

    public addProductToShopingCart() {
        if (this.selectedItem != undefined && this.shopingCartService.getProductItemInShopingCart(this.shopingCartItems, this.selectedItem.toString()) === undefined) {
            let product: product = { name: this.selectedItem.toString(), quantity: 1 };
            this.shopingCartItems.push(product);
        }
    }

    public removeItemFromShopingCart(shoppingCartItemSelected: Object) {
        this.shopingCartItems.splice(this.shopingCartItems.indexOf(this.shopingCartService.getProductItemInShopingCart(this.shopingCartItems, shoppingCartItemSelected.toString())), 1);
    }

    public compareStores() {
        if (this.shopingCartItems.length > 0 && this.selectedStoresToCompare.length > 0) {
            this.shopingCartService.getReport(this.selectedStoresToCompare, this.shopingCartItems).then(reportReturned => {
                this.report = reportReturned;
            });
        }

        this.selectedStoreToReport = undefined;
        this.selectedStoreReport = "";
    }

    public selectedStoreToReportChanged() {
        for (let i = 0; i < this.report.length; i++) {
            if (this.report[i].storeName === this.selectedStoreToReport.toString()) {
                this.selectedStoreReport = this.report[i].storeReport;
            }
        }
    }
}