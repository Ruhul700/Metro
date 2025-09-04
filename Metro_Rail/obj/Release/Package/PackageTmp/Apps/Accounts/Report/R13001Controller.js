
app.controller("R13001Controller", ["$scope","Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.R13001 = {};       
        getCenter();
        getActHeader();
        getPartyType();
        getParty();
        getDepartment();
        getPurpose();
        getTrans();
        $scope.obj.R13001.FROM_DATE = new Date();
        $scope.obj.R13001.TO_DATE = new Date();
        var fromDate = $filter('date')($scope.obj.R13001.FROM_DATE, 'dd-MM-yyyy');
        var toDate = $filter('date')($scope.obj.R13001.TO_DATE, 'dd-MM-yyyy');
        
        function getCenter() {
            var center = Service.loadDataWithoutParm('/T13001/GetCenterData')
            center.then(function (redata) {
                $scope.obj.CenterList = JSON.parse(redata);
            });
        }        
        function getTrans() {
            var trans = Service.loadDataWithoutParm('/T13001/GetTransData');
            trans.then(function (redata) {
                $scope.obj.TransList = JSON.parse(redata);
            });
        }
        function getPartyType() {
            var partyType = Service.loadDataWithoutParm('/T13001/GetPartyTypeData');
            partyType.then(function (redata) {
                $scope.obj.PartyTypeList = JSON.parse(redata);
            });
        }
        function getParty() {
            loader(true)
            var party = Service.loadDataSingleParm('/T13001/GetParty', '00');
            party.then(function (redata) {
                $scope.obj.AllPartyData = JSON.parse(redata);
                loader(false)
            });
        }
        function getActHeader() {
            var actHeader = Service.loadDataWithoutParm('/T13001/GetActHeaderData');
            actHeader.then(function (redata) {
                $scope.obj.ActHeaderList = JSON.parse(redata);
            });
        }
        function getDepartment() {
            var department = Service.loadDataWithoutParm('/T13001/GetDepartmentData');
            department.then(function (redata) {
                $scope.obj.DepartmentList = JSON.parse(redata);
            });
        }
        function getPurpose() {
            var purpose = Service.loadDataWithoutParm('/T13001/GetPurposeData');
            purpose.then(function (redata) {
                $scope.obj.PurposeList = JSON.parse(redata);
            });
        }

        $scope.CheckAll_Click = function () {
            if ($scope.obj.CheckAll_FLG == '0') {
                for (var i = 0; i < $scope.obj.ActHeaderList.length; i++) {
                    $scope.obj.ActHeaderList[i].HEADER_FLG = '0';
                }
            } else {
                for (var i = 0; i < $scope.obj.ActHeaderList.length; i++) {
                    $scope.obj.ActHeaderList[i].HEADER_FLG = '1';
                }
            }
        }
        $scope.CheckSingle_Click = function (ind,data) {
            $scope.obj.CheckAll_FLG = '0'
        }

        $scope.Save_Click = function () {
            alert('Save');
        }
        $scope.Clear_Click = function () {
            alert('Clear');
        }
        $scope.Print_Click = function () {
            var header =0;
            var headerList = $scope.obj.ActHeaderList.filter(x => x.HEADER_FLG == '1');
            for (var i = 0; i < headerList.length;i++) {
                header = header+',' + headerList[i].ACCOUNT_HEADER_CODE;
            }           
            var fromDate = $filter('date')($scope.obj.R13001.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.R13001.TO_DATE, 'dd-MM-yyyy');
            var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;
            var partyType = $scope.obj.ddlPartyType == null ? '0' : $scope.obj.ddlPartyType.PARTY_TYPE_CODE;
            var party = $scope.obj.ddlParty == null ? '0' : $scope.obj.ddlParty.PARTY_CODE;
            var department = $scope.obj.ddlDepartment == null ? '0' : $scope.obj.ddlDepartment.DEPARTMENT_CODE;
            var purpuse = $scope.obj.ddlpurpuse == null ? '0' : $scope.obj.ddlpurpuse.PURPOSE_CODE;
            var trans = $scope.obj.ddlTrans == null ? '0' : $scope.obj.ddlTrans.TRANSACTION_TYPE_CODE;
            //center, fromDate, toDate
           // if ($scope.obj.PrintAll_FLG == '1' && $scope.obj.VouchNo == '0') {
            $window.open("../R13001/LegerReport?center=" + center + "&fromDate=" + fromDate + "&toDate=" + toDate + "&header=" + header + "&partyType=" + partyType + "&party=" + party + "&department=" + department + "&purpuse=" + purpuse + "&trans=" + trans, "_blank");
           // } else {
               // $window.open("../AT13004/ReportVoucherSingle?voucherNo=" + $scope.obj.VouchNo, "popup", "width=600,height=600,left=100,top=50");
           // }
        }
       
    }
]);