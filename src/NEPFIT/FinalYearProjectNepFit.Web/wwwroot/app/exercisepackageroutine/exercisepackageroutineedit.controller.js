
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisepackageroutineEditCtrl', exercisepackageroutineEditCtrl);
    exercisepackageroutineEditCtrl.$inject = ['exercisePackageRoutineService',  "$uibModalInstance", '$scope', 'param'];
    function exercisepackageroutineEditCtrl(exercisePackageRoutineService,  $uibModalInstance, $scope, param) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit ExercisePackageRoutine';
        activate();
        function showLoading() {
            App.blockUI({
                target: '#exercisepackageroutineList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exercisepackageroutineList');
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
        



})(angular, $, kendo, App);

