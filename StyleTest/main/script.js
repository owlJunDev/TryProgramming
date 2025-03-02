// Функция для переключения сайдбара
document.getElementById('toggleSidebar').addEventListener('click', function () {
    const sidebar = document.getElementById('sidebar');
    sidebar.classList.toggle('collapsed');
});

// Функция для показа/скрытия меню профиля
document.getElementById('profileButton').addEventListener('click', function () {
    const profileMenu = document.getElementById('profileMenu');
    if (profileMenu.style.display === 'block') {
        profileMenu.style.display = 'none';
    } else {
        profileMenu.style.display = 'block';
    }
});

// Закрытие меню профиля при клике вне его
window.addEventListener('click', function (event) {
    const profileMenu = document.getElementById('profileMenu');
    const profileButton = document.getElementById('profileButton');
    if (event.target !== profileButton && !profileButton.contains(event.target)) {
        profileMenu.style.display = 'none';
    }
});

// Функция для аккордеона
document.querySelectorAll('.category-header').forEach(header => {
    header.addEventListener('click', () => {
        header.classList.toggle('active');
        const submenu = header.nextElementSibling;
        if (submenu.style.display === 'block') {
            submenu.style.display = 'none';
        } else {
            submenu.style.display = 'block';
        }
    });
});