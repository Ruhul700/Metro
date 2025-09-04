app.controller("T12012Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12012 = {};
        $scope.obj.T12012.PURPOSE_CODE = '0';
        loadData();
        function loadData() {
            loader(true);
            var gridData = Service.loadDataWithoutParm('/T12012/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false);
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            loader(true);
            var save = Service.saveData('/T12012/SaveData', $scope.obj.T12012);
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
            $scope.obj.T12012.PURPOSE_NAME = data.PURPOSE_NAME;
            $scope.obj.T12012.PURPOSE_CODE = data.PURPOSE_CODE;
        }
        function clear() {
            $scope.obj.T12012.PURPOSE_NAME = '';
            $scope.obj.T12012.PURPOSE_CODE = '0';
        }      
    }
]);