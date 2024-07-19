document.addEventListener("DOMContentLoaded", function () {
    var selectImageButton = document.getElementById('select-image-button');
    var imageGallery = document.getElementById('image-gallery');
    var selectedImagePreview = document.getElementById('selected-image-preview');
    var selectedImagePreviewContainer = document.getElementById('selected-image-preview-container');
    var hiddenInput = document.getElementById('CreateAppUserRequest_UniverseImageId');

    // Butona tıklama olayı ekle
    selectImageButton.addEventListener('click', function () {
        imageGallery.classList.toggle('d-none'); // Galeri görünürlüğünü değiştir

        // Seçili görseli gizle
        if (!imageGallery.classList.contains('d-none')) {
            selectedImagePreview.style.display = 'none';
        }
    });

    // Resim seçme fonksiyonu
    function selectImage(imageId, imgSrc) {
        hiddenInput.value = imageId; // Görsel Id'sini gizli inputa ekle
        selectedImagePreview.src = imgSrc;
        selectedImagePreviewContainer.style.display = 'block';
        selectedImagePreview.style.display = 'block';

        // Seçilen resmin galeriyi gizlemesi
        imageGallery.classList.add('d-none');

        // Tüm resimlerden 'selected' sınıfını kaldır ve seçilen resme ekle
        var selectedImages = document.querySelectorAll('#image-gallery .image-item.selected');
        selectedImages.forEach(function (image) {
            image.classList.remove('selected');
        });
        document.querySelector('.image-item[data-id="' + imageId + '"]').classList.add('selected');
    }

    // Tüm resimlere tıklama olayı ekle
    var images = document.querySelectorAll('#image-gallery .image-item img');
    images.forEach(function (image) {
        image.addEventListener('click', function () {
            var imageId = this.parentElement.getAttribute('data-id');
            selectImage(imageId, this.src);
        });
    });
});