
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exerciseroutineEditCtrl', exerciseroutineEditCtrl);
    exerciseroutineEditCtrl.$inject = ['exerciseRoutineService', "$uibModalInstance", '$scope', 'param', 'blockUI', 'exerciseTypeService'];
    function exerciseroutineEditCtrl(exerciseRoutineService, $uibModalInstance, $scope, param, blockUI, exerciseTypeService) {
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
            vm.exerciseRoutine = param.item;
            exerciseTypeService.getAllExerciseType()
                .then(function (result) {
                    vm.exerciseTypeIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exerciseTypeId",
                        valuePrimitive: true,
                        value: vm.exerciseRoutine.exerciseTypeId,
                        dataSource: {

                            data: result.data

                        }

                    }
                    vm.exerciseRoutine = param.item;

                });




            vm.validationError = [];

            function validateForm() {
                vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
            }

            vm.saveExerciseRoutine = function (option) {
                if (!validateForm()) return;
                showLoading();
                exerciseRoutineService.updateExerciseRoutine(vm.exerciseRoutine)
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

