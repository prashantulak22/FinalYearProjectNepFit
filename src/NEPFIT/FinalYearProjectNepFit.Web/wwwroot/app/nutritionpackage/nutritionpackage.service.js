
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('nutritionPackageService', nutritionPackageService);

    nutritionPackageService.$inject = ['$http'];

    function nutritionPackageService($http, tokenService, $q) {
        var service = {
            getAllNutritionPackage: getAllNutritionPackage,
            getAllNutritionPackageById: getAllNutritionPackageById,
            updateNutritionPackage: updateNutritionPackage,
            deleteNutritionPackage: deleteNutritionPackage,
            createNutritionPackage: createNutritionPackage,
        };

        return service;

 
        function  getAllNutritionPackage() {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'GET',
                    url:'api/nutritionpackage/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
        function  getAllNutritionPackageById(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url:'api/nutritionpackage/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }

        function  createNutritionPackage(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url:'api/nutritionpackage/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            }
            );
        }
        
       function  updateNutritionPackage(item) {
            return tokenService.getToken().then(function () {
                return $http({
                    method: 'POST',
                    url:'api/nutritionpackage/update',
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
                method: 'POST',
                url: '/api/nutritionpackage/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
