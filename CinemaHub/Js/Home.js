
var nav = document.getElementById("nav");

window.onscroll = function () {
    if (window.scrollY > 0) {
        nav.style.boxShadow = "rgba(0, 0, 0, 0.3) 0px 19px 38px, rgba(0, 0, 0, 0.22) 0px 15px 12px";

    } else {
        nav.style.boxShadow = "";

    }

}





var Movise_1_Left=document.getElementById("Movise_1_Left");
var Movise_1_Right=document.getElementById("Movise_1_Right");




var Movise_2_Left=document.getElementById("Movise_2_Left");
var Movise_2_Right=document.getElementById("Movise_2_Right");



var Movise_3_Left=document.getElementById("Movise_3_Left");
var Movise_3_Right=document.getElementById("Movise_3_Right");



//var Movise_Left=document.getElementById("Movise_Left");
//var Movise_Right=document.getElementById("Movise_Right");

var Movise_1_Slider = document.querySelector(".Movise_1_Slider");
var Movise_2_Slider = document.querySelector(".Movise_2_Slider");
var Movise_3_Slider = document.querySelector(".Movise_3_Slider");
//var Movise_Slider=document.querySelector(".Movise_Slider")




Movise_1_Left.onclick=function(){
    Movise_1_Slider.style.transform=" translateX(0px)";

}

Movise_1_Right.onclick=function(){
    Movise_1_Slider.style.transform=" translateX(-440px)";
 }


 Movise_2_Left.onclick=function(){
    Movise_2_Slider.style.transform=" translateX(0px)";
 }
 
 Movise_2_Right.onclick=function(){
    Movise_2_Slider.style.transform=" translateX(-440px)";
  }
 
  Movise_3_Left.onclick=function(){
    Movise_3_Slider.style.transform=" translateX(0px)";
 }
 
 Movise_3_Right.onclick=function(){
    Movise_3_Slider.style.transform=" translateX(-440px)";
  }
 
