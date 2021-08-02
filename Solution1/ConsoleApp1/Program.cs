using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            {
                int nr3;
                int nr4;
                string name;
                int age;
                string mail;
                int nr1;
                //newFile()
                int nr2;
                Console.WriteLine("Hello World!");
                try
                {
                    name = checkName();
                    age = checkAge(name);
                    mail = checkMail(name, age);
                    Console.WriteLine($@"HEllo,{name}!
Enter the dividend:");
                    nr1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Enter a divisor:");
                    nr2 = Convert.ToInt32(Console.ReadLine());
                    nr3 = nr1 / nr2;
                    Console.WriteLine("Enter a result");
                    nr4 = Convert.ToInt32(Console.ReadLine());
                    if (nr3 == nr4)
                    {
                        Console.WriteLine($@"Well done!!
Name:{name} mail:{mail} age: {age}");
                        scriereFiser("WriteLines.txt", $"Correct answer:{name} mail:{mail} age: {age}");
                    }
                    else
                    {
                        Console.WriteLine($@"Ups, your answer was wrong!!
Name:{name} mail:{mail} age: {age}");
                        scriereFiser("WriteLines.txt", $"Correct answer:{name} mail:{mail} age: {age}");

                    }
                }
                catch (UserException a)
                {

                    Console.WriteLine(a.Message);

                }
                catch (DivideByZeroException a)
                {
                    Console.WriteLine(a.Message);
                    scriereFiser("WriteLines.txt", "0 erorr");

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    scriereFiser("WriteLines.txt", "format erorr");
                }
                finally
                {

                    Console.WriteLine("Te mai asteptam!");
                }
            }


            static string checkName()
            {

                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine();
                if (name.Length < 3 || (name[0] > 'Z' && name[0] < 'A'))
                {
                    scriereFiserEroareName("WriteLines.txt", "Name wrong", name);
                    throw new UserException("Name wrong");
                    
                }
                return name;
            }
            static int checkAge(string name)
            {
                Console.WriteLine("Enter your age:");
                int age = Convert.ToInt32(Console.ReadLine());
                if (age < 14)
                {
                    scriereFiserEroareAge("WriteLines.txt", name, "You are too young", age);
                    throw new UserException("You are too young");
                }
                return age;
            }
            static string checkMail(string name, int age)
            {
                Console.WriteLine("Enter your mail:");
                string email = Console.ReadLine();
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
             
                    if (!match.Success)
                {
                    scriereFiserEroareEmail( "WriteLines.txt", name, "Mail wrong", age, email);
                    throw new UserException("Mail wrong"); }
                return email;
            }
            static void scriereFiser(string file, string n )
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, file), true))
                {
                    DateTime localDate = DateTime.Now;

                    outputFile.WriteLine($"time:{localDate.ToString()} :: {n}");
                    outputFile.Close();
                }
            }

           static void scriereFiserEroareName(string file, string name, string er)
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, file), true))
                {
                    DateTime localDate = DateTime.Now;

                    outputFile.WriteLine($"time:{localDate.ToString()} name:{name} eroare:{er}");
                    outputFile.Close();
                }
            }
             static void scriereFiserEroareAge(string file, string name, string er, int age)
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, file), true))
                {
                    DateTime localDate = DateTime.Now;

                    outputFile.WriteLine($"time:{localDate.ToString()} name:{name} eroare:{er} ani:{age} ");
                    outputFile.Close();
                }
            }
          static  void scriereFiserEroareEmail(string file, string name, string er, int age, string email)
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, file), true))
                {
                    DateTime localDate = DateTime.Now;

                    outputFile.WriteLine($"time:{localDate.ToString()} name:{name} eroare:{er} ani:{age}  email:{email}");
                    outputFile.Close();
                }
            }
            static void newFile()
            {
                // Create a string array with the lines of text
                string[] lines = { "new File", "games data:"};

                // Set a variable to the Documents path.
                string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }


            }
        }
        class UserException : Exception
        {
            public UserException(string er) : base(er)
            {
               
            }

            public UserException() : base()
            { }
          



        }
    }
}