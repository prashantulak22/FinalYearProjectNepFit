
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('exercisepackageEditCtrl', exercisepackageEditCtrl);
    exercisepackageEditCtrl.$inject = ['exercisePackageService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function exercisepackageEditCtrl(exercisePackageService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
                vm.isNew = false;
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
       
             vm.exercisePackage = param.item;
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
            exercisePackageService.updateExercisePackage(vm.exercisePackage)
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

