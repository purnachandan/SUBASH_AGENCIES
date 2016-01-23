app.controller('AddSalesManController', function ($scope, $window, $routeParams, $http, $location, SalesManService) {
    $scope.SalesMan = {
        SalesManId:0,
        SalesMan_Name: '',
        Start_Date: '',
        End_Date: ''
    };
    if ($routeParams.id > 0) {
        $scope.SalesMan = {
            SalesManId: $routeParams.SalesManId,
            SalesMan_Name: SalesManService.SalesManObj.SalesManName,
            Start_Date: SalesManService.SalesManObj.Start_Date,
            End_Date: SalesManService.SalesManObj.End_Date
        }
    }
    $scope.AddSalesMan = function () {
        $http.put('/Master/AddUpdateSalesMan', $scope.SalesMan).success(function (data) {
            if(data == 1){
                $window.alert('SalesMan: ' + $scope.SalesMan.SalesMan_Name + ' ' + (($scope.SalesMan.SalesManId > 0) ? 'updated' : 'added')  + ' successfully');
            }
            else{
                $window.alert('Unable to add/update SalesMan: ' + $scope.SalesMan.SalesMan_Name);
            }
            $scope.Reset();
            $location.path('/ViewSalesMan');
        }).error(function(data, status){
            $window.alert('Unable to add/update SalesMan: ' + $scope.SalesMan.SalesMan_Name + ' \n Status Code:' + status);
            $scope.Reset();
            $location.path('/ViewSalesMan');
        });        
    }
    $scope.Reset = function () {
        $scope.SalesMan = {
            SalesManId: 0,
            SalesMan_Name: '',
            Start_Date: '',
            End_Date: ''
        };
    }
});