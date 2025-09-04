

app.controller("T12011Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12011 = {};
        $scope.obj.T12011.DEPARTMENT_CODE = '0';
        loadData();
        function loadData() {
            loader(true);
            var gridData = Service.loadDataWithoutParm('/T12011/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false);
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
            loader(true);           
            var save = Service.saveData('/T12011/SaveData', $scope.obj.T12011);
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
            $scope.obj.T12011.DEPARTMENT_NAME = data.DEPARTMENT_NAME;
            $scope.obj.T12011.DEPARTMENT_CODE = data.DEPARTMENT_CODE;
        }
        function clear() {
            $scope.obj.T12011.DEPARTMENT_NAME = '';
            $scope.obj.T12011.DEPARTMENT_CODE = '0';
        }        
    }
]);