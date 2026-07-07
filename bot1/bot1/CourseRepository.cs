using System;
using System.Collections.Generic;
using System.Linq;

namespace MoscowVPN.Models // Название пространства имен под твой проект (при необходимости скорректируй)
{
    public enum CourseLevel
    {
        JuniorMinus,
        Junior,
        Middle
    }

    public class Lesson
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string MarkdownContent { get; set; } = string.Empty;
        public string PracticeTask { get; set; } = string.Empty;
        public string CorrectCode { get; set; } = string.Empty;
        public int XpReward { get; set; }
        public string PrerequisiteLessonId { get; set; } = string.Empty; // ID урока, который нужно пройти до этого
    }

    public class Module
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public CourseLevel Level { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }

    public class CourseRepository
    {
        private readonly List<Module> _modules = new List<Module>();

        public CourseRepository()
        {
            InitializeCourseStructure();
        }

        /// <summary>
        /// Возвращает все модули со всеми уроками
        /// </summary>
        public List<Module> GetAllModules()
        {
            return _modules;
        }

        /// <summary>
        /// Поиск урока по его ID во всех модулях
        /// </summary>
        public Lesson? GetLessonById(string lessonId)
        {
            return _modules.SelectMany(m => m.Lessons).FirstOrDefault(l => l.Id == lessonId);
        }

        /// <summary>
        /// Проверка правильности решения практического задания
        /// </summary>
        public bool CheckAnswer(string lessonId, string userCode)
        {
            var lesson = GetLessonById(lessonId);
            if (lesson == null) return false;

            // Очищаем код пользователя и правильный ответ от лишних пробелов по краям для точности проверки
            string cleanUserCode = userCode.Trim().Replace("\r\n", "\n");
            string cleanCorrectCode = lesson.CorrectCode.Trim().Replace("\r\n", "\n");

            return cleanUserCode == cleanCorrectCode;
        }

        /// <summary>
        /// Полная инициализация контента курса: 3 модуля, 7 уроков
        /// </summary>
        private void InitializeCourseStructure()
        {
            // ==========================================
            // МОДУЛЬ 1: Основы синтаксиса (Junior-)
            // ==========================================
            var syntaxModule = new Module
            {
                Id = "mod_syntax",
                Title = "1. Знакомство с Python",
                Level = CourseLevel.JuniorMinus
            };

            // Урок 1: Вводный
            syntaxModule.Lessons.Add(new Lesson
            {
                Id = "lesson_hello",
                Title = "Твоя первая программа",
                Description = "Узнаем, как устроен вывод данных в Python и напишем Hello World.",
                MarkdownContent = "# Вывод данных\\n\\nВ Python для вывода текста на экран используется встроенная функция `print()`. Текст внутри функции обязательно оборачивается в кавычки (одинарные или двойные).\\n\\n```python\\nprint('Привет, Telegram!')\\n```",
                PracticeTask = "Напиши команду print, которая выведет на экран слово: Python",
                CorrectCode = "print('Python')",
                XpReward = 20,
                PrerequisiteLessonId = "" // Доступен сразу
            });

            // Урок 2: Переменные
            syntaxModule.Lessons.Add(new Lesson
            {
                Id = "lesson_vars",
                Title = "Переменные и их создание",
                Description = "Поймем, как Python сохраняет данные в памяти без явного указания типов.",
                MarkdownContent = "# Переменные\\n\\nВ Python переменная создается в момент присваивания ей значения через знак `=`. Имя переменной не должно начинаться с цифр.\\n\\n```python\\nx = 10\\nname = 'Alex'\\n```",
                PracticeTask = "Создай переменную с именем age и присвой ей числовое значение 25",
                CorrectCode = "age = 25",
                XpReward = 25,
                PrerequisiteLessonId = "lesson_hello"
            });

            // Урок 3: Типы данных
            syntaxModule.Lessons.Add(new Lesson
            {
                Id = "lesson_types",
                Title = "Типы данных: Строки и Числа",
                Description = "Разберем разницу между целыми числами (int), дробными (float) и текстом (str).",
                MarkdownContent = "# Типы данных\\n\\nPython автоматически понимает тип: `a = 5` (целое число), `b = 5.5` (дробное), `c = '5'` (строка). Складывать строку с числом напрямую нельзя!\\n\\nДля перевода текста в целое число используется функция `int()`.\\n\\n```python\\nnum = int('10') # Переведет строку в число\\n```",
                PracticeTask = "У тебя есть переменная s = '42'. Переведи её в целое число с помощью функции int() и запиши результат в переменную с именем result.",
                CorrectCode = "result = int(s)",
                XpReward = 30,
                PrerequisiteLessonId = "lesson_vars"
            });

            _modules.Add(syntaxModule);


            // ==========================================
            // МОДУЛЬ 2: Управляющие конструкции (Junior)
            // ==========================================
            var logicModule = new Module
            {
                Id = "mod_logic",
                Title = "2. Условия и Списки",
                Level = CourseLevel.Junior
            };

            // Урок 4: Условия (if-else)
            logicModule.Lessons.Add(new Lesson
            {
                Id = "lesson_if",
                Title = "Конструкция ветвления if-else",
                Description = "Научим программу принимать решения в зависимости от условий.",
                MarkdownContent = "# Условия if-else\\n\\nВ Python блоки кода выделяются отступами (4 пробела). Знак `:` обязателен после условий.\\n\\n```python\\nif score > 50:\\n    print('Победа')\\nelse:\\n    print('Проигрыш')\\n```",
                PracticeTask = "Напиши условие: если переменная x больше 10, то создай переменную y со значением True (с большой буквы, без кавычек). Отступы делай обычными пробелами.",
                CorrectCode = "if x > 10:\\n    y = True",
                XpReward = 35,
                PrerequisiteLessonId = "lesson_types"
            });

            // Урок 5: Списки
            logicModule.Lessons.Add(new Lesson
            {
                Id = "lesson_lists",
                Title = "Работа со списками (массивами)",
                Description = "Изучим, как хранить коллекции элементов в одной переменной.",
                MarkdownContent = "# Списки (Lists)\\n\\nСписок создается в квадратных скобках. Элементы разделяются запятыми. Чтобы добавить элемент в конец списка, используют метод `.append()`.\\n\\n```python\\nmy_list = [1, 2, 3]\\nmy_list.append(4) # Теперь список [1, 2, 3, 4]\\n```",
                PracticeTask = "Добавь в список с именем users строку 'admin' с помощью метода append",
                CorrectCode = "users.append('admin')",
                XpReward = 40,
                PrerequisiteLessonId = "lesson_if"
            });

            _modules.Add(logicModule);


            // ==========================================
            // МОДУЛЬ 3: Продвинутые концепции (Middle)
            // ==========================================
            var advancedModule = new Module
            {
                Id = "mod_advanced",
                Title = "3. Функции и Асинхронность",
                Level = CourseLevel.Middle
            };

            // Урок 6: Функции
            advancedModule.Lessons.Add(new Lesson
            {
                Id = "lesson_functions",
                Title = "Создание собственных функций",
                Description = "Учимся инкапсулировать код для повторного использования с помощью def.",
                MarkdownContent = "# Функции\\n\\nФункции объявляются ключевым словом `def`. Результат возвращается через `return`.\\n\\n```python\\ndef greet(name):\\n    return 'Привет, ' + name\\n```",
                PracticeTask = "Создай простую функцию с именем get_data, которая не принимает аргументов и просто возвращает число 100",
                CorrectCode = "def get_data():\\n    return 100",
                XpReward = 45,
                PrerequisiteLessonId = "lesson_lists"
            });

            // Урок 7: Асинхронность
            advancedModule.Lessons.Add(new Lesson
            {
                Id = "lesson_asyncio",
                Title = "Основы asyncio и Event Loop",
                Description = "Разбираемся, как работает конкурентность в однопоточном приложении.",
                MarkdownContent = "# Библиотека asyncio\\n\\nАсинхронные функции создаются с помощью связки `async def`, а вызываются внутри других асинхронных функций через ключевое слово `await`.\\n\\n```python\\nimport asyncio\\nasync def main():\\n    await asyncio.sleep(1)\\n```",
                PracticeTask = "Каким ключевым словом создается асинхронная функция?",
                CorrectCode = "async def",
                XpReward = 50,
                PrerequisiteLessonId = "lesson_functions"
            });

            _modules.Add(advancedModule);
        }
    }
}