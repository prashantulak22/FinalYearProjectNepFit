
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisetypeAddCtrl', exercisetypeAddCtrl);
    exercisetypeAddCtrl.$inject = ['exerciseTypeService', "$uibModalInstance", '$scope', 'blockUI'];
    function exercisetypeAddCtrl(exerciseTypeService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
       

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
                    description: ""
                };
            }
            vm.exerciseType = initialize();
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
                exerciseTypeService.createExerciseType(vm.exerciseType)
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

