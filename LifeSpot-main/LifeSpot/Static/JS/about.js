//alert("about.js работает!");
function getFeedbackData()
{
    let feedback = {};
    feedback["name"] = prompt("Введите ваше имя:");
    if (feedback["name"] == null) { return };
    feedback["comment"] = prompt("Введите ваш комментарий");
    feedback["date"] = new Date().toLocaleString();

    addFeedback(feedback);
}
const addFeedback = feedback => 
{
    let elem = document.getElementsByClassName("review-button")[0];
    elem.innerHTML +=
        '    <div class="review-text">\n' +
        `<p> <i> <b>${feedback['name']}</b> ${feedback['date']}</i></p>` +
        `<p>${feedback['comment']}</p>` +
        "</div>";
}

