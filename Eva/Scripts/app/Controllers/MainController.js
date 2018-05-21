(function() {
    var app = angular.module("Eva");

    var MainController = function($scope, $location) {
        $scope.showBooks = function () {
            $location.replace();
            $location.url('/books');
        };
    };

    app.controller("MainController", MainController);
})();