mergeInto(LibraryManager.library, {
    OpenURL: function (url) {
        url = Pointer_stringify(url);
        window.open(url,'_blank');    }
});