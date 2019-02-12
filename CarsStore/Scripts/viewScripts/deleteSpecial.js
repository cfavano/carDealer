(function () {
    $(document).ready(function () {
        $('.delete-special').on('click', deleteSpecial);
    });

    function deleteSpecial() {
        if (confirm("Are you sure you want to delete this special?")) {

            var value = $(this).attr('id');

            $.ajax({
                type: 'delete',
                url: '/Admin/Specials/' + value
            });

            $(".row-" + value).remove();
        }
    }

})();