
(function (angular, app) {
    angular
        .module('tableapp')
        .factory('nutritionPackageRoutineService', nutritionPackageRoutineService);

    nutritionPackageRoutineService.$inject = ['$http', 'tokenService', '$q'];

    function nutritionPackageRoutineService($http, tokenService, $q) {
        var service = {
            getAllNutritionPackageRoutine: getAllNutritionPackageRoutine,
            getAllNutritionPackageRoutineById: getAllNutritionPackageRoutineById,
            updateNutritionPackageRoutine: updateNutritionPackageRoutine,
            createNutritionPackageRoutine: createNutritionPackageRoutine,
        };

        return service;

 
        function  getAllNutritionPackageRoutine() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url: app.nutritionpackageroutineApibaseUrl + 'api/nutritionpackageroutine/getall',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        function  getAllNutritionPackageRoutineById(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.nutritionpackageroutineApibaseUrl + 'api/nutritionpackageroutine/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }

        function  createNutritionPackageRoutine(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.nutritionpackageroutineApibaseUrl + 'api/nutritionpackageroutine/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
       function  updateNutritionPackageRoutine(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url: app.nutritionpackageroutineApibaseUrl + 'api/nutritionpackageroutine/update',
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
