(function ($) {

    window.testController = {
        initForm: init
    }

    function init(id) {
        var $form = $('#' + id);
        var $submitButton = $form.find('.btn-submit')

        $form.find('.btn-add-new').click(addRow);
        $form.on('click', '.btn-remove', removeRow);
        $.validator.unobtrusive.parse($form);

        window['begin_' + id] = beginUpdate($submitButton)
        window['complete_' + id] = endUpdate($submitButton)
    }
    
    function removeRow() {
        $(this).closest('tr').remove();
    }

    function addRow(e) {
        var $addRowBtn = $(this);
        var $form = $addRowBtn.closest('form');
        var $target = $form.find('[data-collection=' + $addRowBtn.data('collection') + '] tbody');

        var addRowUrl = $addRowBtn.data("url");
        var index = $target.children().length;

        $.ajax(addRowUrl, {
            success: appendRow,
            context: { $target: $target, $form: $form }
        });
    }

    function appendRow(data) {
        var $newRow = $(data).find('tbody > *')
        this.$target.append($newRow);
        initValidation(this.$form);
    }

    function initValidation($form) {
        $form.removeData('validator');
        $form.removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse($form);
    }

    function beginUpdate($submitButton) {
        return function () {
            $submitButton.prop('disabled', true);
        }
    }

    function endUpdate($submitButton) {
        return function () {
            $submitButton.prop('disabled', false);
        }
    }    
})(jQuery);