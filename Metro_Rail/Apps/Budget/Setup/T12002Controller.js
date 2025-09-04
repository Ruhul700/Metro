
app.controller("T12002Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12002 = {};
        //$scope.obj.T_PERIOD_START_DATE = new Date();
       // $scope.obj.T_PERIOD_END_DATE = new Date();
        loadData();
        function loadData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/T12002/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false)
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
           // if (isEmpty('txtStartDate', 'lblStartDate')) { return; }
            if (isEmpty('txtUm', 'lblUm')) { return; }
           // $scope.obj.T12002.T_PERIOD_START_DATE = $filter('date')($scope.obj.T_PERIOD_START_DATE, 'dd-MM-yyyy');
          //  $scope.obj.T12002.T_PERIOD_END_DATE = $filter('date')($scope.obj.T_PERIOD_END_DATE, 'dd-MM-yyyy');
            loader(true);
            var save = Service.saveData('/T12002/SaveData', $scope.obj.T12002);
            save.then(function (result) {
                smsAlert(result);
                loadData()
                clear();
                loader(false)
            });
        }
        $scope.Clear_Click = function () {
            clear();
        }        
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T12002.T_PERIOD_ID = data.T_PERIOD_ID;
            $scope.obj.T12002.T_PERIOD_CODE = data.T_PERIOD_CODE;
            $scope.obj.T12002.T_PERIOD_NAME = data.T_PERIOD_NAME;
            $scope.obj.T12002.T_UM = data.T_UM;
          //  $scope.obj.T_PERIOD_START_DATE = data.T_PERIOD_START_DATE == ''?'':stringToDate(data.T_PERIOD_START_DATE,'dd-MM-yyyy','-') ;
           // $scope.obj.T_PERIOD_END_DATE = data.T_PERIOD_END_DATE==''?'': stringToDate(data.T_PERIOD_END_DATE, 'dd-MM-yyyy', '-');
        }
        function clear() {
            $scope.obj.T12002 = {};            
        }
    }
]);