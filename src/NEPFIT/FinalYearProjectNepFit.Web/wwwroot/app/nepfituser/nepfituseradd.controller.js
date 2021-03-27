
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('nepfituserAddCtrl', nepfituserAddCtrl);
    nepfituserAddCtrl.$inject = ['nepFitUserService',  "$uibModalInstance", '$scope'];
    function nepfituserAddCtrl(nepFitUserService,  $uibModalInstance, $scope) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add NepFitUser';
        
        activate();
        function showLoading() {
            App.blockUI({
                target: '#nepfituserList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#nepfituserList');
        }
        function activate() {
       
        
                function initialize() {
            return {
              
                    UserId: "",
                    FirstName: "",
                    LastName: "",
                    Gender: "",
                    MobileNumber: 0,            
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
        



})(angular, $, kendo, App);

