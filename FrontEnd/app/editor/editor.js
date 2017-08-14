function timelogTypeEditorController($routeParams, $http, toaster) {
	let ctrl = this;

	ctrl.id = $routeParams.id;
	$http.get('http://localhost:3397/v1/timelogtypes/' + ctrl.id)
		.then(function(response) {
			ctrl.data = response.data;
		}, function(r) {
			toaster.pop({
				type: 'error',
				body: r.statusText
			});
		});

	ctrl.save = function() {
		console.log(ctrl.data.timelogType);
		$http.put('http://localhost:3397/v1/timelogtypes/' + ctrl.id, '"' + ctrl.data.timelogType + '"')
			.then(function() {
				history.back();
			}, function(r) {
				toaster.pop({
					type: 'error',
					body: r.statusText
				});
			});
	};

	ctrl.cancel = function() {
		history.back();
	};
}

timelogTypeEditorController.$inject = ['$routeParams', '$http', 'toaster'];
