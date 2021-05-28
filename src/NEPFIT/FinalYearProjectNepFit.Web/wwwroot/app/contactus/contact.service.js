
(function (angular, app) {
    angular
        .module('nepFitApp')
        .factory('userNotesService', userNotesService);

    userNotesService.$inject = ['$http'];

    function userNotesService($http) {
        var service = {
            getAllUserNotes: getAllUserNotes,
            getAllUserNotesByUserId: getAllUserNotesByUserId,
            updateUserNotes: updateUserNotes,
            createUserNotes: createUserNotes,
            deleteUserNotes: deleteUserNotes,


        };

        return service;

 
        function  getAllUserNotes() {
            
                return $http({
                    method: 'GET',
                    url: 'api/usernotes/all',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
            
        }
        
        function  getAllUserNotesByUserId() {
            
                return $http({
                    method: 'GET',
                    url: 'api/usernotes/notes',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken }
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
            
        }

        function  createUserNotes(item) {
         
                return $http({
                    method: 'POST',
                    url: 'api/usernotes/add',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
           
        }
        
       function  updateUserNotes(item) {
            
                return $http({
                    method: 'POST',
                    url: 'api/usernotes/update',
                    headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                    data: item
                }).then(
                    function (data, status, headers, config) {
                        return data;
                    });
           
       }

        function deleteUserNotes(item) {
            return $http({
                method: 'POST',
                url: '/api/usernotes/delete',
                headers: { 'Authorization': 'Bearer ' + app.jwtToken },
                data: item
            }).then(
                function (data, status, headers, config) {
                    return data;
                });
        }
        
        
    }
})(angular, app);
