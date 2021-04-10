
(function (angular, $, kendo,) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('nepfituserEditCtrl', nepfituserEditCtrl);


    nepfituserEditCtrl.$inject = ['nepFitUserService', "$uibModalInstance", '$scope', 'param', 'blockUI', 'exerciseNutritionPackageService'];
    function nepfituserEditCtrl(nepFitUserService, $uibModalInstance, $scope, param, blockUI, exerciseNutritionPackageService) {
        var vm = this;
                vm.isNew = false;
        vm.title = ' Edit NepFitUser';
        activate();
        function showLoading() {
            blockUI.start();
        }

        function hideLoading() {
            blockUI.stop();
        }
        function activate() {
            vm.nepFitUser = param.item;
            exerciseNutritionPackageService.getAllExerciseNutritionPackage()
                .then(function (result) {
                    vm.exerciseTypeIdDropdownOptions = {
                        dataTextField: "name",
                        dataValueField: "exerciseTypeId",
                        valuePrimitive: true,
                        value: vm.nepFitUser.exerciseTypeId,
                        
                        dataSource: {
                            data: result.data
                        }
                    }
                    vm.nepFitUser = param.item;

                });
       
             
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
        hideLoading();
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
        



})(angular, $, kendo);

