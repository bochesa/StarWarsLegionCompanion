$(function () {
    $('[data-toggle="tooltip"]').tooltip({
        delay: {
            "show": 0,
            "hide": 0
        }
    });
});

//At some point Refactor the shit!!! Learn JavaScript
const collapseAvail1 = $("#group-avail-card-1");
const collapseAvail2 = $("#group-avail-card-2");
const collapseAvail3 = $("#group-avail-card-3");
const collapseAvail4 = $("#group-avail-card-4");
const collapseAvail5 = $("#group-avail-card-5");
const collapseAvail6 = $("#group-avail-card-6");

collapseAvail1.on("shown.bs.collapse", function () {
    localStorage.setItem("group-avail-card-1", "show");
});
collapseAvail2.on("shown.bs.collapse", function () {
    localStorage.setItem("group-avail-card-2", "show");
});
collapseAvail3.on("shown.bs.collapse", function () {
    localStorage.setItem("group-avail-card-3", "show");
});
collapseAvail4.on("shown.bs.collapse", function () {
    localStorage.setItem("group-avail-card-4", "show");
});
collapseAvail5.on("shown.bs.collapse", function () {
    localStorage.setItem("group-avail-card-5", "show");
});
collapseAvail6.on("shown.bs.collapse", function () {
    localStorage.setItem("group-avail-card-6", "show");
});


collapseAvail1.on("hidden.bs.collapse", function () {
    localStorage.setItem("group-avail-card-1", "hide");
});
collapseAvail2.on("hidden.bs.collapse", function () {
    localStorage.setItem("group-avail-card-2", "hide");
});
collapseAvail3.on("hidden.bs.collapse", function () {
    localStorage.setItem("group-avail-card-3", "hide");
});
collapseAvail4.on("hidden.bs.collapse", function () {
    localStorage.setItem("group-avail-card-4", "hide");
});
collapseAvail5.on("hidden.bs.collapse", function () {
    localStorage.setItem("group-avail-card-5", "hide");
});
collapseAvail6.on("hidden.bs.collapse", function () {
    localStorage.setItem("group-avail-card-6", "hide");
});

const showCollapseAvail1 = localStorage.getItem("group-avail-card-1");
const showCollapseAvail2 = localStorage.getItem("group-avail-card-2");
const showCollapseAvail3 = localStorage.getItem("group-avail-card-3");
const showCollapseAvail4 = localStorage.getItem("group-avail-card-4");
const showCollapseAvail5 = localStorage.getItem("group-avail-card-5");
const showCollapseAvail6 = localStorage.getItem("group-avail-card-6");

if (showCollapseAvail1 === "show") {
    collapseAvail1.collapse("show");
} else {
    collapseAvail1.collapse("hide");
}

if (showCollapseAvail2 === "show") {
    collapseAvail2.collapse("show");
} else {
    collapseAvail2.collapse("hide");
}

if (showCollapseAvail3 === "show") {
    collapseAvail3.collapse("show");
} else {
    collapseAvail3.collapse("hide");
}

if (showCollapseAvail4 === "show") {
    collapseAvail4.collapse("show");
} else {
    collapseAvail4.collapse("hide");
}

if (showCollapseAvail5 === "show") {
    collapseAvail5.collapse("show");
} else {
    collapseAvail5.collapse("hide");
}

if (showCollapseAvail6 === "show") {
    collapseAvail6.collapse("show");
} else {
    collapseAvail6.collapse("hide");
}
});