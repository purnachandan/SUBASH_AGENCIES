var app = angular.module('Customer', ['ngRoute']);
app.config(function ($routeProvider) {
    $routeProvider
        .when('/ViewCustomer', {
            templateUrl: '/PartialViews/Customer/ViewCustomer.html',
            controller: 'ViewCustomer'
        }).when('/AddCustomer/:customerid', {
            templateUrl: '/PartialViews/Customer/AddCustomer.html',
            controller: 'AddCustomer'
        }).when('/', {
            templateUrl: '/PartialViews/Customer/ViewCustomer.html',
            controller: 'ViewCustomer'
        });
}).controller('customer', function ($scope, $http) {
    $scope.beat = {};
    $scope.category = {};
    $scope.type = {};
    $scope.city = {};
    $scope.status = {};
    $scope.category = $http.get('/Master/GetCategory').success(function (data) {
        $scope.category = data;
    });
    $scope.type = $http.get('/Master/GetTypes').success(function (data) {
        $scope.type = data;
    });
    $scope.beat = $http.get('/Master/GetBeat').success(function (data) {
        $scope.beat = data;
    });
    $scope.city = $http.get('/Master/GetCity').success(function (data) {
        $scope.city = data;
    });
    $scope.status = $http.get('/Master/GetStatus').success(function (data) {
        $scope.status = data;
    });
});