
(function (angular, $, kendo, App) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisepackageAddCtrl', exercisepackageAddCtrl);
    exercisepackageAddCtrl.$inject = ['exercisePackageService',  "$uibModalInstance", '$scope'];
    function exercisepackageAddCtrl(exercisePackageService,  $uibModalInstance, $scope) {
        var vm = this;
        vm.isNew = true;
        vm.title = ' Add ExercisePackage';
        
        activate();
        function showLoading() {
            App.blockUI({
                target: '#exercisepackageList',
                boxed: true,
                message: 'Loading...'
            });
        }
        function hideLoading() {
            App.unblockUI('#exercisepackageList');
        }
        function activate() {
       
        
                function initialize() {
            return {
              
                    ExercisePackageId: "",
                    Name: "",
                    Description: "",
                    Active: "",
                    UpdatedBy: "",
                    CreatedBy: "",            
            };
            }
             vm.exercisePackage = initialize();
     vm.validationError = [];
     
             function validateForm() {
            vm.validationError = [];
                  if (vm.validationError.length > 0) return false;
                if ($scope.validator.validate()) return true;
                return false;
        }
        
                vm.saveExercisePackage = function (option) {
            if (!validateForm()) return;
           showLoading();
            exercisePackageService.createExercisePackage(vm.exercisePackage)
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

