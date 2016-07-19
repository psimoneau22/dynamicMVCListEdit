(function ($) {
    
    var $form;
    var autoCompleteSettings;

    window.testController = {
        initForm: init
    }

    function init(id) {
        $form = $('#' + id);
        var $submitButton = $form.find('.btn-submit')
        
        $form.find('.btn-add-new').click(addRow);
        $form.on('click', '.btn-remove', removeRow);
        $.validator.unobtrusive.parse($form);

        autoCompleteSettings = {
            source: getAutoCompleteSource,            
            minLength: 0,
            select: function (e, ui) {
                $(this).val(ui.item.label);
                return false;
            }
        };

        initUi();

        window['begin_' + id] = beginUpdate($submitButton)
        window['complete_' + id] = endUpdate($submitButton)
    }

    function initUi() {
        var autoCompletes = $form.find('.autocomplete')
            .autocomplete(autoCompleteSettings)
            .focus(function () {
                console.log('search');
                $(this).autocomplete("search", $(this).val());
            });
    }

    function getAutoCompleteSource(req, resp) {
        $.get('http://jsonplaceholder.typicode.com/users', function (data) {
            resp(data.filter(function (item) {                        
                return !req.term || new RegExp($.ui.autocomplete.escapeRegex(req.term), 'i').test(item.name + '(' + item.username + ') - ' + item.id)
            }).map(function (item) {
                return {
                    label: item.name + '(' + item.username + ') - ' + item.id,
                    value: item.id
                }
            }));
        });
    }
    
    function removeRow() {
        $(this).closest('tr').remove();
    }

    function addRow(e) {
        var $addRowBtn = $(this);
        var $target = $form.find('[data-collection=' + $addRowBtn.data('collection') + '] tbody');

        var addRowUrl = $addRowBtn.data("url");
        var index = $target.children().length;

        $.ajax(addRowUrl, {
            success: appendRow,
            context: { $target: $target }
        });
    }

    function appendRow(data, x, y) {
        var rawHtml = $.parseHTML(data.trim());
        var $source = $(rawHtml);

        var sourceTarget = y.getResponseHeader('Dynamic-Row-Target');
        if (sourceTarget) {
            $source = $(data).find(sourceTarget);
        }

        this.$target.append($source);

        initValidation();
        initUi()
    }

    function initValidation() {
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
        return function (x, y, z) {
            $submitButton.prop('disabled', false);
        }
    }    
})(jQuery);