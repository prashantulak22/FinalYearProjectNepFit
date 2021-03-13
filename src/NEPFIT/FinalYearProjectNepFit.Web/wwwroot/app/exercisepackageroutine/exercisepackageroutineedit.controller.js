
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisepackageroutineEditCtrl', exercisepackageroutineEditCtrl);
    exercisepackageroutineEditCtrl.$inject = ['exercisePackageRoutineService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function exercisepackageroutineEditCtrl(exercisePackageRoutineService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit ExercisePackageRoutine';
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
       
             vm.exercisePackageRoutine = param.item;
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

