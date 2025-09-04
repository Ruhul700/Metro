

app.controller("T12005Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12005 = {};
        $scope.obj.T12005.CENTER_CODE = '0';
        loadData();
        function loadData() {
            loader(true);           
            var gridData = Service.loadDataWithoutParm('/T12005/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);                
                loader(false);
            });
        }
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }          
            loader(true);            
            var save = Service.saveData('/T12005/SaveData', $scope.obj.T12005);
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
            $scope.obj.T12005.CENTER_NAME = data.CENTER_NAME;
            $scope.obj.T12005.CENTER_CODE = data.CENTER_CODE;
        }
        function clear() {
            $scope.obj.T12005.CENTER_NAME = '';
            $scope.obj.T12005.CENTER_CODE = '0';
        }      
    }
]);