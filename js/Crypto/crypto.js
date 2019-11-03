let jssha = require('jssha');

function hex2dec(s) { return parseInt(s, 16); }

let shaObj = new jssha('SHA-1', 'HEX');
shaObj.setHMACKey('48656c6c6f21deadbeef', 'HEX');
shaObj.update('00000000031ff27b');

let hmac = shaObj.getHMAC("HEX");
console.log(`HMAC SHA1 : ${hmac}`);

let offset = hex2dec(hmac.substring(hmac.length - 1));
let otp = (hex2dec(hmac.substr(offset * 2, 8)) & hex2dec('7fffffff')) + '';
otp = (otp).substr(otp.length - 6, 6);
console.log(`OTP : ${otp}`);
