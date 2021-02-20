(function (angular, app) {
    'use strict';
    angular
        .module('nepFitApp', ['kendo.directives', 'ui.bootstrap', 'ui.router', 'blockUI'])
        .config([
            "$stateProvider", "$urlRouterProvider", '$locationProvider', 'blockUIConfig',
            function ($stateProvider, $urlRouterProvider, $locationProvider, blockUIConfig) {

                //Don't use abstract state (and remove app. from url), because it doesn't work with htm5Mode
                //Use the HTML5 History API
                $locationProvider.html5Mode(true);
                blockUIConfig.autoBlock = false;

                $stateProvider
                    .state("home",
                        {
                            url: "/",
                            templateUrl: "/app/home/home.html",
                            title: "home"
                        })
                    .state("register",
                        {
                            url: "/register/medicaluser",
                            templateUrl: "/app/medicaluser/register.html",
                            title: "Register"
                        });

                $urlRouterProvider.otherwise(function ($injector, $location) {
                    var $state = $injector.get('$state');
                    console.log($location.$location.$$url);
                    $state.go('home', {});
                });
            }
        ]);

})(angular, app);

