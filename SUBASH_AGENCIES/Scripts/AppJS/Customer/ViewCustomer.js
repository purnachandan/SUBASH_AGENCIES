app.controller('ViewCustomer', function ($scope, $http, $location, $log) {
    $scope.heading = "View Customer details";    
    $scope.outletlist = [];
    $scope.Outlet = '';
    $scope.editCustomer = function (outletid) {
        $location.path('/AddCustomer/' + outletid);
    };
    $scope.pulloutlets = function (Outlet) {
        $http.get('/Master/GetCustomer?sOutlet=' + Outlet).success(function (data) {
            $scope.outletlist = data;
        });        
    };
    $scope.ChangeStatus = function (outlet) {
        $http.post('/Master/ChangeCustomerStatus?id=' + outlet.ID + "&status=" + ((outlet.STATUS=='ACTIVE') ? 1 :2)).success(function (data) {
            if (data == 1) {
                var index = $scope.outletlist.indexOf(outlet, 0);
                $scope.outletlist[index].STATUS = (outlet.STATUS == 'ACTIVE') ? 'INACTIVE' : 'ACTIVE'
            }
        });
    };
    //$scope.$watch('heading', function (newVal, oldVal) {
    //    $log.log('changed');
    //    $log.log('Old Value is ' + oldVal);
    //    $log.log('new Value is ' + newVal);
    //});
    //$scope.$watch('Outlet', function (newVal, old) {
    //    $log.log('changed');
    //    $log.log('Old Value is ' + old);
    //    $log.log('new Value is ' + newVal);
    //    var a = newVal;
    //    if (a.length > 0) {
    //        $scope.pulloutlets = $http.get('/Master/GetCustomer?sOutlet=' + a).success(function (data) {
    //            $scope.outletlist = data;
    //        });
    //    }
    //    else
    //    {
    //        $scope.pulloutlets='';
    //    }
    //});
});
