
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('userexercisenutritionAddCtrl', userexercisenutritionAddCtrl);
    userexercisenutritionAddCtrl.$inject = ['userExerciseNutritionService', "$uibModalInstance", '$scope', 'blockUI'];
    function userexercisenutritionAddCtrl(userExerciseNutritionService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add UserExerciseNutrition';
        
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
              
                    userExerciseNutritionId: "",
                    userId: "",
                    exerciseNutritionPackageId: "",            
            };
            }
             vm.userExerciseNutrition = initialize();
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
            userExerciseNutritionService.createUserExerciseNutrition(vm.userExerciseNutrition)
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

