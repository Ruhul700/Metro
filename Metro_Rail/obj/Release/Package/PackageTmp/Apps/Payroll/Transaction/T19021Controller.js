app.controller("T19021Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) {
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19021 = {};
      
        loadMonthItemData();

        function loadMonthItemData() {
            loader(true);
            var load = Service.loadDataWithoutParm('/T19021/GetMonthList');
            load.then(function (returnData) {
                $scope.obj.MonthList = JSON.parse(returnData);

                var currentMonth = new Date().getMonth() + 1;
                var currentMonthStr = currentMonth.toString().trim(); // string format

                angular.forEach($scope.obj.MonthList, function (item) {
                    item.T_MONTH_CODE = item.T_MONTH_CODE.toString().trim(); // ensure string
                    item.disabled = parseInt(item.T_MONTH_CODE) > currentMonth;
                });
                //$scope.obj.ddlItemTo = currentMonthStr;
                loader(false);
            });
        }

        $scope.onMonthChange = function () {
            $scope.obj.T19021.T_SALARY_MONTH_FROM = $scope.obj.ddlItem;
        };
         $scope.onMonthToChange = function () {
             $scope.obj.T19021.T_SALARY_MONTH_TO = $scope.obj.ddlItemTo;
             loadGridDataList();
        };

        function loadGridDataList() {        

            loader(true)
            var load = Service.loadDataSingleParm('/T19021/LoadGridData', $scope.obj.T19021);
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                console.log($scope.obj.griDataList);
                loader(false)
            });
        }   
        
        $scope.Clear_Click = function () {
            clear();
        }       
        function clear() {
            $scope.obj.T19021 = {};
        }
        $scope.Print_Click = function () {
            if (isEmpty('ddlFromDate', 'lblFromDate')) { return; }
            if (isEmpty('ddlToDate', 'lblToDate')) { return; }

            fromMonth = $scope.obj.ddlItem;
            toMonth = $scope.obj.ddlItemTo;
            $window.open("../T19021/GetSalarySummeryMonthWise?fromDate=" + fromMonth + "&toDate=" + toMonth, "_blank");
        }
    }
]);