
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisepackageEditCtrl', exercisepackageEditCtrl);
    exercisepackageEditCtrl.$inject = ['exercisePackageService',  "$uibModalInstance", '$scope', 'param'];
    function exercisepackageEditCtrl(exercisePackageService,  $uibModalInstance, $scope, param) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit ExercisePackage';
        activate();
        function showLoading() {
            App.blockUI({
                target: '#exercisepackageList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exercisepackageList');
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
        



})(angular, $, kendo, App);

