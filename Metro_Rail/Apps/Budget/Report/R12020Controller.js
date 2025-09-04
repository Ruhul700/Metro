
app.controller("R12020Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.R12020 = {};
        ProjectData()
        //loadData();
        function loadData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/R12020/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false)
            });
        }
        function ProjectData() {
            loader(true)
            var gridData = Service.loadDataWithoutParm('/R12020/GetAllProjectData');
            gridData.then(function (redata) {
                $scope.obj.ProjectList = JSON.parse(redata);
                loader(false)
            });
        }
        $scope.CheckSingle_Click = function (id) {
            if (id == 'Budget') {
                $scope.obj.Budget_FLG = '1'
                $scope.obj.Fund_FLG = '0'
                $scope.obj.Expense_FLG = '0'
            }
            else if (id == 'Fund') {
                $scope.obj.Budget_FLG = '0'
                $scope.obj.Fund_FLG = '1'
                $scope.obj.Expense_FLG = '0'
            }
            else if (id == 'Expense') {
                $scope.obj.Budget_FLG = '0'
                $scope.obj.Fund_FLG = '0'
                $scope.obj.Expense_FLG = '1'
            }

        }
        $scope.Clear_Click = function () {
            clear();
        }
        function clear() {
            $scope.obj.R12020 = {};
        }
        $scope.Print_Click = function () {
            if (isEmpty('ddlProject', 'lblProject')) { return; }
            var projectCode = $scope.obj.ddlProject.T_PROJECT_CODE
            var projectName = $scope.obj.ddlProject.T_PROJECT_NAME
            if ($scope.obj.Budget_FLG == '1') {
                $window.open("../R12020/GetBudgetReport?projectCode=" + projectCode + "&projectName=" + projectName, "_blank");
            }
            else if ($scope.obj.Fund_FLG == '1') {
                $window.open("../R12020/GetFundReport?projectCode=" + projectCode + "&projectName=" + projectName, "_blank");
            }
            else if ($scope.obj.Expense_FLG == '1') {
                $window.open("../R12020/GetExpenseReport?projectCode=" + projectCode + "&projectName=" + projectName, "_blank");
            }
            
        }
    }
]);