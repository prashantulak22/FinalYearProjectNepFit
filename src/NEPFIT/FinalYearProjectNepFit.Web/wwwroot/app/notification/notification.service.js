(function (angular) {
    'use strict';

    angular
        .module('nepFitApp')
        .factory('notificationService', notificationService);

    function notificationService() {
        var service = {
            showErrorNotification: showErrorNotification,
            getErrorNotificationOptions: getErrorNotificationOptions,
            showSuccessNotification: showSuccessNotification,
            getSuccessNotificationOptions: getSuccessNotificationOptions
        };

        return service;

        function getSuccessNotificationOptions() {
            var notf1Options =
            {
                templates: [{
                    type: "success",
                    template: '<p class="notification"><i class="fa fa-lg fa-check-circle" aria-hidden="true"></i> #= kValue # </p>'
                }],
                autoHideAfter: 10000,
                allowHideAfter: 1000,
                closable: true,
                maxHeight: 300,
                title: "Success",
                width: "400px",
                visible: false,
                animation: {
                    open: {
                        effects: "slideIn:down"
                    },
                    close: {
                        effects: "fadeout"
                    }
                }
            }
            return notf1Options;
        }

        function showSuccessNotification(vm, msg) {
            vm.successNotification.show({
                kValue: msg
            }, "success");
        }

        function getErrorNotificationOptions() {
            var options = {
                templates: [{
                    type: "error",
                    template: '<p class="notification"><i class="fa fa-lg fa-times-circle" aria-hidden="true"></i> #= kValue # </p>'
                }],
                actions: [
                    {
                        text: "OK",
                        action: function (e) {
                            return true;
                        }
                    }
                ],
                animation: {
                    open: {
                        effects: "fade:in"
                    },
                    close: {
                        effects: "fade:out"
                    }
                },
                closable: true,
                maxHeight: 300,
                title: "Error",
                width: "400px",
                visible: false
            };
            return options;

        }
        function showErrorNotification(vm, msg) {
            vm.errorNotification.show({
                kValue: msg
            }, "error");
        }
    }
})(angular);
