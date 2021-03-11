
(function (angular ) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritiontypeDeleteCtrl', nutritiontypeDeleteCtrl);
    nutritiontypeDeleteCtrl.$inject = ['nutritionTypeService',  "$uibModalInstance", '$scope', 'param'];
    function nutritiontypeDeleteCtrl(nutritionTypeService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.nutritionType = param.item;
                 vm.deleteNutritionType = function (item) {
                nutritionTypeService.deleteNutritionType(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

