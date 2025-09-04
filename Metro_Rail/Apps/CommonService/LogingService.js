
app.service("LoginService",["$http", function($http) {
            var data = {
                login: login,
                GetValue: GetValue
               // insertData: insertData
            };
    return data;

    function login(userId, pass, clapsSum) {
            try {
                var url = '/Login/UserLogin';
                var params = {};
                return $http({
                    url: url,
                    method: "POST",
                    //data: params
                    data: { userId: userId, pass: pass, clapsSum: clapsSum}
                }).then(function (results) {

                    return results.data;
                }).catch(function (ex) {
                    throw ex;
                });
            } catch (ex) {
                throw ex;
            }
        }
    function GetValue() {
        try {
            var url = '/Login/GetValue';
            var params = {};
            return $http({
                url: url,
                method: "POST",
                //data: params
                data: {}
            }).then(function (results) {

                return results.data;
            }).catch(function (ex) {
                throw ex;
            });
        } catch (ex) {
            throw ex;
        }
    }
        }
    ]);