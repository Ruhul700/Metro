
app.controller("T12009Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T12009 = {};
        $scope.obj.T12009.PARTY_CODE = '0';
        getPartyType();
        loadData();
        function getPartyType() {
            var partyType = Service.loadDataWithoutParm('/T12009/GetPartyTypeData');
            partyType.then(function (redata) {
                $scope.obj.PartyTypeList = JSON.parse(redata);
            });
        }
        function loadData() {
            loader(true);
            var gridData = Service.loadDataWithoutParm('/T12009/GetAllData');
            gridData.then(function (redata) {
                $scope.obj.griDataList = JSON.parse(redata);
                loader(false);
            });
        }
        $scope.Save_Click = function () {           
            if (isEmpty('ddlParty', 'lblParty')) { return; }
            if (isEmpty('txtName', 'lblName')) { return; }
            loader(true);           
            $scope.obj.T12009.PARTY_TYPE_CODE = $scope.obj.ddlPartyType.PARTY_TYPE_CODE;
            var save = Service.saveData('/T12009/SaveData', $scope.obj.T12009);
            save.then(function (result) {
                smsAlert(result);
                loadData()
                clear();
                loader(false);
            });
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        $scope.setProductRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T12009.PARTY_NAME = data.PARTY_NAME;
            $scope.obj.T12009.PARTY_CODE = data.PARTY_CODE;
            $scope.obj.ddlPartyType = { PARTY_TYPE_CODE: data.PARTY_TYPE_CODE, PARTY_TYPE_NAME: data.PARTY_TYPE_NAME}
        }
        function clear() {
            $scope.obj.T12009.PARTY_NAME = '';
            $scope.obj.T12009.PARTY_CODE = '0';          
            $scope.obj.PartyTypeList = {};
            getPartyType();
           
        }        
    }
]);