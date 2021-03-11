
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('nutritionTypeService', nutritionTypeService);

    nutritionTypeService.$inject = ['$http'];

    function nutritionTypeService($http) {
        var service = {
            getAllNutritionType: getAllNutritionType,
            getAllNutritionTypeById: getAllNutritionTypeById,
            updateNutritionType: updateNutritionType,
            deleteNutritionType: deleteNutritionType,
            createNutritionType: createNutritionType,
        };

        return service;

 
        function  getAllNutritionType() {
            
                return $http({
                    method: 'GET',
                    url:'api/nutritiontype/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
        function  getAllNutritionTypeById(item) {
            
                return $http({
                    method: 'POST',
                    url:'api/nutritiontype/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }

        function  createNutritionType(item) {
            
                return $http({
                    method: 'POST',
                    url:'api/nutritiontype/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
       function  updateNutritionType(item) {
            
                return $http({
                    method: 'POST',
                    url:'api/nutritiontype/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
       }
        function deleteNutritionType(item) {
            return $http({
                method: 'POST',
                url: '/api/nutritiontype/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
