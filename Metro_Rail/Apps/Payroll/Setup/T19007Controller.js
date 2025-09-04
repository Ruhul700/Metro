app.controller("T19007Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19007 = {};
        loadGridData();
        function loadGridData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19007/LoadData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            if (isEmpty('txtRatio', 'lblRatio')) { return; }
            loader(true)
            var save = Service.saveData('/T19007/SaveData', $scope.obj.T19007);
            save.then(function (returnData) {
                smsAlert(returnData);
                loadGridData();
                clear();
                loader(false)
            });
        }
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T19007.T_DEDUCTION_ID = data.T_DEDUCTION_ID;
            $scope.obj.T19007.T_DEDUCTION_CODE = data.T_DEDUCTION_CODE;
            $scope.obj.T19007.T_DEDUCTION_NAME = data.T_DEDUCTION_NAME;
            $scope.obj.T19007.T_DEDUCTION_AMOUNT = data.T_DEDUCTION_AMOUNT;           
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clear() {
            $scope.obj.T19007 = {};
        }

    }
]);