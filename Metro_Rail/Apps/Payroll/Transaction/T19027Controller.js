app.controller("T19027Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19027 = {};        
        loadGridDataList();

         function loadGridDataList() {
            loader(true)
             var load = Service.loadDataWithoutParm('/T19027/LoadGridData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        $scope.Save_Click = function () {
            debugger;
           
            debugger;
            var flagValue = $scope.obj.T19027.T_VERIFY_FLAG;
            console.log($scope.obj.T19027, $scope.obj.griDataList);
            loader(true)            
            var save = Service.saveData_Model_List('/T19027/SaveData', $scope.obj.T19027, $scope.obj.griDataList);
            save.then(function (returnData) {
                smsAlert(returnData);
                clear();
                loader(false)
            });
        }
        $scope.Clear_Click = function () {
            clear();
        }        
        function clear() {
            $scope.obj.T19027 = {};
            loadGridDataList();
        }
    }
]);