app.controller('ViewCustomer', function ($scope, $http, $location) {
    $scope.heading = "View Customer details";    
    $scope.outletlist = {};    
    $scope.editCustomer = function (outletid) {
        $location.path('/AddCustomer/' + outletid);
    };
    $scope.pulloutlets = function (Outlet) {
        $http.get('/Master/GetCustomer?sOutlet=' + Outlet).success(function (data) {
            $scope.outletlist = data;
        });
    };
});