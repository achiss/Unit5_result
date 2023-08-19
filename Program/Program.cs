
// resulted task, Unit 5
// august 2023


using System;
using System.Text.RegularExpressions;


namespace Unit5_result
{
    class Program
    {
        static (string Name, string Surname, int Age, string Pet, string[] PetList, string[] FlowersList) UserDataList;
        
        
        public static string GetStringDataFromConsole()
        {
            string dataString = Console.ReadLine();

            if (string.IsNullOrEmpty(dataString))                   // ! IsNullOrEmpty() - есть ли аналоги?
            {
                Console.WriteLine("The data is not correct. You have to enter the characters.");
                Console.Write("Please, repeat entering the string: ");
                return GetStringDataFromConsole();
            }
            else
            {
                return dataString;
            }
        }


        public static string GetTextDataFromConsole()
        {
            string textString = GetStringDataFromConsole();
            bool containsNumber = textString.Any(char.IsDigit);

            if (containsNumber)
            {
                Console.WriteLine("The data is not correct. You have to enter only text except numbers.");
                Console.Write("Please, repeat entering the string:");
                return GetTextDataFromConsole();
            }
            else
            {
                return textString;
            }
        }
        
        
        public static int GetNumberDataFromConsole()
        {
            int dataNumber = int.Parse(GetStringDataFromConsole());

            if (dataNumber < 0)
            {
                Console.WriteLine("The data is not correct. Input number must be '> 0'.");
                Console.Write("Please, repeat entering the number: ");
                return GetNumberDataFromConsole();
            }
            else
            {
                return dataNumber;
            }
        }
        
        
        public static int CheckZeroNumberDataFromConsole(int dataNumber)
        {
            if (dataNumber == 0)
            {
                Console.WriteLine("The data is not correct. Input number must not be zero.");
                Console.Write("Please, repeat entering the number: ");
                return GetNumberDataFromConsole();
            }
            else
            {
                return dataNumber;
            }
        }
        
        
        public static void GetUserDataFromConsole()               // Передать аргумент по ссылке ref ?
        {
            Console.Write("\n");
            
            Console.Write("Input your name: ");
            UserDataList.Name = GetTextDataFromConsole();
            
            Console.Write("Input your surname: ");
            UserDataList.Surname = GetTextDataFromConsole();
            
            Console.Write("Entire your full age by numbers, please: ");
            UserDataList.Age = CheckZeroNumberDataFromConsole(GetNumberDataFromConsole());
            
            Console.Write("Do you have any pet's (Yes(y) or No(n))? ");
            UserDataList.Pet = GetTextDataFromConsole();                  // Или тип bool
            if ((UserDataList.Pet.ToLower() == "yes") || (UserDataList.Pet.ToLower() == "y"))
            {
                UserDataList.Pet = "have";
                Console.Write("How many pet's you have (only numbers)? ");

                int PetListCount = CheckZeroNumberDataFromConsole(GetNumberDataFromConsole());
                UserDataList.PetList = new string[PetListCount];
                for (int i = 0; i < PetListCount; i++)
                {
                    Console.Write("Enter the name of your pet: ");
                    UserDataList.PetList[i] = GetStringDataFromConsole();
                }
            }
            else
            {
                UserDataList.Pet = "didn't have";
            }
            
            Console.Write("How many types from flowers you like (only numbers)? ");
            int FlowersListCount = GetNumberDataFromConsole();
            if (FlowersListCount == 0)
            {
                Console.WriteLine("You have no preference in flowers.");
            }
            else
            {
                UserDataList.FlowersList = new string[FlowersListCount];
                for (int i = 0; i < FlowersListCount; i++)
                {
                    Console.Write("Entire you favorite name of flowers: ");
                    UserDataList.FlowersList[i] = GetStringDataFromConsole();
                }
            }
        }
        
        
        public static void ShowUserData()
        {
            Console.WriteLine(
                $"\tHello, your name is {UserDataList.Name} {UserDataList.Surname} you are {UserDataList.Age} years old.");
            Console.WriteLine($"\tYou have a pet: ");
            for (int i = 0; i < UserDataList.PetList.Length; i++)
            {
                Console.WriteLine($"\t\t{UserDataList.PetList[i]}");
            }
            Console.WriteLine($"\tYou favorite name of flowers: ");
            for (int i = 0; i < UserDataList.FlowersList.Length; i++)
            {
                Console.WriteLine($"\t\t{UserDataList.FlowersList[i]}");
            }
        }
        
        
        
        
        private static void Main(string[] args)
        {
            GetUserDataFromConsole();
            ShowUserData();

            Console.ReadKey();
        }
    }
}