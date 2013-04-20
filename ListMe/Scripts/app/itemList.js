window.todoApp.itemListViewModel = (function (ko) {
    var items = ko.observableArray([
        { name: 'Car'},
        { name: 'Bike'}
    ]);

    return {
        items: items
    };

})(ko);

// Initiate the Knockout bindings
ko.applyBindings(window.todoApp.itemListViewModel);