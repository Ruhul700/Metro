

app.controller("T12000Controller", ["$scope", "T12000Service", "Data", "$window", "$filter",
    function ($scope, T12000Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12000 = {};
        $scope.obj.FormName = 'T12000';
        //$scope.$on('$locationChangeStart', function (event, next, current) {
        //    event.preventDefault();
        //});
        $scope.Login_click = function () {
            login();
        };
        $scope.enter_press = function (event) {
            if (event.keyCode === 13) {
                login();
            }
        }
        function login() {

            
        }
        $scope.Save_Click = function () {
            alert('Save');
        }
        $scope.Clear_Click = function () {
            alert('Clear');
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);