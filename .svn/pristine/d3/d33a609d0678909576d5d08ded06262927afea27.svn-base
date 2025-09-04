app.controller("T19036Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19035 = {};        
        loadGridDataList();

         function loadGridDataList() {
            loader(true)
             var load = Service.loadDataWithoutParm('/T19035/LoadGridData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }    
        $scope.Save_Click = function () {
            debugger;
            var dataToSend = [];
            angular.forEach($scope.obj.griDataList, function (item) {
                if (item.T_VERIFY_FLAG === '1' || item.T_REJECT_FLAG === '1') {
                    dataToSend.push({
                        T_APLCTN_CODE: item.T_APLCTN_CODE,
                        T_EMP_CODE: item.T_EMP_CODE,
                        T_VERIFY_FLAG: item.T_VERIFY_FLAG || '',
                        T_REJECT_FLAG: item.T_REJECT_FLAG || ''
                    });
                }
            });
            loader(true)            
            var save = Service.saveData_Model_List('/T19036/SaveData',$scope.obj.T19036, dataToSend);
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
            $scope.obj.T19036 = {};
            loadGridDataList();
        }

    }
]);