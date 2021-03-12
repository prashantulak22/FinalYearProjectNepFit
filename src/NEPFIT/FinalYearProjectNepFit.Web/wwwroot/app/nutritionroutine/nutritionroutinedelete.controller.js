
(function (angular ) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionroutineDeleteCtrl', nutritionroutineDeleteCtrl);
    nutritionroutineDeleteCtrl.$inject = ['nutritionRoutineService',  "$uibModalInstance", '$scope', 'param'];
    function nutritionroutineDeleteCtrl(nutritionRoutineService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.nutritionRoutine = param.item;
                 vm.deleteNutritionRoutine = function (item) {
                nutritionRoutineService.deleteNutritionRoutine(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

