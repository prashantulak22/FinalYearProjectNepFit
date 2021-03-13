
(function (angular ) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisepackageroutineDeleteCtrl', exercisepackageroutineDeleteCtrl);
    exercisepackageroutineDeleteCtrl.$inject = ['exercisePackageRoutineService',  "$uibModalInstance", '$scope', 'param'];
    function exercisepackageroutineDeleteCtrl(exercisePackageRoutineService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.exercisePackageRoutine = param.item;
                 vm.deleteExercisePackageRoutine = function (item) {
                exercisePackageRoutineService.deleteExercisePackageRoutine(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

