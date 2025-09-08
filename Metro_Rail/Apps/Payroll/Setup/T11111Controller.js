app.controller("T11111Controller", ["$scope", "Service", "ImageService", "Data", "$window", "$filter",
    function ($scope, Service, ImageService, Data, $window, $filter) { //$location,
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
        $scope.obj.ChildList = [];
        $scope.obj.TrainingdataList = [];

        // Function to change tabs
        $scope.setActiveTab = function (tabName) {            
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

        function loadChilds() {
            loader(true)
            var childsList = Service.loadDataSingleParm('/T11111/ChildsData', $scope.obj.T11111.T_EMP_CODE);
            childsList.then(function (returnData) {
                $scope.dbList = JSON.parse(returnData);
                $scope.obj.ChildList = angular.copy($scope.dbList); // grid এ দেখাবেন
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
            if ($scope.obj.activeTab === 'Basic') {                
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
                $scope.Family = {};
                $scope.Family.T_EMP_CODE = $scope.obj.T11111.T_EMP_CODE;
                $scope.Family.spouseInfo = $scope.obj.T11111;
                $scope.Family.ChildList = $scope.obj.ChildList;
                var save = Service.saveData('/T11111/SaveFamilyData', $scope.Family);
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
                $scope.TrainingData = {};
                $scope.TrainingData.T_EMP_CODE = $scope.obj.T11111.T_EMP_CODE;
                if ($scope.obj.TrainingdataList.length > 0) { $scope.TrainingData.TrnigList = $scope.obj.TrainingdataList; } else { smsAlert("Add data in list!-0"); return; }
              
                var save = Service.saveData('/T11111/SaveTrainingData', $scope.TrainingData);
                save.then(function (returnData) {
                    smsAlert(returnData);
                    //loadGridData();                 
                    //clear();
                    loader(false)
                });
            }
            else if ($scope.obj.activeTab === 'Picture') {
                var save = ImageService.saveData($scope.obj.T11111);
                save.then(function (mesg) {
                    smsAlert(mesg);
                    loader(false)
                    $window.location.reload();
                });
            }
            $scope.loading = false;
        };
        //--------------tab faminly start---------------------
        $scope.Add_Child_Click = function () {
            if (isEmpty('txtChildBOD', 'lblChildBOD')) { return; };
            $scope.obj.newList = [];
            let Z = {
                T_CHILD_ID: $scope.obj.T_CHILD_ID,
                T_CHILD_CODE: $scope.obj.T_CHILD_CODE,
                T_CHILD_NAME: $scope.obj.T_CHILD_NAME,
                T_CHILD_GENDER: $scope.obj.ddlChildGnd.T_GENDER_CODE,
                T_GENDER_NAME: $scope.obj.ddlChildGnd.T_GENDER_NAME,
                T_CHILD_DOB: $filter('date')($scope.obj.T_CHILD_DOB, 'dd-MM-yyyy'),
                T_CHILD_SCHOOL: $scope.obj.T_CHILD_SCHOOL,
                T_CHILD_CLASS: $scope.obj.T_CHILD_CLASS,
                T_CHILD_CERTIFICATE: $scope.obj.T_CHILD_CERTIFICATE
            };
            
            let exist = $scope.obj.ChildList.some(x => x.T_CHILD_NAME === Z.T_CHILD_NAME);
            if (exist) {
                smsAlert("Already Exist!-0");
                return;
            }
            $scope.obj.ChildList.push(Z);
           // $scope.obj.newList.push(Z);
            childClear();
        };

        //--------------tab faminly end---------------------
        //--------------tab Education start---------------------
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
        //---------------tab Education end------------------------------
        //---------------tab Trarnign start------------------------------
        $scope.Add_Training = function () {
            if (isEmpty('txtCourseTitle', 'lblCourseTitle')) { return; };
            if (isEmpty('txtTrainingType', 'lblTrainingType')) { return; };
            if (isEmpty('txtFromDate', 'lblFromDate')) { return; };
            if (isEmpty('txtToDate', 'lblToDate')) { return; };
            if (isEmpty('txtPosition', 'lblPosition')) { return; };
            if (isEmpty('txtInstitution', 'lblInstitution')) { return; };

            let Z = {
                T_TRAINING_ID: $scope.obj.T_TRAINING_ID,
                T_TRAINING_CODE: $scope.obj.T_TRAINING_CODE,
                T_COURSE_TITLE: $scope.obj.T_COURSE_TITLE,
                T_TRAINING_TYPE_CODE: $scope.obj.T_TRAINING_TYPE_CODE,                
                T_FROM_DATE: $filter('date')($scope.obj.T_FROM_DATE, 'dd-MM-yyyy'),
                T_TO_DATE: $filter('date')($scope.obj.T_TO_DATE, 'dd-MM-yyyy'),               
                T_POSITION: $scope.obj.T_POSITION,
                T_INSTITUTION_NAME: $scope.obj.T_INSTITUTION_NAME
            };

            let exist = $scope.obj.TrainingdataList.some(x => x.T_COURSE_TITLE === Z.T_COURSE_TITLE);
            if (exist) {
                smsAlert("Already Exist!-0");
                return;
            }
            $scope.obj.TrainingdataList.push(Z);
            // $scope.obj.newList.push(Z);
           // childClear();
            document.getElementById('txtCourseTitle').focus();


            //var ckList = $scope.obj.TrainingdataList == undefined ? 0 : $scope.obj.TrainingdataList.filter(x => x.T_INSTITUTION_NAME == $scope.obj.T_INSTITUTION_NAME);
            //if (ckList.length > 0) { showSMS('Already Exist !!', 'warning'); return; }
            //var Newdatalist = [];
            //var list = {};
            //list.sl = 1;
            //list.T_INSTITUTION_NAME = $scope.obj.T_INSTITUTION_NAME;
            //list.T_GROUP_SUBJECT = $scope.obj.T_GROUP_SUBJECT;
            //list.T_PASSING_YEAR = $scope.obj.T_PASSING_YEAR;
            //list.T_RESULT = $scope.obj.T_RESULT;
            //list.T_DISTINCTION = $scope.obj.T_DISTINCTION;
            //Newdatalist.push(list);

            //var ln = $scope.obj.AcdmcdataList == undefined ? 0 : $scope.obj.AcdmcdataList.length;
            //for (var i = 0; i < ln; i++) {
            //    var list = {};
            //    list.sl = (i + 2);
            //    list.T_INSTITUTION_NAME = $scope.obj.AcdmcdataList[i].T_INSTITUTION_NAME;
            //    list.T_GROUP_SUBJECT = $scope.obj.AcdmcdataList[i].T_GROUP_SUBJECT;
            //    list.ACCOUNT_HEADER_CODE = $scope.obj.AcdmcdataList[i].ACCOUNT_HEADER_CODE;
            //    list.T_PASSING_YEAR = $scope.obj.AcdmcdataList[i].T_PASSING_YEAR;
            //    list.T_RESULT = $scope.obj.AcdmcdataList[i].T_RESULT;
            //    list.T_DISTINCTION = $scope.obj.AcdmcdataList[i].T_DISTINCTION;
            //    Newdatalist.push(list);
            //}
            //$scope.obj.AcdmcdataList = Newdatalist;
           
        }
        //---------------tab Training end------------------------------
        //---------------tab Picture start------------------------------
        //Image Upload Function Start
        $scope.stepsModel = [];
        $scope.imageUpload = function (event) {
            $scope.obj.T11111.T_PROFILE_IMAGE = '';
            $scope.imgDiv = false;
            var files = event.target.files; //FileList object         
            for (var i = 0; i < files.length; i++) {
                var file = files[0];
                var reader = new FileReader();
                reader.onload = $scope.imageIsLoaded;
                reader.readAsDataURL(file);
            }

        }
        $scope.imageIsLoaded = function (e) {
            $scope.$apply(function () {
                $scope.stepsModel.push(e.target.result);
            });
        }
        //Image Upload Function End

        //---------------tab Pictrue end------------------------------

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
            loadChilds();
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

        $scope.selectGridRow = function (idx, data) {
            debugger;
            loader(true);
            $scope.obj.T_CHILD_ID = data.T_CHILD_ID;
            $scope.obj.T_CHILD_CODE = data.T_CHILD_CODE;
            $scope.obj.T_CHILD_NAME = data.T_CHILD_NAME;
            //$scope.obj.T_CHILD_GENDER = data.T_CHILD_GENDER;
            $scope.obj.ddlChildGnd = { T_GENDER_CODE: data.T_GENDER_CODE, T_GENDER_NAME: data.T_GENDER_NAME };
            var dbDate = data.T_CHILD_DOB;
            $scope.obj.T_CHILD_DOB = convertToDateObject(dbDate);
            $scope.obj.T_CHILD_SCHOOL = data.T_CHILD_SCHOOL;
            $scope.obj.T_CHILD_CLASS = data.T_CHILD_CLASS;
            $scope.obj.T_CHILD_CERTIFICATE = data.T_CHILD_CERTIFICATE;
            $scope.obj.ChildList.splice(idx, 1);
            //$scope.obj.newList.splice(idx, 1);
            //debit_Credit_Calculate()
            loader(false)
        }

        function convertToDateObject(dateStr) {
            if (!dateStr) return null;
            var parts = dateStr.split('/'); // ["25", "05", "2025"]
            // month index 0 থেকে শুরু হয়, তাই -1 করতে হবে
            return new Date(parts[2], parts[1] - 1, parts[0]);
        }

        // Database থেকে আসা value
        //var dbDate = "25/05/2025";
        //$scope.obj.T_CHILD_DOB = convertToDateFormat(dbDate);
        
    }
]);