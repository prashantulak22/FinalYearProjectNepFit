
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('usernutritionroutineCtrl', usernutritionroutineCtrl);
    usernutritionroutineCtrl.$inject = ['nutritionRoutineService', '$scope','blockUI'];
    function usernutritionroutineCtrl(nutritionRoutineService, $scope, blockUI) {
        var vm = this;
        activate();

        function activate() {
            nutritionRoutineService.getNutritionRoutineByUser()
                .then(function (result) {
                    vm.userNutritionRoutine = result.data;
                });
        }






        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }


    }


    })(angular);

