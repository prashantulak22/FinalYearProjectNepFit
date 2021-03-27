
(function (angular ) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisenutritionpackageDeleteCtrl', exercisenutritionpackageDeleteCtrl);
    exercisenutritionpackageDeleteCtrl.$inject = ['exerciseNutritionPackageService',  "$uibModalInstance", '$scope', 'param'];
    function exercisenutritionpackageDeleteCtrl(exerciseNutritionPackageService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.exerciseNutritionPackage = param.item;
                 vm.deleteExerciseNutritionPackage = function (item) {
                exerciseNutritionPackageService.deleteExerciseNutritionPackage(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

