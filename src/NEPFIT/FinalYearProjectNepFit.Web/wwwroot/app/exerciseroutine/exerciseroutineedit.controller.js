
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exerciseroutineEditCtrl', exerciseroutineEditCtrl);
    exerciseroutineEditCtrl.$inject = ['exerciseRoutineService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function exerciseroutineEditCtrl(exerciseRoutineService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit ExerciseRoutine';
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
       
             vm.exerciseRoutine = param.item;
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

