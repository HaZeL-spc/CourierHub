var tomorrow = new Date();
tomorrow.setDate(tomorrow.getDate() + 1);

$(document).ready(function () {
	$('.date').datepicker({
		format: 'yyyy-mm-dd',
		startDate: tomorrow,
		linked: true
	});
});