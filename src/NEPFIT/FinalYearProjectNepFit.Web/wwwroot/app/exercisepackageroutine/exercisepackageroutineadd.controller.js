
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisepackageroutineAddCtrl', exercisepackageroutineAddCtrl);
    exercisepackageroutineAddCtrl.$inject = ['exercisePackageRoutineService',  "$uibModalInstance", '$scope'];
    function exercisepackageroutineAddCtrl(exercisePackageRoutineService,  $uibModalInstance, $scope) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExercisePackageRoutine';
        
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
       
        
                function initialize() {
            return {
              
                    ExercisePackageRoutineId: "",
                    ExercisePackageId: "",
                    ExerciseRoutineId: "",
                    Active: "",
                    UpdatedBy: "",
                    CreatedBy: "",            
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
        



})(angular, $, kendo, App);

