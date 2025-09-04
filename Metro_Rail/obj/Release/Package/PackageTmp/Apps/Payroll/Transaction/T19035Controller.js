app.controller("T19035Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19035 = {};
        loadGridDataList();
        getClient();
        loadLeaveTypeListData();

        function loadLeaveTypeListData() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19035/GetLeaveTypeList');
            load.then(function (returnData) {
                $scope.obj.LeaveTypeList = JSON.parse(returnData);
                loader(false)
            });
        }
        function loadGridDataList() {
            loader(true)
            var load = Service.loadDataWithoutParm('/T19035/LoadGridData');
            load.then(function (returnData) {
                $scope.obj.griDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        $scope.CancelClicked = function (rowData) {
            rowData.T_CANCELLED = "yes";
            loader(true)
            var save = Service.saveData('/T19035/CancelApplication', rowData);
            save.then(function (returnData) {
                smsAlert(returnData);
                loadGridDataList();
                clear();
                loader(false)
            });
        }
        function formatDateToDDMMYYYY(dateObj) {
            if (!dateObj) return "";
            const d = new Date(dateObj);
            const day = ('0' + d.getDate()).slice(-2);
            const month = ('0' + (d.getMonth() + 1)).slice(-2);
            const year = d.getFullYear();
            return `${day}-${month}-${year}`;
        }
        $scope.confirmCancel = function (rowData) {
            var result = confirm("Are you sure you want to cancel the application?");
            if (result) {
                $scope.CancelClicked(rowData);
            }
        };
        $scope.calculateLeaveDays = function () {
            var from = new Date($scope.obj.T19035.T_FROM_DATE);
            var to = new Date($scope.obj.T19035.T_TO_DATE);

            if (!isNaN(from) && !isNaN(to) && to >= from) {
                var diff = to.getTime() - from.getTime();
                var days = Math.floor(diff / (1000 * 60 * 60 * 24)) + 1;

                $scope.obj.T19035.T_TOTAL_DATE = days;
                $scope.obj.T19035.FROM_DATE_STRING = formatDateToDDMMYYYY(from);
                $scope.obj.T19035.TO_DATE_STRING = formatDateToDDMMYYYY(to);
            } else {
                $scope.obj.T19035.TOTAL_DAYS = '';
                $scope.obj.T19035.FROM_DATE_STRING = '';
                $scope.obj.T19035.TO_DATE_STRING = '';
            }
        };
        function getClient() {
            var client = Service.loadDataWithoutParm('/T19035/GetEmpList');
            client.then(function (redata) {
                $scope.obj.ClientList = JSON.parse(redata);
            });
        }
        $scope.ClientName = function () {
            document.getElementById('Client').style.display = "block";
        }
        $scope.closeModal = function (id) {
            document.getElementById(id).style.display = "none";
        }
        $scope.setEmpRow = function (ind, data) {
            debugger;
            document.getElementById('Client').style.display = "none";
            $scope.obj.T19035.T_EMP_CODE = data.T_EMP_CODE;
            $scope.obj.T19035.T_EMP_NAME = data.T_EMP_NAME;
        }
        $scope.setRowData = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T19035.T_APLCTN_CODE = data.T_APLCTN_CODE;
            $scope.obj.T19035.T_EMP_CODE = data.T_EMP_CODE;
            $scope.obj.T19035.T_EMP_NAME = data.T_EMP_NAME;
            $scope.obj.T19035.T_WIDTH_PAY = data.T_WIDTH_PAY;
            $scope.obj.T19035.T_FROM_DATE = parseDateFromString(data.FROM_DATE_STRING);
            $scope.obj.T19035.T_TO_DATE = parseDateFromString(data.TO_DATE_STRING);
            $scope.obj.T19035.T_TOTAL_DATE = data.T_TOTAL_DATE;
            $scope.obj.ddlItem = { T_LEAVE_CODE: data.T_LEAVE_CODE, T_LEAVE_NAME: data.T_LEAVE_NAME };
        }
        function parseDateFromString(dateStr) {
            if (!dateStr) return null;
            var parts = dateStr.split('-');
            return new Date(parts[2], parts[1] - 1, parts[0]);
        }
        $scope.Save_Click = function () {
            $scope.obj.T19035.T_LEAVE_CODE = $scope.obj.ddlItem.T_LEAVE_CODE;
            loader(true)
            var save = Service.saveData('/T19035/SaveData', $scope.obj.T19035);
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
            $scope.obj.T19035 = {};
            loadGridDataList();
            getClient();
            loadLeaveTypeListData();
        }

    }
]);