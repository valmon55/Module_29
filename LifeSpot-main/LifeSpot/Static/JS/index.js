/*let userAge = prompt("Укажите свой возраст:");
let today = new Date().toLocaleString();
let userAgent = new Map();

userAgent.set("Age", userAge);
userAgent.set("SessionDate", today);
userAgent.set("UserBrowser", window.navigator.userAgent);

if (userAge >= 18) {
    alert('Приветствуем на LifeSpot' + today);
}
else { 
    alert("Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены");
    window.location.href = "http://www.google.com";
}
*/
// создадим объект Map для хранения сессии
let session = new Map();
// Сохраним UserAgent
session.set("userAgent", window.navigator.userAgent)


// Запросим возраст пользователя и тоже сохраним
session.set("age", prompt("Пожалуйста, введите ваш возраст?"))

// Проверка на возраст и сохранение сессии
if (session.get("age") >= 18) {
    let startDate = new Date().toLocaleString();

    alert("Приветствуем на LifeSpot! " + '\n' + "Текущее время: " + startDate);
    session.set("startDate", startDate)
}
else {
    alert("Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены");
    window.location.href = "http://www.google.com"
    a = true + 20 + "name"
}

// Вывод в консоль
for (let result of session) {
    console.log(result)
}