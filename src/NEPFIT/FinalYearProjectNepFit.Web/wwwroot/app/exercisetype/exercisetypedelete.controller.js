
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisetypeDeleteCtrl', exercisetypeDeleteCtrl);
    exercisetypeDeleteCtrl.$inject = ['exerciseTypeService', "$uibModalInstance", '$scope', 'param'];
    function exercisetypeDeleteCtrl(exerciseTypeService, $uibModalInstance, $scope, param) {
        var vm = this;
        activate();

        function activate() {
            vm.exerciseType = param.item;
            vm.deleteExerciseType = function (item) {
                exerciseTypeService.deleteExerciseType(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
            vm.close = function () {
                $uibModalInstance.close();
            };


        }


    }




})(angular);

