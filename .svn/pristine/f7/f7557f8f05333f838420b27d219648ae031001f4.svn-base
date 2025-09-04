app.controller("T11104Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T11104 = {};
        loadData();
        function loadData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/T11104/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false)
            });
        }

        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            // $scope.obj.T11104.T_ROLL_CODE = $scope.obj.ddlPeriod.T_ROLL_CODE;
            var save = Service.saveData('/T11104/SaveData', $scope.obj.T11104);
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
            $scope.obj.T11104.T_ROLL_ID = data.T_ROLL_ID;
            $scope.obj.T11104.T_ROLL_CODE = data.T_ROLL_CODE;
            $scope.obj.T11104.T_ROLL_NAME = data.T_ROLL_NAME;
            $scope.obj.ddlRull = { T_ROLL_CODE: data.T_ROLL_CODE, T_ROLL_NAME: data.T_ROLL_NAME };
        }
        function clear() {
            $scope.obj.T11104 = {};
        }
    }
]);