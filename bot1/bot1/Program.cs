using System;
using MoscowVPN.Models;

namespace bot1
{
    internal class Program
    {
        // ВОТ ОН! Твой токен Telegram-бота возвращен на базу
        private static readonly string _botToken = "8927319649:AAGPXIGU3zpirmxf_cJ9R8NUu_oizRryjZo";

        private static void Main(string[] args)
        {
            Console.WriteLine("[Сервер] Запуск системы обучения...");

            // Создаем экземпляр репозитория
            CourseRepository repository = new CourseRepository();

            // Проверяем, что всё загрузилось успешно (без неоднозначных интерполяций строк)
            var modules = repository.GetAllModules();
            Console.WriteLine("============= СТРУКТУРА КУРСА =============");
            Console.WriteLine("[Успех] Загружено модулей: " + modules.Count);
            
            foreach (var module in modules)
            {
                // Используем классический безопасный формат вывода
                Console.WriteLine(" - Модуль: {0} (Уроков: {1})", module.Title, module.Lessons.Count);
            }
            Console.WriteLine("===========================================");

            Console.WriteLine("[Сервер] Токен бота успешно загружен.");
            Console.WriteLine("[Сервер] Ожидание подключений...");
            
            // Сюда дальше пойдет логика старта самого Telegram-бота (используя _botToken)
            // ...

            Console.ReadLine(); 
        }
    }
}