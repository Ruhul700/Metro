
app.controller("T13006Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T13006 = {};
        $scope.t006 = {};
        $scope.Param = {};
        $scope.obj.T13006.T_RADIO_VALUE = '1';
        $scope.obj.BILL_DATE = new Date();
        getBudget();
        getActHeader();
        getDepartment();
        billType();
        getPurpose();
        getVoucherNo();
        function getVoucherNo() {
            var voucher = Service.loadDataWithoutParm('/T13001/GetVoucherNo');
            voucher.then(function (redata) {
                $scope.obj.T13006.BILL_NO = redata;
            });
        }
        function getBudget() {
            var center = Service.loadDataWithoutParm('/T13001/GeProjectData');
            center.then(function (redata) {
                $scope.obj.ProjectList = JSON.parse(redata);
                $scope.obj.T13006.PAY_POINT = $scope.obj.ProjectList[0].T_PROJECT_NAME;
                $scope.obj.T13006.T_PROJECT_CODE = $scope.obj.ProjectList[0].T_PROJECT_CODE;
                $scope.obj.T13006.FISCAL_YEAR = '2025 - 2026';
                $scope.obj.T13006.PAYEE_TYPE = 'Supplier';
                $scope.obj.T13006.PAYMENT = 'Road and Highways';
            });
        }
        function billType() {
            $scope.obj.BillType=[{ CODE: '101', NAME: 'Against Contract' }, { CODE: '102', NAME: 'Without Contract' }]
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
        
        $scope.SearchSupplier = function () {
            $scope.T06 = {};
            var radioVal = $scope.obj.T13006.T_RADIO_VALUE;
            if (radioVal == undefined || radioVal == '') { showSMS('Please select one', 'warning'); return; }
            $scope.T06.T_RADIO_VALUE = radioVal;
            $scope.T06.T_SEARCH = $scope.obj.T13006.T_SEARCH;
            loader(true);
            var search = Service.loadDataSingleParm('/T13006/GetSearchValue', $scope.T06);
            search.then(function (success) {
                $scope.JsonData = JSON.parse(success);
                if ($scope.JsonData.length > 0) {
                    $scope.obj.T_SUPPLIER_ID = $scope.JsonData[0].T_SUPPLIER_ID;
                    $scope.obj.T_SUPPLIER_CODE = $scope.JsonData[0].T_SUPPLIER_CODE;
                    $scope.obj.T13006.T_SUPPLIER_NAME = $scope.JsonData[0].T_SUPPLIER_NAME;
                    $scope.obj.T_MOBILE_NO = $scope.JsonData[0].T_MOBILE_NO;
                    $scope.obj.T_ACCOUNT_NAME = $scope.JsonData[0].T_ACCOUNT_NAME;
                    $scope.obj.T_ACCOUNT_NO = $scope.JsonData[0].T_ACCOUNT_NO;
                    $scope.obj.T_BANK_NAME = $scope.JsonData[0].T_BANK_NAME;
                    $scope.obj.T_BRANCH = $scope.JsonData[0].T_BRANCH;
                    $scope.obj.T_SUPPLIER_TYPE = $scope.JsonData[0].T_SUPPLIER_TYPE;
                }
                   
                    loader(false)
                })
        }
        $scope.changeHeader = function (data) {
            $scope.obj.ACCOUNT_ECONO_CODE = data.ACCOUNT_ECONO_CODE;            
        }
        $scope.Add_Click = function () {
            if (isEmpty('txtProCode', 'lblProCode')) { return; };           
            var ckList = $scope.obj.dataList == undefined ? 0 : $scope.obj.dataList.filter(x => x.ACCOUNT_HEADER_CODE == $scope.obj.ACCOUNT_HEADER_CODE);
            if (ckList.length > 0) { showSMS('Already Exist !!', 'warning'); return; }
            var Newdatalist = [];
            var list = {};
            list.sl = 1;
            list.ACCOUNT_ECONO_CODE = $scope.obj.ACCOUNT_ECONO_CODE;           
            list.ACCOUNT_HEADER_NAME = $scope.obj.ddlActHead.ACCOUNT_HEADER_NAME;
            list.ACCOUNT_HEADER_CODE = $scope.obj.ddlActHead.ACCOUNT_HEADER_CODE;
            list.DEPARTMENT_NAME = $scope.obj.ddlDepartment.DEPARTMENT_NAME;
            list.DEPARTMENT_CODE = $scope.obj.ddlDepartment.DEPARTMENT_CODE;
            list.PURPOSE_NAME = $scope.obj.ddlpurpuse.PURPOSE_NAME;
            list.PURPOSE_CODE = $scope.obj.ddlpurpuse.PURPOSE_CODE;
            list.DEBIT = $scope.obj.DEBIT == undefined ? 0 : $scope.obj.DEBIT == '' ? 0 : $scope.obj.DEBIT;
            list.CREDIT = $scope.obj.CREDIT == undefined ? 0 : $scope.obj.CREDIT == '' ? 0 : $scope.obj.CREDIT;
            Newdatalist.push(list);

            var ln = $scope.obj.dataList == undefined ? 0 : $scope.obj.dataList.length;
            for (var i = 0; i < ln; i++) {
                var list = {};
                list.sl = (i + 2);
                list.ACCOUNT_ECONO_CODE = $scope.obj.dataList[i].ACCOUNT_ECONO_CODE;               
                list.ACCOUNT_HEADER_NAME = $scope.obj.dataList[i].ACCOUNT_HEADER_NAME;
                list.ACCOUNT_HEADER_CODE = $scope.obj.dataList[i].ACCOUNT_HEADER_CODE;
                list.DEPARTMENT_NAME = $scope.obj.dataList[i].DEPARTMENT_NAME;
                list.DEPARTMENT_CODE = $scope.obj.dataList[i].DEPARTMENT_CODE;
                list.PURPOSE_NAME = $scope.obj.dataList[i].PURPOSE_NAME;
                list.PURPOSE_CODE = $scope.obj.dataList[i].PURPOSE_CODE;
                list.DEBIT = $scope.obj.dataList[i].DEBIT;
                list.CREDIT = $scope.obj.dataList[i].CREDIT;               
                Newdatalist.push(list);
            }
            $scope.obj.dataList = Newdatalist;
            document.getElementById('txtProCode').focus();
            debit_Credit_Calculate();          
            clearAddProduct();
        }
        function debit_Credit_Calculate() {
            var debittotal = 0;
            var credittotal = 0;
            for (var i = 0; i < $scope.obj.dataList.length; i++) {
                debittotal = parseFloat(debittotal) + parseFloat($scope.obj.dataList[i].DEBIT == '' ? '0' : $scope.obj.dataList[i].DEBIT)
                credittotal = parseFloat(credittotal) + parseFloat($scope.obj.dataList[i].CREDIT == '' ? '0' : $scope.obj.dataList[i].CREDIT)
            }
            $scope.obj.TOTAL_DEBIT = debittotal;
            $scope.obj.TOTAL_CREDIT = credittotal;
        }
        $scope.removeRow = function (ind, data) {
            $scope.obj.dataList.splice(ind, 1);
            debit_Credit_Calculate()
        }
        $scope.selectGridRow = function (idx, data) {
            loader(true);   
            $scope.obj.ACCOUNT_ECONO_CODE = data.ACCOUNT_ECONO_CODE;
            $scope.obj.T_PRODUCT_CODE = data.T_PRODUCT_CODE;
            $scope.obj.ddlActHead = { ACCOUNT_HEADER_CODE: data.ACCOUNT_HEADER_CODE, ACCOUNT_HEADER_NAME: data.ACCOUNT_HEADER_NAME }
            $scope.obj.ddlDepartment = { DEPARTMENT_CODE: data.DEPARTMENT_CODE, DEPARTMENT_NAME: data.DEPARTMENT_NAME }
            $scope.obj.ddlpurpuse = { PURPOSE_CODE: data.PURPOSE_CODE, PURPOSE_NAME: data.PURPOSE_NAME }           
            $scope.obj.DEBIT = data.DEBIT;
            $scope.obj.CREDIT = data.CREDIT;
            $scope.obj.dataList.splice(idx, 1);
            debit_Credit_Calculate()
            loader(false)
        }
        
        $scope.Save_Click = function () {
            loader(true)
           // if (isEmpty('ddlProject', 'lblProject')) { return; };
            $scope.obj.T13006.VOUCHER_DATE = $filter('date')($scope.obj.BILL_DATE, 'dd-MM-yyyy');
            $scope.obj.T13006.TOTAL_DEBIT = $scope.obj.TOTAL_DEBIT;
            $scope.obj.T13006.TOTAL_CREDIT = $scope.obj.TOTAL_CREDIT;
            if ($scope.obj.dataList.length > 0) {
                $scope.t006.SingleData = $scope.obj.T13006;
                $scope.t006.ListData = $scope.obj.dataList;
              
                var save = Service.saveData('/T13006/SaveData', $scope.t006);
                save.then(function (success) {
                    smsAlert(success);                 
                    loader(false)
                })
            } else {
               
            }
        }
        function clearAddProduct() {
            $scope.obj.ACCOUNT_ECONO_CODE = '';
            $scope.obj.ddlActHead = '';
            $scope.obj.DEBIT = '';
            $scope.obj.CREDIT = '';
        }
        $scope.Clear_Click = function () {
           // getBudget();          
            $scope.obj.dataList = [];
            $scope.obj.T13006 = {};
            $scope.obj.ddlDepartment = '';
            $scope.obj.ddlpurpuse = '';
            getVoucherNo();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }

    }
]);