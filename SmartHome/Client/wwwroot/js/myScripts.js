window.PrepareData = () => {
    let settings = document.querySelectorAll("#settings input");
    let preparedData = {};

    for (var item of settings) {
        preparedData[item.getAttribute("name")] = String(item.value);
    }
    return JSON.stringify(preparedData);
}

window.EditDisplayName = (isEditing) => {
    let displaynamerow = document.querySelector("div.displayname-row");
    let child = displaynamerow.firstChild;
    let button = document.querySelector("div.displayname-row button");
    let text;
    if (!isEditing) {
        text = child.firstChild.innerHTML
        child.innerHTML = "<input type=\"text\" id=\"displayname\" name=\"displayname\" value=\"" + text + "\" />";
        button.innerHTML = "Save";
        button.classList.remove("displayname-edit-button-false");
        button.classList.add("displayname-edit-button-true");
    }
    else {
        text = document.querySelector("div.displayname-row input[type=\"text\"]").value;
        child.innerHTML = "<span>" + text + "</span>";
        button.innerHTML = "Edit";
        button.classList.remove("displayname-edit-button-true");
        button.classList.add("displayname-edit-button-false");
    }

    return text;
}

window.AuthorizeDevice = (name) => {
    const Http = new XMLHttpRequest();
    const url = 'http://server:60648/api/devices/authorizeDevice/' + name;
    Http.open("GET", url);
    Http.send();
}

var darkTheme = false;

window.GetDarkThemeStatus = () => {
    return darkTheme;
}

window.ToggleDarkTheme = () => {
    let elements = document.getElementsByClassName("dark-theme-component");
    let images = document.querySelectorAll("img.dark-theme-img");
    if (!darkTheme) {
        for (var i = 0; i < elements.length; i++) {
            elements[i].classList.add("dark-theme");
        }
        for (var i = 0; i < images.length; i++) {
            images[i].setAttribute("src", images[i].getAttribute("src").replace("/light/", "/dark/"));
        }
    }
    else {
        for (var i = 0; i < elements.length; i++) {
            elements[i].classList.remove("dark-theme");
        }
        for (var i = 0; i < images.length; i++) {
            images[i].setAttribute("src", images[i].getAttribute("src").replace("/dark/", "/light/"));
        }
    }
    darkTheme = !darkTheme;
}