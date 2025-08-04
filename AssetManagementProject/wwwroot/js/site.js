document.addEventListener("DOMContentLoaded", function () {
    const collapsibles = document.querySelectorAll(".collapsible, .collapsibletwo");

    collapsibles.forEach((item) => {
        const toggleLink = item.querySelector(".toggle-link");
        const submenu = item.querySelector("ul");

        toggleLink.addEventListener("click", function (e) {
            e.preventDefault();

            submenu.classList.toggle("show");

            // Arrow direction toggle
            const currentArrow = toggleLink.textContent.includes("▾") ? "▾" : "▸";
            const newArrow = currentArrow === "▸" ? "▾" : "▸";
            toggleLink.textContent = toggleLink.textContent.replace(/▸|▾/, newArrow);
        });
    });
});

// ✅ Sidebar AJAX navigation + active class
$(document).ready(function () {
    $('.sidebar a').on('click', function (e) {
        const url = $(this).attr('href');

        if (url && !url.startsWith("http") && url !== "#") {
            e.preventDefault();

            // 🔄 Remove all existing .active classes
            $('.sidebar a').removeClass('active');

            // ✅ Add active to clicked link
            $(this).addClass('active');

            $('#ajax-container').fadeOut(200, function () {
                $('#ajax-container').load(url, function () {
                    $('#ajax-container').fadeIn(200);
                });
            });
        }
    });

    // Optional: back/forward button support
    $(window).on('popstate', function () {
        $('#ajax-container').load(location.pathname);
    });
});
