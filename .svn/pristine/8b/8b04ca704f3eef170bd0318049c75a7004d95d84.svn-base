app.controller("T19013Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19013 = {};
        loadGridData();
        function loadGridData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19013/LoadData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            if (isEmpty('txtDays', 'lblDays')) { return; }
            loader(true)
            var save = Service.saveData('/T19013/SaveData', $scope.obj.T19013);
            save.then(function (returnData) {
                smsAlert(returnData);
                loadGridData();
                clear();
                loader(false)
            });
        }
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T19013.T_LEAVE_ID = data.T_LEAVE_ID;
            $scope.obj.T19013.T_LEAVE_CODE = data.T_LEAVE_CODE;
            $scope.obj.T19013.T_LEAVE_NAME = data.T_LEAVE_NAME;
            $scope.obj.T19013.T_LEAVE_DAY = data.T_LEAVE_DAY;
            $scope.obj.ddlItem = { T_LEAVE_NAME: data.T_LEAVE_NAME, T_LEAVE_CODE: data.T_LEAVE_CODE };
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clear() {
            $scope.obj.T19013 = {};
        }

    }
]);