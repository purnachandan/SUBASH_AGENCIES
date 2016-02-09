var app = angular.module('Employee', ['ngRoute']);
app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: '/PartialViews/Employee/ViewEmployee.html',
        controller: 'ViewEmployeeController'
    }).when('/AddEmployee/:EmployeeId', {
        templateUrl: '/PartialViews/Employee/AddEmployee.html',
        controller: 'AddEmployeeController'
    }).when('/ViewEmployee', {
        templateUrl: '/PartialViews/Employee/ViewEmployee.html',
        controller: 'ViewEmployeeController'
    });
}).controller('EmployeeController', function ($scope, $http) {
    $scope.heading = 'Employee Master';
    $scope.Designations = $http.get('/Master/GetEmployeeDesignations').success(function (data, statuscode) {
        $scope.Designations = data;
    })
}).service('EmployeeService', function () {
    var self = this;
    var EmployeeObj = {
        EmployeeId: 0,
        Employee_Name: '',
        Start_Date: '',
        End_Date: ''
    };
    var EmployeeList = {
        Employee_Id: 0,
        Employee_Name: '',
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