window.todoApp = window.todoApp || {};

window.todoApp.itemListViewModel = (function (ko) {
    var items = ko.observableArray([]);

    (function getItemList() {
        return ajaxRequest("get", "/api/listitem/")
            .done(getSucceeded)
            .fail(getFailed);

        function getSucceeded(data) {
            var mappedTodoLists = $.map(data, function (list) { return new { name: list.name } });
            items(mappedTodoLists);
        }

        function getFailed() {
            items([{ name: 'Failed1' }, { name: 'Failed2' }]);
        }
    })();

    function ajaxRequest(type, url, data, dataType) { // Ajax helper
        var options = {
            dataType: dataType || "json",
            contentType: "application/json",
            cache: false,
            type: type,
            data: data ? data.toJson() : null
        };
        var antiForgeryToken = $("#antiForgeryToken").val();
        if (antiForgeryToken) {
            options.headers = {
                'RequestVerificationToken': antiForgeryToken
            }
        }
        return $.ajax(url, options);
    }

    return {
        items: items
    };

})(ko);

// Initiate the Knockout bindings
ko.applyBindings(window.todoApp.itemListViewModel);