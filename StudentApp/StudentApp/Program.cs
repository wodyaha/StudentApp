using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var context = new StudentContext();
        while (true)
        {
            Console.WriteLine("\n1 - Добавить студента\n2 - Показать студентов\n3 - Обновить студента\n4 - Удалить студента\n5 - Выход");
            Console.Write("Выбор: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Имя: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Фамилия: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Дата рождения (гггг-мм-дд): ");
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());

                    var student = new Student { FirstName = firstName, LastName = lastName, BirthDate = birthDate };
                    context.Students.Add(student);
                    context.SaveChanges();
                    Console.WriteLine("Студент добавлен.");
                    break;

                case "2":
                    var students = context.Students.ToList();
                    students.ForEach(s => Console.WriteLine($"{s.Id}: {s.FirstName} {s.LastName}, {s.BirthDate:d}"));
                    break;

                case "3":
                    Console.Write("ID студента: ");
                    int idToUpdate = int.Parse(Console.ReadLine());
                    var updateStudent = context.Students.Find(idToUpdate);
                    if (updateStudent != null)
                    {
                        Console.Write("Новое имя: ");
                        updateStudent.FirstName = Console.ReadLine();
                        Console.Write("Новая фамилия: ");
                        updateStudent.LastName = Console.ReadLine();
                        Console.Write("Новая дата рождения: ");
                        updateStudent.BirthDate = DateTime.Parse(Console.ReadLine());
                        context.SaveChanges();
                        Console.WriteLine("Обновлено.");
                    }
                    else Console.WriteLine("Студент не найден.");
                    break;

                case "4":
                    Console.Write("ID студента: ");
                    int idToDelete = int.Parse(Console.ReadLine());
                    var deleteStudent = context.Students.Find(idToDelete);
                    if (deleteStudent != null)
                    {
                        context.Students.Remove(deleteStudent);
                        context.SaveChanges();
                        Console.WriteLine("Удалено.");
                    }
                    else Console.WriteLine("Студент не найден.");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}
