
app.controller("T13003Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T13003 = {};
        $scope.Param = {};
        $scope.obj.POSTING_ALL = '0';
        $scope.obj.T13003.FROM_DATE = new Date();
        $scope.obj.T13003.TO_DATE = new Date();
        var fromDate = $filter('date')($scope.obj.T13003.FROM_DATE, 'dd-MM-yyyy');
        var toDate = $filter('date')($scope.obj.T13003.TO_DATE, 'dd-MM-yyyy');
        getVoucherList('0', fromDate, toDate);
        getCenter();
        function getVoucherList(center, fromDate, toDate) {
            $scope.Param.CENTER = center;
            $scope.Param.FROM_DATE = fromDate;
            $scope.Param.TO_DATE = toDate;
            loader(true);           
            var allvoucher = Service.loadDataListParm('/T13003/GetVoucherList', $scope.Param);
            allvoucher.then(function (redata) {
                $scope.obj.VoucherList = JSON.parse(redata);
                $scope.obj.TotalVoucher = $scope.obj.VoucherList.length;
                loader(false);
            });
        }
        function getCenter() {
            var center = Service.loadDataWithoutParm('/T13001/GetCenterData');
            center.then(function (redata) {
                $scope.obj.CenterList = JSON.parse(redata);
            });
        }
        $scope.obj.SelectCenter = function () {
            var fromDate = $filter('date')($scope.obj.T13003.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.T13003.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            getVoucherList(center, fromDate, toDate);
        }
        $scope.date_click = function () {
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            var fromDate = $filter('date')($scope.obj.T13003.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.T13003.TO_DATE, 'dd-MM-yyyy');
            getVoucherList(center, fromDate, toDate);
        }
        $scope.postingAll = function () {
            if ($scope.obj.POSTING_ALL == '0') {
                for (var i = 0; i < $scope.obj.VoucherList.length; i++) {
                    $scope.obj.VoucherList[i].POSTING_FLG = '1';
                }
            } else {
                for (var i = 0; i < $scope.obj.VoucherList.length; i++) {
                    $scope.obj.VoucherList[i].POSTING_FLG = '0';
                }
            }
            //alert(k);
        }
        $scope.Login_click = function () {
            login();
        };
        $scope.enter_press = function (event) {
            if (event.keyCode === 13) {
                login();
            }
        }
        $scope.Save_Click = function () {
            loader(true)
            var fromDate = $filter('date')($scope.obj.T13003.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.T13003.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
           
            if ($scope.obj.POSTING_ALL == '0') {
                $scope.Newlist = $scope.obj.VoucherList.filter(x => x.POSTING_FLG == '1');
                var posting = Service.saveData('/T13003/PostingData',$scope.Newlist);
                posting.then(function (success) {
                    smsAlert(success)
                    getVoucherList(center, fromDate, toDate);
                    loader(false)
                })
            } else {
                var verify = Service.saveData('/T13003/PostingData',$scope.obj.VoucherList);
                verify.then(function (success) {
                    smsAlert(success)
                    getVoucherList(center, fromDate, toDate);
                    loader(false)
                })
            }
        }
        $scope.Clear_Click = function () {
            alert('Clear');
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function login() {

        }

        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);