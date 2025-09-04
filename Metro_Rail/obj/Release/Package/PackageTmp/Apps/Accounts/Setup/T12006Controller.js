

app.controller("T12006Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12006 = {};
        $scope.obj.T12006.VAUCHER_TYPE_CODE = '0';
        loadData();
        function loadData() {
            loader(true);
            var gridData = Service.loadDataWithoutParm('/T12006/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false);
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            loader(true);            
            var save = Service.saveData('/T12006/SaveData', $scope.obj.T12006);
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
            $scope.obj.T12006.VAUCHER_TYPE_NAME = data.VAUCHER_TYPE_NAME;
            $scope.obj.T12006.VAUCHER_TYPE_CODE = data.VAUCHER_TYPE_CODE;
        }
        function clear() {
            $scope.obj.T12006.VAUCHER_TYPE_NAME = '';
            $scope.obj.T12006.VAUCHER_TYPE_CODE = '0';
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);