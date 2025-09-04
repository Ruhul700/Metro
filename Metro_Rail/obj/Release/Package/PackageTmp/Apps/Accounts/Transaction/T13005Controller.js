app.controller("AT13005Controller", ["$scope", "AT13005Service", "Data", "$window", "$filter",
    function ($scope, AT13005Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.AT13005 = {};
        $scope.obj.POSTING_ALL = '0';
        $scope.obj.VouchNo = '0';
        $scope.obj.AT13005.DATE = new Date();
        document.getElementById('txtProjectName').focus();
        loadData();
        supplier();
        getPartyType();
        getProject();
        function supplier() {
            var supply = AT13005Service.getSupplierData();
            supply.then(function (sup) {
                $scope.obj.SupplierList = JSON.parse(sup);
            })
        }
        // var fromDate = $filter('date')($scope.obj.AT13005.FROM_DATE, 'dd-MM-yyyy');
        //var toDate = $filter('date')($scope.obj.AT13005.TO_DATE, 'dd-MM-yyyy');
        // getVoucherList('0', fromDate, toDate);
        // getCenter();
        function getPartyType() {
            var partyType = AT13005Service.getPartyTypeData();
            partyType.then(function (redata) {
                $scope.obj.PartyTypeList = JSON.parse(redata);
            });
        }
        function getProject() {

            loader(true);
            var allProject = AT13005Service.getProjectList();
            allProject.then(function (redata) {
                $scope.obj.ProjectList = JSON.parse(redata);
                loader(false);
            });
        }
        function loadData() {
            loader(true);
            var datalist = [];
            for (var i = 0; i < 5; i++) {
                var list = {};
                list.sl = i + 1;
                list.T_PARTY_LIMIT = '';
                // list.ddlSupplier = { PARTY_CODE: '', PARTY_NAME: ''};
                datalist.push(list);
            }
            $scope.obj.dataList = datalist;
            loader(false);
        }
        $scope.AddRow_Click = function () {
            var datalist = [];
            var ln = $scope.obj.dataList.length;
            for (var i = 0; i < ln + 1; i++) {
                var list = {};
                if (i < ln) {

                    list.sl = $scope.obj.dataList[i].sl;
                    list.ddlSupplier = $scope.obj.dataList[i].ddlSupplier;
                    list.T_PARTY_LIMIT = $scope.obj.dataList[i].T_PARTY_LIMIT;
                    list.PARTY_CODE = $scope.obj.dataList[i].PARTY_CODE;
                    list.T_PRJCT_DEL_ID = $scope.obj.dataList[i].T_PRJCT_DEL_ID;
                    datalist.push(list);
                } else {
                    list.sl = ln + 1;
                    list.T_PARTY_LIMIT = '';
                    list.ddlSupplier = { PARTY_CODE: '', PARTY_NAME: '' };
                    datalist.push(list);
                }

            }
            $scope.obj.dataList = datalist;
        }
        $scope.removeRow = function (idx, val) {
            $scope.obj.dataList.splice(idx, 1);
            for (var i = 0; i < $scope.obj.dataList.length; i++) {
                $scope.obj.dataList[i].sl = i + 1;
            }
        };
        $scope.obj.SelectCenter = function () {
            var fromDate = $filter('date')($scope.obj.AT13001.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.AT13001.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            getVoucherList(center, fromDate, toDate);
        }
        $scope.enter_press = function (event) {
            if (event.keyCode === 13) {
                login();
            }
        }
        $scope.projectPopup = function (id) {
            getProject();
            document.getElementById(id).style.display = "block";
        }
        $scope.closeModal = function (id) {
            document.getElementById(id).style.display = "none";
        }
        $scope.Save_Click = function () {
            loader(true)
            $scope.obj.AT13005.ENTRY_DATE = $filter('date')($scope.obj.AT13005.DATE, 'dd-MM-yyyy');
            if ($scope.obj.AT13005.T_PROJECT_NAME == undefined || $scope.obj.AT13005.T_PROJECT_NAME == '') { alert('Write Project Name'); return; }
            // $scope.obj.AT13005.PARTY_TYPE_CODE = $scope.obj.ddlProject.PARTY_TYPE_CODE;
            // $scope.obj.AT13005.T_PROJECT_NAME = $scope.obj.ddlProject.PARTY_TYPE_NAME;
            $scope.list = $scope.obj.dataList.filter(x => x.T_PARTY_LIMIT != '');
            for (var i = 0; i < $scope.list.length; i++) {
                if ($scope.list[i].ddlSupplier == undefined) { alert('Select Account Head'); document.getElementById(i + 'ddlSupplier').focus(); return; }
                // else if ($scope.list[i].T_SUPPLIER_LIMIT == undefined) { alert('Select Party'); document.getElementById(i + 'ddlParry').focus(); return; }

            }

            $scope.newDataList = [];
            for (var i = 0; i < $scope.list.length; i++) {
                var objlist = {};
                objlist.T_PARTY_CODE = $scope.list[i].ddlSupplier.PARTY_CODE;
                objlist.T_PARTY_LIMIT = $scope.list[i].T_PARTY_LIMIT;
                objlist.T_PRJCT_DEL_ID = $scope.list[i].T_PRJCT_DEL_ID;

                $scope.newDataList.push(objlist);
            }
            if ($scope.newDataList.length > 0) {
                var posting = AT13005Service.saveData($scope.obj.AT13005, $scope.newDataList);
                posting.then(function (success) {
                    alert(success);
                    clear();
                    loader(false)
                    loadData();
                })
            } else {

            }


        }
        $scope.Refresh_Click = function () {
            var fromDate = $filter('date')($scope.obj.AT13001.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.AT13001.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            getVoucherList(center, fromDate, toDate);
        }
        $scope.selectProjectRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.AT13005.T_PROJECT_ID = data.T_PROJECT_ID;
            $scope.obj.AT13005.T_PROJECT_NAME = data.T_PROJECT_NAME;
            $scope.obj.AT13005.PARTY_TYPE_CODE = data.PARTY_TYPE_CODE;
            $scope.obj.AT13005.T_PROJECT_VALUE = data.T_PROJECT_VALUE;
            $scope.obj.AT13005.T_PROJECT_LIMIT = data.T_PROJECT_LIMIT;
            var dateConverted = dateConvert(data.ENTRY_DATE)
            $scope.obj.AT13005.DATE = dateConverted;

            //data.ENTRY_DATE;// $filter('date')(data.ENTRY_DATE, 'dd-MM-yyyy');
            // $scope.obj.AT13005.DATE = new Date(data.ENTRY_DATE); //data.ENTRY_DATE;// $filter('date')(data.ENTRY_DATE, 'dd-MM-yyyy');


            document.getElementById('ProjectList').style.display = "none";
            var pDetails = AT13005Service.getProjectDetails($scope.obj.AT13005.T_PROJECT_ID);
            pDetails.then(function (redata) {
                $scope.obj.dataList = JSON.parse(redata);
                $scope.data = JSON.parse(redata);
                for (var i = 0; i < $scope.data.length; i++) {
                    $scope.obj.dataList[i].sl = i + 1;
                    $scope.obj.dataList[i].ddlSupplier = { PARTY_NAME: $scope.data[i].PARTY_NAME, PARTY_CODE: $scope.data[i].PARTY_CODE }
                    $scope.obj.dataList[i].PARTY_CODE = $scope.data[i].PARTY_CODE;
                    // $scope.obj.dataList[i].T_PRJCT_DEL_ID = $scope.data[i].T_PRJCT_DEL_ID;

                }
            });

        }
        $scope.ddlSuplier_change = function (ind, data) {


            $scope.gridList = $scope.obj.dataList.filter(x => x.PARTY_CODE == data.PARTY_CODE);
            if ($scope.gridList.length > 0) {
                alert('Already has been added !!');
                $scope.obj.dataList[ind].ddlSupplier = { PARTY_CODE: '', PARTY_NAME: '' };
                return;
            }
            $scope.obj.dataList[ind].PARTY_CODE = data.PARTY_CODE
        }

        $scope.Clear_Click = function () {
            clear();
        }
        function clear() {
            $scope.obj.AT13005 = {};
            $scope.obj.dataList = [];
            $scope.obj.AT13005.DATE = new Date();
            loadData();
        }
        $scope.Print_Click = function () {
            //var fromDate = $filter('date')($scope.obj.AT13001.FROM_DATE, 'dd-MM-yyyy');
            //var toDate = $filter('date')($scope.obj.AT13001.TO_DATE, 'dd-MM-yyyy');
            //var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            ////center, fromDate, toDate
            //if ($scope.obj.PrintAll_FLG == '1' && $scope.obj.VouchNo == '0') {
            //    $window.open("../AT13004/ReportVoucherList?center=" + center + "&fromDate=" + fromDate + "&toDate=" + toDate, "popup", "width=600,height=600,left=100,top=50");
            //} else {
            //    $window.open("../AT13004/ReportVoucherSingle?voucherNo=" + $scope.obj.VouchNo, "popup", "width=600,height=600,left=100,top=50");
            //}
        }

        $scope.PrintAll_Click = function () {
            //$scope.obj.VouchNo = '0';
            //for (var i = 0; i < $scope.obj.VoucherList.length; i++) {
            //    $scope.obj.VoucherList[i].PrintSingle_FLG = '0';
            //}
        }
        $scope.PrintSingle_Click = function (ind, voucherNo) {
            //$scope.obj.VouchNo = voucherNo;
            //$scope.obj.PrintAll_FLG = '0';
            //for (var i = 0; i < $scope.obj.VoucherList.length; i++) {
            //    if (i == ind) {

            //    } else {
            //        $scope.obj.VoucherList[i].PrintSingle_FLG = '0';
            //    }
            //}
        }
        function dateConvert(dateString) {
            var dataSplit = dateString.split('-');
            var dateConverted = new Date(dataSplit[2], dataSplit[1] - 1, dataSplit[0]);
            return dateConverted;
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);