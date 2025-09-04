app.controller("T19030Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19030 = {};
        $scope.Insert = {};
        loadGridData();
        getMonthData();
        $scope.onMonth = function () {
            var month = $scope.obj.ddlMonth.T_MONTH_CODE;
            loader(true)
            var load = Service.loadDataSingleParm('/T19030/LoadDataByMonth', month);
            load.then(function (returnData) {
                $scope.JsonData = JSON.parse(returnData)
                if ($scope.JsonData.length > 0) {
                    $scope.obj.griDataList = JSON.parse(returnData);
                    $scope.obj.T19030.T_ATTENDENCE_CODE = $scope.JsonData[0].T_ATTENDENCE_CODE;
                    $scope.obj.T19030.T_WORKING_DAY = $scope.JsonData[0].T_WORKING_DAY;
                } else {
                    loadGridData();
                }
                

                loader(false)
            });
        }
        function loadGridData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19030/LoadData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        function getMonthData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19030/GetMonthData');
            load.then(function (returnData) {
                $scope.obj.monthList = JSON.parse(returnData);
                loader(false)
            });
        }
        $scope.onPresent = function (ind, data) {
            var tDays = $scope.obj.T19030.T_WORKING_DAY;
            if (parseFloat(tDays) >= parseFloat(data.T_TOTAL_PRESENT)) {
                $scope.obj.griDataList[ind].T_TOTAL_ABSENT = parseFloat(tDays) - parseFloat(data.T_TOTAL_PRESENT);
            } else {
                var prt = data.T_TOTAL_PRESENT.toString();
                var p = prt.slice(0, -1);
                $scope.obj.griDataList[ind].T_TOTAL_PRESENT = parseFloat(p)

                    
            }
           

        }
        $scope.Save_Click = function () {
           // if (isEmpty('txtName', 'lblName')) { return; }
           // if (isEmpty('txtT.W.Day', 'lblT.W.Day')) { return; }
            $scope.Insert.T30Single = $scope.obj.T19030;
            $scope.Insert.T31List = $scope.obj.griDataList;
            loader(true)
            var save = Service.saveData('/T19030/SaveData', $scope.Insert);
            save.then(function (returnData) {
                smsAlert(returnData);
                loadGridData();
                clear();
                loader(false)
            });
        }
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T19030.T_ATTENDANCE_ID = data.T_ATTENDANCE_ID;
            $scope.obj.T19030.T_ATTENDANCE_CODE = data.T_ATTENDANCE_CODE;
            $scope.obj.T19030.T_ATTENDANCE_NAME = data.T_ATTENDANCE_NAME;
            $scope.obj.T19030.T_ATTENDANCE_TOTALWORKINGDAY = data.T_ATTENDANCE_TOTALWORKINGDAY;
            $scope.obj.ddlItem = { T_ATTENDANCE_NAME: data.T_ATTENDANCE_NAME, T_ATTENDANCE_CODE: data.T_DEDUCTION_CODE };
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clear() {
            $scope.obj.T19030 = {};
        }

    }
]);