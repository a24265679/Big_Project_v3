﻿document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('toggleButton').addEventListener('click', function () {
        var leftNavbar = document.querySelector('.left_navbar');
        var overlay = document.querySelector('.overlay');

        // 切換側邊欄
        leftNavbar.classList.toggle('translate');

        // 顯示或隱藏遮罩層
        if (leftNavbar.classList.contains('translate')) {
            overlay.style.display = 'block'; // 顯示遮罩層
        } else {
            overlay.style.display = 'none'; // 隱藏遮罩層
        }
    });

    // 點擊遮罩層時，隱藏側邊欄和遮罩層
    document.querySelector('.overlay').addEventListener('click', function () {
        var leftNavbar = document.querySelector('.left_navbar');
        var overlay = document.querySelector('.overlay');

        leftNavbar.classList.remove('translate');
        overlay.style.display = 'none';
    });

    // 顯示左側導覽列當前頁籤
    // 使用 JavaScript 或 jQuery 來手動添加和移除 .active 類
    // 選擇所有 class 為 .nav-link 的連結元素
    const links = document.querySelectorAll('.nav-link');
    // 遍歷所有選中的 .nav-link 元素
    links.forEach(link => {
        // 檢查每個連結的 href 是否與當前頁面的 URL 相同
        if (link.href === window.location.href) {
            // 如果相同，為該連結添加 'active' 類，這樣它就會顯示為活動狀態
            link.classList.add('active');
        }
    });
});

