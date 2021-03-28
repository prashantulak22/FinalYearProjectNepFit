
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('userexerciseroutineCtrl', userexerciseroutineCtrl);
    userexerciseroutineCtrl.$inject = ['exerciseRoutineService', '$scope', 'blockUI'];
    function userexerciseroutineCtrl(exerciseRoutineService, $scope, blockUI) {
        var vm = this;
        activate();

        function activate() {
            exerciseRoutineService.getExerciseRoutineByUser()
                .then(function (result) {
                    vm.userExerciseRoutine = result.data;
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

