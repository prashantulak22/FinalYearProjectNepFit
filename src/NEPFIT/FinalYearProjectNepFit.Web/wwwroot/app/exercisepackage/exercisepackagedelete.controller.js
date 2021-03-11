
(function (angular ) {
    'use strict';

    angular
        .module('tableapp')
        .controller('exercisepackageDeleteCtrl', exercisepackageDeleteCtrl);
    exercisepackageDeleteCtrl.$inject = ['exercisePackageService',  "$uibModalInstance", '$scope', 'param'];
    function exercisepackageDeleteCtrl(exercisePackageService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.exercisePackage = param.item;
                 vm.deleteExercisePackage = function (item) {
                exercisePackageService.deleteExercisePackage(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

