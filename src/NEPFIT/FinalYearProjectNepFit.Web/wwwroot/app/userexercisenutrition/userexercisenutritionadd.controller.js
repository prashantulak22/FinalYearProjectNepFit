
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('userexercisenutritionAddCtrl', userexercisenutritionAddCtrl);
    userexercisenutritionAddCtrl.$inject = ['userExerciseNutritionService',  "$uibModalInstance", '$scope'];
    function userexercisenutritionAddCtrl(userExerciseNutritionService,  $uibModalInstance, $scope) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add UserExerciseNutrition';
        
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
       
        
                function initialize() {
            return {
              
                    Active: "",
                    UpdatedBy: "",
                    CreatedBy: "",
                    UserId: "",
                    ExerciseNutritionPackageId: "",            
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
        



})(angular, $, kendo, App);

