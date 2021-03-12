
(function (angular, app) {
    angular
        .module('tableapp')
        .factory('exerciseRoutineService', exerciseRoutineService);

    exerciseRoutineService.$inject = ['$http', 'tokenService', '$q'];

    function exerciseRoutineService($http, tokenService, $q) {
        var service = {
            getAllExerciseRoutine: getAllExerciseRoutine,
            getAllExerciseRoutineById: getAllExerciseRoutineById,
            updateExerciseRoutine: updateExerciseRoutine,
            createExerciseRoutine: createExerciseRoutine,
        };

        return service;

 
        function  getAllExerciseRoutine() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url: app.exerciseroutineApibaseUrl + 'api/exerciseroutine/getall',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        function  getAllExerciseRoutineById(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exerciseroutineApibaseUrl + 'api/exerciseroutine/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }

        function  createExerciseRoutine(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exerciseroutineApibaseUrl + 'api/exerciseroutine/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
       function  updateExerciseRoutine(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exerciseroutineApibaseUrl + 'api/exerciseroutine/update',
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
