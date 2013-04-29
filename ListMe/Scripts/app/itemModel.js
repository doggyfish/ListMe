window.todoApp = window.todoApp || {};

(function (ko) {
    window.todoApp.item = function (data) {
        var self = this;
        data = data || {};

        // Persisted properties
        self.id = data.listItemId;
        self.name = data.title;
        self.desc = data.description;
        self.icon = data.icon;
        self.userId = data.userId;
        self.categoryId = data.categoryId;

        self.category = new window.todoApp.category(data.category);

        self.images = data.itemImages;
        self.details = data.itemDetails;
        self.comments = data.itemComments;

        self.isDeleted = ko.observable(data.isDeleted);
        self.isEnabled = ko.observable(data.isEnabled);
    };

    window.todoApp.category = function (data) {
        var self = this;
        data = data || {};

        // Persisted properties
        self.id = data.categoryId;
        self.name = data.title;
        self.items = data.listItems;
    };
})(ko);