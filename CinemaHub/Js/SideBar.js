

var nav = document.getElementById("nav");
var toggleBtn = document.getElementById("menu-toggle");
var toggleBtnSpan = document.querySelectorAll(".menu-toggle span");
var cnt = false;
toggleBtn.addEventListener("click", function () {
    if (cnt == false) {
        nav.classList.add("openNav");
        nav.classList.remove("closeNav");
        toggleBtnSpan[0].style.backgroundColor = "#fc9603";
        toggleBtnSpan[1].style.backgroundColor = "#fc9603";
        toggleBtnSpan[2].style.backgroundColor = "#fc9603";

        cnt = true;
    }

    else if (cnt == true) {
        nav.classList.add("closeNav");
        nav.classList.remove("openNav");
        cnt = false;
        toggleBtnSpan[0].style.backgroundColor = "#333";
        toggleBtnSpan[1].style.backgroundColor = "#333";
        toggleBtnSpan[2].style.backgroundColor = "#333";
    }
});