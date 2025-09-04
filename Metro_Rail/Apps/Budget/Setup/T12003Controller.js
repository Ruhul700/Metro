app.controller("T12003Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12003 = {};
        $scope.obj.T_PERIOD_START_DATE = new Date();
        $scope.obj.T_PERIOD_END_DATE = new Date();
        loadData();
        PeriodData();
        function loadData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/T12003/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false)
            });
        }
        function PeriodData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/T12003/GetAllPeriodData');
            gridData.then(function (redata) {
                $scope.obj.periodDataList = JSON.parse(redata);
                loader(false)
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            if (isEmpty('ddlPeriod', 'lblPeriod')) { return; }
             if (isEmpty('txtStartDate', 'lblStartDate')) { return; }
            if (isEmpty('txtEndDate', 'lblEndDate')) { return; }
             $scope.obj.T12003.T_PERIOD_CODE = $scope.obj.ddlPeriod.T_PERIOD_CODE;
             $scope.obj.T12003.T_PERIOD_START_DATE = $filter('date')($scope.obj.T_PERIOD_START_DATE, 'dd-MM-yyyy');
              $scope.obj.T12003.T_PERIOD_END_DATE = $filter('date')($scope.obj.T_PERIOD_END_DATE, 'dd-MM-yyyy');
            loader(true);
            var save = Service.saveData('/T12003/SaveData', $scope.obj.T12003);
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
            $scope.obj.T12003.T_PROJECT_ID = data.T_PROJECT_ID;
            $scope.obj.T12003.T_PROJECT_CODE = data.T_PROJECT_CODE;
            $scope.obj.T12003.T_PROJECT_NAME = data.T_PROJECT_NAME;
            $scope.obj.ddlPeriod = { T_PERIOD_CODE: data.T_PERIOD_CODE, T_PERIOD_NAME: data.T_PERIOD_NAME };
           // $scope.obj.T12003.T_PERIOD_START_DATE = data.T_PERIOD_START_DATE;
            //$scope.obj.T12003.T_PERIOD_END_DATE = data.T_PERIOD_END_DATE;
              $scope.obj.T_PERIOD_START_DATE = data.T_PERIOD_START_DATE == ''?'':stringToDate(data.T_PERIOD_START_DATE,'dd-MM-yyyy','-') ;
             $scope.obj.T_PERIOD_END_DATE = data.T_PERIOD_END_DATE==''?'': stringToDate(data.T_PERIOD_END_DATE, 'dd-MM-yyyy', '-');
        }
        function clear() {
            $scope.obj.T12003 = {};
        }
    }
]);