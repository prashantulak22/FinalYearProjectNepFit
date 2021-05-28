    
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('usernotesEditCtrl', usernotesEditCtrl);
    usernotesEditCtrl.$inject = ['userNotesService', "$uibModalInstance", '$scope', 'param', 'blockUI'];
    function usernotesEditCtrl(userNotesService, $uibModalInstance, $scope, param, blockUI) {
        var vm = this;
                vm.isNew = false;
        
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
       
             vm.userNotes = param.item;
          vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
  vm.saveUserNotes = function (option) {
            if (!validateForm()) return;
           showLoading();
            userNotesService.updateUserNotes(vm.userNotes)
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

