
(function (angular, app) {
    angular
        .module('tableapp')
        .factory('exercisePackageRoutineService', exercisePackageRoutineService);

    exercisePackageRoutineService.$inject = ['$http', 'tokenService', '$q'];

    function exercisePackageRoutineService($http, tokenService, $q) {
        var service = {
            getAllExercisePackageRoutine: getAllExercisePackageRoutine,
            getAllExercisePackageRoutineById: getAllExercisePackageRoutineById,
            updateExercisePackageRoutine: updateExercisePackageRoutine,
            createExercisePackageRoutine: createExercisePackageRoutine,
        };

        return service;

 
        function  getAllExercisePackageRoutine() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url: app.exercisepackageroutineApibaseUrl + 'api/exercisepackageroutine/getall',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        function  getAllExercisePackageRoutineById(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisepackageroutineApibaseUrl + 'api/exercisepackageroutine/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }

        function  createExercisePackageRoutine(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisepackageroutineApibaseUrl + 'api/exercisepackageroutine/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
       function  updateExercisePackageRoutine(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisepackageroutineApibaseUrl + 'api/exercisepackageroutine/update',
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
