
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('exerciseTypeService', exerciseTypeService);

    exerciseTypeService.$inject = ['$http'];

    function exerciseTypeService($http) {
        var service = {
            getAllExerciseType: getAllExerciseType,
            getAllExerciseTypeById: getAllExerciseTypeById,
            updateExerciseType: updateExerciseType,
            deleteExerciseType: deleteExerciseType,
            createExerciseType: createExerciseType,
        };

        return service;


        function getAllExerciseType() {
            return $http({
                method: 'GET',
                url: app.exercisetypeApibaseUrl + 'api/exercisetype/getall',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }

        function getAllExerciseTypeById(item) {
            return $http({
                method: 'POST',
                url: app.exercisetypeApibaseUrl + 'api/exercisetype/getbyid',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }

        function createExerciseType(item) {
            return $http({
                method: 'POST',
                url: app.exercisetypeApibaseUrl + 'api/exercisetype/add',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }

        function updateExerciseType(item) {
            return $http({
                method: 'POST',
                url: app.exercisetypeApibaseUrl + 'api/exercisetype/update',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }

        function deleteExerciseType(item) {
            return $http({
                method: 'POST',
                url: app.exercisetypeApibaseUrl + 'api/exercisetype/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }

    }
})(angular, app);
