app.controller("T19023Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19023 = {};
        loadGridDataList();
        function loadGridDataList() {            
            loader(true)
            var load = Service.loadDataWithoutParm('/T19023/LoadGridData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }      

                
        $scope.Clear_Click = function () {
            clear();
        }       
        function clear() {
            $scope.obj.T19021 = {};
        }
        $scope.Print_Click = function (item) {
            debugger;
            $window.open("/T19023/ChalanReport?T_EMP_CODE=" + item.T_EMP_CODE, "_blank");
            //window.open('/T19023/ChalanReport', '_blank');
        }
    }
]);