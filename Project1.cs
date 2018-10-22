using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1
{
    class Person : IComparable
    {
        private String @name = "";
        private String @Officenumber;
        private String @telephonenumber;
        //Decalring a name property using type string

        public String GetName()
        {

            return @name;
        }
        public String Getofficenumber()
        {
            return @Officenumber;

        }
        public String Gettelephonenumber()
        {
            return @telephonenumber;

        }
        public void SetName(String @name)
        {

            this.@name = @name;
        }
        public void SetOfficenumber(string @Officenumber)
        {
            this.@Officenumber = @Officenumber;

        }
        public void SetTelephonenumber(String @telephonenumber)
        {
            this.@telephonenumber = @telephonenumber;
        }


        //constructor   
        public Person(String @name, String @Officenumber, String @telephonenumber)
        {
            this.@name = @name;
            this.@Officenumber = @Officenumber;
            this.@telephonenumber = @telephonenumber;

        }
        public int CompareTo(object OBJ)
        {
            Person p1 = (Person)OBJ;

            String Name1 = null;
            String Name2 = null;

            int i = (String.Compare(this.GetName(), p1.GetName(), true));
            if (i == 0)
            {
                return 0;
            }

            if (i < 0)
            {
                return -1;
            }

            if (i > 0)
            {
                return 1;
            }
        }

        static class Program
        {
            public static Person[] Pn = new Person[20];
            public static int InUse = 0;

        }
        static public void read()
        {
            String @name;
            String @Officenumber;
            String @telephonenumber;
            StreamReader inputfile = new StreamReader(@"C:\data1.txt");
            {
                String line;

                while ((line = inputfile.ReadLine()) != null)
                {
                    line = inputfile.ReadLine();

                    if (InUse < 20)
                    {
                        i[InUse] = new Person(@name, @Officenumber, @telephonenumber);//creating a new object and calling the parametrical constructor
                        InUse++;
                    }
                }

            }
        }

        //Implementation of the main method
        static void Main(String[] args)
        {
            Program.read(); //calling the static readfile method
            char option, O = 'a';  //character to read the menu options
            while (O != 'b')
            {
                Console.WriteLine("A. Print the Menu List");
                Console.WriteLine("B.Add an Entry");
                Console.WriteLine("C.Search for a Name");
                Console.WriteLine("D.Search for an Office Number");
                Console.WriteLine("E.Search for a telephone number");
                Console.WriteLine("F.change an Office number ");
                Console.WriteLine("G.Sort the list by name");
                Console.WriteLine("H.Quit");
                option = Convert.ToChar(Console.ReadLine());

                 switch(Menu options)
                 {
                 Case a
                    {
                       
                     int x = 0;
                     Console.WriteLine("Name" +"Officenumber" +"telephone number");
                     
                     while(i < InUse)
                     {
                        Console.WriteLine((i[x].GetName()) +(i[x].Getofficenumber()) +(i[x].Gettelephonenumber()));
                            x++;                    
                     }
                     break ;
                   }

                   case b :

                     Console.WriteLine("Enter the name of a Person");
                     String @name1 = Console.ReadLine();
                     Console.WriteLine("Enter the Officenumber");
                     String @Officenumber1 =Console.ReadLine();
                     Console.WriteLine("Enter the telephone number");
                     String @telephonenumber1 = Console.ReadLine();
                     i[InUse] = new Person(@name1,@Officenumber1,@telephonenumber1);
                     InUse++;


                     case c :
                     {
                         Console.WriteLine("enter the Person name");
                         String @name = Console.ReadLine();
                         int i =0; //varaible checking for the size
                         int check = 0;// flag

                         while(x < InUse)
                         {
                             if(i[x].GetName()).Equals(this.@name)
                         }
                     }

                 }

        }
    }
}
