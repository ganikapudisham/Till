app.controller('subcategory', function ($scope, $http) {

    $scope.subCategories = [];
    $scope.categories = [];

    $scope.init = function () {
        $http.get('http://lapi.till.com/subcategories').success(function (data) {
            $scope.subCategories = data;
        });

        $http.get('http://lapi.till.com/categories').success(function (data) {
            $scope.categories = data;
        });

    }
    $scope.init();

    $scope.get = function (Id) {
        $http.get('http://lapi.till.com/subcategories/' + Id).success(function (data) {
            $scope.editSubCatId = data.Id;
            $scope.categoryIdEdit = data.CategoryId;
            $scope.editSubCatName = data.Name;
        });
    }
    $scope.add = function () {

        $scope.subCategory = {
            CategoryId: $scope.categoryIdSelected,
            Name: $scope.subCategoryName
        };

        $http({
            method: 'POST',
            url: 'http://lapi.till.com/subcategories',
            data: $scope.subCategory
        }).then(function (response) {
            var subCategory = {
                'Id': response.data.Id,
                'Name': response.data.Name,
                'CategoryId':response.data.CategoryId
            };

            $scope.subCategories.push(subCategory);
            $scope.categoryName = "";
        },
         function (response) {
            
         });

    }

    $scope.delete = function (Id) {

        $http({
            method: 'DELETE',
            url: 'http://lapi.till.com/subcategories/' + Id
        }).then(function (response) {
            $scope.subCategories.splice($scope.subCategories.findIndex(x=>x.Id === Id), 1);
        },
         function (response) { // optional
            
         });

    }

    $scope.update = function () {

        $scope.subCategory = {
            Id: $scope.editSubCatId,
            Name: $scope.editSubCatName,
            CategoryId: $scope.categoryIdEdit
        };

        $http({
            method: 'PUT',
            url: 'http://lapi.till.com/subcategories/' + $scope.editSubCatId,
            data: $scope.subCategory
        }).then(function (response) {
            $scope.init();
        },
         function (response) { // optional
            
         });

    }

});


