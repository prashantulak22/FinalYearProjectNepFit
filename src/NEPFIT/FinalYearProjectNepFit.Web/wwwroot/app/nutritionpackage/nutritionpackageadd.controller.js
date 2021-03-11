
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageAddCtrl', nutritionpackageAddCtrl);
    nutritionpackageAddCtrl.$inject = ['nutritionPackageService', "$uibModalInstance", '$scope', 'blockUI'];
    function nutritionpackageAddCtrl(nutritionPackageService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add NutritionPackage';
        
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
                    description: "",
                             
            };
            }
             vm.nutritionPackage = initialize();
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
            nutritionPackageService.createNutritionPackage(vm.nutritionPackage)
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

