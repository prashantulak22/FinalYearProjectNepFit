
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritiontypeEditCtrl', nutritiontypeEditCtrl);
    nutritiontypeEditCtrl.$inject = ['nutritionTypeService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function nutritiontypeEditCtrl(nutritionTypeService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit NutritionType';
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
       
             vm.nutritionType = param.item;
          vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
  vm.saveNutritionType = function (option) {
            if (!validateForm()) return;
           showLoading();
            nutritionTypeService.updateNutritionType(vm.nutritionType)
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

