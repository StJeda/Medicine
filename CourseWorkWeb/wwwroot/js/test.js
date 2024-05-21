function handleFileInputChange() {
    var filePath;
    document.getElementById('fileInput1').addEventListener('change', function(event) {
        var files = event.target.files;
        if (files.length > 0) {
            filePath = URL.createObjectURL(files[0]);
        }
        return filePath;
    });
}