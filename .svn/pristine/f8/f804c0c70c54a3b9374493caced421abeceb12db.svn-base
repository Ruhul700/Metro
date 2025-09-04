app.controller("T19002Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T19002 = {};
        $scope.obj.T19002.T_TYPE_CODE = 'Ruhul Amin';
        // loadGridData();
        // loadItemData();
        //function loadGridData() {
        //    loader(true)
        //    var load = Service.loadDataWithoutParm('/T19001/LoadData');
        //    load.then(function (returnData) {
        //        $scope.obj.griDataList = JSON.parse(returnData);
        //        loader(false)
        //    });
        //}

        //$scope.Save_Click = function () {
        //    if (isEmpty('txtName', 'lblName')) { return; }
        //    if (isEmpty('ddlItem', 'lblItem')) { return; }
        //    $scope.obj.T19001.T_ITEM_CODE = $scope.obj.ddlItem.T_ITEM_CODE;
        //    loader(true)
        //    var save = Service.saveData('/T19001/SaveData', $scope.obj.T19001);
        //    save.then(function (returnData) {
        //        smsAlert(returnData);
        //        loadGridData();
        //        clear();
        //        loader(false)
        //    });
        //}
        //$scope.setProductRow = function (ind, data) {
        //    $scope.selectedRow = ind;
        //    $scope.obj.T19001.T_TYPE_ID = data.T_TYPE_ID;
        //    $scope.obj.T19001.T_TYPE_CODE = data.T_TYPE_CODE;
        //    $scope.obj.T19001.T_TYPE_NAME = data.T_TYPE_NAME;
        //    $scope.obj.ddlItem = { T_ITEM_NAME: data.T_ITEM_NAME, T_ITEM_CODE: data.T_ITEM_CODE };
        //}
        getData();
        function getData() {
            var dataList = [
                { 'Code': '101', 'Name': 'Rayyan', 'Mobile': '01723611037', 'Address': 'Bogura' },
                { 'Code': '102', 'Name': 'Taheem', 'Mobile': '464', 'Address': 'Bogura' },
                { 'Code': '103', 'Name': 'Rubel', 'Mobile': '4645', 'Address': 'Bogura' },
                { 'Code': '104', 'Name': 'Hanif', 'Mobile': '46455645', 'Address': 'Bogura' },
                { 'Code': '105', 'Name': 'Manik', 'Mobile': '46456456', 'Address': 'Bogura' },
            ];
            $scope.obj.laodList = dataList;
        }
        $scope.Clear_Click = function () {
            //getData();
            // clear();
        }
        $scope.onRowClick = function (ind, data) {
            var n = data.Code + ' ' + data.Name + '  ' + data.Mobile;
            $scope.obj.T19002.T_TYPE_CODE = n;
        }
        $scope.Save_Click = function () {
          var dd=  $scope.obj.T19002;
           // alert($scope.obj.T19002.T_TYPE_CODE);
        }
        $scope.Print_Click = function () {
            alert('Print');
        }
        function clear() {
            $scope.obj.T19001 = {};
        }

    }
]);