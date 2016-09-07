$(document).ready(function() {
    var navbar = document.getElementById('navbarId');
    var darkSide = document.getElementById('isDarkSide').value;
    if (darkSide === 'false') {
        navbar.className = "navbar navbar-default navbar-fixed-top";
        alert("Lol. There is no way out! \n P.S. Your HR Departament has been contacted!");
    } else {
        navbar.className = "navbar navbar-inverse navbar-fixed-top";
    }
});