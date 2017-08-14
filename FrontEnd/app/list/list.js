function TimelogTypeListController($http) {
	var ctrl = this;

	ctrl.data = [];
	$http({
		method: 'GET',
		url: 'http://localhost:3397/v1/timelogtypes'
	}).then(function (response) {
		console.log(response.data);
		ctrl.data = response.data;
	}, function(r) {
		toaster.pop({
			type: 'error',
			body: r.statusText
		});
	});
}

TimelogTypeListController.$inject = [ '$http' ];
