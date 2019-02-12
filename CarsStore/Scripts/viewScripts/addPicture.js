


function submitImage() {
    var formdata = new FormData();
    var fileInput = document.getElementById('picture-input');

    for (i = 0; i < fileInput.files.length; i++) {
        formdata.append(fileInput.files[i].name, fileInput.files[i]);
    }

    var xhr = new XMLHttpRequest();

    xhr.open('POST', '/Admin/AddPicture');

    xhr.send(formdata);



    return false;
}

function submitUpdateImage(x){
    

    var formdata = new FormData();
    formdata.append("id", x);

    var fileInput = document.getElementById('picture-input');

    for (i = 0; i < fileInput.files.length; i++) {
        formdata.append(fileInput.files[i].name, fileInput.files[i]);
    }

    var xhr = new XMLHttpRequest();

    xhr.open('POST', '/Admin/UpdatedPicture');

    xhr.send(formdata);



    return false;
}
