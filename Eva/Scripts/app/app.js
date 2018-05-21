(function () {

    var app = angular.module("Eva", ["ngRoute", "ngResource"]);

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/main", {
                templateUrl: "/Templates/Main.html",
                controller: "MainController"
            })
            .when('/books', {
                templateUrl: 'Templates/books.html',
            controller: 'BooksController'
            })
            .when('/addBook', {
                templateUrl: 'Templates/AddBook.html',
                controller: 'AddBookController'
            })
        .otherwise({redirectTo:'/main'});

    });

})();