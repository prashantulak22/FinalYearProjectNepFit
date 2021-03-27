
(function (angular ) {
    'use strict';

    angular
        .module('tableapp')
        .controller('userexercisenutritionDeleteCtrl', userexercisenutritionDeleteCtrl);
    userexercisenutritionDeleteCtrl.$inject = ['userExerciseNutritionService',  "$uibModalInstance", '$scope', 'param'];
    function userexercisenutritionDeleteCtrl(userExerciseNutritionService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.userExerciseNutrition = param.item;
                 vm.deleteUserExerciseNutrition = function (item) {
                userExerciseNutritionService.deleteUserExerciseNutrition(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

