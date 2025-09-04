app.controller("T19005Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19005 = {};
        loadGridData();
        LoadBaseData();
        function loadGridData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19005/LoadData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        function LoadBaseData() {           
            var load = Service.loadDataWithoutParm('/T19005/GetBaseData');
            load.then(function (returnData) {
                $scope.obj.BaseList = JSON.parse(returnData);               
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtCode', 'lblCode')) { return; }
            if (isEmpty('txtName', 'lblName')) { return; }
            if (isEmpty('ddlBase', 'lblBase')) { return; }
            $scope.obj.T19005.T_BASE_CODE = $scope.obj.ddlBase.T_BASE_CODE;
            loader(true)
            var save = Service.saveData('/T19005/SaveData', $scope.obj.T19005);
            save.then(function (returnData) {
                smsAlert(returnData);
                loadGridData();
                clear();
                loader(false)
            });
        }
        $scope.setRowData = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T19005.T_SALARY_INFO_ID = data.T_SALARY_INFO_ID;
            $scope.obj.T19005.T_SALARY_INFO_CODE = data.T_SALARY_INFO_CODE;
            $scope.obj.T19005.T_SALARY_INFO_NAME = data.T_SALARY_INFO_NAME;
            $scope.obj.ddlBase = { T_BASE_CODE: data.T_BASE_CODE, T_BASE_NAME: data.T_BASE_NAME };
            $scope.obj.T19005.T_SALARY_INFO_RATIO = data.T_SALARY_INFO_RATIO;
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clear() {
            $scope.obj.T19005 = {};
        }

    }
]);