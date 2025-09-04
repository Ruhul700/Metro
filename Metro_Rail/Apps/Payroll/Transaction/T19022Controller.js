app.controller("T19022Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19022 = {};
        loadItemData();
        function loadGridDataList(month) {
            loader(true)
            var load = Service.loadDataSingleParm('/T19022/LoadGridData', month);
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }

        function loadItemData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19022/GetMonthList');
            load.then(function (returnData) {
                $scope.obj.MonthList = JSON.parse(returnData);
                loader(false)
            });
        }

        $scope.onMonthChange = function () {
            $scope.obj.T19022.T_SALARY_MONTH = $scope.obj.ddlItem.T_MONTH_CODE;
            loadGridDataList($scope.obj.ddlItem.T_MONTH_CODE);
        };

        $scope.Save_Click = function () {
            loader(true)            
            var save = Service.saveData_Model_List('/T19027/SaveData', $scope.obj.T19022, $scope.obj.griDataList);
            save.then(function (returnData) {
                smsAlert(returnData);
                clear();
                loader(false)
            });
        }
        $scope.Clear_Click = function () {
            clear();
        }        
        function clear() {
            $scope.obj.T19022 = {};
            $scope.obj.ddlItem = null;
            loadGridDataList();
            loadItemData();
        }

    }
]);