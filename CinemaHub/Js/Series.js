
var Movise_Left = document.getElementById("Movise_Left");
var Movise_Right = document.getElementById("Movise_Right");


Movise_Left.onclick = function () {
    Movise_Slider.style.transform = " translateX(0px)";

}

Movise_Right.onclick = function () {
    Movise_Slider.style.transform = " translateX(-440px)";
}

