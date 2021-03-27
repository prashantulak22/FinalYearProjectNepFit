
(function (angular, app) {
    angular
        .module('tableapp')
        .factory('exerciseNutritionPackageService', exerciseNutritionPackageService);

    exerciseNutritionPackageService.$inject = ['$http', 'tokenService', '$q'];

    function exerciseNutritionPackageService($http, tokenService, $q) {
        var service = {
            getAllExerciseNutritionPackage: getAllExerciseNutritionPackage,
            getAllExerciseNutritionPackageById: getAllExerciseNutritionPackageById,
            updateExerciseNutritionPackage: updateExerciseNutritionPackage,
            createExerciseNutritionPackage: createExerciseNutritionPackage,
        };

        return service;

 
        function  getAllExerciseNutritionPackage() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url: app.exercisenutritionpackageApibaseUrl + 'api/exercisenutritionpackage/getall',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        function  getAllExerciseNutritionPackageById(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisenutritionpackageApibaseUrl + 'api/exercisenutritionpackage/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }

        function  createExerciseNutritionPackage(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisenutritionpackageApibaseUrl + 'api/exercisenutritionpackage/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
       function  updateExerciseNutritionPackage(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.exercisenutritionpackageApibaseUrl + 'api/exercisenutritionpackage/update',
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
