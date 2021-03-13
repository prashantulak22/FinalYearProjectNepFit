
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisepackageroutineAddCtrl', exercisepackageroutineAddCtrl);
    exercisepackageroutineAddCtrl.$inject = ['exercisePackageRoutineService', "$uibModalInstance", '$scope', 'blockUI'];
    function exercisepackageroutineAddCtrl(exercisePackageRoutineService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExercisePackageRoutine';
        
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
              
                    ExercisePackageRoutineId: "",
                    ExercisePackageId: "",
                    ExerciseRoutineId: "",
                                
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

