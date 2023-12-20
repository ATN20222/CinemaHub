var Movise_1_Left=document.getElementById("Movise_1_Left");
var Movise_1_Right=document.getElementById("Movise_1_Right");
var Movise_1_Slider=document.querySelector(".Movise_1_Slider")


var position="0px";


Movise_1_Left.onclick=function(){
   Move_Left();
}



function Move_Left(){
    Movise_1_Slider.style.transform=" translateX(0px)";

};


Movise_1_Right.onclick=function(){
    Movise_1_Slider.style.transform=" translateX(-400px)";

}


var MenuBtn=document.getElementById("MenuBtn");
var Menu=document.querySelector(".Menu");
var MenuCloseBtn=document.getElementById("MenuClose");
var MenuClose=document.querySelector(".MenuClose");
var MenuOpen=document.querySelector(".MenuOpen");
var loginbox=document.querySelector(".login-box");
var ShowLogin=document.getElementById("ShowLogin");
var ShowHome=document.getElementById("ShowHome");
MenuBtn.onclick=function(){
    Menu.style.height="200px";
    MenuClose.style.height="30px";
    MenuClose.style.width="30px";
    MenuOpen.style.width="0px";
    MenuOpen.style.height="0px";

    
}

MenuCloseBtn.onclick=function(){
    Menu.style.height="30px";
    MenuOpen.style.width="30px";
    MenuOpen.style.height="30px";
    MenuClose.style.height="0px";
    MenuClose.style.width="0px";
}
ShowLogin.onclick=function(){
    loginbox.style.transform="rotateY(0deg)";
}


ShowHome.onclick=function(){
    loginbox.style.transform="rotateY(90deg)";
}


