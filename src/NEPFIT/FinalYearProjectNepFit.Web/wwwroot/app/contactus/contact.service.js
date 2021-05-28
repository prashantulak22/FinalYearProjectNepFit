
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('contactService', contactService);

    contactService.$inject = ['$http'];

    function contactService($http) {
        var service = {
            sendemail: sendemail,
        }
        return service;

        function  sendemail(item) {
         
                return $http({
                    method: 'POST',
                    url: 'api/contact/us',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
           
        }

        
        
    }
})(angular, app);
