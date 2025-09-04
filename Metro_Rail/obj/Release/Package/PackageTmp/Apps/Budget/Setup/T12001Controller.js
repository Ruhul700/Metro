app.controller("T12001Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12001 = {};
        loadData();       
        function loadData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/T12001/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false)
            });
        }
     
        $scope.Save_Click = function () {
            if (isEmpty('txtName', 'lblName')) { return; }
           // $scope.obj.T12001.T_BUDGET_YEAR_CODE = $scope.obj.ddlPeriod.T_BUDGET_YEAR_CODE;
            var save = Service.saveData('/T12001/SaveData', $scope.obj.T12001);
            save.then(function (result) {
                smsAlert(result);
                loadData()
                clear();
                loader(false)
            });
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T12001.T_BUDGET_YEAR_ID = data.T_BUDGET_YEAR_ID;
            $scope.obj.T12001.T_BUDGET_YEAR_CODE = data.T_BUDGET_YEAR_CODE;
            $scope.obj.T12001.T_BUDGET_YEAR_NAME = data.T_BUDGET_YEAR_NAME;
            $scope.obj.ddlBudget = { T_BUDGET_YEAR_CODE: data.T_BUDGET_YEAR_CODE, T_BUDGET_YEAR_NAME: data.T_BUDGET_YEAR_NAME };
           
        }
        function clear() {
            $scope.obj.T12001 = {};
        }
    }
]);