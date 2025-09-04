app.controller("T19025Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19025 = {};      
        loadBonusData();

        function loadBonusData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19025/GetBonusList');
            load.then(function (returnData) {
                $scope.obj.BonusList = JSON.parse(returnData);
                loader(false)
            });
        }
        function loadGridDataList(infoCode) {
            loader(true)
            var load = Service.loadDataSingleParm('/T19025/LoadGridData', infoCode);
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        $scope.onBonusChange = function () {
            loadGridDataList($scope.obj.ddlBonus.T_SALARY_INFO_CODE);
        };
        $scope.Save_Click = function () {
            $scope.obj.T19025.T_SALARY_INFO_CODE = $scope.obj.ddlBonus.T_SALARY_INFO_CODE
            loader(true)
            var save = Service.saveData_Model_List('/T19025/SaveData', $scope.obj.T19025, $scope.obj.griDataList);
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
            $scope.obj.T19025 = {};
            loadBonusData();

        }

    }
]);