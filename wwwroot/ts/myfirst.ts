import $ from "jquery";

function greeting(txt: string, time: string): string {    
    $("#x").html("hallo");
    return `${time} ${txt}`;
}

var g = greeting("Hallo Welt", "9:00");

let A = 99;
