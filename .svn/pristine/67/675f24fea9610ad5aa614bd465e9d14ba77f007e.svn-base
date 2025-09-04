
app.controller("R13003Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.AR14003 = {};
        getPartyType();
        getParty();
        $scope.obj.Project_FLG = '1';
        $scope.obj.isShow_project = true;;
        
        $scope.obj.AR14003.FROM_DATE = new Date();
        $scope.obj.AR14003.TO_DATE = new Date();

        function getPartyType() {
            var partyType = Service.loadDataWithoutParm('/T13001/GetPartyTypeData');
            partyType.then(function (redata) {
                $scope.obj.PartyTypeList = JSON.parse(redata);
            });
        }
        function getParty() {
            var party = Service.loadDataSingleParm('/T13001/GetParty', '00');
            party.then(function (redata) {
                $scope.obj.PartyList = JSON.parse(redata);
            });
        }
        $scope.CheckSingle_Click = function (id) {
            if (id == 'Project') {
                $scope.obj.Project_FLG = '1'
                $scope.obj.ComSummary_FLG = '0'               
                $scope.obj.isShow_project = true;
                $scope.obj.isShow_supplier = false;
            }
            
            //else if (id == 'InSupDetlUnProject') {
            //    $scope.obj.Project_FLG = '0'
            //    $scope.obj.Supplier_FLG = '0'
            //    $scope.obj.AllProjStatement_FLG = '0'
            //    $scope.obj.Ind_Suplr_Und_Proj_FLG = '1'
            //    $scope.obj.Ind_Suplr_All_Proj_Summary_FLG = '0'
            //    $scope.obj.isShow_project = false;
            //    $scope.obj.isShow_supplier = false;
            //    $scope.obj.isShow_supplier_details = true;

            //}
            //else if (id == 'InSupAllProjSummary') {
            //    $scope.obj.Project_FLG = '0'
            //    $scope.obj.Supplier_FLG = '0'
            //    $scope.obj.AllProjStatement_FLG = '0'
            //    $scope.obj.Ind_Suplr_Und_Proj_FLG = '0'
            //    $scope.obj.Ind_Suplr_All_Proj_Summary_FLG='1'
            //    $scope.obj.isShow_project = false;
            //    $scope.obj.isShow_supplier_details = false;
            //    $scope.obj.isShow_supplier = true;

            //}
            else if (id == 'ComSummary') {
                $scope.obj.Project_FLG = '0'
               // $scope.obj.Supplier_FLG = '0'
               // $scope.obj.Ind_Suplr_Und_Proj_FLG = '0'
               // $scope.obj.Ind_Suplr_All_Proj_Summary_FLG = '0'
                $scope.obj.ComSummary_FLG = '1'
                $scope.obj.isShow_project = false;
                $scope.obj.isShow_supplier = false;
                $scope.obj.isShow_supplier_details = false;

            }           

        }
       
        $scope.Clear_Click = function () {
            alert('Clear');
        }
        $scope.Print_Click = function () {
            var fromDate = $filter('date')($scope.obj.AR14003.FROM_DATE, 'dd-MM-yyyy');
            var toDate = $filter('date')($scope.obj.AR14003.TO_DATE, 'dd-MM-yyyy');
           // var center = $scope.obj.ddlCenter == null ? '0' : $scope.obj.ddlCenter.CENTER_CODE;

            if ($scope.obj.Project_FLG == '1') {
                var partyType = $scope.obj.ddlPartyType == undefined || $scope.obj.ddlPartyType.PARTY_TYPE_CODE == '' ? '0' : $scope.obj.ddlPartyType.PARTY_TYPE_CODE;
                if (partyType == '0') { alert('Please select Company name'); }
                else {
                   // $window.open("../AR14003/CompanyDetailsReport?partyType=" + partyType, "_blank");
                    $window.open("../R13003/CompanyCashFlowReport?partyType=" + partyType + "&fDate=" + fromDate + "&tDate=" + toDate, "_blank");
                }
            }
            else if ($scope.obj.Supplier_FLG == '1') {
                var party = $scope.obj.ddlParty == undefined || $scope.obj.ddlParty.PARTY_CODE == '' ? '0' : $scope.obj.ddlParty.PARTY_CODE;
                if (party == '0') { alert('Please select Supplier name'); }
                else {
                    $window.open("../R13003/SupplierStatement?party=" + party, "_blank");
                }
            }
            else if ($scope.obj.Ind_Suplr_Und_Proj_FLG == '1') {
                var party = $scope.obj.ddlParty == undefined || $scope.obj.ddlParty.PARTY_CODE == '' ? '0' : $scope.obj.ddlParty.PARTY_CODE;
                var partyType = $scope.obj.ddlPartyType == undefined || $scope.obj.ddlPartyType.PARTY_TYPE_CODE == '' ? '0' : $scope.obj.ddlPartyType.PARTY_TYPE_CODE;
                if (party == '0') { alert('Please select Supplier name'); }
                if ( partyType == '0') { alert('Please select Project name'); }
                else {
                    $window.open("../R13003/IndividualSuprDetlsUnderProj?partyType=" + partyType + "&party=" + party, "_blank");
                }
            }
            else if ($scope.obj.Ind_Suplr_All_Proj_Summary_FLG == '1') {
                var party = $scope.obj.ddlParty == undefined || $scope.obj.ddlParty.PARTY_CODE == '' ? '0' : $scope.obj.ddlParty.PARTY_CODE;
                if (party == '0') { alert('Please select Supplier name'); }
                else {
                    $window.open("../R13003/IndividualSuprAllProjSummary?party=" + party, "_blank");
                }
            }
            else if ($scope.obj.ComSummary_FLG == '1') {
                var center = "0";
                //var party = $scope.obj.ddlParty == undefined || $scope.obj.ddlParty.PARTY_CODE == '' ? '0' : $scope.obj.ddlParty.PARTY_CODE;
              //  if (party == '0') { alert('Please select Supplier name'); }
              //  else {
                $window.open("../R13003/AllCompanySummary", "_blank");
               // $window.open("../AR14003/AllProjectStatement?center=" + center, "popup", "width=600,height=600,left=100,top=50");
              //  }
            }
           
        }
        function loader(p) {
            $scope.loading = p === undefined ? false : p;
            return $scope.loading;
        };
    }
]);