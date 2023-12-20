


var ProfileBtn=document.getElementById("ProfileBtn");
var ChangePasswordBtn=document.getElementById("ChangePasswordBtn");
var ChangePlanBtn=document.getElementById("ChangePlanBtn");
var LogoutBtn=document.getElementById("LogoutBtn");
var UserProfileField=document.querySelector(".UserProfileField");
var ChangePasswordField=document.querySelector(".ChangePasswordField");
var ChangePlanField=document.querySelector(".ChangePlanField");

var ChangeBtnColor=function(C){
    C.style.color="#fc9603";
    
}

var ResetBtnColor=function(C){
    C.style.color=" #4b505e";
    
}

ChangeBtnColor(ProfileBtn);
ProfileBtn.onclick=function(){
    ChangeBtnColor(ProfileBtn);
    ResetBtnColor(ChangePasswordBtn);
    ResetBtnColor(ChangePlanBtn);
    ResetBtnColor(LogoutBtn);
    UserProfileField.style.display="block";
    ChangePasswordField.style.display="none";
    ChangePlanField.style.display="none";
    
    
}


ChangePasswordBtn.onclick=function(){
    ChangeBtnColor(ChangePasswordBtn);
    ResetBtnColor(ProfileBtn);
    ResetBtnColor(ChangePlanBtn);
    ResetBtnColor(LogoutBtn);
    UserProfileField.style.display="none";
    ChangePasswordField.style.display="block";
    ChangePlanField.style.display="none";
}

ChangePlanBtn.onclick=function(){
    ChangeBtnColor(ChangePlanBtn);
    ResetBtnColor(ProfileBtn);
    ResetBtnColor(ChangePasswordBtn);
    ResetBtnColor(LogoutBtn);
    UserProfileField.style.display="none";
    ChangePasswordField.style.display="none";
    ChangePlanField.style.display="block";
}

LogoutBtn.onclick=function(){
    ChangeBtnColor(LogoutBtn);
    ResetBtnColor(ProfileBtn);
    ResetBtnColor(ChangePasswordBtn);
    ResetBtnColor(ChangePlanBtn);
}




