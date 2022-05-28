using System;
using System.Collections.Generic;
using System.IO;

namespace phase_student
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string dir = Directory.GetCurrentDirectory();
            string filename = dir + "\\project.txt";

            static void update(string filename)
            {
                List<student> liststudent = new List<student>();

                string[] arrstudent = System.IO.File.ReadAllLines(filename);

                foreach (string line in arrstudent)
                {
                    string[] l = line.Split(',');
                    student _student = new student();
                    _student.Id = l[0];
                    _student.FirstName = l[1];
                    _student.LastName = l[2];
                    _student.CClass = l[3];
                    _student.Section = l[4];
                    liststudent.Add(_student);

                }
                string id;
                Console.WriteLine("Enter the id you want to update:");
                id = Console.ReadLine();
                foreach (student t in liststudent)
                {
                    if (t.Id == id)
                    {
                        Console.WriteLine("enter first name:");
                        string ufirstname = Console.ReadLine();
                        Console.WriteLine("enter last name:");
                        string ulastname = Console.ReadLine();
                        Console.WriteLine("enter class:");
                        string uclass = Console.ReadLine();
                        Console.WriteLine("enter section:");
                        string usection = Console.ReadLine();
                        t.FirstName = ufirstname;
                        t.LastName = ulastname;
                        t.CClass = uclass;
                        t.Section = usection;
                        Console.WriteLine("updated one is:");
                        Console.WriteLine($"{ t.Id},{ t.FirstName},{ t.LastName},{ t.CClass},{ t.Section}");


                        break;

                    }
                }
                int count = 0;
                string[] arr = new string[liststudent.Count];
                foreach (student t1 in liststudent)
                {
                    string s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                    arr[count] = s;
                    count++;

                }
                File.WriteAllLines(filename, arr);


            }
            static void create(string filename)
            {
                string UIId = "";
                string UIFirstName = "";
                string UILastName = "";
                string UIClass = "";
                string UIsection = "";
                using (FileStream fs = new FileStream(filename, FileMode.Append))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    student teacher = new student();
                    teacher.Id = UIId;
                    teacher.FirstName = UIFirstName;
                    teacher.LastName = UILastName;
                    teacher.CClass = UIClass;
                    teacher.Section = UIsection;

                    Console.WriteLine(" enter additional data to create?");


                    Console.WriteLine("Please enter the student id: ");
                    UIId = Console.ReadLine();
                    Console.WriteLine("Please enter the student firstname: ");
                    UIFirstName = Console.ReadLine();
                    Console.WriteLine("Please enter the student Lastname: ");
                    UILastName = Console.ReadLine();
                    Console.WriteLine("Please enter the student class: ");
                    UIClass = Console.ReadLine();
                    Console.WriteLine("Please enter the section: ");
                    UIsection = Console.ReadLine();
                    string fullText = (UIId + "," + UIFirstName + "," + UILastName + "," + UIClass + "," + UIsection);
                    sw.WriteLine(fullText);
                }
            }
            static void delete(string filename)
            {
                List<student> liststudent = new List<student>();
                string teacherfile = filename;
                string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);

                foreach (string line in arrteacher)
                {
                    string[] l = line.Split(',');
                  student teacher = new student();
                    teacher.Id = l[0];
                    teacher.FirstName = l[1];
                    teacher.LastName = l[2];
                    teacher.CClass = l[3];
                    teacher.Section = l[4];
                    liststudent.Add(teacher);

                }
                string id;
                Console.WriteLine("Enter the id to delete:");
                id = Console.ReadLine();
                foreach (student t in liststudent)
                {
                    if (t.Id == id)
                    {
                        liststudent.Remove(t);
                        break;

                    }

                }

                int count = 0;
                string[] arr = new string[liststudent.Count];
                foreach (student t1 in liststudent)
                {
                    string s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                    arr[count] = s;
                    count++;

                }
                File.WriteAllLines(filename, arr);

            }

            static void search(string filename)
            {
                List<student> liststudent = new List<student>();
                string teacherfile = filename;
                string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);

                foreach (string line in arrteacher)
                {
                    string[] l = line.Split(',');
                    student teacher = new student();
                    teacher.Id = l[0];
                    teacher.FirstName = l[1];
                    teacher.LastName = l[2];
                    teacher.CClass = l[3];
                    teacher.Section = l[4];
                    liststudent.Add(teacher);

                }
                Console.WriteLine("enter lastname to search:");
                string last_name = Console.ReadLine();
                foreach (student t in liststudent)
                {
                    if (t.LastName == last_name)
                    {
                        Console.WriteLine("given student {0} is present in the given file", last_name);
                        Console.WriteLine($"student Id: { t.Id} , student Firstname: { t.FirstName} , student Lastname: { t.LastName} , student Class: { t.CClass} , student Section: { t.Section}");
                        break;

                    }
                }

            }
            static void display(string filename)
            {

                static void firstname(string filename)
                {
                    List<student> liststudent = new List<student>();
                    string teacherfile = filename;
                    string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);
                    foreach (string line in arrteacher)
                    {
                        string[] l = line.Split(',');
                        student teacher = new student();
                        teacher.Id = l[0];
                        teacher.FirstName = l[1];
                        teacher.LastName = l[2];
                        teacher.CClass = l[3];
                        teacher.Section = l[4];
                        liststudent.Add(teacher);

                    }
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("After sorting by First Name:");
                    liststudent.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));

                    foreach (student s in liststudent)
                    {
                        Console.WriteLine($"Teacher Id: { s.Id} , Teacher Firstname: { s.FirstName} , Teacher Lastname: { s.LastName} , Teacher Class: { s.CClass} , Teacher Section: { s.Section}");


                    }
                }
                static void id(string filename)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("After sorting by Id:");
                    List<student> liststudent= new List<student>();
                    string teacherfile = filename;
                    string[] arrteacher = System.IO.File.ReadAllLines(teacherfile);
                    foreach (string line in arrteacher)
                    {
                        string[] l = line.Split(',');
                        student teacher = new student();
                        teacher.Id = l[0];
                        teacher.FirstName = l[1];
                        teacher.LastName = l[2];
                        teacher.CClass = l[3];
                        teacher.Section = l[4];
                        liststudent.Add(teacher);
                    }



                    liststudent.Sort((a, b) => a.Id.CompareTo(b.Id));

                    foreach (student s in liststudent)
                    {
                        Console.WriteLine($"Teacher Id: { s.Id} , Teacher Firstname: { s.FirstName} , Teacher Lastname: { s.LastName} , Teacher Class: { s.CClass} , Teacher Section: { s.Section}");


                    }

                    int count = 0;
                    string[] arr = new string[liststudent.Count];
                    foreach (student t1 in liststudent)
                    {
                        string s = ($"{t1.Id},{t1.FirstName},{t1.LastName},{t1.CClass},{t1.Section}");
                        arr[count] = s;
                        count++;

                    }
                    File.WriteAllLines(@"C:\project\Teacher.txt", arr);


                }
                firstname(filename);
                id(filename);

            }
            bool s = true;
            while (s)
            {
                int option;
                Console.WriteLine("1.create\n2.update\n3.delete\n4.search\n5.display\n6.Exit");
                Console.WriteLine("Enter Option You want to perform: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        create(filename);
                        break;
                    case 2:
                        update(filename);
                        break;
                    case 3:
                        delete(filename);
                        break;
                    case 4:
                        search(filename);
                        break;
                    case 5:
                        display(filename);
                        break;
                    case 6:
                        s = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }

        }
    }
}
