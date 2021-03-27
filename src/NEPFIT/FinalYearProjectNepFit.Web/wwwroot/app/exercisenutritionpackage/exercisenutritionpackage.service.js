
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('exerciseNutritionPackageService', exerciseNutritionPackageService);

    exerciseNutritionPackageService.$inject = ['$http'];

    function exerciseNutritionPackageService($http) {
        var service = {
            getAllExerciseNutritionPackage: getAllExerciseNutritionPackage,
            getAllExerciseNutritionPackageById: getAllExerciseNutritionPackageById,
            updateExerciseNutritionPackage: updateExerciseNutritionPackage,
            createExerciseNutritionPackage: createExerciseNutritionPackage,
            deleteExerciseNutritionPackage: deleteExerciseNutritionPackage,
        };

        return service;

 
        function  getAllExerciseNutritionPackage() {
            
                return $http({
                    method: 'GET',
                    url:'api/exercisenutritionpackage/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
           
        }
        
        function  getAllExerciseNutritionPackageById(item) {
            
                return $http({
                    method: 'POST',
                    url:'api/exercisenutritionpackage/getbyid',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
           
        }

        function  createExerciseNutritionPackage(item) {
            
                return $http({
                    method: 'POST',
                    url:'api/exercisenutritionpackage/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }
        
       function  updateExerciseNutritionPackage(item) {
           
                return $http({
                    method: 'POST',
                    url: 'api/exercisenutritionpackage/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
           
       }
        function deleteExerciseNutritionPackage(item) {
            return $http({
                method: 'POST',
                url: '/api/exercisenutritionpackage/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }


        
        
    }
})(angular, app);
