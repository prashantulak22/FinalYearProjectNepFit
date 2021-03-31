
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageEditCtrl', nutritionpackageEditCtrl);
    nutritionpackageEditCtrl.$inject = ['nutritionPackageService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function nutritionpackageEditCtrl(nutritionPackageService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
                vm.isNew = false;
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
       
             vm.nutritionPackage = param.item;
          vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
  vm.saveNutritionPackage = function (option) {
            if (!validateForm()) return;
           showLoading();
            nutritionPackageService.updateNutritionPackage(vm.nutritionPackage)
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

