using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarLotProject
{
    class Worker
    
    {
      

        /*
        Seting properties for Class: Worker
        */

        public string Name { get; set; }
        public string City { get; set; }
        public int Year { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public float PickingRate { get; set; }


        public static Worker CreateWorker(string name,
                                string city,
                                int year,
                                string nationality,
                                string phoneNumber,
                                float pickingRate)
        {
            Worker createdWorker = new Worker();
            createdWorker.Name = name;
            createdWorker.City = city;
            createdWorker.Nationality = nationality; //TODO needs to figure out how to list all enumurations with values in console
            createdWorker.Year = year;
            createdWorker.PhoneNumber = phoneNumber;
            createdWorker.PickingRate = pickingRate;

            return createdWorker;



        }


        public static Worker CreateWorkerFromAnswer(string userInput)
        {




            //TODO needs to add that when is UserAnswerOnQuestionYesNoEnum "No"
            //then console displays first line and you can write again answer


            UserAnswerOnQuestionYesNoEnum userAnswer;

            if (Enum.TryParse<UserAnswerOnQuestionYesNoEnum>(userInput, true, out userAnswer))
            {

                switch (userAnswer)
                {
                    case UserAnswerOnQuestionYesNoEnum.yes:

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine();
                        Console.Write("Name of your Worker: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string userName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine();
                        Console.Write("From which city?: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string userCity = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine();
                        Console.Write("He is born?: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string userWorkerYear = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine();
                        Console.Write("Phone Number: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string userPhoneNumber = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine();
                        Console.Write("Nationality:"); //TODO need to create that console shows all enums and it's values
                        Console.ForegroundColor = ConsoleColor.White;                                             // CarColor color = Console.ReadLine(); // needs to figure out how to input color
                        string userNationality = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine();
                        Console.Write("What picking rate he have?: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        //Console.Write("\u00A3 ");
                        string userPickingRate = Console.ReadLine();
                       

                                     

                        var data = Worker.CreateWorker(userName, userCity, int.Parse(userWorkerYear), userPhoneNumber, userNationality, int.Parse(userPickingRate));
                        XML.CreateXmlFile(userName, userCity, userWorkerYear,userNationality, userPhoneNumber, userPickingRate);

                        /*
                           Displays what is inserted in xml file
                        */


                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Following details was added to the file:");
                          Console.WriteLine("Name\t  - {0}\nPhone Nr. - {1}\nCity\t  - {2}\nYear\t  - {3}\nNationality\t  - {4}\nPicking Rate\t  - \u00A3{5}\t\n",
                                            data.Name,
                                            data.PhoneNumber,
                                            data.City,
                                            data.Year,
                                            data.Nationality,
                                            data.PickingRate);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press <Enter> to exit application!");
                        return data;


                    case UserAnswerOnQuestionYesNoEnum.no:
                        
                        return null;
                    //break;


                    default:
                       
                        return null;
                        //break;
                }




            }

            else
            {
                Console.WriteLine("Sorry. We didn't understand your answer!");
               
                return null;

            }

        }





    }



    /*
    setting enumuration for UserAnswerOnQuestionYesNor to use only these answers
    "Yes" or "No"

    */


    enum UserAnswerOnQuestionYesNoEnum
    {
        unknown,
        yes,
        no
    }



    /*
    setting enumuration for CarColor to use only these colours

    */

    //enum CarColor : int
    //{
    //    black,
    //    white,
    //    red,
    //    blue,
    //    grey,
    //    green

    //}
}
