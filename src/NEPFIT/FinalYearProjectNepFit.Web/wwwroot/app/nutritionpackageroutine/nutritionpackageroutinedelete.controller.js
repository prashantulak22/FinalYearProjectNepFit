
(function (angular ) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionpackageroutineDeleteCtrl', nutritionpackageroutineDeleteCtrl);
    nutritionpackageroutineDeleteCtrl.$inject = ['nutritionPackageRoutineService',  "$uibModalInstance", '$scope', 'param'];
    function nutritionpackageroutineDeleteCtrl(nutritionPackageRoutineService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.nutritionPackageRoutine = param.item;
                 vm.deleteNutritionPackageRoutine = function (item) {
                nutritionPackageRoutineService.deleteNutritionPackageRoutine(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

