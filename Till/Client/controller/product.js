app.controller('product', function ($scope, $http) {

    $scope.products = [];
    $scope.subCategories = [];
    $scope.init = function () {
        $http.get('http://lapi.till.com/products').success(function (data) {
            $scope.products = data;
        });

        $http.get('http://lapi.till.com/subCategories').success(function (data) {
            $scope.subCategories = data;
        });
    }
    $scope.init();

    $scope.get = function (Id) {
        $http.get('http://lapi.till.com/products/' + Id).success(function (data) {
            $scope.editProductId = data.Id;
            $scope.subCategoryIdEdit = data.SubCategoryId;
            $scope.editProductName = data.Name;
        });
    }
    $scope.add = function () {

        $scope.product = {
            SubCategoryId: $scope.categoryIdSelected,
            Name: $scope.Product
        };

        $http({
            method: 'POST',
            url: 'http://lapi.till.com/products',
            data: $scope.product
        }).then(function (response) {
            var product = {
                'Id': response.data.Id,
                'Name': response.data.Name,
                'SubCategoryId': response.data.SubCategoryId
            };

            $scope.products.push(product);
            $scope.product = "";
        },
         function (response) {
             
         });

    }

    $scope.delete = function (Id) {

        $http({
            method: 'DELETE',
            url: 'http://lapi.till.com/products/' + Id
        }).then(function (response) {
            $scope.products.splice($scope.products.findIndex(x=>x.Id === Id), 1);
        },
         function (response) { // optional
             
         });

    }

    $scope.update = function () {

        $scope.product = {
            Id: $scope.editProductId,
            Name: $scope.editProductName,
            SubCategoryId: $scope.subCategoryIdEdit
        };

        $http({
            method: 'PUT',
            url: 'http://lapi.till.com/products/' + $scope.editProductId,
            data: $scope.product
        }).then(function (response) {
            $scope.init();
        },
         function (response) { // optional
             
         });

    }

});


