var vid=document.querySelector("video");
var img=document.querySelector(".card img");
// console.log(img.attributes.item(0).value);

var source=img.attributes.item(0).value.replace("jpg","mp4");

vid.attributes.item(2).value=source;