app.controller('AddSalesManController', function ($scope, $window, $routeParams, $http, $location, $filter, SalesManService) {
    $scope.SalesMan = {
        SalesManId:0,
        SalesMan_Name: '',
        Start_Date: '',
        End_Date: ''
    };
    $scope.Controls = {
        SubmitButton: 'Add',
        Heading: 'Add SalesMan',
        DisableControl: false
    };
    if ($routeParams.SalesManId > 0) {
        $scope.SalesMan = {
            SalesManId: SalesManService.SalesManObj.SalesManId,
            SalesMan_Name: SalesManService.SalesManObj.SalesMan_Name,
            Start_Date: (SalesManService.SalesManObj.Start_Date != null) ? $filter('date')(SalesManService.formatDate(SalesManService.SalesManObj.Start_Date), 'dd-MM-yyyy') : SalesManService.SalesManObj.Start_Date,
            End_Date: (SalesManService.SalesManObj.End_Date != null) ? $filter('date')(SalesManService.formatDate(SalesManService.SalesManObj.End_Date), 'dd-MM-yyyy') : SalesManService.SalesManObj.End_Date
        }
        $scope.Controls={
            SubmitButton : 'Update',
            Heading: 'Update SalesMan',
            DisableControl: true    
        };
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
        $location.path('/ViewSalesMan');
    }
    $scope.PrepareDate = function (dt) {
        return SalesManService.formatDate(dt);
    }
});