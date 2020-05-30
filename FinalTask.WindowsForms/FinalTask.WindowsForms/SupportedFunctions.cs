using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.WindowsForms
{
    class SupportedFunctions
    {
        public static void Print(string message)  // функция для вывода текста на экран
        {
            Console.WriteLine(message);
        }



        public static string Read() // функция для считывания текста с экрана
        {
            string note = Console.ReadLine();
            return note;
        }

        public static string GetFirstLetter(string word) // функция получения первой буквы в слове
        {
                return word.Substring(0, 1).ToLower();

           
        }



        public static string GetLastLetter(string word) // функция получения последней буквы в слове
        {
            string letter = word.Substring(word.Length - 1);
            if (letter == "ь" || letter == "ы")
            {
                return word.Substring(word.Length - 2, 1);
            }
            else
            {
                return letter;
            }
        }

        public static bool CheckIsHasWordInArray(string enteredWord, string[] arrCities) //проверяем наличие введенного города в массиве
        {
            for (int i = 0; i < arrCities.Length; i++) //переводим названия городов в массиве в нижний регистр
            {
                arrCities[i] = arrCities[i].ToLower();
            }
            return arrCities.Contains(enteredWord.ToLower());
        }
        

        public static int GetNumberPlayer(int gamer)  // меняем игрока
        {
            if (gamer == 2 || gamer == 0) 
            {
                return 1;
            }
            else 
            {
                return 2;
            }
        }
    }
}
