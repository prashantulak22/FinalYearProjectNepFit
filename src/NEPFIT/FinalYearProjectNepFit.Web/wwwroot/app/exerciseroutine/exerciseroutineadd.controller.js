
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exerciseroutineAddCtrl', exerciseroutineAddCtrl);
    exerciseroutineAddCtrl.$inject = ['exerciseRoutineService', "$uibModalInstance", '$scope', 'blockUI'];
    function exerciseroutineAddCtrl(exerciseRoutineService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExerciseRoutine';
        
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
              
                    
                    Name: "",
                    Description: "",
                    Repetition: 5,
                    Duration: 0,
                              
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

