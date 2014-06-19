

$(function () {
    $('#datetimepicker_mask').datetimepicker({
        //mask: '39/19/9999',
        timepicker: false,
        //value: '00/00/0000',
        format: 'd/m/Y',
        maxDate: '+02/01/1970'//tommorow is maximum date calendar
    });
});

$(function () {
    $('#datetimepicker_time').datetimepicker({
        datepicker: false,
        hours12: false,
        format: 'H:m',
    });
});