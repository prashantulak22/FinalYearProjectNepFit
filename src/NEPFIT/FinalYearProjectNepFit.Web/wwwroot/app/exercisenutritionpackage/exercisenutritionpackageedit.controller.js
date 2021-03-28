
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisenutritionpackageEditCtrl', exercisenutritionpackageEditCtrl);
    exercisenutritionpackageEditCtrl.$inject = ['exerciseNutritionPackageService', "$uibModalInstance", '$scope', 'param', 'blockUI', 'exercisePackageService', 'nutritionPackageService'];
    function exercisenutritionpackageEditCtrl(exerciseNutritionPackageService, $uibModalInstance, $scope, param, blockUI, exercisePackageService, nutritionPackageService ) {
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
            exercisePackageService.getAllExercisePackage()
                .then(function (result) {
                    vm.exercisePackageIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exercisePackageId",
                        valuePrimitive: true,
                        value: vm.exerciseNutritionPackage.exercisePackageId,
                        dataSource: {
                            data: result.data
                        }
                    }
                    vm.exerciseNutritionPackage = param.item;

                });

            vm.exerciseNutritionPackage = param.item;
            nutritionPackageService.getAllNutritionPackage()
                .then(function (result) {
                    vm.nutritionPackageIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "nutritionPackageId",
                        valuePrimitive: true,
                        value: vm.exerciseNutritionPackage.nutritionPackageId,
                        dataSource: {
                            data: result.data
                        }
                    }
                    vm.exerciseNutritionPackage = param.item;

                });
       
             
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

