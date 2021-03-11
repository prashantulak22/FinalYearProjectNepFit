
(function (angular, app) {
    angular
        .module('tableapp')
        .factory('exercisePackageService', exercisePackageService);

    exercisePackageService.$inject = ['$http', 'tokenService', '$q'];

    function exercisePackageService($http, tokenService, $q) {
        var service = {
            getAllExercisePackage: getAllExercisePackage,
            getAllExercisePackageById: getAllExercisePackageById,
            updateExercisePackage: updateExercisePackage,
            createExercisePackage: createExercisePackage,
        };

        return service;

 
        function  getAllExercisePackage() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url: app.exercisepackageApibaseUrl + 'api/exercisepackage/getall',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        function  getAllExercisePackageById(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisepackageApibaseUrl + 'api/exercisepackage/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }

        function  createExercisePackage(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisepackageApibaseUrl + 'api/exercisepackage/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
       function  updateExercisePackage(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisepackageApibaseUrl + 'api/exercisepackage/update',
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
