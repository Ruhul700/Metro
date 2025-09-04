
app.controller("R13004Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.AR14004 = {};
        getCustomer();
        $scope.obj.AR14004.FROM_DATE = new Date();
        $scope.obj.AR14004.TO_DATE = new Date();
      //  getParty();
        $scope.obj.Summary_FLG = '1';
       // $scope.obj.isShow_project = true;;

        $scope.obj.AR14004.FROM_DATE = new Date();
        $scope.obj.AR14004.TO_DATE = new Date();
        function getCustomer() {
            var partyType = Service.loadDataWithoutParm('/T13004/GetAllCustomer')
            partyType.then(function (redata) {
                $scope.obj.CustomerList = JSON.parse(redata);
            });
        }
        

        $scope.CheckSingle_Click = function (id) {
            if (id == 'CsmrSummary') {
                $scope.obj.Summary_FLG = '1'
                $scope.obj.Statment_FLG = '0'
                //$scope.obj.AllProjStatement_FLG = '0'
                //$scope.obj.Ind_Suplr_Und_Proj_FLG = '0'
                //$scope.obj.Ind_Suplr_All_Proj_Summary_FLG = '0'
                $scope.obj.isShow_Statment = false;
                $scope.obj.isShow_CustSammary = false;
            }
            else if (id == 'CustStatment') {
                $scope.obj.Summary_FLG = '0'
                $scope.obj.Statment_FLG = '1'
                //$scope.obj.AllProjStatement_FLG = '0'
               // $scope.obj.Ind_Suplr_Und_Proj_FLG = '0'
               // $scope.obj.Ind_Suplr_All_Proj_Summary_FLG = '0'
               // $scope.obj.isShow_project = false;
                $scope.obj.isShow_CustSammary = false;
                $scope.obj.isShow_Statment = true;

            }
            else if (id == 'InSupDetlUnProject') {
                $scope.obj.Project_FLG = '0'
                $scope.obj.Supplier_FLG = '0'
                $scope.obj.AllProjStatement_FLG = '0'
                $scope.obj.Ind_Suplr_Und_Proj_FLG = '1'
                $scope.obj.Ind_Suplr_All_Proj_Summary_FLG = '0'
                $scope.obj.isShow_project = false;
                $scope.obj.isShow_supplier = false;
                $scope.obj.isShow_supplier_details = true;

            }
            else if (id == 'InSupAllProjSummary') {
                $scope.obj.Project_FLG = '0'
                $scope.obj.Supplier_FLG = '0'
                $scope.obj.AllProjStatement_FLG = '0'
                $scope.obj.Ind_Suplr_Und_Proj_FLG = '0'
                $scope.obj.Ind_Suplr_All_Proj_Summary_FLG = '1'
                $scope.obj.isShow_project = false;
                $scope.obj.isShow_supplier_details = false;
                $scope.obj.isShow_supplier = true;

            }
            else if (id == 'AllProjStatement') {
                $scope.obj.Project_FLG = '0'
                $scope.obj.Supplier_FLG = '0'
                $scope.obj.Ind_Suplr_Und_Proj_FLG = '0'
                $scope.obj.Ind_Suplr_All_Proj_Summary_FLG = '0'
                $scope.obj.AllProjStatement_FLG = '1'
                $scope.obj.isShow_project = false;
                $scope.obj.isShow_supplier = false;
                $scope.obj.isShow_supplier_details = false;

            }

        }

        $scope.Clear_Click = function () {
            alert('Clear');
        }
        $scope.Print_Click = function () {
            var fromDate = $filter('date')($scope.obj.AR14004.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.AR14004.TO_DATE, 'dd-MM-yyyy');  
             if ($scope.obj.Statment_FLG == '1') {
                var custId = $scope.obj.ddlCustormerName == undefined || $scope.obj.ddlCustormerName.T_CUSTOMER_ID == '' ? '0' : $scope.obj.ddlCustormerName.T_CUSTOMER_ID;

                if (custId == '0') { alert('Please select Customer name'); }
                else {
                    $window.open("../R13004/IndividualCustomer?custId=" + custId + "&fDate=" + fromDate + "&tDate=" + toDate, "_blank");
                }
            }
            else if ($scope.obj.Summary_FLG == '1') {
                var center = "0";                
                 $window.open("../R13004/AllCustormerSummary", "_blank");
            }

        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);