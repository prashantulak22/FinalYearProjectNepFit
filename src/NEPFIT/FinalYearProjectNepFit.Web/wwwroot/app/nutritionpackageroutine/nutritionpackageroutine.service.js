
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('nutritionPackageRoutineService', nutritionPackageRoutineService);

    nutritionPackageRoutineService.$inject = ['$http'];

    function nutritionPackageRoutineService($http) {
        var service = {
            getAllNutritionPackageRoutine: getAllNutritionPackageRoutine,
            getAllNutritionPackageRoutineById: getAllNutritionPackageRoutineById,
            updateNutritionPackageRoutine: updateNutritionPackageRoutine,
            deleteNutritionPackageRoutine: deleteNutritionPackageRoutine,
            createNutritionPackageRoutine: createNutritionPackageRoutine,
        };

        return service;

 
        function  getAllNutritionPackageRoutine() {
            
                return $http({
                    method: 'GET',
                    url: 'api/nutritionpackageroutine/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
        function  getAllNutritionPackageRoutineById(item) {
           
                return $http({
                    method: 'POST',
                    url:'api/nutritionpackageroutine/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }

        function  createNutritionPackageRoutine(item) {
            
                return $http({
                    method: 'POST',
                    url:'api/nutritionpackageroutine/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
       function  updateNutritionPackageRoutine(item) {
            
                return $http({
                    method: 'POST',
                    url:  'api/nutritionpackageroutine/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
       }

        function deleteNutritionPackageRoutine(item) {
            return $http({
                method: 'POST',
                url: '/api/nutritionpackageroutine/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
