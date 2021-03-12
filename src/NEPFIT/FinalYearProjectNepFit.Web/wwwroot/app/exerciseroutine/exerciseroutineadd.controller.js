
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exerciseroutineAddCtrl', exerciseroutineAddCtrl);
    exerciseroutineAddCtrl.$inject = ['exerciseRoutineService',  "$uibModalInstance", '$scope'];
    function exerciseroutineAddCtrl(exerciseRoutineService,  $uibModalInstance, $scope) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExerciseRoutine';
        
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
       
        
                function initialize() {
            return {
              
                    ExerciseRoutineId: "",
                    Name: "",
                    Description: "",
                    Repetition: 0,
                    Duration: 0,
                    ExerciseTypeId: "",
                    Active: "",
                    UpdatedBy: "",
                    CreatedBy: "",            
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
        



})(angular, $, kendo, App);

