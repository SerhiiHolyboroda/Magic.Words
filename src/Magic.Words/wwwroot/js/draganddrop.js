document.addEventListener('DOMContentLoaded', function () {
    var dragText = document.getElementById('drag-text');
    var offsetX = 0;
    var offsetY = 0;
    var isDragging = false;
    dragText.addEventListener('mousedown', function (e) {
        isDragging = true;
        offsetX = e.clientX - dragText.getBoundingClientRect().left;
        offsetY = e.clientY - dragText.getBoundingClientRect().top;
        dragText.style.zIndex = '1000';
    });
    document.addEventListener('mousemove', function (e) {
        if (isDragging) {
            var x = e.clientX - offsetX;
            var y = e.clientY - offsetY;
            dragText.style.left = "".concat(x, "px");
            dragText.style.top = "".concat(y, "px");
        }
    });
    document.addEventListener('mouseup', function () {
        isDragging = false;
        dragText.style.zIndex = 'auto';
    });
});
//# sourceMappingURL=draganddrop.js.map