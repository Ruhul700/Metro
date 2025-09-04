app.controller("T11111Controller", ["$scope", "Service", "Data", "$window", "$filter",
    function ($scope, Service, Data, $window, $filter) { //$location,
        $scope.obj = {};
        $scope.obj = Data;
        $scope.obj.T11111 = {};
        $scope.obj.ddlGender = {};
        $scope.obj.ddlReligion = {};
        $scope.obj.ddlDesig = {};
        $scope.obj.T11111.T_ACTIVE_TAB = 'Basic';

        $scope.obj.activeTab= 'Basic';
        $scope.obj.basicInfoSaved= false;
        $scope.obj.familyInfoSaved = false;
        $scope.obj.educationInfoSaved = false;
        $scope.obj.trainingInfoSaved = false;
        $scope.obj.pictureInfoSaved = false;
        $scope.obj.childrenDataList = [];
        $scope.obj.academicDataList = [];
        $scope.obj.professionalDataListv = [];
        $scope.obj.trainingDataListv = [];
      
        // Initialize with one empty row for each list
       // $scope.obj.childrenDataList.push({});
       // $scope.obj.academicDataList.push({});
      //  $scope.obj.professionalDataList.push({});
      //  $scope.obj.trainingDataList.push({});

        // Function to change tabs
        $scope.setActiveTab = function (tabName) {
            // Prevent changing tabs unless the previous one is saved
            //if (tabName === 'Family' && !$scope.obj.basicInfoSaved) {
            //    return;
            //}
            //if (tabName === 'Education') {
            //    return;
            //}
            //if (tabName === 'Training' && !$scope.obj.educationInfoSaved) {
            //    return;
            //}
            //if (tabName === 'Picture' && !$scope.obj.trainingInfoSaved) {
            //    return;
            //}
            //if (tabName === 'Profile' && !$scope.obj.pictureInfoSaved) {
            //    return;
            //}
            $scope.obj.activeTab = tabName;
            $scope.obj.T11111.T_ACTIVE_TAB = tabName;
        };
        
        loadGender();
        loadReligion();
        loadDesignation();
        loadDepartment();
        getClient();

        function loadGender() {
            loader(true)
            var gender = Service.loadDataWithoutParm('/T11111/GenderData');
            gender.then(function (returnData) {
                $scope.obj.genderDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        function loadReligion() {
            loader(true)
            var religion = Service.loadDataWithoutParm('/T11111/ReligionData');
            religion.then(function (returnData) {
                $scope.obj.religionDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        function loadDesignation() {
            loader(true)
            var desig = Service.loadDataWithoutParm('/T11111/DesignationData');
            desig.then(function (returnData) {
                $scope.obj.designationDataList = JSON.parse(returnData);
                loader(false)
            });
        }
        function loadDepartment() {
            loader(true)
            var desig = Service.loadDataWithoutParm('/T11111/DepartmentData');
            desig.then(function (returnData) {
                $scope.obj.departmentDataList = JSON.parse(returnData);
                loader(false)
            });
        }



        // CRUD functions for dynamic fields
        $scope.addChild = function () {
            $scope.obj.childrenDataList.push({});
        };
        $scope.removeChild = function (index) {
            $scope.obj.childrenDataList.splice(index, 1);
        };

        // Save Logic for all tabs
        $scope.Save_Click = function () {
            $scope.loading = true;
            // Logic to save data for the active tab
            if ($scope.obj.activeTab === 'Basic') {
                // Validate basic info
                if (!$scope.obj.T11111.T_EMP_CODE || !$scope.obj.T11111.T_EMP_NAME) {
                    alert("Please fill out all required fields in Basic Information.");
                    $scope.loading = false;
                    return;
                }                
                var save = Service.saveData('/T11111/SaveData', $scope.obj.T11111);
                save.then(function (returnData) {
                    smsAlert(returnData);
                    //loadGridData();
                    //clear();
                    $scope.obj.basicInfoSaved = true;
                    loader(false)
                });                
            }
            else if ($scope.obj.activeTab === 'Family') {
                // Save family info logic
                // Service.SaveData(obj.T11111, obj.childrenDataList).then(function(response) { ... });
                
                var save = Service.saveData_Model_List('/T11111/SaveData', $scope.obj.T11111, $scope.obj.childrenDataList);
                save.then(function (returnData) {
                    smsAlert(returnData);
                    //loadGridData();
                    $scope.obj.familyInfoSaved = true;
                    //clear();
                    loader(false)
                });
            }
            else if ($scope.obj.activeTab === 'Education') {
                $scope.EduData = {};
                $scope.EduData.T_EMP_CODE = $scope.obj.T11111.T_EMP_CODE;
                if ($scope.obj.AcdmcdataList.length > 0) { $scope.EduData.AcademicList = $scope.obj.AcdmcdataList; }
                if ($scope.obj.ProfedataList.length > 0) { $scope.EduData.ProfesList = $scope.obj.ProfedataList; }
                var save = Service.saveData('/T11111/SaveEducationData', $scope.EduData);
                save.then(function (returnData) {
                    smsAlert(returnData);
                    //loadGridData();
                    $scope.obj.familyInfoSaved = true;
                    //clear();
                    loader(false)
                });
              
            }
            else if ($scope.obj.activeTab === 'Training') {
                
            }
            else if ($scope.obj.activeTab === 'Picture') {
                
            }
            $scope.loading = false;
        };

        //$scope.Save_Click = function () {            
        //    if (isEmpty('txtName','lblName')) { return; };
        //    if (isEmpty('txtMobile','lblMobile') ) { return; };
        //    if (isEmpty('ddlGender','lblGender') ) { return; };
        //    if (isEmpty('ddlReligion','lblReligion') ) { return; };
        //    if (isEmpty('ddlDesig','lblDesig')) { return; };
        //    if (isEmpty('txtAddress','lblAddress') ) { return; };
        //    if (!checkMobileNumber($scope.obj.T11111.T_EMP_MOBILE)) { showSMS('Mobile is not valide', 'warning'); return; }

        //    loader(true)
        //    $scope.obj.T11111.T_GENDER_CODE = $scope.obj.ddlGender.T_GENDER_CODE;
        //    $scope.obj.T11111.T_RELIGION_CODE = $scope.obj.ddlReligion.T_RELIGION_CODE;
        //    $scope.obj.T11111.T_DESIGNATION_CODE = $scope.obj.ddlDesig.T_DESIGNATION_CODE;
        //    var save = Service.saveData('/T11111/SaveData',$scope.obj.T11111);
        //    save.then(function (returnData) {
        //        smsAlert(returnData);
        //        loadGridData();
        //        clear();
        //        loader(false)
        //    });
        //}

        //--------------tab Education---------------------
        $scope.Add_Academic = function () {
            if (isEmpty('txtAdmIsntName', 'lblAdmIsntName')) { return; };
            if (isEmpty('txtAdmGroup', 'lblAdmGroup')) { return; };
            if (isEmpty('txtAdmPasYear', 'lblAdmPasYear')) { return; };
            if (isEmpty('txtAdmResult', 'lblAdmResult')) { return; };
            if (isEmpty('txtAdmDistnc', 'lblAdmDistnc')) { return; };

            var ckList = $scope.obj.AcdmcdataList == undefined ? 0 : $scope.obj.AcdmcdataList.filter(x => x.T_INSTITUTION_NAME == $scope.obj.T_INSTITUTION_NAME);
            if (ckList.length > 0) { showSMS('Already Exist !!', 'warning'); return; }
            var Newdatalist = [];
            var list = {};
            list.sl = 1;
            list.T_INSTITUTION_NAME = $scope.obj.T_INSTITUTION_NAME;
            list.T_GROUP_SUBJECT = $scope.obj.T_GROUP_SUBJECT;
            list.T_PASSING_YEAR = $scope.obj.T_PASSING_YEAR;
            list.T_RESULT = $scope.obj.T_RESULT;
            list.T_DISTINCTION = $scope.obj.T_DISTINCTION;
            Newdatalist.push(list);

            var ln = $scope.obj.AcdmcdataList == undefined ? 0 : $scope.obj.AcdmcdataList.length;
            for (var i = 0; i < ln; i++) {
                var list = {};
                list.sl = (i + 2);
                list.T_INSTITUTION_NAME = $scope.obj.AcdmcdataList[i].T_INSTITUTION_NAME;
                list.T_GROUP_SUBJECT = $scope.obj.AcdmcdataList[i].T_GROUP_SUBJECT;
                list.ACCOUNT_HEADER_CODE = $scope.obj.AcdmcdataList[i].ACCOUNT_HEADER_CODE;
                list.T_PASSING_YEAR = $scope.obj.AcdmcdataList[i].T_PASSING_YEAR;
                list.T_RESULT = $scope.obj.AcdmcdataList[i].T_RESULT;
                list.T_DISTINCTION = $scope.obj.AcdmcdataList[i].T_DISTINCTION;
                Newdatalist.push(list);
            }
            $scope.obj.AcdmcdataList = Newdatalist;
            document.getElementById('txtProfeIsntName').focus();
        }
        $scope.Add_Professional = function () {
            if (isEmpty('txtProfeIsntName', 'lblProfeIsntName')) { return; };
            if (isEmpty('txtProfeGroup', 'lblProfeGroup')) { return; };
            if (isEmpty('txtProfePasYear', 'lblProfePasYear')) { return; };
            if (isEmpty('txtProfeResult', 'lblProfeResult')) { return; };
            if (isEmpty('txtProfeDistnc', 'lblProfeDistnc')) { return; };

            var ckList = $scope.obj.ProfedataList == undefined ? 0 : $scope.obj.ProfedataList.filter(x => x.T_INSTITUTION_NAME == $scope.obj.T_PRF_INSTITUTION_NAME);
            if (ckList.length > 0) { showSMS('Already Exist !!', 'warning'); return; }
            var Newdatalist = [];
            var list = {};
            list.sl = 1;
            list.T_INSTITUTION_NAME = $scope.obj.T_PRF_INSTITUTION_NAME;
            list.T_GROUP_SUBJECT = $scope.obj.T_PRF_GROUP_SUBJECT;
            list.T_PASSING_YEAR = $scope.obj.T_PRF_PASSING_YEAR;
            list.T_RESULT = $scope.obj.T_PRF_RESULT;
            list.T_DISTINCTION = $scope.obj.T_PRF_DISTINCTION;
            Newdatalist.push(list);

            var ln = $scope.obj.ProfedataList == undefined ? 0 : $scope.obj.ProfedataList.length;
            for (var i = 0; i < ln; i++) {
                var list = {};
                list.sl = (i + 2);
                list.T_INSTITUTION_NAME = $scope.obj.ProfedataList[i].T_INSTITUTION_NAME;
                list.T_GROUP_SUBJECT = $scope.obj.ProfedataList[i].T_GROUP_SUBJECT;
                list.ACCOUNT_HEADER_CODE = $scope.obj.ProfedataList[i].ACCOUNT_HEADER_CODE;
                list.T_PASSING_YEAR = $scope.obj.ProfedataList[i].T_PASSING_YEAR;
                list.T_RESULT = $scope.obj.ProfedataList[i].T_RESULT;
                list.T_DISTINCTION = $scope.obj.ProfedataList[i].T_DISTINCTION;
                Newdatalist.push(list);
            }
            $scope.obj.ProfedataList = Newdatalist;
            document.getElementById('txtAdmIsntName').focus();
        }


        $scope.selectedtRow = function (ind, data) {
            $scope.selectedRow = ind;
            $scope.obj.T11111.T_EMP_ID = data.T_EMP_ID;
            $scope.obj.T11111.T_EMP_CODE = data.T_EMP_CODE;
            $scope.obj.T11111.T_EMP_NAME = data.T_EMP_NAME;
            $scope.obj.T11111.T_EMP_MOBILE = data.T_EMP_MOBILE;
            $scope.obj.T11111.T_EMP_ADDRESS = data.T_EMP_ADDRESS;
            $scope.obj.T11111.T_ACCOUNT_NO = data.T_ACCOUNT_NO;
            $scope.obj.T11111.T_BANK_NAME = data.T_BANK_NAME;
            $scope.obj.T11111.T_ROUTING_NO = data.T_ROUTING_NO;
            $scope.obj.ddlGender = { T_GENDER_CODE: data.T_GENDER_CODE, T_GENDER_NAME: data.T_GENDER_NAME };
            $scope.obj.ddlReligion = { T_RELIGION_CODE: data.T_RELIGION_CODE, T_RELIGION_NAME: data.T_RELIGION_NAME };
            $scope.obj.ddlDesig = { T_DESIGNATION_CODE: data.T_DESIGNATION_CODE, T_DESIGNATION_NAME: data.T_DESIGNATION_NAME };
            $scope.obj.T11111.T_ENTRY_DATE = data.T_ENTRY_DATE;
        }
        $scope.Clear_Click = function () {
            clear();
        }
        $scope.Print_Click = function () {
            $window.open("../T11111/T11111_GetEmployeeProfileData?empCode=" + $scope.obj.T11111.T_EMP_CODE, "_blank");
        }
        function clear() {
            $scope.obj.T11111 = {};
        }

        //popup start

        $scope.ClientName = function () {
            document.getElementById('Client').style.display = "block";
        }
        $scope.closeModal = function (id) {
            document.getElementById(id).style.display = "none";
        }
        $scope.setClientRow = function (ind, data) {
            debugger;
            document.getElementById('Client').style.display = "none";
            $scope.obj.T11111 = data;
            //$scope.obj.T11111.T_EMP_CODE = data.T_EMP_CODE;
            //$scope.obj.T11111.T_EMP_NAME = data.T_EMP_NAME;
            $scope.obj.basicInfoSaved = true;
            //$scope.obj.ddlItem = { T_GRADE_NAME: data.T_GRADE_NAME, T_GRADE_CODE: data.T_GRADE_CODE };
            //$scope.obj.ddlItemDesignation = { T_DESIGNATION_NAME: data.T_DESIGNATION_NAME, T_DESIGNATION_CODE: data.T_DESIGNATION_CODE };
            
        }

        //popup end
        function getClient() {
            var client = Service.loadDataWithoutParm('/T11111/LoadData');
            client.then(function (redata) {
                $scope.obj.ClientList = JSON.parse(redata);
            });
        }
        
    }
]);