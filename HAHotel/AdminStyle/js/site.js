function confirmDelete(link) {
    if (!link) {
        return;
    }
    var conf = confirm("Bạn có chắc chắc muốn xóa?");
    if (conf) {
        window.location.replace(link.data("url"));
    }
}