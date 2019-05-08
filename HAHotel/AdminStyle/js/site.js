function confirmDelete(link) {
    if (!link) {
        return;
    }
    var conf = confirm("Bạn có chắc chắc muốn xóa?");
    if (conf) {
        window.location.replace(link.data("url"));
    }
}

function selectFile(input) {
    var ckfinder = new CKFinder();
    ckfinder.selectActionFunction = function (url) {
        input.value(url);
    };

    ckfinder.popup();
}