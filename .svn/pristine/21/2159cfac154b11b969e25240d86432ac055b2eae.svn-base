

app.controller("AS12014Controller", ["$scope", "AS12014Service", "Data", "$window", "$filter",
    function ($scope, AS12014Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.AS12014 = {};
        //$scope.obj.AS12012.PURPOSE_CODE = '0';
        loadData();
        function loadData() {
            loader(true);
            var gridData = AS12014Service.getAllData();
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false);
            });
        }
        $scope.Save_Click = function () {
            $scope.Newlist = $scope.obj.griDataList.filter(x => x.T_ACTIVE_FLG == '1');           
            loader(true);            
            var save = AS12014Service.saveData($scope.Newlist);
            save.then(function (redata) {
                alert(redata);
                loadData()
              //  clear();
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
           // $scope.obj.AS12012.PURPOSE_NAME = data.PURPOSE_NAME;
            //$scope.obj.AS12012.PURPOSE_CODE = data.PURPOSE_CODE;
        }
        function clear() {
           // $scope.obj.AS12012.PURPOSE_NAME = '';
           // $scope.obj.AS12012.PURPOSE_CODE = '0';
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);