
var SearchBtn = document.getElementById("SearchBtn");
var SearchField = document.querySelector(".SearchField");
var SearchIcon = document.querySelector(".SearchIcon");

SearchField.classList.remove("Open");


SearchBtn.onclick = function () {
    SearchField.classList.add("Open");
}


var HomeBtn = document.getElementById("HomeBtn");
var MoviseBtn = document.getElementById("MoviseBtn");
var SeriesBtn = document.getElementById("SeriesBtn");
var MyListBtn = document.getElementById("MyListBtn");
var Home = document.querySelector(".Home");
var body = document.querySelector(".body");



var nav = document.getElementById("nav");
var toggleBtn = document.getElementById("menu-toggle");
var toggleBtnSpan = document.querySelectorAll(".menu-toggle span");
var cnt = false;
toggleBtn.addEventListener("click", function () {
    if (cnt == false) {
        nav.classList.add("openNav");
        nav.classList.remove("closeNav");
        toggleBtnSpan[0].style.backgroundColor ="#fc9603";
        toggleBtnSpan[1].style.backgroundColor ="#fc9603";
        toggleBtnSpan[2].style.backgroundColor ="#fc9603";
        
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