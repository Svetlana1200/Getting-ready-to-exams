# Getting-ready-to-exams

Данный проект представляет собой веб-приложение для подготовки к НТК по английскому языку.<br>
Над проектом работали студентки группы ФТ-202: Дюжева Мария, Семёнова Светлана, Ясинецкая Александра.

Проект создан на платформе ASP.NET Core MVC. В качестве базы данных используется MongoDB.<br>
Задания взяты с сайта https://www.englishapple.ru/, для парсинга HTML-страниц и загрузки заданий в базу данных создан отдельный проект [Downloading to DB](Downloading%20to%20DB).<br>
Приложение развёрнуто на платформе Microsoft Azure: https://english-test-urfu.azurewebsites.net/<br>

Точки расширения проекта:<br>
1. Добавление новых типов заданий (интерфейс [ITask](EnglishTest/Models/ITask.cs) для самого задания и интерфейс [IAnswer](EnglishTest/Models/IAnswer.cs) для проверки ответа на задание).<br>
2. Добавление новых типов тренировок (абстрактный класс [Training](EnglishTest/Models/Training.cs)).<br>
3. Добавление новых условий окончания тренировки (интерфейс [ITrainingEndCondition](EnglishTest/Models/ITrainingEndCondition.cs)).<br>

Сборка зависимостей происходит в классе [Startup](EnglishTest/Startup.cs) в методе [ConfigureServices](EnglishTest/Startup.cs#L22).<br>

Проект создан в соответствии с паттерном MVC.<br>
Классы, расположенные в папке [Models](EnglishTest/Models), моделируют предметную область: задания, ответы, тренировки, условия окончания тренировок и результаты.<br>
Слой пользовательского интерфейса реализован с помощью представлений, расположенных в папке [Views](EnglishTest/Views).<br>
[Контроллер](EnglishTest/Controllers/HomeController.cs) обеспечивает связь между пользователем и приложением.<br>
Такие классы, как [SessionExtensions](EnglishTest/Controllers/SessionExtensions.cs) и [EnumExtensions](EnglishTest/Models/EnumExtensions.cs) составляют инфраструктуру проекта.
