
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisenutritionpackageEditCtrl', exercisenutritionpackageEditCtrl);
    exercisenutritionpackageEditCtrl.$inject = ['exerciseNutritionPackageService',  "$uibModalInstance", '$scope', 'param'];
    function exercisenutritionpackageEditCtrl(exerciseNutritionPackageService,  $uibModalInstance, $scope, param) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit ExerciseNutritionPackage';
        activate();
        function showLoading() {
            App.blockUI({
                target: '#exercisenutritionpackageList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exercisenutritionpackageList');
        }
        function activate() {
       
             vm.exerciseNutritionPackage = param.item;
          vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
  vm.saveExerciseNutritionPackage = function (option) {
            if (!validateForm()) return;
           showLoading();
            exerciseNutritionPackageService.updateExerciseNutritionPackage(vm.exerciseNutritionPackage)
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

