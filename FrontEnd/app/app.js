let app = angular.module('app', ['ngRoute', 'ngAnimate', 'toaster']);

function appConfig($routeProvider, $locationProvider) {
	$locationProvider.html5Mode(false);

	$routeProvider.when('/list', { 
		templateUrl: 'app/list/list.html',
		controller: TimelogTypeListController,
		controllerAs: 'ctrl'
	});
	$routeProvider.when('/edit/:id', { 
		templateUrl: 'app/editor/editor.html',
		controller: timelogTypeEditorController,
		controllerAs: 'ctrl'
	});
	$routeProvider.otherwise({ redirectTo: '/list' });
}

appConfig.$inject = ['$routeProvider','$locationProvider'];

app.config(appConfig);