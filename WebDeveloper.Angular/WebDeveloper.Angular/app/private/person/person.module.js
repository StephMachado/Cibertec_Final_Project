(function () {
    'use strict';
    angular.module('app')
    .controller('PersonController', personController);

    personController.$inject = ['$scope'];

    function personController($scope) {
        var vm = this;
        vm.title = "Person Module";
    }

})();