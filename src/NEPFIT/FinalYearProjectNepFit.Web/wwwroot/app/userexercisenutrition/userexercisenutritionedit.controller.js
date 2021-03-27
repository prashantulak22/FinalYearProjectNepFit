
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('userexercisenutritionEditCtrl', userexercisenutritionEditCtrl);
    userexercisenutritionEditCtrl.$inject = ['userExerciseNutritionService', "$uibModalInstance", '$scope', 'blockUI'];
    function userexercisenutritionEditCtrl(userExerciseNutritionService, $uibModalInstance, $scope, param, blockUI ) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit UserExerciseNutrition';
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
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
        



})(angular, $, kendo);

