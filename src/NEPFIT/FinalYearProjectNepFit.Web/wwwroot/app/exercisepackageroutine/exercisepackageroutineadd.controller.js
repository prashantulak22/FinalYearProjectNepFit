
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisepackageroutineAddCtrl', exercisepackageroutineAddCtrl);
    exercisepackageroutineAddCtrl.$inject = ['exercisePackageRoutineService', "$uibModalInstance", '$scope', 'blockUI', 'exercisePackageService', 'exerciseRoutineService'];
    function exercisepackageroutineAddCtrl(exercisePackageRoutineService, $uibModalInstance, $scope, blockUI, exercisePackageService, exerciseRoutineService) {
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
            exercisePackageService.getAllExercisePackage()
                .then(function (result) {
                    vm.exercisePackageIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exercisePackageId",
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }

                });

            exerciseRoutineService.getAllExerciseRoutine()
                .then(function (result) {
                    vm.exerciseRoutineIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exerciseRoutineId",
                        valuePrimitive: true,
                        dataSource: {
                            data: result.data
                        }
                    }

                });
       
        
                function initialize() {
            return {
              
                    exercisePackageRoutineId: "",
                    exercisePackageId: "",
                    exerciseRoutineId: "",
                                
            };
            }
             vm.exercisePackageRoutine = initialize();
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
            exercisePackageRoutineService.createExercisePackageRoutine(vm.exercisePackageRoutine)
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

