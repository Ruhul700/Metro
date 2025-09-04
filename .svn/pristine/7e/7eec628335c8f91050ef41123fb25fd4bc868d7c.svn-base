app.controller("T11011Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T11011 = {};
        loadGridData();       
        function loadGridData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T11011/LoadData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }       
        $scope.Save_Click = function () {
            if (isEmpty('txtMonth', 'lblMonth')) { return; }  
            loader(true)
            var save = Service.saveData('/T11011/SaveData', $scope.obj.T11011);
            save.then(function (returnData) {
                smsAlert(returnData);
                loadGridData();
                clear();
                loader(false)
            });
        }
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T11011.T_MONTH_ID = data.T_MONTH_ID;
            $scope.obj.T11001.T_MONTH_CODE = data.T_MONTH_CODE;
            $scope.obj.T11011.T_MONTH_NAME = data.T_MONTH_NAME;
            $scope.obj.ddlItem = { T_MONTH_NAME: data.T_MONTH_NAME, T_MONTH_CODE: data.T_MONTH_CODE };
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clear() {
            $scope.obj.T11011 = {};
        }

    }
]);