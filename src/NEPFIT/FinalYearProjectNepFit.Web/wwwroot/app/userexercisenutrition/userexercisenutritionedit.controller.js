
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('userexercisenutritionEditCtrl', userexercisenutritionEditCtrl);
    userexercisenutritionEditCtrl.$inject = ['userExerciseNutritionService',  "$uibModalInstance", '$scope', 'param'];
    function userexercisenutritionEditCtrl(userExerciseNutritionService,  $uibModalInstance, $scope, param) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit UserExerciseNutrition';
        activate();
        function showLoading() {
            App.blockUI({
                target: '#userexercisenutritionList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#userexercisenutritionList');
        }
        function activate() {
       
             vm.userExerciseNutrition = param.item;
          vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
  vm.saveUserExerciseNutrition = function (option) {
            if (!validateForm()) return;
           showLoading();
            userExerciseNutritionService.updateUserExerciseNutrition(vm.userExerciseNutrition)
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

