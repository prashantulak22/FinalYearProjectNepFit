
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('nutritionpackageroutineAddCtrl', nutritionpackageroutineAddCtrl);
    nutritionpackageroutineAddCtrl.$inject = ['nutritionPackageRoutineService',  "$uibModalInstance", '$scope'];
    function nutritionpackageroutineAddCtrl(nutritionPackageRoutineService,  $uibModalInstance, $scope) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add NutritionPackageRoutine';
        
        activate();
        function showLoading() {
            App.blockUI({
                target: '#nutritionpackageroutineList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#nutritionpackageroutineList');
        }
        function activate() {
       
        
                function initialize() {
            return {
              
                    NutritionPackageRoutineId: "",
                    NutritionPackageId: "",
                    NutritionRoutineId: "",
                    Active: "",
                    UpdatedBy: "",
                    CreatedBy: "",            
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
        



})(angular, $, kendo, App);

