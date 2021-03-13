
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageroutineAddCtrl', nutritionpackageroutineAddCtrl);
    nutritionpackageroutineAddCtrl.$inject = ['nutritionPackageRoutineService', "$uibModalInstance", '$scope', 'blockUI'];
    function nutritionpackageroutineAddCtrl(nutritionPackageRoutineService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add NutritionPackageRoutine';
        
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
              
                    NutritionPackageRoutineId: "",
                    NutritionPackageId: "",
                    NutritionRoutineId: "",
                                
            };
            }
             vm.nutritionPackageRoutine = initialize();
     vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                  if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
                vm.saveNutritionPackageRoutine = function (option) {
            if (!validateForm()) return;
           showLoading();
            nutritionPackageRoutineService.createNutritionPackageRoutine(vm.nutritionPackageRoutine)
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

