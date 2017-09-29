(function() {

	var sections = [
		$('.home__about'),
		$('.home__blog')
	]

	var togglers = [
		$('[data-toggle="about-section"]'),
		$('[data-toggle="article-section"]')
	]

	function navigateTo(section, toggler) {
		sections.forEach(function(item) {
			item.removeClass('is-visible');
		});
		togglers.forEach(function(item) {
			item.removeClass('active');
		});
		$(section).addClass('is-visible');
		$(toggler).addClass('active');
	}

	$('[data-toggle="about-section"]').click(function() {
		navigateTo(sections[0], togglers[0]);
	});

	$('[data-toggle="article-section"]').click(function() {
		navigateTo(sections[1], togglers[1]);
	});

	if (location.hash == "#about-me") navigateTo(sections[0], togglers[0]);
	else if (location.hash == "#blog") navigateTo(sections[1], togglers[1]);
	else navigateTo(sections[0], togglers[0]);

})();