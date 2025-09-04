
app.controller("T12023Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12023 = {};
        $scope.obj.T_PERIOD_START_DATE = new Date();
        $scope.obj.T_PERIOD_END_DATE = new Date();
        loadData();
       // PeriodData();
        ProjectData()
        HeaderData();
        function loadData(code) {
            loader(true)
            var gridData = Service.loadDataSingleParm('/T12023/GetAllData', code);
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false)
            });
        }
        function ProjectData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/T12023/GetAllProjectData');
            gridData.then(function (redata) {
                $scope.obj.ProjectList = JSON.parse(redata);
                loader(false)
            });
        }      
        
        function HeaderData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/T12023/GetHeaderData');
            gridData.then(function (redata) {
                $scope.obj.headerDataList = JSON.parse(redata);
                loader(false)
            });
        }
        $scope.changeProject = function (data) {
            loadData(data.T_PROJECT_CODE);
            
        }
       
        $scope.changeHeader = function (data) {
            $scope.obj.T12023.ACCOUNT_ECONO_CODE = data.ACCOUNT_ECONO_CODE;
            $scope.obj.T12023.ACCOUNT_TYPE_NAME = data.ACCOUNT_TYPE_NAME;
        }    
       
        $scope.Save_Click = function () {
            
            // if ($scope.obj.ddlHeader == undefined || $scope.obj.ddlHeader.ACCOUNT_HEADER_CODE == "") { showSMS('Header Name' + ' is require', 'warning'); return; }
            var newList = $scope.obj.griDataList.filter(x => x.T_FUND_COLLECT != 0);
            if (newList.length>0) {
                $scope.obj.T12023.T12023List = newList
                $scope.obj.T12023.T_PROJECT_CODE = $scope.obj.ddlProject.T_PROJECT_CODE
                loader(true);
                var save = Service.saveData('/T12023/SaveData', $scope.obj.T12023);
                save.then(function (result) {
                    smsAlert(result);
                    //loadData()
                   // clear();
                    loader(false)
                });
            }
         
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.selectGridRow = function (ind, data) {
            $scope.selectedRow = ind;
            //$scope.obj.T12023.T_BUDGET_ID = data.T_BUDGET_ID;
            //$scope.obj.T12023.T_BUDGET_CODE = data.T_BUDGET_CODE;
            //$scope.obj.T12023.T_BUDGET_NAME = data.T_BUDGET_NAME;
            //$scope.obj.T12023.ACCOUNT_HEADER_CODE = data.ACCOUNT_HEADER_CODE;
            //$scope.obj.ddlProject = { T_PROJECT_CODE: data.T_PROJECT_CODE, T_PROJECT_NAME: data.T_PROJECT_NAME };
            //// $scope.obj.ddlPeriod = { T_PERIOD_CODE: data.T_PERIOD_CODE, T_PERIOD_NAME: data.T_PERIOD_NAME} ;
            //$scope.obj.T12023.ACCOUNT_TYPE_NAME = data.ACCOUNT_TYPE_NAME;
            //$scope.obj.ddlHeader = { ACCOUNT_HEADER_CODE: data.ACCOUNT_HEADER_CODE, ACCOUNT_HEADER_NAME: data.ACCOUNT_HEADER_NAME };
            //$scope.obj.T12023.T_ADP_GOB = parseFloat(data.T_ADP_GOB);
            //$scope.obj.T12023.T_ADP_PRO_HELP = parseFloat(data.T_ADP_PRO_HELP);
            //$scope.obj.T12023.T_TOTAL_ADP_AMOUNT = parseFloat(data.T_TOTAL_ADP_AMOUNT);
            //$scope.obj.T12023.T_RADP_GOB = parseFloat(data.T_RADP_GOB);
            //$scope.obj.T12023.T_RADP_PRO_HELP = parseFloat(data.T_RADP_PRO_HELP);
            //$scope.obj.T12023.T_TOTAL_RADP_AMOUNT = parseFloat(data.T_TOTAL_RADP_AMOUNT);
            // $scope.obj.T12023.T_PERIOD_START_DATE = data.T_PERIOD_START_DATE;
            // $scope.obj.T12023.T_PERIOD_END_DATE = data.T_PERIOD_END_DATE;
            //$scope.obj.T_PERIOD_START_DATE = data.T_PERIOD_START_DATE == '' ? '' : stringToDate(data.T_PERIOD_START_DATE, 'dd-MM-yyyy', '-');
            // $scope.obj.T_PERIOD_END_DATE = data.T_PERIOD_END_DATE == '' ? '' : stringToDate(data.T_PERIOD_END_DATE, 'dd-MM-yyyy', '-');
        }
        function clear() {
            $scope.obj.T12023 = {};
            $scope.obj.ddlPeriod = '';
            $scope.obj.ddlHeader = '';
        }
    }
]);