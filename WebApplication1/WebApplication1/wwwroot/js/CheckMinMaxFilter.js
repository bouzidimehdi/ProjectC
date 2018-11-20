function checkmin() {
    var minimum = document.getElementById("min").value;
    var maximum = document.getElementById("max").value;

    if (number(minimum) < number(maximum)) {
        return true;
    } else {
        alert("The minimum value cannot be higher then the maximum value!");
        return false;
    }
}

function checkMinRealTime() {
    var minimum = parseInt(document.getElementById("min").value, 10);
    var maximum = parseInt(document.getElementById("max").value, 10);

    if (minimum < 1) {
        minimum = 1;
    }

    if (maximum < 2) {
        maximum = 2;
    }

    if (minimum > maximum) {
        minimum = maximum - 1;
    }

    document.getElementById("min").value = minimum;
    document.getElementById("max").value = maximum;
}