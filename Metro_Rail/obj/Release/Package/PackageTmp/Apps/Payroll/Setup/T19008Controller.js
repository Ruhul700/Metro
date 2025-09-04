app.controller("T19008Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19008 = {};
        loadGridData();
        function loadGridData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19008/LoadData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            if (isEmpty('txtRatio', 'lblRatio')) { return; }
            loader(true)
            var save = Service.saveData('/T19008/SaveData', $scope.obj.T19008);
            save.then(function (returnData) {
                smsAlert(returnData);
                loadGridData();
                clear();
                loader(false)
            });
        }
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T19008.T_GRADE_ID = data.T_GRADE_ID;
            $scope.obj.T19008.T_GRADE_CODE = data.T_GRADE_CODE;
            $scope.obj.T19008.T_GRADE_NAME = data.T_GRADE_NAME;
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clear() {
            $scope.obj.T19008 = {};
        }

    }
]);