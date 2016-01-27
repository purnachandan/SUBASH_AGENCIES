var app = angular.module('SalesMan', ['ngRoute']);
app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: '/PartialViews/SalesMan/ViewSalesMan.html',
        controller: 'ViewSalesManController'
    }).when('/AddSalesMan/:SalesManId', {
        templateUrl: '/PartialViews/SalesMan/AddSalesMan.html',
        controller: 'AddSalesManController'
    }).when('/ViewSalesMan', {
        templateUrl: '/PartialViews/SalesMan/ViewSalesMan.html',
        controller: 'ViewSalesManController'
    });
}).controller('SalesManController', function ($scope) {
    $scope.heading = 'SalesMan Master';
}).service('SalesManService', function () {
    var self = this;
    var SalesManObj = {
        SalesManId: 0,
        SalesMan_Name: '',
        Start_Date: '',
        End_Date: ''
    };
    var SalesManList = {
        SalesMan_Id: 0,
        SalesMan_Name: '',
        Start_Date: '',
        End_Date: ''
    };
    self.formatDate = function (dt) {
        return new Date(self.returnNumber(dt) * 1);
    }
    self.returnNumber = function (dt) {
        var dt1 = '';
        for (i = 0; i < dt.length; i++) {
            if (!isNaN(dt.substr(i, 1))) {
                dt1 = dt1 + dt.substr(i, 1).toString();
            }
        }
        return dt1;
    }
});