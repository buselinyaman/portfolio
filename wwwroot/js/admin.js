// Image preview
document.querySelectorAll('input[type="file"]').forEach(input => {
    input.addEventListener('change', function() {
        const preview = document.querySelector('.image-preview');
        if (preview && this.files[0]) {
            const reader = new FileReader();
            reader.onload = e => preview.src = e.target.result;
            reader.readAsDataURL(this.files[0]);
        }
    });
});

// Range input live value
document.querySelectorAll('.form-range').forEach(range => {
    const val = range.nextElementSibling;
    if (val) {
        val.textContent = range.value + '%';
        range.addEventListener('input', () => val.textContent = range.value + '%');
    }
});

// Delete confirm
document.querySelectorAll('.btn-delete').forEach(btn => {
    btn.addEventListener('click', e => {
        if (!confirm('Bu öğeyi silmek istediğinizden emin misiniz?')) {
            e.preventDefault();
        }
    });
});
