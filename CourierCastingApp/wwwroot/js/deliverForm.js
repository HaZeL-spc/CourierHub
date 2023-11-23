var tomorrow = new Date();
tomorrow.setDate(tomorrow.getDate() + 1);

$(document).ready(function () {
	$('.date').datepicker({
		format: 'yyyy-mm-dd',
		startDate: tomorrow,
		linked: true
	});
});

$(document).ready(function () {
	$('.timepicker input').timepicker({
		showMeridian: false,  // Set to true if you want the 12-hour format
		showSeconds: false    // Set to true if you want to display seconds
	});
});