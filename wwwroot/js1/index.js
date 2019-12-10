document.addEventListener("DOMContentLoaded",function(){
    var x = document.getElementsByClassName('shop-cart');
    var x = x[0];
    
    var y = document.getElementsByClassName('gio-hang');
    var y = y[0];
    x.onclick = function(){
        y.classList.toggle('ra');
    }
},false)