
$(function () {
    function setHeight() {
        windowHeight = $(window).innerHeight();
        $('.topBar').css('min-height', windowHeight-110);
    };
    setHeight();

    $(window).resize(function () {
        setHeight();
    });
    $(window).scroll(function () {
        setHeight();
    });
});

$(window).scroll(function () {

    var top = $('#progressBar').offset().top - window.innerHeight;

    var pTop = $(document).scrollTop();

    if (pTop > top) {
        progressBar();
    }
});


function progressBar() {

    $('#Progress-70').pieChart({
        barColor: '#50b7fc',
        trackColor: '#eee',
        lineCap: 'round',
        lineWidth: 8,
        animate: {
            duration: 3000,
            enabled: true
        },
        onStep: function (from, to, percent) {
            $(this.element).find('.progress-70').text(Math.round(percent) + '%');
        }
    });

    $('#Progress-50').pieChart({
        barColor: '#8365d5',
        trackColor: '#eee',
        lineCap: 'butt',
        lineWidth: 8,
        animate: {
            duration: 3000,
            enabled: true
        },
        onStep: function (from, to, percent) {
            $(this.element).find('.progress-50').text(Math.round(percent) + '%');
        }
    });

    $('#Progress-65').pieChart({
        barColor: '#2fcf4b',
        trackColor: '#eee',
        lineCap: 'square',
        lineWidth: 8,
        animate: {
            duration: 3000,
            enabled: true
        },
        onStep: function (from, to, percent) {
            $(this.element).find('.progress-65').text(Math.round(percent) + '%');
        }
    });

    $('#Progress-100').pieChart({
        barColor: '#fc5340',
        trackColor: '#eee',
        lineCap: 'round',
        lineWidth: 8,
        rotate: 90,
        animate: {
            duration: 3000,
            enabled: true
        },
        onStep: function (from, to, percent) {
            $(this.element).find('.progress-100').text(Math.round(percent) + '%');
        }
    });
}


