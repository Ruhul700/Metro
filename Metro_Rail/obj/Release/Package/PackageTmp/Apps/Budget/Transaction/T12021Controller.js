app.controller("T12021Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12021 = {};
        getBudget();
        loadData();
        function loadData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/T12021/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false)
            });
        }
        function getBudget() {
            var center = Service.loadDataWithoutParm('/T13001/GeProjectData');
            center.then(function (redata) {
                $scope.obj.ProjectList = JSON.parse(redata);
            });
        }
        $scope.ChangeStatus = function (ind) {
            $scope.obj.griDataList[ind].T_STATUS = '1';
        }
        $scope.Save_Click = function () {
           // if (isEmpty('ddlProject', 'lblProject')) { return; }           
           // if ($scope.obj.ddlHeader == undefined || $scope.obj.ddlHeader.ACCOUNT_HEADER_CODE == "") { showSMS('Header Name' + ' is require', 'warning'); return; }
           // if (isEmpty('txtAmount', 'lblAmount')) { return; }           
           // $scope.obj.T12020.T_PROJECT_CODE = $scope.obj.ddlProject.T_PROJECT_CODE;           
            // $scope.obj.T12020.T_ACCOUNT_HEADER_CODE = $scope.obj.ddlHeader.ACCOUNT_HEADER_CODE;    
            var NewList = $scope.obj.griDataList.filter(x => x.T_STATUS == '1');
            if (NewList.length>0) {
                loader(true);
                var save = Service.saveData('/T12021/SaveData', NewList);
                save.then(function (result) {
                    smsAlert(result);
                    loadData();
                   
                    loader(false)
                });
            }
           
        }
        $scope.Clear_Click = function () {
            loadData();
        }
        $scope.Print_Click = function () {
           // if (isEmpty('ddlProject', 'lblProject')) { return; }
            var projectCode = $scope.obj.ddlProject.T_PROJECT_CODE
            var projectName = $scope.obj.ddlProject.T_PROJECT_NAME
            $window.open("../T12021/GetSetBudgetReport?projectCode=" + projectCode + "&projectName=" + projectName, "_blank");
        }
    }])