
(function (angular ) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('usernotesDeleteCtrl', usernotesDeleteCtrl);
    usernotesDeleteCtrl.$inject = ['userNotesService',  "$uibModalInstance", '$scope', 'param'];
    function usernotesDeleteCtrl(userNotesService,  $uibModalInstance, $scope, param) {
        var vm = this;
        activate();
 
        function activate() {
             vm.userNotes = param.item;
                 vm.deleteUserNotes = function (item) {
                userNotesService.deleteUserNotes(item).then(function (result) {
                    $uibModalInstance.close();
                });
            }
                vm.close = function () {
            $uibModalInstance.close();
        };
        
        
        }
             
 
        }
        



})(angular );

