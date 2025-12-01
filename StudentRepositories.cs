using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDOM.Repositories
{
    internal class StudentRepositories
    {
        private readonly string _filePath;
        public StudentRepositoryTxt(string filePath = "students.txt")
        {
            _filePath = filePath;
        }

        public void Save(List<Student> students)
        {
            var lines = new List<string>();
            foreach (var s in students)
            {
                lines.Add($"{s.Name};{s.Grade}");
            }
            File.AppendAllLines(_filePath, lines);  // Дописва редове към файл
                                                    // File.WriteAllLines(_filePath, lines); // Презаписва целия файл
        }

        public List<Student> Load()
        {
            var list = new List<Student>();

            if (!File.Exists(_filePath))
                return list;

            //TODO  
            //1.Прочитане на всички редове от файл
            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                //2.Разделяне(Split) по ';'
                var parts = line.Split(';');
                //  * Първи елемент - име
                var name = parts[0];
                //  * Втори елемент - оценка
                var grade = int.Parse(parts[1]);
                //3.Създаване на Student
                var student = new Student(name, grade);
                //4.Добавяне в List < Student >
                list.Add(student);

            }

            return list;
        }
    }
}
}
