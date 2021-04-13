

function namethis(e) {
    var file = document.getElementById('img_file');
    var ext = file.value.match(/\.([^\.]+)$/)[1];
    switch (ext) {
        case 'jpg':
        case 'jpeg':
        case 'png':
        case 'pdf':
            break;
        default:
            alert('File not allowed, please select an image with the extension of .png., .jpg, .pdf');
            document.getElementById('img_file').value = '';
    }
};