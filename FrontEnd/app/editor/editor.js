function timelogTypeEditorController($routeParams, $http) {
	let ctrl = this;

	ctrl.id = $routeParams.id;
	$http.get('http://localhost:3397/v1/timelogtypes/' + ctrl.id)
		.then(function(response) {
			ctrl.data = response.data;
		});

	ctrl.save = function() {
		console.log(ctrl.data.timelogType);
		$http.put('http://localhost:3397/v1/timelogtypes/' + ctrl.id, '"' + ctrl.data.timelogType + '"')
			.then(function() {
				history.back();
			});
	};

	ctrl.cancel = function() {
		history.back();
	};
}

timelogTypeEditorController.$inject = ['$routeParams', '$http'];
