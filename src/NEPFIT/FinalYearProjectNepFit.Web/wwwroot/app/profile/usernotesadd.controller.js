
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('usernotesAddCtrl', usernotesAddCtrl);
    usernotesAddCtrl.$inject = ['userNotesService', "$uibModalInstance", '$scope', 'blockUI'];
    function usernotesAddCtrl(userNotesService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        
        
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
              
                    
                    userNotes: "",
                    
                               
            };
            }
             vm.userNotes = initialize();
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
            userNotesService.createUserNotes(vm.userNotes)
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

