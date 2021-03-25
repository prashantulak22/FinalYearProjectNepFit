
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageroutineAddCtrl', nutritionpackageroutineAddCtrl);
    nutritionpackageroutineAddCtrl.$inject = ['nutritionPackageRoutineService', "$uibModalInstance", '$scope', 'blockUI', 'nutritionPackageService', 'nutritionRoutineService'];
    function nutritionpackageroutineAddCtrl(nutritionPackageRoutineService, $uibModalInstance, $scope, blockUI, nutritionPackageService, nutritionRoutineService) {
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

            nutritionPackageService.getAllNutritionPackage()
                .then(function (result) {
                    vm.nutritionPackageIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "nutritionPackageId",
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }

                });

            nutritionRoutineService.getAllNutritionRoutine()
                .then(function (result) {
                    vm.nutritionRoutineIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "nutritionRoutineId",
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }

                });

       
        
                function initialize() {
            return {
              
                    nutritionPackageRoutineId: "",
                    nutritionPackageId: "",
                    nutritionRoutineId: "",
                                
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

