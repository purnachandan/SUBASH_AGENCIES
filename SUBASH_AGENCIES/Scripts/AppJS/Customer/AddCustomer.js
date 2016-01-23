app.controller('AddCustomer', function ($scope, $routeParams, $http, $window, $location) {
    $scope.heading = "Add Customer";
    $scope.id = $routeParams.customerid;
    $scope.customer = {};
    $scope.existingoutlet = false;
    $scope.DisplayPin = function (cid) {
        if (cid != null) {
            angular.forEach($scope.city, function (key, value) {
                if (key.CITYID == cid) {
                    $scope.PINCODE = key.PINCODE;
                }
            });
        }
        else {
            $scope.PINCODE = '';
        }
    }
    if ($scope.id != 0) {
        $scope.pullcustomer = $http.get('/Master/GetCustomerByID?id=' + $scope.id).success(function (data) {
            $scope.customer = data;
            $scope.DisplayPin($scope.customer.CITYID);
        });
        $scope.heading = "Update Customer";
        $scope.existingoutlet = true;
    }
    else {
        $scope.existingoutlet = false;
    }
    $scope.AddUpdateCustomer = function () {
        var id = $scope.customer.ID;
        $http.put('/Master/AddUpdateCustomer', $scope.customer).success(function (data) {
            if (data == 1) {
                if ($scope.id == 0) {
                    $window.alert('Outlet: ' + $scope.customer.OUTLET_NAME + ' added successfully');
                }
                else {
                    $window.alert('Outlet: ' + $scope.customer.OUTLET_NAME + ' updated successfully');
                }
            }
            else {
                $window.alert('Unable to add/update the Outlet: ' + $scope.customer.OUTLET_NAME);
            }
            $location.path('/');
        }).error(function (data) {
            $window.alert('Unable to add/update the customer: ' + $scope.customer.OUTLET_NAME);
        });
    }
    $scope.PlayPinCode = function (cid) {
        $scope.DisplayPin(cid);
    }
    $scope.ResetAddUpdateCustomer = function () {
        $location.path('ViewCustomer');
    }
});