
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exerciseroutineEditCtrl', exerciseroutineEditCtrl);
    exerciseroutineEditCtrl.$inject = ['exerciseRoutineService',  "$uibModalInstance", '$scope', 'param'];
    function exerciseroutineEditCtrl(exerciseRoutineService,  $uibModalInstance, $scope, param) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit ExerciseRoutine';
        activate();
        function showLoading() {
            App.blockUI({
                target: '#exerciseroutineList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exerciseroutineList');
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
        



})(angular, $, kendo, App);

