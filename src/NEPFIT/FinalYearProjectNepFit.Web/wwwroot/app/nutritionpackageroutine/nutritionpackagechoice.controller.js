
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nutritionPackageChoiceCtrl', nutritionpackageChoiceCtrl);
    nutritionPackageChoiceCtrl.$inject = ['nutritionPackageService', 'blockUI'];
    function nutritionPackageChoiceCtrl(nutritionPackageService, blockUI) {
        var vm = this;
        activate();

        function activate() {
            nutritionPackageService.get

        }





        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }



    }



})(angular, $, kendo);

