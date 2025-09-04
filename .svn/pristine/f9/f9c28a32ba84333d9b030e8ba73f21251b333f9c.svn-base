app.controller("T13001Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
       // $scope.obj = Data;
        $scope.obj.T13001 = {};
        getCenter();
        getBudget();
        getVoucher();
        getTrans();
        getPartyType();
        getActHeader();
        getDepartment();
        getPurpose();
        loadData();
        getVoucherNo();
        getParty();
        $scope.obj.T13001.DATE = new Date();
        function getCenter() {
            var center = Service.loadDataWithoutParm('/T13001/GetCenterData');
            center.then(function (redata) {               
                $scope.obj.CenterList = JSON.parse(redata);
            });
        }
        function getBudget() {
            var center = Service.loadDataWithoutParm('/T13001/GeProjectData');
            center.then(function (redata) {
                $scope.obj.ProjectList = JSON.parse(redata);
            });
        }
        function getVoucher() {
            var voucher = Service.loadDataWithoutParm('/T13001/GetVoucherData');
            voucher.then(function (redata) {
                $scope.obj.VoucherTypeList = JSON.parse(redata);
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
            var party = Service.loadDataSingleParm('/T13001/GetParty','00');
            party.then(function (redata) {
                $scope.obj.AllPartyData = JSON.parse(redata);
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
        function getVoucherNo() {
            var voucher = Service.loadDataWithoutParm('/T13001/GetVoucherNo');
            voucher.then(function (redata) {
                $scope.obj.T13001.VOUCHER_NO = redata;
            });
        }
        function getAllVoucher() {
            var date = $filter('date')($scope.obj.T13001.DATE, 'dd-MM-yyyy');
            var allvoucher = Service.loadDataSingleParm('/T13001/GetAllVoucher', date);
            allvoucher.then(function (redata) {  
                $scope.obj.VoucherList = JSON.parse(redata);
                document.getElementById('Voucherlist').style.display = "block";
            });
        }
        function loadData() {
            loader(true);         
                var datalist = [];
                for (var i = 0; i < 2; i++) {
                    var list = {};
                    list.sl = i + 1;
                    list.VOU_DESCRIPTION = '';
                    list.DEBIT = '';
                    list.CREDIT = '';
                    datalist.push(list);
                }
            $scope.obj.dataList = datalist;
            $scope.obj.TOTAL_DEBIT = '0';
            $scope.obj.TOTAL_CREDIT = '0';
                loader(false);           
        }
        $scope.HeadChange = function (ind,data) {
            $scope.obj.dataList[ind].ACCOUNT_ECONO_CODE = data.ACCOUNT_ECONO_CODE;
        }
        $scope.AddRow_Click = function () {
            var datalist = [];
            var ln = $scope.obj.dataList.length;
            for (var i = 0; i < ln + 1; i++) {
                var list = {};
                if (i < ln) {
                    list.sl = $scope.obj.dataList[i].sl;
                    list.ACCOUNT_ECONO_CODE = $scope.obj.dataList[i].ACCOUNT_ECONO_CODE;
                    list.ddlActHead = $scope.obj.dataList[i].ddlActHead;
                    list.ddlParry = $scope.obj.dataList[i].ddlParry;
                    list.ddlDepartment = $scope.obj.dataList[i].ddlDepartment;
                    list.ddlpurpuse = $scope.obj.dataList[i].ddlpurpuse;
                    list.VOU_DESCRIPTION = $scope.obj.dataList[i].VOU_DESCRIPTION;
                    list.DEBIT = $scope.obj.dataList[i].DEBIT;
                    list.CREDIT = $scope.obj.dataList[i].CREDIT;
                    datalist.push(list);
                } else {
                    list.sl = ln + 1;
                    list.DEBIT = '';
                    list.CREDIT = '';                  
                    datalist.push(list);
                }
            }
            $scope.obj.dataList = datalist;            
        }

        $scope.removeRow = function (idx, val) {          
            $scope.obj.dataList.splice(idx, 1);
            debitCalculate();
            creditCalculate();
            for (var i = 0; i < $scope.obj.dataList.length; i++) {
                $scope.obj.dataList[i].sl = i + 1;
            }
        };
        $scope.keyup_debit = function (e, ind) {
            var lastDigit = $scope.obj.dataList[ind].DEBIT.substr($scope.obj.dataList[ind].DEBIT.length - 1)
            var pars = parseFloat(lastDigit == '' ? '0' : lastDigit)
            var check = Number.isInteger(pars)
            if (check) {
                debitCalculate();
            } else {
                $scope.obj.dataList[ind].DEBIT= $scope.obj.dataList[ind].DEBIT.slice(0, -1); return;
            }  
        }
        function debitCalculate() {
            var debittotal = 0;
            for (var i = 0; i < $scope.obj.dataList.length; i++) {
                debittotal = parseFloat(debittotal) + parseFloat($scope.obj.dataList[i].DEBIT == '' ? '0' : $scope.obj.dataList[i].DEBIT)
            }
            $scope.obj.TOTAL_DEBIT = debittotal;
        }
        $scope.keyup_credit = function (e, ind) {
            var lastDigit = $scope.obj.dataList[ind].CREDIT.substr($scope.obj.dataList[ind].CREDIT.length - 1)
            var pars = parseFloat(lastDigit == '' ? '0' : lastDigit)
            var check = Number.isInteger(pars)
            if (check) {
                creditCalculate();
            } else {
                $scope.obj.dataList[ind].CREDIT = $scope.obj.dataList[ind].CREDIT.slice(0, -1); return;
            }
           
        }
        function creditCalculate() {
            var credittotal = 0;
            for (var i = 0; i < $scope.obj.dataList.length; i++) {
                credittotal = parseFloat(credittotal) + parseFloat($scope.obj.dataList[i].CREDIT == '' ? '0' : $scope.obj.dataList[i].CREDIT)
            }
            $scope.obj.TOTAL_CREDIT = credittotal;
        }
        $scope.obj.SelectPartyType = function () {
            var Ptype = $scope.obj.ddlPartyType.PARTY_TYPE_CODE;
            $scope.obj.PartyList = $scope.obj.AllPartyData.filter(x => x.PARTY_TYPE_CODE == Ptype)
            //getParty(Ptype);
        }
       
        $scope.Save_Click = function () {
            if (isEmpty('ddlProject','lblProject')) { return; };
            if (isEmpty('ddlVoucherType', 'lblVoucherType')) { return; };
            if (isEmpty('ddlTransType', 'lblTransType')) { return; };
            if (isEmpty('ddlPartyType', 'lblPartyType')) { return; };
            if (isEmpty('ddlParty','lblParty')) { return; };
            if ($scope.obj.TOTAL_DEBIT != $scope.obj.TOTAL_CREDIT) { showSMS('Debit and Credit is not same', 'error'); return;}

            $scope.obj.T13001.VOUCHER_DATE = $filter('date')($scope.obj.T13001.DATE, 'dd-MM-yyyy');
            $scope.obj.T13001.T_PROJECT_CODE = $scope.obj.ddlProject.T_PROJECT_CODE;
             $scope.obj.T13001.VOUCHER_NO = $scope.obj.T13001.VOUCHER_NO;
             $scope.obj.T13001.VAUCHER_TYPE_CODE = $scope.obj.ddlVoucher.VAUCHER_TYPE_CODE;
             $scope.obj.T13001.TRANSACTION_TYPE_CODE = $scope.obj.ddlTrans.TRANSACTION_TYPE_CODE;
             $scope.obj.T13001.PARTY_TYPE_CODE = $scope.obj.ddlPartyType.PARTY_TYPE_CODE;
            $scope.obj.T13001.PARTY_CODE = $scope.obj.ddlParty.PARTY_CODE;
            $scope.obj.T13001.TOTAL_DEBIT = $scope.obj.TOTAL_DEBIT;
            $scope.obj.T13001.TOTAL_CREDIT = $scope.obj.TOTAL_CREDIT;

            $scope.list = $scope.obj.dataList.filter(x => x.DEBIT != '' || x.CREDIT != '');
            for (var i = 0; i < $scope.list.length; i++) {
                if ($scope.list[i].ddlActHead == undefined) { alert('Select Account Head'); document.getElementById(i + 'ddlActHead').focus(); return; }               
                //else if ($scope.list[i].ddlDepartment == undefined) { alert('Select Department'); document.getElementById(i + 'ddlDepartment').focus(); return; }
                else if ($scope.list[i].ddlpurpuse == undefined) { alert('Select Purpose'); document.getElementById(i + 'ddlpurpuse').focus(); return; }
            }

            $scope.newDataList = [];
            for (var i = 0; i < $scope.list.length; i++) {
                var objlist = {};
                objlist.ACCOUNT_HEADER_CODE = $scope.list[i].ddlActHead.ACCOUNT_HEADER_CODE;               
                objlist.DEPARTMENT_CODE = '101';
                objlist.PURPOSE_CODE = $scope.list[i].ddlpurpuse.PURPOSE_CODE;
                objlist.VOU_DESCRIPTION = $scope.list[i].VOU_DESCRIPTION;
                objlist.DEBIT = $scope.list[i].DEBIT;
                objlist.CREDIT = $scope.list[i].CREDIT;
                $scope.newDataList.push(objlist);
            }

            if ($scope.newDataList.length > 0) {
                loader(true)
                var save = Service.saveData_Model_List('/T13001/SaveData',$scope.obj.T13001, $scope.newDataList);
                save.then(function (success) {
                    smsAlert(success)
                    clearData();
                    loadData();                    
                    loader(false)
                })
            } else {
                alert('Please add list !!!')
                document.getElementById(0 + 'ddlActHead').focus(); return;
            }           

        }
        $scope.setVoucherRow = function (ind, data) {
            $scope.obj.PartyList = $scope.obj.AllPartyData.filter(x => x.PARTY_TYPE_CODE == data.PARTY_TYPE_CODE);
            $scope.obj.ddlProject = { T_PROJECT_NAME: data.T_PROJECT_NAME, T_PROJECT_CODE: data.T_PROJECT_CODE };
            $scope.obj.T13001.VOUCHER_NO = data.VOUCHER_NO;          
            $scope.obj.T13001.VOUCHER_MASTER_ID = data.VOUCHER_MASTER_ID;
            $scope.obj.TOTAL_DEBIT = data.TOTAL_DEBIT;
            $scope.obj.TOTAL_CREDIT = data.TOTAL_CREDIT;
            $scope.obj.ddlVoucher = { VAUCHER_TYPE_CODE: data.VAUCHER_TYPE_CODE, VAUCHER_TYPE_NAME: data.VAUCHER_TYPE_NAME };          
            $scope.obj.ddlTrans = { TRANSACTION_TYPE_CODE: data.TRANSACTION_TYPE_CODE, TRANSACTION_TYPE_NAME: data.TRANSACTION_TYPE_NAME };
            $scope.obj.ddlPartyType = { PARTY_TYPE_CODE: data.PARTY_TYPE_CODE, PARTY_TYPE_NAME: data.PARTY_TYPE_NAME };          
            $scope.obj.ddlParty = { PARTY_CODE: data.PARTY_CODE, PARTY_NAME: data.PARTY_NAME };
            document.getElementById('Voucherlist').style.display = "none";
            var vDetails = Service.loadDataSingleParm('/T13001/GetVoucherDetails',$scope.obj.T13001.VOUCHER_NO);
            vDetails.then(function (redata) {
                $scope.obj.dataList = JSON.parse(redata);
                $scope.data = JSON.parse(redata);
                for (var i = 0; i < $scope.data.length; i++) {
                    $scope.obj.dataList[i].sl = i + 1;
                    $scope.obj.dataList[i].VOUCHER_DETAILS_ID = $scope.data[i].VOUCHER_DETAILS_ID
                    $scope.obj.dataList[i].ACCOUNT_ECONO_CODE = $scope.data[i].ACCOUNT_ECONO_CODE
                    $scope.obj.dataList[i].ddlActHead = { ACCOUNT_HEADER_NAME: $scope.data[i].ACCOUNT_HEADER_NAME, ACCOUNT_HEADER_CODE: $scope.data[i].ACCOUNT_HEADER_CODE }
                    $scope.obj.dataList[i].ddlParry = { PARTY_NAME: $scope.data[i].PARTY_NAME, PARTY_CODE: $scope.data[i].PARTY_CODE }
                    $scope.obj.dataList[i].ddlDepartment = { DEPARTMENT_NAME: $scope.data[i].DEPARTMENT_NAME, DEPARTMENT_CODE: $scope.data[i].DEPARTMENT_CODE }
                    $scope.obj.dataList[i].ddlpurpuse = { PURPOSE_NAME: $scope.data[i].PURPOSE_NAME, PURPOSE_CODE: $scope.data[i].PURPOSE_CODE }
                   
                }
            });

        }
        $scope.voucherPopup = function (id) {
            getAllVoucher();           
        }
        $scope.closeModal = function (id) {
            document.getElementById(id).style.display = "none";
        }
        $scope.Clear_Click = function () {
            clearData();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clearData() {
            $scope.obj.T13001 = {};
            $scope.obj.dataList = [];
            $scope.obj.TOTAL_DEBIT = {};
            $scope.obj.TOTAL_CREDIT = {};

            $scope.obj.ddlCenter = {};
            $scope.obj.ddlVoucher = {};
            $scope.obj.ddlTrans = {};
            $scope.obj.ddlPartyType = {};
            $scope.obj.ddlParty = {};


            getVoucherNo();
            $scope.obj.T13001.DATE = new Date();
            //getCenter();
            //getVoucher();
            //getTrans();
            //getPartyType();
            //getActHeader();
            //getDepartment();
            //getPurpose();
            //clearData();
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);