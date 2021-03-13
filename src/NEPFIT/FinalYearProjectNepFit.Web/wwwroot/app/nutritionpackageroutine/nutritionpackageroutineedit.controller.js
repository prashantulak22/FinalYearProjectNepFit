
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('nutritionpackageroutineEditCtrl', nutritionpackageroutineEditCtrl);
    nutritionpackageroutineEditCtrl.$inject = ['nutritionPackageRoutineService',  "$uibModalInstance", '$scope', 'param'];
    function nutritionpackageroutineEditCtrl(nutritionPackageRoutineService,  $uibModalInstance, $scope, param) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit NutritionPackageRoutine';
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
        



})(angular, $, kendo, App);

