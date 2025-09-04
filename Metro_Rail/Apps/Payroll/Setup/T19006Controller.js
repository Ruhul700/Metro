app.controller("T19006Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19006 = {};
        loadGridData();
        function loadGridData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19006/LoadData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }        
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            //if (isEmpty('ddlItem', 'lblItem')) { return; }
            //$scope.obj.T19005.T_SALARY_INFO_CODE = $scope.obj.ddlItem.T_ITEM_CODE;
            loader(true)
            var save = Service.saveData('/T19006/SaveData', $scope.obj.T19006);
            save.then(function (returnData) {
                smsAlert(returnData);
                loadGridData();
                clear();
                loader(false)
            });
        }
        $scope.setRowData = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T19006.T_BENEFIT_ID = data.T_BENEFIT_ID;
            $scope.obj.T19006.T_BENEFIT_CODE = data.T_BENEFIT_CODE;
            $scope.obj.T19006.T_BENEFIT_NAME = data.T_BENEFIT_NAME;
            $scope.obj.T19006.T_BENEFIT_AMOUNT = data.T_BENEFIT_AMOUNT;
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clear() {
            $scope.obj.T19006 = {};
        }

    }
]);