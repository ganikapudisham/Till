app.controller('category', function ($scope, $http) { 

    $scope.categories = [];
    $scope.init = function () {
        $http.get('http://lapi.till.com/categories').success(function (data) {
            $scope.categories = data;
        });
    } 
    $scope.init();

    $scope.get = function (Id) {
        $http.get('http://lapi.till.com/categories/' + Id).success(function (data) {
            $scope.editCatId = data.Id;
            $scope.editCatName = data.Name;
        });
    }
    $scope.add = function () { 
   
   $scope.category={
Name:$scope.categoryName 
};
   
   $http({
    method: 'POST',
    url: 'http://lapi.till.com/categories',
    data: $scope.category
   }).then(function (response) {
       var cat = {
           'Id': response.data.Id,
           'Name': response.data.Name
       };

       $scope.categories.push(cat);
       $scope.categoryName = "";
    }, 
    function(response) {  
            
    });
   
    }

    $scope.delete = function (Id) {

        $http({
            method: 'DELETE',
            url: 'http://lapi.till.com/categories/' + Id 
        }).then(function (response) { 
            $scope.categories.splice($scope.categories.findIndex(x=>x.Id === Id), 1);
        },
         function (response) { // optional
             
         });

    }

    $scope.update = function () {

        $scope.category = {
            Id: $scope.editCatId,
            Name: $scope.editCatName
        };

        $http({
            method: 'PUT',
            url: 'http://lapi.till.com/categories/' + $scope.editCatId,
            data: $scope.category
        }).then(function (response) {
            $scope.init();
        },
         function (response) { // optional
             
         });

    }
    
});

 
 