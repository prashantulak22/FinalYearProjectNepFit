
(function (angular ) {
    'use strict';

    angular
        .module('tableapp')
        .controller('nepfituserDeleteCtrl', nepfituserDeleteCtrl);
    nepfituserDeleteCtrl.$inject = ['nepFitUserService',  "$uibModalInstance", '$scope', 'param'];
    function nepfituserDeleteCtrl(nepFitUserService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.nepFitUser = param.item;
                 vm.deleteNepFitUser = function (item) {
                nepFitUserService.deleteNepFitUser(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

