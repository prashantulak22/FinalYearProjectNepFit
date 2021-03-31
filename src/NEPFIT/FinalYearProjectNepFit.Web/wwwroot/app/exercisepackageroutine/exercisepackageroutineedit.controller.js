
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisepackageroutineEditCtrl', exercisepackageroutineEditCtrl);
    exercisepackageroutineEditCtrl.$inject = ['exercisePackageRoutineService', "$uibModalInstance", '$scope', 'param', 'blockUI', 'exercisePackageService', 'exerciseRoutineService'];
    function exercisepackageroutineEditCtrl(exercisePackageRoutineService, $uibModalInstance, $scope, param, blockUI, exercisePackageService, exerciseRoutineService) {
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
            vm.exercisePackageRoutine = param.item;
            exercisePackageService.getAllExercisePackage()
                .then(function (result) {
                    vm.exercisePackageIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exercisePackageId",
                        valuePrimitive: true,
                        value: vm.exercisePackageRoutine.exercisePackageId,
                        dataSource: {
                            data: result.data
                        }
                    }
                    vm.exercisePackageRoutine = param.item;

                });
            vm.exercisePackageRoutine = param.item;
            exerciseRoutineService.getAllExerciseRoutine()
                .then(function (result) {
                    vm.exerciseRoutineIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exerciseRoutineId",
                        value: vm.exercisePackageRoutine.exerciseRoutineId,
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }
                    vm.exercisePackageRoutine = param.item;
                });
             vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
  vm.saveExercisePackageRoutine = function (option) {
            if (!validateForm()) return;
           showLoading();
            exercisePackageRoutineService.updateExercisePackageRoutine(vm.exercisePackageRoutine)
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

