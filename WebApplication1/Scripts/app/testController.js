(function ($) {

    function init(id) {
        var $form = $('#' + id);

        $form.find('.btn-add-new').click({ form: $form }, addRow);
        $form.on('click', '.btn-remove', removeRow);
        $.validator.unobtrusive.parse($form);

        window['success_' + id] = function () { console.log("success:"); console.log(arguments) }
        window['begin_' + id] = function () { console.log("begin:"); console.log(arguments) }
        window['complete_' + id] = function () { console.log("complete:"); console.log(arguments) }
    }

    function removeRow() {
        $(this).closest('tr').remove();
    }

    function addRow(e) {
        var $addRowBtn = $(this);
        var $form = e.data.form;
        var $target = $form.find('.table-list-test tbody');

        var addRowUrl = $addRowBtn.data("url");
        var index = $target.children().length;

        $.ajax(addRowUrl, {
            data: { index: index },
            success: appendRow,
            context: { target: $target, form: $form },
            cache: true
        });
    }

    function appendRow(data) {
        this.target.append(data);
        initValidation(this.form);
    }

    function initValidation(form) {
        form.removeData('validator');
        form.removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse(form);
    }

    window.testController = {
        initForm: init
    }
})(jQuery);