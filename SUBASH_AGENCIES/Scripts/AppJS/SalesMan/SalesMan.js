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
    var SalesManObj = {
        SalesManId: 0,
        SalesMan_Name: '',
        Start_Date: '',
        End_Date: ''
    };
});