
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisenutritionpackageEditCtrl', exercisenutritionpackageEditCtrl);
    exercisenutritionpackageEditCtrl.$inject = ['exerciseNutritionPackageService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function exercisenutritionpackageEditCtrl(exerciseNutritionPackageService, $uibModalInstance, $scope, param, blockUI ) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit ExerciseNutritionPackage';
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
       
             vm.exerciseNutritionPackage = param.item;
          vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
  vm.saveExerciseNutritionPackage = function (option) {
            if (!validateForm()) return;
           showLoading();
            exerciseNutritionPackageService.updateExerciseNutritionPackage(vm.exerciseNutritionPackage)
                .then(function () {
                    hideLoading();
                      vm.close();
                }, function errorCallback(response) {
                    hideLoading();
                    });
        }
        
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        
        }
             
 
        }
        



})(angular, $, kendo);

