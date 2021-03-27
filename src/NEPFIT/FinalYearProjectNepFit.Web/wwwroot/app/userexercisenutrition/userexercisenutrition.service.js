
(function (angular, app) {
    angular
        .module('tableapp')
        .factory('userExerciseNutritionService', userExerciseNutritionService);

    userExerciseNutritionService.$inject = ['$http', 'tokenService', '$q'];

    function userExerciseNutritionService($http, tokenService, $q) {
        var service = {
            getAllUserExerciseNutrition: getAllUserExerciseNutrition,
            getAllUserExerciseNutritionById: getAllUserExerciseNutritionById,
            updateUserExerciseNutrition: updateUserExerciseNutrition,
            createUserExerciseNutrition: createUserExerciseNutrition,
        };

        return service;

 
        function  getAllUserExerciseNutrition() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url: app.userexercisenutritionApibaseUrl + 'api/userexercisenutrition/getall',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        function  getAllUserExerciseNutritionById(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.userexercisenutritionApibaseUrl + 'api/userexercisenutrition/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }

        function  createUserExerciseNutrition(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.userexercisenutritionApibaseUrl + 'api/userexercisenutrition/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
       function  updateUserExerciseNutrition(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.userexercisenutritionApibaseUrl + 'api/userexercisenutrition/update',
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
