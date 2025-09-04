
app.controller("T13004Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T13004 = {};
        $scope.Param = {};
        $scope.obj.POSTING_ALL = '0';
        $scope.obj.VouchNo = '0';
        $scope.obj.T13004.FROM_DATE = new Date();
        $scope.obj.T13004.TO_DATE = new Date();
        var fromDate = $filter('date')($scope.obj.T13004.FROM_DATE, 'dd-MM-yyyy');
        var toDate = $filter('date')($scope.obj.T13004.TO_DATE, 'dd-MM-yyyy');
        getVoucherList('0', fromDate, toDate);
        getCenter();
        function getVoucherList(center, fromDate, toDate) {
            $scope.Param.CENTER = center;
            $scope.Param.FROM_DATE = fromDate;
            $scope.Param.TO_DATE = toDate;
            loader(true);            
            var allvoucher = Service.loadDataListParm('/T13004/GetVoucherList', $scope.Param);
            allvoucher.then(function (redata) {
                $scope.obj.VoucherList = JSON.parse(redata);
                $scope.obj.TotalVoucher = $scope.obj.VoucherList.length;
                $scope.obj.TotalPosting = $scope.obj.VoucherList.filter(x => x.POSTING_FLG == '1').length;
                $scope.obj.TotalVerify = $scope.obj.VoucherList.filter(x => x.VERIFY_FLG == '1').length;
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
            var fromDate = $filter('date')($scope.obj.T13004.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.T13004.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            getVoucherList(center, fromDate, toDate);
        }
        $scope.date_click = function () {
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            var fromDate = $filter('date')($scope.obj.T13004.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.T13004.TO_DATE, 'dd-MM-yyyy');
            getVoucherList(center, fromDate, toDate);
        }
        //$scope.postingAll = function () {
        //    if ($scope.obj.POSTING_ALL == '0') {
        //        for (var i = 0; i < $scope.obj.VoucherList.length; i++) {
        //            $scope.obj.VoucherList[i].POSTING_FLG = '1';
        //        }
        //    } else {
        //        for (var i = 0; i < $scope.obj.VoucherList.length; i++) {
        //            $scope.obj.VoucherList[i].POSTING_FLG = '0';
        //        }
        //    }
        //    //alert(k);
        //}
        $scope.Login_click = function () {
            login();
        };
        $scope.enter_press = function (event) {
            if (event.keyCode === 13) {
                login();
            }
        }
       
        $scope.Refresh_Click = function () {
            var fromDate = $filter('date')($scope.obj.T13004.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.T13004.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            getVoucherList(center, fromDate, toDate);
        }
        $scope.Print_Click = function () {
            var fromDate = $filter('date')($scope.obj.T13004.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.T13004.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            //center, fromDate, toDate
            if ($scope.obj.PrintAll_FLG == '1' && $scope.obj.VouchNo == '0') {
                $window.open("../T13004/ReportVoucherList?center=" + center + "&fromDate=" + fromDate + "&toDate=" + toDate, "popup", "width=600,height=600,left=100,top=50");
            } else {
                $window.open("../T13004/ReportVoucherSingle?voucherNo=" + $scope.obj.VouchNo , "popup", "width=1200,height=600,left=100,top=50");
            }
        }
        
        $scope.PrintAll_Click = function () {
            $scope.obj.VouchNo = '0';
            for (var i = 0; i < $scope.obj.VoucherList.length; i++) {              
                    $scope.obj.VoucherList[i].PrintSingle_FLG = '0';                
            }
        }
        $scope.PrintSingle_Click = function (ind, voucherNo) {
            $scope.obj.VouchNo = voucherNo;
            $scope.obj.PrintAll_FLG = '0';
            for (var i = 0; i < $scope.obj.VoucherList.length; i++) {
                if (i==ind) {

                } else {
                    $scope.obj.VoucherList[i].PrintSingle_FLG = '0';
                }
            }    
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);