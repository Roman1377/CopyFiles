using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            // Запит шляхів до файлів
            Console.Write("Введіть шлях до вихідного файлу: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Введіть шлях до файлу, в який потрібно скопіювати дані: ");
            string destinationPath = Console.ReadLine();

            // Перевірка, чи існує вихідний файл
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Помилка: вихідний файл не знайдено.");
                return;
            }

            // Читання і запис вмісту файлу
            string content = File.ReadAllText(sourcePath);
            File.WriteAllText(destinationPath, content);

            Console.WriteLine("Файл успішно скопійовано!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Помилка: недостатньо прав доступу до файлу.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Помилка вводу/виводу: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася непередбачена помилка: {ex.Message}");
        }
    }
}
