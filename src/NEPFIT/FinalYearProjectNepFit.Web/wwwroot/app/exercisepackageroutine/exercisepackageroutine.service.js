
(function (angular, app) {
    angular
        .module('tableapp')
        .factory('exercisePackageRoutineService', exercisePackageRoutineService);

    exercisePackageRoutineService.$inject = ['$http'];

    function exercisePackageRoutineService($http) {
        var service = {
            getAllExercisePackageRoutine: getAllExercisePackageRoutine,
            getAllExercisePackageRoutineById: getAllExercisePackageRoutineById,
            updateExercisePackageRoutine: updateExercisePackageRoutine,
            deleteExercisePackageRoutine: deleteExercisePackageRoutine,
            createExercisePackageRoutine: createExercisePackageRoutine,
        };

        return service;

 
        function  getAllExercisePackageRoutine() {
            
                return $http({
                    method: 'GET',
                    url:'api/exercisepackageroutine/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
        function  getAllExercisePackageRoutineById(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/exercisepackageroutine/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            ;
        }

        function  createExercisePackageRoutine(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/exercisepackageroutine/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
       function  updateExercisePackageRoutine(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/exercisepackageroutine/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
           
       }

        function deleteExercisePackageRoutine(item) {
            return $http({
                method: 'POST',
                url: '/api/exercisepackageroutine/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
