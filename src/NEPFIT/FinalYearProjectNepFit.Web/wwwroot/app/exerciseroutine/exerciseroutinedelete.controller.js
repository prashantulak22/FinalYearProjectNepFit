
(function (angular ) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exerciseroutineDeleteCtrl', exerciseroutineDeleteCtrl);
    exerciseroutineDeleteCtrl.$inject = ['exerciseRoutineService',  "$uibModalInstance", '$scope', 'param'];
    function exerciseroutineDeleteCtrl(exerciseRoutineService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.exerciseRoutine = param.item;
                 vm.deleteExerciseRoutine = function (item) {
                exerciseRoutineService.deleteExerciseRoutine(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

