using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher engin = new Teacher(mediator);
            engin.Name = "Engin";

            mediator.Teacher = engin;

            Student berat = new Student(mediator);
            berat.Name = "Berat";
            

            Student berkay = new Student(mediator);
            berkay.Name = "Berkay";

            mediator.Students = new List<Student> { berat, berkay };

            engin.SendNewImageUrl("slide.jpg");
            engin.RecieveQuestion("is it true",berat);

            Console.ReadLine();



        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;
        public CourseMember (Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }
        public Teacher(Mediator mediator): base(mediator)
        {

        }
       
        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieve a question from {0},{1}", student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} recieve image : {0}",url,Name);
        }
        

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieve answer {0}",answer);
        }

        public string Name { get; set; }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
