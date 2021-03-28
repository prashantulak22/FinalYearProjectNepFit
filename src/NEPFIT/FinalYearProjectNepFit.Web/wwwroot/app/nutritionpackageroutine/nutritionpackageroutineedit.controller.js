
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageroutineEditCtrl', nutritionpackageroutineEditCtrl);
    nutritionpackageroutineEditCtrl.$inject = ['nutritionPackageRoutineService', "$uibModalInstance", '$scope', 'param', 'blockUI', 'nutritionPackageService', 'nutritionRoutineService'];
    function nutritionpackageroutineEditCtrl(nutritionPackageRoutineService, $uibModalInstance, $scope, param, blockUI, nutritionPackageService, nutritionRoutineService) {
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
            vm.nutritionPackageRoutine = param.item
            nutritionPackageService.getAllNutritionPackage()
                .then(function (result) {
                    vm.nutritionPackageIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "nutritionPackageId",
                        valuePrimitive: true,
                        value: vm.nutritionPackageRoutine.nutritionPackageId,
                        dataSource: {
                            data: result.data
                        }
                    }

                });

            vm.nutritionPackageRoutine = param.item
            nutritionRoutineService.getAllNutritionRoutine()
                .then(function (result) {
                    vm.nutritionRoutineIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "nutritionRoutineId",
                        valuePrimitive: true,
                        value: vm.nutritionPackageRoutine.nutritionRoutineId,
                        dataSource: {
                            data: result.data
                        }
                    }

                });
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

