app.config(['$stateProvider', function($stateProvider) {
   
   $stateProvider
  .state('unauth', {  
		url:'',
        templateUrl: 'view/menu-unauth.html'   
  }) 
   
   .state('unauth.categories', {  
		url:'/categories',
        templateUrl: 'view/category.html',
        controller: 'category'		
   })

    .state('unauth.subcategories', {
        url: '/subcategories',
        templateUrl: 'view/subcategory.html',
        controller: 'subcategory'
    })

    .state('unauth.products', {
        url: '/products',
        templateUrl: 'view/product.html',
        controller: 'product'
    })
}]);