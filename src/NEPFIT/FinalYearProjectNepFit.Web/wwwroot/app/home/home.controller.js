
(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .controller('homeCtrl', homeCtrl);
    homeCtrl.$inject = ['$uibModal', '$state', 'nepFitUserService'];
    function homeCtrl($uibModal, $state, nepFitUserService) {
        var vm = this;
        vm.dispalyContent = false;
        activate();
        function activate() {
            app.user = {};
            nepFitUserService.getLoggedInUser().then(function (result) {
                app.user = result.data;
                vm.isAdmin = app.user.isAdmin;
                if (!result.data) {
                  $state.go('register');
                } else
                
                {
                    vm.dispalyContent = true;
                }
                if (vm.isAdmin){
                    $state.go('admin');
                }
               

            });

        }

        

     
        vm.showAdmin = function () {
            $state.go('admin');
        }

        vm.showPostRegister = function () {
            $state.go('register');
        }
    }


})(angular);

