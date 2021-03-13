
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageroutineEditCtrl', nutritionpackageroutineEditCtrl);
    nutritionpackageroutineEditCtrl.$inject = ['nutritionPackageRoutineService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function nutritionpackageroutineEditCtrl(nutritionPackageRoutineService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit NutritionPackageRoutine';
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
       
             vm.nutritionPackageRoutine = param.item;
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
            nutritionPackageRoutineService.updateNutritionPackageRoutine(vm.nutritionPackageRoutine)
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

