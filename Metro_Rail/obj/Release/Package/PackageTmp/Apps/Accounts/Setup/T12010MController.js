app.controller("T12010MController", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12010M = {};
        $scope.obj.T12010M.ACCOUNT_HEADER_MAIN_CODE = '0';
        loadData();
        loadAccountType();
        function loadData() {
            loader(true);
            var gridData = Service.loadDataWithoutParm('/T12010M/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false);
            });
        }
        function loadAccountType() {
            var gridData = Service.loadDataWithoutParm('/T12010M/GetAccountType');
            gridData.then(function (redata) {
                $scope.obj.AccountTypeList = JSON.parse(redata);
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtEconoCode', 'lblEconoCode')) { return; }
            if (isEmpty('txtName', 'lblName')) { return; }
            if (isEmpty('ddlType', 'lblType')) { return; }
            loader(true);
            $scope.obj.T12010M.ACCOUNT_TYPE_CODE = $scope.obj.ddlAccountType.ACCOUNT_TYPE_CODE;
            var save = Service.saveData('/T12010M/SaveData', $scope.obj.T12010M);
            save.then(function (result) {
                smsAlert(result);
                loadData()
                clear();
                loader(false);
            });
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T12010M.ACCOUNT_HEADER_MAIN_ID = data.ACCOUNT_HEADER_MAIN_ID;
            $scope.obj.T12010M.ACCOUNT_HEADER_MAIN_NAME = data.ACCOUNT_HEADER_MAIN_NAME;
            $scope.obj.T12010M.ACCOUNT_HEADER_MAIN_NAME_ENG = data.ACCOUNT_HEADER_MAIN_NAME_ENG;
            $scope.obj.T12010M.ACCOUNT_HEADER_MAIN_CODE = data.ACCOUNT_HEADER_MAIN_CODE;
            $scope.obj.T12010M.ACCOUNT_ECONO_MAIN_CODE = data.ACCOUNT_ECONO_MAIN_CODE;
            $scope.obj.ddlAccountType = { ACCOUNT_TYPE_NAME: data.ACCOUNT_TYPE_NAME, ACCOUNT_TYPE_CODE: data.ACCOUNT_TYPE_CODE };
        }
        function clear() {
            $scope.obj.T12010M = {};
            $scope.obj.ddlAccountType = '';
        }
    }
]);