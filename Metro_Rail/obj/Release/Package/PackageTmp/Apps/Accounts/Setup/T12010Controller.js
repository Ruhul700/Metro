
app.controller("T12010Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12010 = {};
        $scope.obj.T12010.ACCOUNT_HEADER_CODE = '0';
        loadData();
        loadAccountType();
        loadMainHeader()
        function loadData() {
            loader(true);
            var gridData = Service.loadDataWithoutParm('/T12010/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false);
            });
        }
        function loadAccountType() {          
            var gridData = Service.loadDataWithoutParm('/T12010/GetAccountType');
            gridData.then(function (redata) {
                $scope.obj.AccountTypeList = JSON.parse(redata);               
            });
        }
        function loadMainHeader() {
            var mainHeader = Service.loadDataWithoutParm('/T12010/GetMainHeader');
            mainHeader.then(function (redata) {
                $scope.obj.MainHeaderList = JSON.parse(redata);
            });
        }
        $scope.MainHeadChange = function (data) {
            $scope.obj.T12010.ACCOUNT_ECONO_MAIN_CODE = data.ACCOUNT_ECONO_MAIN_CODE;
            $scope.obj.ddlAccountType = { ACCOUNT_TYPE_CODE: data.ACCOUNT_TYPE_CODE, ACCOUNT_TYPE_NAME: data.ACCOUNT_TYPE_NAME };

        }
        $scope.Save_Click = function () {           
            if (isEmpty('txtName', 'lblName')) { return; }
            if (isEmpty('ddlType', 'lblType')) { return; }
            loader(true);           
            $scope.obj.T12010.ACCOUNT_TYPE_CODE = $scope.obj.ddlAccountType.ACCOUNT_TYPE_CODE;
            $scope.obj.T12010.ACCOUNT_HEADER_MAIN_CODE = $scope.obj.ddlMainHeader.ACCOUNT_HEADER_MAIN_CODE;
            var save = Service.saveData('/T12010/SaveData', $scope.obj.T12010);
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
            $scope.obj.T12010.ACCOUNT_HEADER_ID = data.ACCOUNT_HEADER_ID;
            $scope.obj.T12010.ACCOUNT_HEADER_NAME = data.ACCOUNT_HEADER_NAME;
            $scope.obj.T12010.ACCOUNT_HEADER_NAME_ENG = data.ACCOUNT_HEADER_NAME_ENG;
            $scope.obj.T12010.ACCOUNT_HEADER_CODE = data.ACCOUNT_HEADER_CODE;
            $scope.obj.T12010.ACCOUNT_ECONO_CODE = data.ACCOUNT_ECONO_CODE;
            $scope.obj.T12010.ACCOUNT_ECONO_MAIN_CODE = data.ACCOUNT_ECONO_MAIN_CODE;
            $scope.obj.ddlAccountType = { ACCOUNT_TYPE_NAME: data.ACCOUNT_TYPE_NAME, ACCOUNT_TYPE_CODE: data.ACCOUNT_TYPE_CODE};
            $scope.obj.ddlMainHeader = { ACCOUNT_HEADER_MAIN_NAME: data.ACCOUNT_HEADER_MAIN_NAME, ACCOUNT_HEADER_MAIN_CODE: data.ACCOUNT_HEADER_MAIN_CODE};
        }
        function clear() {
            $scope.obj.T12010 = {};
            $scope.obj.T12010.ACCOUNT_HEADER_CODE = '0';
            $scope.obj.ddlAccountType = '';
        }       
    }
]);