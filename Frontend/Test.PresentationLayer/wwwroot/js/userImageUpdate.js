function showImageGallery() {
    document.getElementById('image-gallery-container').style.display = 'block';
}

function selectImage(imageId, imageUrl) {
    document.getElementById('SelectedImageId').value = imageId;
    var currentProfileImage = document.getElementById('current-profile-image');
    currentProfileImage.src = imageUrl;

    // Görselleri kapat
    document.getElementById('image-gallery-container').style.display = 'none';
}

document.addEventListener("DOMContentLoaded", function () {
    var selectImageButton = document.getElementById('select-image-button');
    var imageGallery = document.getElementById('image-gallery');

    selectImageButton.addEventListener('click', function () {
        imageGallery.classList.toggle('d-none');
    });

    var images = document.querySelectorAll('#image-gallery .image-item img');
    images.forEach(function (image) {
        image.addEventListener('click', function () {
            var imageId = this.parentElement.getAttribute('data-id');
            selectImage(imageId, this.src);
        });
    });
});