
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisepackageAddCtrl', exercisepackageAddCtrl);
    exercisepackageAddCtrl.$inject = ['exercisePackageService', "$uibModalInstance", '$scope' 'blockUI'];
    function exercisepackageAddCtrl(exercisePackageService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExercisePackage';
        
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
              
                    
                    name: "",
                    description: "",
             
                               
            };
            }
             vm.exercisePackage = initialize();
     vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                  if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
                vm.saveExercisePackage = function (option) {
            if (!validateForm()) return;
           showLoading();
            exercisePackageService.createExercisePackage(vm.exercisePackage)
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

