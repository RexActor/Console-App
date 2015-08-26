/*
TODO: Needs to add method when object is created 
it creates xml file and adds these details to this file
and after that user can search by his car details and locate in whic position
car is located in parkinglot
TODO: Need to evaluate if entered value is int or string.
If incorrect type entered then return back one step.

*/



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
//using System.IO;
using System.Xml.Linq;
//using System.Threading;

namespace MyCarLotProject
{
    class Program
    {

        
        static void Main(string[] args)
        {
             
            try
            {
                Console.Title = "Parking Lot Administration Tool";
                
                Console.SetWindowSize(100, 20);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\t\t##################################################################\n\t"+
                                  "\t#                                                                #\n\t" +
                                  "\t# With this Application you can add to our database your vehicle #\n\t" +
                                  "\t#               You can enter following data:                    #\n\t"+
                                  "\t#          Brand , Plate Number , Model , Color , Year          #\n\t"+
                                  "\t#                     and Price of your vehicle                  #\n\t"+
                                  "\t# Application have options to see all Vehicles which one are     #\n\t" +
                                  "\t# already added to database, to search by specific parameter     #\n\t" +
                                  "\t#                                                                #\n\t" +
                                  "\t#                     To Continue <Press Enter>                  #\n\t" +
                                  "\t#                                                                #\n\t" +
                                  "\t##################################################################\n\n\t"                                                 
                    );

                Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Would you like to see already added workers?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--> Answer with <Yes> or <No> <--");
                Console.SetWindowSize(122, 54);
                Console.ForegroundColor = ConsoleColor.White;
                string userChoice = Console.ReadLine();
                UserAnswerOnQuestionYesNoEnum UserAnswer2;
                if (Enum.TryParse<UserAnswerOnQuestionYesNoEnum>(userChoice, true,out UserAnswer2))
                {
                    switch (UserAnswer2)
                    {
                        
                        case UserAnswerOnQuestionYesNoEnum.yes:
                            //  Console.WriteLine("soon will be option! Sorry!");
                            //Console.WriteLine("Enter your car's plate number:");
                            //string searchValue = Console.ReadLine().ToUpper();
                            //XML.ReadXmlFile(searchValue);
                            Console.WriteLine("Would you like to search?");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--> Answer with <Yes> or <No> <--");
                            Console.ForegroundColor = ConsoleColor.White;
                            string userChoiceSearch = Console.ReadLine();
                            UserAnswerOnQuestionYesNoEnum UserAnswerChoice;
                            if (Enum.TryParse<UserAnswerOnQuestionYesNoEnum>(userChoiceSearch,true,out UserAnswerChoice))
                            {
                                switch (UserAnswerChoice)
                                {
                                    case UserAnswerOnQuestionYesNoEnum.unknown:
                                        break;
                                    case UserAnswerOnQuestionYesNoEnum.yes:



                                        Console.WriteLine("In which group you wan't to search? Please select number!");
                                        Console.WriteLine("Categories:\n\tName\t -  1\n\tPhone Nr -  2\n\tCity\t -  3\n\tYear\t -  4\n\tNationality\t -  5\n\tPicking Rate\t -  6\n\t");
                                        Console.Write("Enter your value: ");
                                        string userPick=Console.ReadLine();
                                        //Console.WriteLine("Enter your search string:");
                                          
                                    
                                        switch (userPick)
                                        {
                                            
                                                case "1":
                                                Console.WriteLine();
                                                Console.Write("Name: ");
                                                string userInput1 = Console.ReadLine();
                                                if (userInput1 ==null)
                                                {
                                                    XML.ReadXmlFile();
                                                }
                                                else 
                                                //var userInput1 = "Brand";
                                                XML.SearchInXmlFile("Name", userInput1);
                                                //return userInput1;
                                                break;

                                                case "2":
                                                Console.WriteLine();
                                                Console.Write("Phone Number: ");
                                                string userInput3 = Console.ReadLine();
                                                if (userInput3 == null)
                                                {
                                                    XML.ReadXmlFile();
                                                }
                                                else
                                                    //var userInput1 = "PlateNumber";
                                                    XML.SearchInXmlFileAttribute("PhoneNumber", userInput3);
                                                //return userInput1;
                                                break;

                                                case "3":
                                                Console.WriteLine();
                                                Console.Write("City: ");
                                                string userInput4 = Console.ReadLine();
                                                if (userInput4 == null)
                                                {
                                                    XML.ReadXmlFile();
                                                }
                                                else
                                                    //var userInput1 = "Model";
                                                    XML.SearchInXmlFile("City", userInput4);
                                                //return userInput1;
                                                break;

                                            case "4":
                                                Console.WriteLine();
                                                Console.Write("Year: ");
                                                string userInput5 = Console.ReadLine();
                                                if (userInput5 == null)
                                                {
                                                    XML.ReadXmlFile();
                                                }
                                                else
                                                    //var userInput1 = "Year";
                                                    XML.SearchInXmlFile("Year", userInput5);
                                                //return userInput1;
                                                break;

                                            case "5":
                                                Console.WriteLine();
                                                Console.Write("Nationality: ");
                                                string userInput6 = Console.ReadLine();
                                                if (userInput6 == null)
                                                {
                                                    XML.ReadXmlFile();
                                                }
                                                else
                                                    //var userInput1 = "Color";
                                                    XML.SearchInXmlFile("Nationality", userInput6);
                                                //return userInput1;
                                                break;

                                            case "6":
                                                Console.WriteLine();
                                                Console.Write("Picking Rate: ");
                                                string userInput7 = Console.ReadLine();
                                                if (userInput7 == null)
                                                {
                                                    XML.ReadXmlFile();
                                                }
                                                else
                                                    //var userInput1 = "Price";
                                                    XML.SearchInXmlFile("PickingRate", userInput7);
                                                //return userInput1;
                                                break;
                                                
                                            default:
                                                Console.WriteLine("We couldn't understand your input value! By default we will show you all list!");
                                                Thread.Sleep(2000);
                                                XML.ReadXmlFile();
                                                //Thread.Sleep(2000);
                                               // return;
                                                break;
                                        }

                                        //return;
                                       break;
                                    case UserAnswerOnQuestionYesNoEnum.no:
                                        XML.ReadXmlFile();
                                        break;
                                    default:
                                        break;
                                }
                            }

                            
                            

                        
                            break;
                        case UserAnswerOnQuestionYesNoEnum.no: case UserAnswerOnQuestionYesNoEnum.unknown:
                            Console.WriteLine("Hi. Would you like to add your workers's details to our database?");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--> Answer with <Yes> or <No> <--");
                            Console.ForegroundColor = ConsoleColor.White;
                            var userInput = Console.ReadLine();
                            var vehicle3 = Worker.CreateWorkerFromAnswer(userInput);
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Sorry. We didn't understand your answer!");

                }
               
              
                
                
               

              



            }

            /*
            Catches an errror if is applicable
            */
            catch (Exception e)
            {
                Console.WriteLine("There is something wrong: {0}", e.Message);
            }
           
            Console.ReadLine();


        }



    }

 



  

}
