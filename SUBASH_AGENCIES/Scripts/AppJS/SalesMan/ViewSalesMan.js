app.controller('ViewSalesManController', ['$scope', '$http', '$location', '$filter', 'SalesManService', function ($scope, $http, $location, $filter, SalesManService) {
    $scope.SalesManSearchText = '';
    $scope.SalesManList = [];
    $scope.pullSalesMan = function () {
        $http.get('/Master/PullSalesMan', { SalesManSearchString: $scope.SalesManSearchText }).success(function (data, status) {
            if (status == 200) {
                $scope.SalesManList = data;
            }
        });
    }
    $scope.PrepareDate = function (dt) {
        if ( dt == undefined || dt == null)                 
        {
            return '';            
        }
        else if (dt != null || dt.length != 0) {
            return $filter('date')(SalesManService.formatDate(dt), 'dd-MMM-yyyy');
        }
        
    }
    
    $scope.navigateSalesManPage = function (SalesMan) {
        SalesManService.SalesManObj = {
            SalesManId: SalesMan.SALESMANID,
            SalesMan_Name: SalesMan.SALESMAN_NAME,
            Start_Date: SalesMan.START_DATE,
            End_Date: SalesMan.END_DATE
        }
        $location.path('/AddSalesMan/' + SalesMan.SALESMANID);
    }
}]);

