selectItemModule.component("selectItem", {
    templateUrl: "index-main-app/components/Item-selection/item-selection.html",
    controller: SelectItemController,
    bindings: {
        selectedItem: "=",
        items: "=",
        addClass: "=",
        change: "&"
    }
});
