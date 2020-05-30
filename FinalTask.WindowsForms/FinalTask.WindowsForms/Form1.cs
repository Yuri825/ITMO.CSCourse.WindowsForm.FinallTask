using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTask.WindowsForms
{
    public partial class step : Form
    {
       
        public step()
        {
            InitializeComponent();
            
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(4, 4, button1.Width-8, button1.Height-8);

            Region myRegion = new Region(myPath);
            button1.Region = myRegion;
        }

        int gamer = 1;
        int count = 1; // переменная для смены фона
        List<string> UsedWords = new List<string> { }; // создаем список для использованных слов

        string enteredWord; // переменная для вводимых слов
        string lastLetter; // переменная для записи в нее предыдущего слова
  

        private void textBox1_MouseClick(object sender, MouseEventArgs e) // очищаем поле ввода по клику на него
        {
            textBox1.Text = "";
        }
        string lastWord;
      
        private void button1_Click(object sender, EventArgs e)  // группа проверок введенного слова
        {
           
            // по нажатию на кнопку меняем фон:
            this.BackgroundImage = ArrayCities.arrImages[count];
            count++;
            if (count == 3)
            {
                count = 0;
            }
            
            enteredWord = textBox1.Text.Trim();  // записываем в переменную значение из поля ввода

           if(UsedWords.Count > 0) // если это слово не первое в игре
            {
                lastLetter = SupportedFunctions.GetLastLetter(lastWord); // последняя буква предыдущего слова
            }

            for (int i = 0; i < ArrayCities.arrCities.Length; i++)
            {
                if (SupportedFunctions.CheckIsHasWordInArray(enteredWord, ArrayCities.arrCities) == false) // проверка на наличие города в массиве
                {
                    this.BackgroundImage = FinalTask.WindowsForms.Properties.Resources.они;
                    MessageBox.Show("Такого города нет, вы проиграли ");
                    this.Close();
                    break;
                }

               
                if (UsedWords.Contains(enteredWord.ToLower().Trim())) // проверка на наличие в списке использованных слов
                {
                    this.BackgroundImage = FinalTask.WindowsForms.Properties.Resources.они;
                    MessageBox.Show("Такой город уже называли, вы проиграли ");
                    this.Close();
                    break;
                }


                UsedWords.Add(enteredWord); // добавляем слово в список использованных слов

                gamer = SupportedFunctions.GetNumberPlayer(gamer); // меняем игрока


                numberOfGamer.Text = "Ход игрока № " + gamer;
                label1.Text = "Введите название города РФ на букву " + "\"" + SupportedFunctions.GetLastLetter(enteredWord) + "\"";
                enteredWord = textBox1.Text.Trim();
                string firstLetter = SupportedFunctions.GetFirstLetter(enteredWord); // первая буква
        
                 
           

                if(UsedWords.Count > 1)
                {
                    if (lastLetter != firstLetter) // проверка равны ли последняя буква предыдущего слова и первая текущего
                    {
                        this.BackgroundImage = FinalTask.WindowsForms.Properties.Resources.они;
                        MessageBox.Show("Вы назвали город не на ту букву, вы проиграли ");
                        this.Close();
                        break;
                    }
                }
                lastWord = enteredWord;
                break;
            }
        }
     
        private void rules_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }

        private void rules_MouseMove(object sender, MouseEventArgs e)
        {
            rules.BackColor = Color.Yellow;
            
        }

        private void rules_MouseLeave(object sender, EventArgs e)
        {
            rules.BackColor = Color.Lime;
        }  
    }
}
