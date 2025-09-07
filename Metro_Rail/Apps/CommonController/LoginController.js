
app.controller("LoginController", [ "$scope", "LoginService", "Data", "$window", "$filter",
        function($scope, LoginService, Data, $window, $filter) { //$location,
            $scope.obj = {};
            $scope.obj = Data;
            $scope.obj.T12000 = {};
            loadValue();
            document.getElementsByTagName('input')[0].focus();
            function loadValue() {
                loader(true);
                var gridData = LoginService.GetValue();
                gridData.then(function (data) {
                    $scope.obj.T12000.Value = data;
                    const myArray = data.split("/");
                    var val_1 = myArray[0];
                    var val_ = myArray[1];
                    loader(false);
                });
            }

            $scope.Login_click = function () {
                login();                
            };
            $scope.enter_press = function (event) {
                if (event.keyCode === 13) {
                    if ($scope.obj.T12000.User_Name == undefined || $scope.obj.T12000.User_Name == '') {
                        document.getElementById('txtUserName').focus(); return;
                    }
                    else if ($scope.obj.T12000.Password == undefined || $scope.obj.T12000.Password == '') {
                        document.getElementById('txtPassword').focus(); return;
                    }
                    else if ($scope.obj.T12000.CLAPS_SUM == undefined || $scope.obj.T12000.CLAPS_SUM == '') {
                        document.getElementById('txtClapsSum').focus(); return;
                    }
                    else if ($scope.obj.T12000.User_Name != undefined && $scope.obj.T12000.User_Name != '' && $scope.obj.T12000.Password != undefined && $scope.obj.T12000.Password != '' && $scope.obj.T12000.CLAPS_SUM != undefined && $scope.obj.T12000.CLAPS_SUM != '') {
                        login();
                    }                  
                }
            }
            function login() {
              
                if ($scope.obj.T12000.User_Name != undefined && $scope.obj.T12000.User_Name != '' && $scope.obj.T12000.Password != undefined && $scope.obj.T12000.Password != '' && $scope.obj.T12000.CLAPS_SUM != undefined && $scope.obj.T12000.CLAPS_SUM != '') {
                    loader(true);
                    var d = LoginService.login($scope.obj.T12000.User_Name, $scope.obj.T12000.Password, $scope.obj.T12000.CLAPS_SUM);
                    d.then(function (data) {
                        const myArray = data.split("-");
                        if (myArray[0] == '1') {
                            if (myArray[1] == '100') {
                                window.location.href = "/Home/H00001";
                                // window.location.href = "/DT01111/DT01111";
                            } else if (myArray[1] == '101') {
                                window.location.href = "/Home/H00001";
                                /*window.location.href = "/Transaction/AT13001";*/
                            } else {
                                window.location.href = "/Home/H00001";
                            }
                           // window.location.href = "/Transaction/SendSms";
                            // loader(false);
                        } else if (data == '2') {
                            alert('userId or password is wrong !!!');
                            loader(false);
                            loadValue();
                            $scope.obj.T12000.CLAPS_SUM = ''
                        } else {
                            alert('You are not Authenticate user. Please Contact with 01515265289');
                            loader(false);
                            loadValue();
                            $scope.obj.T12000.CLAPS_SUM = ''
                        }
                    });
                } else {
                    alert('Please enter userId and password');
                    loader(false);
                }
            }           

            function loader(p) {
                $scope.loading = p === undefined ? false : p;
                return $scope.loading;
            };
        }
    ]);