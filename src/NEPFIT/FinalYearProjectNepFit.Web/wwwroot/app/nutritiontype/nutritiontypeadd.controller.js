
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritiontypeAddCtrl', nutritiontypeAddCtrl);
    nutritiontypeAddCtrl.$inject = ['nutritionTypeService', "$uibModalInstance", '$scope', 'blockUI'];
    function nutritiontypeAddCtrl(nutritionTypeService, $uibModalInstance, $scope, blockUI) {
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
       
        
                function initialize() {
            return {
              
                    
                    name: "",
                    description: ""
                                
            };
            }
             vm.nutritionType = initialize();
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
            nutritionTypeService.createNutritionType(vm.nutritionType)
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

