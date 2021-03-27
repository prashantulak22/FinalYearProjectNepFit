
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisenutritionpackageAddCtrl', exercisenutritionpackageAddCtrl);
    exercisenutritionpackageAddCtrl.$inject = ['exerciseNutritionPackageService',  "$uibModalInstance", '$scope'];
    function exercisenutritionpackageAddCtrl(exerciseNutritionPackageService,  $uibModalInstance, $scope) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExerciseNutritionPackage';
        
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
       
        
                function initialize() {
            return {
              
                    ExerciseNutritionPackageId: "",
                    ExercisePackageId: "",
                    NutritionPackageId: "",
                    Active: "",
                    UpdatedBy: "",
                    CreatedBy: "",            
            };
            }
             vm.exerciseNutritionPackage = initialize();
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
            exerciseNutritionPackageService.createExerciseNutritionPackage(vm.exerciseNutritionPackage)
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

