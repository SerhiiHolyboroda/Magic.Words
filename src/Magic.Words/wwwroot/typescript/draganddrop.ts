document.addEventListener('DOMContentLoaded', () => {
    const dragText = document.getElementById('drag-text');

    let offsetX = 0;
    let offsetY = 0;
    let isDragging = false;

    dragText.addEventListener('mousedown', (e) => {
        isDragging = true;
        offsetX = e.clientX - dragText.getBoundingClientRect().left;
        offsetY = e.clientY - dragText.getBoundingClientRect().top;
        dragText.style.zIndex = '1000';
    });

    document.addEventListener('mousemove', (e) => {
        if (isDragging) {
            const x = e.clientX - offsetX;
            const y = e.clientY - offsetY;

            dragText.style.left = `${x}px`;
            dragText.style.top = `${y}px`;
        }
    });

    document.addEventListener('mouseup', () => {
        isDragging = false;
        dragText.style.zIndex = 'auto';
    });
});