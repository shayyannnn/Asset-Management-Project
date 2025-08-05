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
function renderAssetsByCategoryChart(labels, dataValues) {
    const canvas = document.getElementById('assetsByCategoryChart');
    if (!canvas) return;

    const ctx = canvas.getContext('2d');

    const existingChart = Chart.getChart(ctx);
    if (existingChart) {
        existingChart.destroy();
    }

    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: 'Assets by Category',
                data: dataValues,
                backgroundColor: [
                    '#6a5acd', '#20b2aa', '#ffcc00', '#ff6347',
                    '#2e8b57', '#ff8c00', '#8b0000'
                ],
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'right'
                }
            }
        }
    });
}

$(document).ready(function () {
    $('.sidebar a').on('click', function (e) {
        const url = $(this).attr('href');

        if (url && !url.startsWith("http") && url !== "#") {
            e.preventDefault();

            $('.sidebar a').removeClass('active');
            $(this).addClass('active');

            $('#ajax-container').fadeOut(200, function () {
                $('#ajax-container').load(url, function () {
                    $('#ajax-container').fadeIn(200, function () {

                        const labelsScript = document.getElementById('assetCategoryLabelsJson');
                        const dataScript = document.getElementById('assetCategoryDataJson');

                        if (labelsScript && dataScript) {
                            const labels = JSON.parse(labelsScript.textContent || '[]');
                            const dataValues = JSON.parse(dataScript.textContent || '[]');
                            renderAssetsByCategoryChart(labels, dataValues);
                        }
                    });
                });
            });
        }
    });

    $(window).on('popstate', function () {
        $('#ajax-container').load(location.pathname);
    });

    const labelsScript = document.getElementById('assetCategoryLabelsJson');
    const dataScript = document.getElementById('assetCategoryDataJson');

    if (labelsScript && dataScript) {
        const labels = JSON.parse(labelsScript.textContent || '[]');
        const dataValues = JSON.parse(dataScript.textContent || '[]');
        renderAssetsByCategoryChart(labels, dataValues);
    }
});



