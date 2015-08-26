using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MyCarLotProject
{
    class XML
    {
         //public string filePath { get; set; }

        public static bool isFileLocked(string file)
        {

            FileStream stream = null;
            try
            {
                stream = File.Open(file,FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                
            }
            catch (IOException)
            {
                /*the file is unavailable because it is:
                still being written to or being processed by
                another thread or does not exist
                */
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                 
            }
            return false;


        }


        public static void CreateXmlFile(string workerName, string workerCity, string workerYear, string workerNationality, string workerPhoneNumber, string workerPickingRate)
        {
            /*
            TODO: method creates xml file
            and adds user data in this file
            if file is already created then
            file is beeing amended.!!!
            */
            string filePath = "Workers.xml";
            
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;



                if (!File.Exists(filePath))
                {

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("\n\n\nFile don't exists. We are creating new.");

                    XmlWriter xmlWrite = XmlWriter.Create(filePath, settings);



                    xmlWrite.WriteStartDocument();
                    xmlWrite.WriteStartElement("Workers");
                    xmlWrite.WriteStartElement("Pickers");
                    xmlWrite.WriteAttributeString("PhoneNumber", workerPhoneNumber.ToUpper()); //attribute in element so we can filter by this unique plate number
                    xmlWrite.WriteElementString("Name", workerName.ToUpper());
                    xmlWrite.WriteElementString("City", workerCity.ToUpper());
                    xmlWrite.WriteElementString("Year", workerYear);
                    xmlWrite.WriteElementString("Nationality", workerNationality.ToUpper());
                    xmlWrite.WriteElementString("PickingRate", workerPickingRate);
                    xmlWrite.WriteEndElement();
                    xmlWrite.WriteEndDocument();
                    xmlWrite.Close();
                    xmlWrite.Flush();
                    Thread.Sleep(3000);


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n\nfile Exists. We are amending existing file!!\n\n\n");



                    XmlDocument xmlDoc = new XmlDocument();
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    xmlDoc.Load(fs);

                    XmlElement newCatalogEntry = xmlDoc.CreateElement("Pickers");//New XML element created

                    XmlAttribute newCatalogAttribute = xmlDoc.CreateAttribute("PhoneNumber"); // New attribute created
                    newCatalogAttribute.Value = workerPhoneNumber.ToUpper();//Value Given for attribute
                    newCatalogEntry.SetAttributeNode(newCatalogAttribute); //Attach attribute to XML element



                    XmlElement firstElement = xmlDoc.CreateElement("Name");//first element Brand -created
                    firstElement.InnerText = workerName.ToUpper(); //Value given for first element
                    newCatalogEntry.AppendChild(firstElement); //Append the newly created element as a child element

                    XmlElement secondElement = xmlDoc.CreateElement("City");//second element Model - created
                    secondElement.InnerText = workerCity.ToUpper();//Value given for second element
                    newCatalogEntry.AppendChild(secondElement);//Append the newly created element as a child element

                    XmlElement thirdElement = xmlDoc.CreateElement("Year");//third element Year - created
                    thirdElement.InnerText = workerYear;//Value given for third element
                    newCatalogEntry.AppendChild(thirdElement);//Append the newly created element as a child element

                    XmlElement fourthElement = xmlDoc.CreateElement("Nationality");//fourth element Color - created
                    fourthElement.InnerText = workerNationality.ToUpper();//Value given for tfourth element
                    newCatalogEntry.AppendChild(fourthElement);//Append the newly created element as a child element

                    XmlElement fifthElement = xmlDoc.CreateElement("Pickingrate");//fifth element Price - created
                    fifthElement.InnerText = workerPickingRate;//value given for fifth element
                    newCatalogEntry.AppendChild(fifthElement);//Append the newly created element as a child element

                    xmlDoc.DocumentElement.InsertAfter(newCatalogEntry, xmlDoc.DocumentElement.LastChild);//New XML element inserted into the document

                    FileStream fsxml = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite); //An instance of Filestream created
                                                                                                                           //The first parameter is the path to the XML file       
                    xmlDoc.Save(fsxml);//XML document saved
                    Thread.Sleep(3000);
                }
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine("Press <Enter> to exit application!");

           









        }

        public static void SearchInXmlFileAttribute(string attribute, string data)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("Workers.xml");
            XmlNodeList itemList = Doc.SelectNodes("/Workers/Pickers[@"+attribute+"='"+data+"']");
            //XmlNodeList itemList = Doc.SelectNodes("/ParkingLot/Cars[contains(" + group + ",'" + data.ToUpper() + "')]");
            Console.WriteLine("\nYou was searching by following word: {0}\n\t Your search results:\t\n", data);
            foreach (XmlNode currNode in itemList)
            {
                string phoneNum = string.Empty;
                phoneNum = currNode.Attributes["PhoneNumber"].Value.ToString();
                XmlNode name = currNode.SelectSingleNode("Name");
                XmlNode city = currNode.SelectSingleNode("City");
                XmlNode year = currNode.SelectSingleNode("Year");
                XmlNode nationality = currNode.SelectSingleNode("Nationality");
                XmlNode pickingRate = currNode.SelectSingleNode("PickingRate");


                Console.Write("Name\t  - {0}\nPhone Nr. - {1}\nCity\t  - {2}\nYear\t  - {3}\nNationality\t  - {4}\nPicking Rate\t  - \u00A3{5}\t\n", // \u00A3 is pound (£) sign
                                        name.InnerText,
                                        phoneNum,
                                        city.InnerText,
                                        year.InnerText,
                                        nationality.InnerText,
                                        pickingRate.InnerText);
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press <Enter> to exit application!");


        }

        public static void SearchInXmlFile(string group, string data)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("Workers.xml");
            //XmlNodeList itemList = Doc.SelectNodes("/ParkingLot/Cars[@PlateNumber='"+data+"']");
            XmlNodeList itemList = Doc.SelectNodes("/Workers/Pickers[contains("+group+",'"+data.ToUpper()+"')]");
            Console.WriteLine("\nYou was searching by following word: {0}\n\t Your search results:\t\n", data);
            foreach (XmlNode currNode in itemList)
            {
                string phoneNum = string.Empty;
                phoneNum = currNode.Attributes["PhoneNumber"].Value.ToString();
                XmlNode name = currNode.SelectSingleNode("Name");
                XmlNode city = currNode.SelectSingleNode("City");
                XmlNode year = currNode.SelectSingleNode("Year");
                XmlNode nationality = currNode.SelectSingleNode("Nationality");
                XmlNode pickingRate = currNode.SelectSingleNode("PickingRate");

                
                Console.Write("Name\t  - {0}\nPhone Nr. - {1}\nCity\t  - {2}\nYear\t  - {3}\nNationality\t  - {4}\nPicking Rate\t  - \u00A3{5}\t\n", // \u00A3 is pound (£) sign
                                        name.InnerText,
                                        phoneNum,
                                        city.InnerText,
                                        year.InnerText,
                                        nationality.InnerText,
                                        pickingRate.InnerText);
                Console.WriteLine("");
            }
           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press <Enter> to exit application!");

        }
        public static void ReadXmlFile()
        {
            /*
            TODO: method read xml file
            and displays all requested user information
            in console 
            
            */

            //XmlDocument doc = new XmlDocument();
            //doc.Load("parkingLot.xml");

            ////Get and display all the book titles

            //XmlElement root = doc.DocumentElement;


            //XmlNodeList elemList = root.GetElementsByTagName("Brand");
            //XmlNodeList elemList2 = root.GetElementsByTagName("Model");
            //XmlNodeList elemList3 = root.GetAttribute("PlateNumber");
            //XmlNodeList elemList4 = root.GetElementsByTagName("Year");
            //XmlNodeList elemList5 = root.GetElementsByTagName("Color");
            //XmlNodeList elemList6 = root.GetElementsByTagName("Price");

            //// XmlNodeList elemList5 = root.GetAttribute("Picker");

            ////switch (doc.NodeType) {

            ////case XmlNodeType.Attribute
            //for (int i = 0; i < elemList.Count; i++)
            //{



            //    Console.WriteLine("Brand: " + elemList[i].InnerXml);
            //    Console.WriteLine("Model: " + elemList2[i].InnerXml);
            //    Console.WriteLine("Plate Number: " + elemList3[i].InnerXml);
            //    Console.WriteLine("Year: " + elemList4[i].InnerXml);
            //    Console.WriteLine("Color: " + elemList5[i].InnerXml);
            //    Console.WriteLine("Price: " + elemList6[i].InnerXml);
            //    Console.WriteLine("");



            //}
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("We have following Workers.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            XmlDocument Doc = new XmlDocument();
            Doc.Load("Workers.xml");
            XmlNodeList itemList = Doc.DocumentElement.SelectNodes("Pickers");
            
            foreach (XmlNode currNode in itemList)
            {
                string phoneNum = string.Empty;
                phoneNum = currNode.Attributes["PhoneNumber"].Value.ToString();
                XmlNode name = currNode.SelectSingleNode("Name");
                XmlNode city = currNode.SelectSingleNode("City");
                XmlNode year = currNode.SelectSingleNode("Year");
                XmlNode nationality = currNode.SelectSingleNode("Nationality");
                XmlNode pickingRate = currNode.SelectSingleNode("PickingRate");
               

                Console.Write("Name\t  - {0}\nPhone Nr. - {1}\nCity\t  - {2}\nYear\t  - {3}\nNationality\t  - {4}\nPicking Rate\t  - \u00A3{5}\t\n", // \u00A3 is pound (£) sign
                                        name.InnerText,
                                        phoneNum,
                                        city.InnerText,
                                        year.InnerText,
                                        nationality.InnerText,
                                        pickingRate.InnerText);
                Console.WriteLine("");
                

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press <Enter> to exit application!");





        }



        }
}
   

