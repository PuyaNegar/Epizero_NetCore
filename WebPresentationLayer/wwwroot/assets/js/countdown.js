// Set the date we're counting down to
//var countDownDate = new Date("Aug 14, 2020 15:37:25").getTime();

let elems=document.querySelectorAll(".countdown_epizero");
elems.forEach((elem)=>{
    var x = setInterval(function () {
        let countDownDate=parseInt(elem.getAttribute("data-todate"));
        // Get todays date and time
        var now = new Date().getTime();
    
        // Find the distance between now an the count down date
        var distance = countDownDate - now;
    
        // Time calculations for days, hours, minutes and seconds
        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);
        
        days = formatted_string("00",days,"l");
        hours = formatted_string("00",hours,"l");
        minutes = formatted_string("00",minutes,"l");
        seconds = formatted_string("00",seconds,"l");
    
        // Output the result in an element with id="demo"
        elem.innerHTML = "<div class='number'><span class='txt'>" + days + "</span><span class='title'>روز</span> " + "</div>" + "<div class='number'><span class='txt'>" + hours + "</span><span class='title'>ساعت</span> " + "</div>" + "<div class='number'><span class='txt'>" + minutes + "</span><span class='title'>دقیقه</span> " + "</div>" + "<div class='number'><span class='txt'>" + seconds + "</span><span class='title'>ثانیه</span> " + "</div>";
    
        // If the count down is over, write some text 
        if (distance < 0) {
            clearInterval(x);
            elem.innerHTML = "<div class='expired'>زمان آزمون به اتمام رسیده</div>";
        }
    }, 1000);
})
// Update the count down every 1 second



function formatted_string(pad, user_str, pad_pos) {
    if (typeof user_str === 'undefined')
        return pad;
    if (pad_pos == 'l') {
        return (pad + user_str).slice(-pad.length);
    } else {
        return (user_str + pad).substring(0, pad.length);
    }
}
