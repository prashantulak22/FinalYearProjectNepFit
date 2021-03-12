
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('nutritionRoutineService', nutritionRoutineService);

    nutritionRoutineService.$inject = ['$http'];

    function nutritionRoutineService($http) {
        var service = {
            getAllNutritionRoutine: getAllNutritionRoutine,
            getAllNutritionRoutineById: getAllNutritionRoutineById,
            updateNutritionRoutine: updateNutritionRoutine,
            deleteNutritionRoutine: deleteNutritionRoutine,
            createNutritionRoutine: createNutritionRoutine,
        };

        return service;

 
        function  getAllNutritionRoutine() {
            
                return $http({
                    method: 'GET',
                    url: 'api/nutritionroutine/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
        function  getAllNutritionRoutineById(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/nutritionroutine/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }

        function  createNutritionRoutine(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/nutritionroutine/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
       function  updateNutritionRoutine(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/nutritionroutine/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
       }

        function deleteNutritionRoutine(item) {
            return $http({
                method: 'POST',
                url: '/api/nutritionroutine/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
