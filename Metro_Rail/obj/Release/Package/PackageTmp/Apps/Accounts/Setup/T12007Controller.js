
app.controller("T12007Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12007 = {};
        $scope.obj.T12007.TRANSACTION_TYPE_CODE = '0';
        loadData();
        function loadData() {
            loader(true);
            var gridData = Service.loadDataWithoutParm('/T12007/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false);
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            loader(true);           
            var save = Service.saveData('/T12007/SaveData', $scope.obj.T12007);
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
            $scope.obj.T12007.TRANSACTION_TYPE_NAME = data.TRANSACTION_TYPE_NAME;
            $scope.obj.T12007.TRANSACTION_TYPE_CODE = data.TRANSACTION_TYPE_CODE;
        }
        function clear() {
            $scope.obj.T12007.TRANSACTION_TYPE_NAME = '';
            $scope.obj.T12007.TRANSACTION_TYPE_CODE = '0';
        }        
    }
]);