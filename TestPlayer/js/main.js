function GetData() {
    return {
        "orgs": [
            {
                "name": "ГМУ Ушакова",
                "groups": [
                    "1 1",
                    "1 2",
                    "1 3"
                ]
            },
            {
                "name": "НКСЭ",
                "groups": [
                    "2 1",
                    "2 2",
                    "2 3"
                ]
            },
            {
                "name": "Что-то ещё",
                "groups": [
                    "3 1",
                    "3 2",
                    "3 3"
                ]
            }
        ],
        "tests": [
            {
                "name": "Зависимое поведение",
                "answerType": "simple"
            },
            {
                "name": "Употребление наркотиков",
                "answerType": "simple"
            },
            {
                "name": "Девиантное поведение (МУЖ)",
                "answerType": "extended"
            },
            {
                "name": "Девиантное поведение (ЖЕН)",
                "answerType": "extended"
            },
        ]
    };
}

let TestData;

let global_wrapper;
let start_screen;

let org_select;
let grp_select;

let test_choose_screen;

let test_buttons;

let test_start_screen;
let current_test_title;

let test_question_screen;

let current_test;

$(document).ready(function() {
    TestData = GetData();

    global_wrapper = $("#global-wrapper");

    start_screen = $("#start-screen");
    test_choose_screen = $("#test-choose-screen");
    test_start_screen = $("#test-start-screen");
    current_test_title = $("#current-test-title");

    test_question_screen = $("#test-question-screen");

    org_select = $("#organization-select");
    grp_select = $("#group-select");
    test_buttons = $("#test-buttons");

    org_select.html(create_org_list(TestData.orgs));
    grp_select.html(create_grp_list(TestData.orgs[org_select.val()]));

    org_select.on("change", function() {
        grp_select.html(create_grp_list(TestData.orgs[org_select.val()]));
        org_select.css("background", "none");
    });

    grp_select.on("change", function() {
        grp_select.css("background", "none");
    });

    $("#start-testing-button").click(function() {
        hasError = false;

        if (org_select.val() < 0) {
            org_select.css("background", "red");
            hasError = true;
        }

        if (grp_select.val() < 0) {
            grp_select.css("background", "red");
            hasError = true;
        }

        if (!hasError) {
            start_screen.addClass("hidden");
            test_choose_screen.removeClass("hidden");
            global_wrapper.removeClass("bg1");
            global_wrapper.addClass("bg2");

            test_buttons.html(generate_tests_buttons(TestData.tests));
            generate_test_buttons_events(TestData.tests);
        }
    });

    $("#back-to-start-screen-button").click(function() {
        test_choose_screen.addClass("hidden");
        start_screen.removeClass("hidden");
        global_wrapper.removeClass("bg2");
        global_wrapper.addClass("bg1");
    });

    $("#back-to-test-choose-screen-button").click(function() {
        test_start_screen.addClass("hidden");
        test_choose_screen.removeClass("hidden");
    });

    $("#begin-selected-test-button").click(function() {
        let isConfirm = confirm("Приступить к выполнению теста?");
        if (isConfirm) {
            test_start_screen.addClass("hidden");
            test_question_screen.removeClass("hidden");
        }
    });
});

function create_org_list(orgs) {
    if (orgs == null || orgs.length < 1) {
        return create_list_item(-10, "[СПИСОК ПУСТ]");
    }

    let html = create_list_item(-1, "Выберите из списка...");

    for (let i = 0; i < orgs.length; i++) {
        html += create_list_item(i, orgs[i].name);
    }

    return html;
}

function create_grp_list(org) {
    if (org == null || org.groups.length < 1) {
        return create_list_item(-10, "");
    }
    else {
        let html = create_list_item(-1, "Выберите из списка...");

        for (let i = 0; i < org.groups.length; i++) {
            html += create_list_item(i , org.groups[i]);
        }

        return html;
    }
}

function create_list_item(value, text, extTags = "") {
    return `<option value="${value}" ${extTags}>${text}</option>\n`;
}

function generate_tests_buttons(tests) {
    if (tests == null) {
        return "";
    }

    let html = "";
    for (let i = 0; i < tests.length; i++) {
        html += create_test_button(i, tests[i].name);

        $(`#test-${i}-button`).click(function() {
            current_test = TestData.tests[i];
            current_test_title.html(current_test.name);
            test_choose_screen.addClass("hidden");
            test_start_screen.removeClass("hidden");
        });
    }

    return html;
}

function create_test_button(index, name) {
    return `<input type="button" id="test-${index}-button" value="${name}" class="button test-button">\n`;
}

function generate_test_buttons_events(tests) {
    if (tests == null) {
        return;
    }

    for (let i = 0; i < tests.length; i++) {
        $(`#test-${i}-button`).click(function() {
            current_test = TestData.tests[i];
            current_test_title.html(current_test.name);
            test_choose_screen.addClass("hidden");
            test_start_screen.removeClass("hidden");
        });
    }
}