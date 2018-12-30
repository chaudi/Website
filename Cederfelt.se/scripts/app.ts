//Person is now string
function Welcome(person: string) {
    return "Hello, " + person;
}

function ClickMeButton() {
    var user = "Mithun Pattankar";
    document.getElementById("divMsg").innerHTML = Welcome(user);
}