app.controller('AddEmployeeController', function ($scope, $window, $routeParams, $http, $location, $filter, EmployeeService) {
    $scope.Employee = {
        EmployeeId:0,
        Employee_Name: '',
        Start_Date: '',
        End_Date: ''
    };
    $scope.Controls = {
        SubmitButton: 'Add',
        Heading: 'Add SalesMan',
        DisableControl: false
    };
    if ($routeParams.SalesManId > 0) {
        $scope.Employee = {
            EmployeeId: EmployeeService.EmployeeObj.EmployeeId,
            Employee_Name: EmployeeService.EmployeeObj.Employee_Name,
            Start_Date: (EmployeeService.EmployeeObj.Start_Date != null) ? $filter('date')(EmployeeService.formatDate(EmployeeService.EmployeeManObj.Start_Date), 'dd-MM-yyyy') : EmployeeService.EmployeeObj.Start_Date,
            End_Date: (EmployeeService.EmployeeObj.End_Date != null) ? $filter('date')(EmployeeService.formatDate(EmployeeService.EmployeeObj.End_Date), 'dd-MM-yyyy') : EmployeeService.EmployeeObj.End_Date
        }
        $scope.Controls={
            SubmitButton : 'Update',
            Heading: 'Update SalesMan',
            DisableControl: true    
        };
    }
    $scope.AddEmployee = function () {
        $http.put('/Master/AddUpdateEmployee', $scope.Employee).success(function (data) {
            if(data == 1){
                $window.alert('SalesMan: ' + $scope.Employee.Employee_Name + ' ' + (($scope.Employee.EmployeeId > 0) ? 'updated' : 'added')  + ' successfully');
            }
            else{
                $window.alert('Unable to add/update Employee: ' + $scope.Employee.Employee_Name);
            }
            $scope.Reset();
            $location.path('/ViewEmployee');
        }).error(function(data, status){
            $window.alert('Unable to add/update Employee: ' + $scope.Employee.Employee_Name + ' \n Status Code:' + status);
            $scope.Reset();
            $location.path('/ViewEmployee');
        });        
    }
    $scope.Reset = function () {
        $location.path('/ViewEmployee');
    }
    $scope.PrepareDate = function (dt) {
        return EmployeeService.formatDate(dt);
    }
});