
app.controller("R13002Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.R13002 = {};      
        $scope.obj.Trail_FLG = '0';
        $scope.obj.Income_FLG = '0';
        $scope.obj.Balace_FLG = '0';
        getCenter();        
        $scope.obj.R13002.FROM_DATE = new Date();
        $scope.obj.R13002.TO_DATE = new Date(); 
        function getCenter() {
            var center = Service.loadDataWithoutParm('/T13001/GetCenterData')
            center.then(function (redata) {
                $scope.obj.CenterList = JSON.parse(redata);
            });
        }  
        $scope.CheckSingle_Click = function (id) {
            if (id == 'Trial') {
                $scope.obj.Trail_FLG = '1'
              //  $scope.obj.Cost_FLG = '0'
                $scope.obj.Income_FLG = '0'
                $scope.obj.Balace_FLG = '0'
                $scope.obj.IntialBalance_FLG = '0'
            }            
            else if (id == 'Income') {
                $scope.obj.Trail_FLG = '0'               
                $scope.obj.Income_FLG = '1'
                $scope.obj.Balace_FLG = '0'
                $scope.obj.IntialBalance_FLG = '0'
            }
            else if (id == 'Balance') {
                $scope.obj.Trail_FLG = '0'               
                $scope.obj.Income_FLG = '0'
                $scope.obj.Balace_FLG = '1'
                $scope.obj.IntialBalance_FLG = '0'
            }
            else if (id == 'IntialBalance') {
                $scope.obj.Trail_FLG = '0'
                $scope.obj.Income_FLG = '0'
                $scope.obj.Balace_FLG = '0'               
                $scope.obj.IntialBalance_FLG = '1'

            }
        }
        
        $scope.Clear_Click = function () {
            alert('Clear');
        }
        $scope.Print_Click = function () {            
            var fromDate = $filter('date')($scope.obj.R13002.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.R13002.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
          
            if ($scope.obj.Trail_FLG == '1') {
                $window.open("../R13002/RrialBalance?center=" + center + "&fromDate=" + fromDate + "&toDate=" + toDate, "_blank");
            }
            else if ($scope.obj.Income_FLG == '1') {
                $window.open("../R13002/IncomeStatement?center=" + center + "&fromDate=" + fromDate + "&toDate=" + toDate, "_blank");
            }
            else if ($scope.obj.Balace_FLG == '1') {
                $window.open("../R13002/BalanceSheet?center=" + center + "&fromDate=" + fromDate + "&toDate=" + toDate, "_blank");
            }
            else if ($scope.obj.IntialBalance_FLG == '1') {
                $window.open("../R13002/Banck_Cash_Initial_Balance", "_blank");
            }
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);