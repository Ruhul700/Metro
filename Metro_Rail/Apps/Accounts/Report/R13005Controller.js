
app.controller("R13005Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.AR14005 = {};
        loadHeader();       
        $scope.obj.AR14005.FROM_DATE = new Date();
        $scope.obj.AR14005.TO_DATE = new Date();
        function loadHeader() {
            var partyType = Service.loadDataWithoutParm('/R13005/GetLoadHeaderData');
            partyType.then(function (redata) {
                $scope.obj.HeadList = JSON.parse(redata);
            });
        }        
        $scope.Clear_Click = function () {
            alert('Clear');
        }
        $scope.Print_Click = function () {
             var fromDate = $filter('date')($scope.obj.AR14005.FROM_DATE, 'dd-MM-yyyy');
             var toDate = $filter('date')($scope.obj.AR14005.TO_DATE, 'dd-MM-yyyy');
            var headCode = $scope.obj.ddlHead == null ? '0' : $scope.obj.ddlHead.ACCOUNT_HEADER_CODE;
            var headName = $scope.obj.ddlHead == null ? '0' : $scope.obj.ddlHead.ACCOUNT_HEADER_NAME;
            if (headCode === '0') { alert('Please Select One') } else {
                $window.open("../R13005/Balance_Flow_Statment?headCode=" + headCode + "&headName=" + headName + "&fromDate=" + fromDate + "&toDate=" + toDate, "_blank");
            }                   
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);