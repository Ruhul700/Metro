
app.controller("R11111Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.R11111 = {};
        //Period();
        loadData();
        function loadData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/R11111/LoadData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false)
            });
        }
        function Period() {
            $scope.obj.PeriodList = [
                { CODE: '101', NAME: '2024-2025' }
            ];
        }
        $scope.Clear_Click = function () {
            clear();
        }
        function clear() {
            $scope.obj.R11111 = {};
        }
        $scope.CheckSingle_Click = function (ind,data) {
            if (data == '0') {
                for (var i = 0; i < $scope.obj.griDataList.length; i++) {                   
                        $scope.obj.griDataList[i].Single_FLG = '0';                    
                }
            } else {
                for (var i = 0; i < $scope.obj.griDataList.length;i++) {
                    if (i == ind) {
                        $scope.obj.griDataList[i].Single_FLG = '1';
                    } else {
                        $scope.obj.griDataList[i].Single_FLG = '0';
                    }
                }
            }
        }
        $scope.Print_Click = function () {
            //if (isEmpty('ddlPeriod', 'lblPeriod')) { return; }           
            //var periodName = $scope.obj.ddlPeriod.NAME
            $scope.Newlist = $scope.obj.griDataList.filter(x => x.Single_FLG == '1');
            if ($scope.Newlist.length == '1') {
                var code = $scope.Newlist[0].T_EMP_CODE;
                $window.open("../R11111/GetSalaryStartment?code=" + code, "_blank");
            } else {
                $window.open("../R11111/GetSalarySheet?code=" + code, "_blank");
            }
           
        }
    }
]);