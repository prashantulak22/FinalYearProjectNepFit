
(function (angular, $, kendo) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nepfituserAddCtrl', nepfituserAddCtrl);
    nepfituserAddCtrl.$inject = ['nepFitUserService', "$uibModalInstance", '$scope', 'blockUI'];
    function nepfituserAddCtrl(nepFitUserService, $uibModalInstance, $scope, blockUI) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add NepFitUser';
        
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
              
                    
                    firstName: "",
                    lastName: "",
                    gender: "",
                               
            };
            }
             vm.nepFitUser = initialize();
     vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                  if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
                vm.saveNepFitUser = function (option) {
            if (!validateForm()) return;
           showLoading();
            nepFitUserService.createNepFitUser(vm.nepFitUser)
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

