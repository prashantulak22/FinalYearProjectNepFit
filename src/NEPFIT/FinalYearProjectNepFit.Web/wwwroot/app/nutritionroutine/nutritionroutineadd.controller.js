
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionroutineAddCtrl', nutritionroutineAddCtrl);
    nutritionroutineAddCtrl.$inject = ['nutritionRoutineService', "$uibModalInstance", '$scope', 'blockUI','nutritionTypeService'];
    function nutritionroutineAddCtrl(nutritionRoutineService, $uibModalInstance, $scope, blockUI, nutritionTypeService) {
        var vm = this;
        vm.isNew = true;
        
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
            nutritionTypeService.getAllNutritionType()
                .then(function (result) {
                    vm.nutritionTypeIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "nutritionTypeId",
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }
                });
       
        
                function initialize() {
            return {
              
                   
                    name: "",
                    description: "",
                howToPrepare: "",
                foodCategory: "N",
                    nutritionTypeId: "",            
            };
            }
             vm.nutritionRoutine = initialize();
     vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                  if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
                vm.saveNutritionRoutine = function (option) {
            if (!validateForm()) return;
           showLoading();
            nutritionRoutineService.createNutritionRoutine(vm.nutritionRoutine)
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

