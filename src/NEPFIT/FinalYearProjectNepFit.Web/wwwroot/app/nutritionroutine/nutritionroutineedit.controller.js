
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionroutineEditCtrl', nutritionroutineEditCtrl);
    nutritionroutineEditCtrl.$inject = ['nutritionRoutineService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function nutritionroutineEditCtrl(nutritionRoutineService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit NutritionRoutine';
        activate();

        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }

        function activate() {
       
             vm.nutritionRoutine = param.item;
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
            nutritionRoutineService.updateNutritionRoutine(vm.nutritionRoutine)
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

