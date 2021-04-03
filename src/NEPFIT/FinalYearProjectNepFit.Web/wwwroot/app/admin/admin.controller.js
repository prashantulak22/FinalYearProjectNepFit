
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('adminCtrl', adminCtrl);
    adminCtrl.$inject = ['$uibModal', '$state', 'nepFitUserService'];
    function adminCtrl($uibModal, $state, nepFitUserService) {
        var vm = this;
        vm.dispalyContent = false;
        activate();
        function activate() {
            

        }

        

        vm.showExcerciseType = function () {
            $state.go('exerciseType');
        }
        vm.showExcerciseRoutine = function () {
            $state.go('exerciseRoutine');
        }
        vm.showExcercisePackage = function () {
            $state.go('exercisePackage');
        }
        vm.showNutritionType = function () {
            $state.go('nutritionType');
        }
        vm.showNutritionPackage = function () {
            $state.go('nutritionPackage');
        }
        vm.showNutritionRoutine = function () {
            $state.go('nutritionRoutine');
        }
        vm.showNutritionPackageRoutine = function () {
            $state.go('nutritionPackageRoutine');
        }
        vm.showExercisePackageRoutine = function () {
            $state.go('exercisePackageRoutine');
        }
        vm.showExerciseNutritionPackage = function () {
            $state.go('exerciseNutritionPackage');
        }
        vm.showNepFitUser = function () {
            $state.go('nepFitUser');
        }
    }


})(angular);

