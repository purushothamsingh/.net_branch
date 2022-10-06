Window.onload = function () {
    render();
}
function render() {
    window.recaptachaVerifier = new firebase.auth.recaptachaVerifier('recaptcha-container');
}
function phoneAuth() {
    debugger
    var a = document.getElementById("number").value;
    var b = +91;
    var number = b + a;
    firebase.auth.signInWithPhoneNumber(number, this.window.recaptachaVerifier).then(function (confirmationResult){

        this.window.confirmationResult = confirmationResult;
        coderesult = confirmationResult;
        console.log(coderesult);
        alert("Message sent")

    }).catch(function (error)){
        alert(error.message);
    }
});



function codeverify() {
    debugger
    var code = document.getElementById("verificationCode").value;
    coderesult = confirm.(code).then(function (result) {
        alert("Message Verified");
        var user = result.user;
        console.log(user);

    });




}