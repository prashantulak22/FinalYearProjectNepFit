
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exerciseroutineAddCtrl', exerciseroutineAddCtrl);
    exerciseroutineAddCtrl.$inject = ['exerciseRoutineService', "$uibModalInstance", '$scope', 'blockUI', 'exerciseTypeService'];
    function exerciseroutineAddCtrl(exerciseRoutineService, $uibModalInstance, $scope, blockUI, exerciseTypeService) {
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
            exerciseTypeService.getAllExerciseType()
                .then(function (result) {
                    vm.exerciseTypeIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exerciseTypeId",
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }

                });

            function initialize() {
                return {

                    name: "",
                    description: "",
                    repetition: 5,
                    duration: 1,
                    exerciseTypeId: "",
                    gender: "M",

                };
            }
            vm.exerciseRoutine = initialize();
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
                exerciseRoutineService.createExerciseRoutine(vm.exerciseRoutine)
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

