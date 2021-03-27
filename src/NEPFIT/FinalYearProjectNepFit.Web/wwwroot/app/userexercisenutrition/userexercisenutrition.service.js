
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('userExerciseNutritionService', userExerciseNutritionService);

    userExerciseNutritionService.$inject = ['$http'];

    function userExerciseNutritionService($http) {
        var service = {
            getAllUserExerciseNutrition: getAllUserExerciseNutrition,
            getAllUserExerciseNutritionById: getAllUserExerciseNutritionById,
            updateUserExerciseNutrition: updateUserExerciseNutrition,
            createUserExerciseNutrition: createUserExerciseNutrition,
            deleteUserExerciseNutrition: deleteUserExerciseNutrition,
        };

        return service;

 
        function  getAllUserExerciseNutrition() {
            
                return $http({
                    method: 'GET',
                    url: 'api/userexercisenutrition/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
        function  getAllUserExerciseNutritionById(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/userexercisenutrition/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }

        function  createUserExerciseNutrition(item) {
           
                return $http({
                    method: 'POST',
                    url: 'api/userexercisenutrition/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
       function  updateUserExerciseNutrition(item) {
           
                return $http({
                    method: 'POST',
                    url: 'api/userexercisenutrition/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
       }

        function deleteUserExerciseNutrition(item) {
            return $http({
                method: 'POST',
                url: '/api/userexercisenutrition/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
