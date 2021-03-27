
(function (angular, app) {
    angular
        .module('tableapp')
        .factory('nepFitUserService', nepFitUserService);

    nepFitUserService.$inject = ['$http', 'tokenService', '$q'];

    function nepFitUserService($http, tokenService, $q) {
        var service = {
            getAllNepFitUser: getAllNepFitUser,
            getAllNepFitUserById: getAllNepFitUserById,
            updateNepFitUser: updateNepFitUser,
            createNepFitUser: createNepFitUser,
        };

        return service;

 
        function  getAllNepFitUser() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url: app.nepfituserApibaseUrl + 'api/nepfituser/getall',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        function  getAllNepFitUserById(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.nepfituserApibaseUrl + 'api/nepfituser/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }

        function  createNepFitUser(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.nepfituserApibaseUrl + 'api/nepfituser/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
       function  updateNepFitUser(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.nepfituserApibaseUrl + 'api/nepfituser/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        
    }
})(angular, app);
