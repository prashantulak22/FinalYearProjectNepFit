
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisetypeEditCtrl', exercisetypeEditCtrl);
    exercisetypeEditCtrl.$inject = ['exerciseTypeService', "$uibModalInstance", '$scope', 'param','blockUI'];
    function exercisetypeEditCtrl(exerciseTypeService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
        vm.isNew = false;
        
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {

            vm.exerciseType = param.item;
            vm.validationError = [];

            function validateForm() {
                vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
            }

            vm.saveExerciseType = function (option) {
                if (!validateForm()) return;
                showLoading();
                exerciseTypeService.updateExerciseType(vm.exerciseType)
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

