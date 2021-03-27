
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisenutritionpackageAddCtrl', exercisenutritionpackageAddCtrl);
    exercisenutritionpackageAddCtrl.$inject = ['exerciseNutritionPackageService', "$uibModalInstance", '$scope', 'blockUI'];
    function exercisenutritionpackageAddCtrl(exerciseNutritionPackageService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExerciseNutritionPackage';
        
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }

        function activate() {
       
        
                function initialize() {
            return {
              
                    exerciseNutritionPackageId: "",
                    exercisePackageId: "",
                    nutritionPackageId: "",
                                
            };
            }
             vm.exerciseNutritionPackage = initialize();
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
            exerciseNutritionPackageService.createExerciseNutritionPackage(vm.exerciseNutritionPackage)
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

