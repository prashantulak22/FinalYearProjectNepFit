
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('exerciseRoutineService', exerciseRoutineService);

    exerciseRoutineService.$inject = ['$http'];

    function exerciseRoutineService($http) {
        var service = {
            getExerciseRoutineByUser: getExerciseRoutineByUser,
            getAllExerciseRoutine: getAllExerciseRoutine,
            getAllExerciseRoutineById: getAllExerciseRoutineById,
            updateExerciseRoutine: updateExerciseRoutine,
            deleteExerciseRoutine: deleteExerciseRoutine,
            createExerciseRoutine: createExerciseRoutine,
        };

        return service;

        function getExerciseRoutineByUser() {

            return $http({
                method: 'GET',
                url: 'api/exerciseroutine/user',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
            }).then(
                function (data, status, headers, config) {
                    return data;
                });

        }

        function  getAllExerciseRoutine() {
            
                return $http({
                    method: 'GET',
                    url:'api/exerciseroutine/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
        function  getAllExerciseRoutineById(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/exerciseroutine/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }

        function  createExerciseRoutine(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/exerciseroutine/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
       function  updateExerciseRoutine(item) {
           
                return $http({
                    method: 'POST',
                    url:'api/exerciseroutine/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
           
       }

        function deleteExerciseRoutine(item) {
            return $http({
                method: 'POST',
                url: '/api/exerciseroutine/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
