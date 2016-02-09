app.controller('ViewEmployeeController', ['$scope', '$http', '$location', '$filter', 'EmployeeService', function ($scope, $http, $location, $filter, EmployeeService) {
    $scope.EmployeeSearchText = '';
    $scope.EmployeeList = [];
    $scope.pullEmployee = function () {
        $http.get('/Master/PullEmployee', { EmployeeSearchString: $scope.EmployeeSearchText }).success(function (data, status) {
            if (status == 200) {
                $scope.EmployeeList = data;
            }
        });
    }
    $scope.PrepareDate = function (dt) {
        if ( dt == undefined || dt == null)                 
        {
            return '';            
        }
        else if (dt != null || dt.length != 0) {
            return $filter('date')(EmployeeService.formatDate(dt), 'dd-MMM-yyyy');
        }
        
    }
    
    $scope.navigateEmployeePage = function (Employee) {
        EmployeeService.EmployeeObj = {
            EmployeeId: Employee.EmployeeID,
            Employee_Name: Employee.Employee_NAME,
            Start_Date: Employee.START_DATE,
            End_Date: Employee.END_DATE
        }
        $location.path('/AddEmployee/' + Employee.EmployeeID);
    }
}]);

