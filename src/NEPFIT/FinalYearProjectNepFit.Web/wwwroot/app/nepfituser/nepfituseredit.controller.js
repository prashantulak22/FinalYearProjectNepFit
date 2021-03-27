
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('nepfituserEditCtrl', nepfituserEditCtrl);
    nepfituserEditCtrl.$inject = ['nepFitUserService',  "$uibModalInstance", '$scope', 'param'];
    function nepfituserEditCtrl(nepFitUserService,  $uibModalInstance, $scope, param) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit NepFitUser';
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
       
             vm.nepFitUser = param.item;
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
            nepFitUserService.updateNepFitUser(vm.nepFitUser)
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

