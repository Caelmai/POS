/// <reference path="../knockout-2.1.0.js" />

function ClientListModel() {
    var self = this;

    self.clientFilter = ko.observable("");
    self.cityFilter = ko.observable("");

    //TODO: get from DB
    self.regions = ["ALL", "North", "South", "Town Center"];
    self.regionsFilter = ko.observable("ALL");

    //TODO: get from DB
    self.genders = ["ALL", "M", "F"];
    self.gendersFilter = ko.observable("ALL");

    //TODO: get from DB
    self.classifications = ["ALL", "Sporadic", "Regular", "VIP"];
    self.classificationFilter = ko.observable("ALL");

    //TODO: get from DB
    self.sellers = ["ALL", "Seller1", "Seller2"];
    self.sellersFilter = ko.observable("ALL");

    self.clients = ko.observableArray(model.Clients);

    self.clear = function () {
        self.clientFilter("");
        self.cityFilter("");
        self.regionsFilter("ALL");
        self.gendersFilter("ALL");
        self.classificationFilter("ALL");
        self.sellersFilter("ALL");
    }


    self.FilteredData = ko.computed(function () {
        //return self.clients;
        return ko.utils.arrayFilter(self.clients(), function (item) {
            return (self.clientFilter() == "" || item.Name.indexOf(self.clientFilter()) > -1) &&
                (self.cityFilter() == "" || item.City.indexOf(self.cityFilter()) > -1) &&
                (self.regionsFilter() == "ALL" || item.Region.indexOf(self.regionsFilter()) > -1) &&
                (self.gendersFilter() == "ALL" || item.Gender.indexOf(self.gendersFilter()) > -1) &&
                (self.classificationFilter() == "ALL" || item.Classification.indexOf(self.classificationFilter()) > -1)&&
                (self.sellersFilter() == "ALL" || item.Seller.indexOf(self.sellersFilter()) > -1);
        });
    });
}

//GOOOOO
ko.applyBindings(new ClientListModel());