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
                "answerType": "simple",
                "questions": [
                    { "number": 1, "text": "Первый вопрос первого теста"},
                    { "number": 2, "text": "Второй вопрос первого теста"},
                ]
            },
            {
                "name": "Употребление наркотиков",
                "answerType": "simple",
                "questions": [
                    { "number": 1, "text": "Первый вопрос второго теста"}
                ]
            },
            {
                "name": "Девиантное поведение (МУЖ)",
                "answerType": "extended",
                "questions": [
                    { "number": 1, "text": "Первый вопрос третьего теста"}
                ]
            },
            {
                "name": "Девиантное поведение (ЖЕН)",
                "answerType": "extended",
                "questions": [
                    { "number": 1, "text": "Первый вопрос четвертого теста"}
                ]
            }
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
let current_question = 1;

let percents;
let time;
let current_question_text;

let previous_question_button;
let next_question_button;

$(document).ready(function() {
    TestData = GetData();
    current_test = TestData.tests[0]; //FIXME убрать после теста

    global_wrapper = $("#global-wrapper");

    start_screen = $("#start-screen");
    test_choose_screen = $("#test-choose-screen");
    test_start_screen = $("#test-start-screen");
    current_test_title = $("#current-test-title");

    test_question_screen = $("#test-question-screen");

    percents = $("#percents");
    time = $("#time");
    current_question_text = $("#current-question");

    previous_question_button = $("#previous-question-button");
    next_question_button = $("#next-question-button");

    org_select = $("#organization-select");
    grp_select = $("#group-select");
    test_buttons = $("#test-buttons");

    org_select.html(create_org_list(TestData.orgs));
    grp_select.html(create_grp_list(TestData.orgs[org_select.val()]));

    org_select.on("change", function() {
        grp_select.html(create_grp_list(TestData.orgs[org_select.val()]));

        org_select.css("background-color", "white");
        org_select.hover((e) => {
            $(this).css("background-color", e.type === "mouseenter" ? "#e7e7e7" : "white");
        })
    });

    grp_select.on("change", function() {
        grp_select.css("background-color", "white");
        grp_select.hover((e) => {
            $(this).css("background-color", e.type === "mouseenter" ? "#e7e7e7" : "white");
        });
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
            begin_test();
        }
    });

    begin_test(); //FIXME убрать после теста
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

let questions_passed = 1;

let answers = [];

function begin_test() {
    update_current_test_screen();


}

function update_current_test_screen() {
    current_question_text.html(current_test.questions[current_question - 1].text);

    percents.html(`${questions_passed / current_test.questions.length * 100}%`);

    if (current_question <= 1) {
        previous_question_button.css("display", "none");
    } else {
        previous_question_button.css("display", "block");
    }

    if (current_question >= questions_passed) {
        next_question_button.css("display", "none");
    } else {
        next_question_button.css("display", "block");
    }
}
