
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('exercisePackageService', exercisePackageService);

    exercisePackageService.$inject = ['$http'];

    function exercisePackageService($http) {
        var service = {
            getAllExercisePackage: getAllExercisePackage,
            getAllExercisePackageById: getAllExercisePackageById,
            updateExercisePackage: updateExercisePackage,
            deleteExercisePackage: deleteExercisePackage,
            createExercisePackage: createExercisePackage,
        };

        return service;

 
        function  getAllExercisePackage() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url: 'api/exercisepackage/all',
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
                    url:'api/exercisepackage/getbyid',
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
                    url: 'api/exercisepackage/add',
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
                    url:'api/exercisepackage/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
       }
        function deleteExerciseType(item) {
            return $http({
                method: 'DELETE',
                url: '/api/exercisepackage/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
