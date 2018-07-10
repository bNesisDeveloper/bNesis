//Used bNesis API Server URL
//var APIServerUrl = "https://socialpilot.bnesis.com/"; //for test with Social Pilot
//var APIServerUrl = "http://localhost/"; //for local test
var APIServerUrl = "https://server2.bnesis.com/"; //for test with free demo bNesis API Server

var win;
var respData = {};
$(document).ready(function () {

    $('.btn-main').click(function () {
        $('.main-wrapper').slideUp(750);
        $('.second-wrapper').fadeIn(750);

        $('.step1-title').text($(this).data('type'));
        // .bootstrapSlider('getValue');

    });


    // $('#datetimepicker1').datetimepicker({
    //     format: 'DD/MM/YYYY',
    //     viewMode: 'years'
    // });
    // $('#datetimepicker2').datetimepicker({
    //     format: 'DD/MM/YYYY',
    //     viewMode: 'years'
    // });

    $('.btn-next-st3').click(function () {
        $('.second-wrapper').slideUp(750);
        $('.third-wrapper').fadeIn(750);

    });

    $('.btn-next-st4').click(function () {
        $('.loader').fadeIn(500);
        setTimeout(function () {
            window.location.replace("./Done");
        }, 6000);
    });

    $('.clickable').click(function () {
        if (!$(this).hasClass('active')) {
            win = window.open('./Popup/' + $(this).data('service-type') + "", "_blank", "height=600, width=750, status=yes, toolbar=no, menubar=no, location=no,addressbar=no");
        }
    });

    $("#summ, #period_years").on('change', function () {
        $('.m-payment').text(getMonthly($('#summ').slider('getValue'), $('#period_years')[0].value));
    });


});

window.setActive = function (name, token) {
    if (name === 'bnp') {
        window.location.replace("../LoanType.html");
    }
    $('.btn-next-st4').removeAttr('disabled');
    $('.' + name).addClass('active');

}

function getMonthly(summ, periodYears) {
    var payment = 0;
    if (periodYears !== null && periodYears > 0) {
        payment = (summ + summ * 0.04) / periodYears / 12;
    }
    return payment.toFixed(2);
}