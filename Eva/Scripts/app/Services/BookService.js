(function () {

    var BookService = function ($resource) {

        var resource = $resource('api/books/:id', { id: '@id' });

        var GetBooks = function () {
            return resource.query();
        };

        var AddBook = function (book) {
            return resource.save(book);
        };

        return {
            GetBooks: GetBooks,
            AddBook: AddBook
        }
    };
    
    var module = angular.module("Eva");
    module.factory("BookService", BookService);

})();