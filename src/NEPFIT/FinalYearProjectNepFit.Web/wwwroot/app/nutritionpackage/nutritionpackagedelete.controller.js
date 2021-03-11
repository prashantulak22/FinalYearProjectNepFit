
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageDeleteCtrl', nutritionpackageDeleteCtrl);
    nutritionpackageDeleteCtrl.$inject = ['nutritionPackageService',  "$uibModalInstance", '$scope', 'param'];
    function nutritionpackageDeleteCtrl(nutritionPackageService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.nutritionPackage = param.item;
                 vm.deleteNutritionPackage = function (item) {
                nutritionPackageService.deleteNutritionPackage(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

