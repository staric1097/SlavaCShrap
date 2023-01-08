using System;
using System.IO; //files lib
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slava2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //создание начального тескта и временой переменой char
            char temp = ' ';
            string text = "Мистер Шерлок Холмс, имевший обыкновение вставать очень поздно, за исключением тех нередких случаев, когда вовсе не ложился спать, сидел за завтраком. Я стоял на коврике перед камином и держал в руках трость, которую наш посетитель забыл накануне вечером. Это была красивая, толстая палка с круглым набалдашником. Как раз под ним палку обхватывала широкая (в дюйм ширины) серебряная лента, а на этой ленте было выгравировано: «Джэмсу Мортимеру, M. R. С. S. от его друзей из С. С. Н.» и год «1884». Это была как раз такого рода трость, какую носят ";
            //логика программы меняется для четного и нечетного еоличесвта символов,
            //поэтому проще убирать нечетный символ, чтобы кол-во символов всегда было четно. Сохраним убраный символ в временной переменой temp
            if (text.Length % 2 != 0)
            {
                //убираем сивол в temp и перезаписываем текст
                temp = char.Parse(text.Substring(text.Length-1, 1));
                text=text.Substring(0, text.Length - 1);
            }

            //переменый для разделения строки на две части и переменая для хранения результата шифрования
            string result="";
            string firstPart, secondPart;

            //делим текс на две равные строки
            firstPart = text.Substring(0,text.Length/2);
            secondPart = text.Substring(text.Length / 2, text.Length / 2);

            //шифруем
            for (int i = 0; i < text.Length/2; i++)
            {
                //в цикле записываем в конец строки результата сначала i-ый символ из первой половины текта, а потом из второй
                result = result.Insert(result.Length, firstPart.Substring(i, 1));
                result = result.Insert(result.Length, secondPart.Substring(i, 1));
            }

            //не забудем вернуть в шифр символ, в случае если мы его убирали
            if (temp != ' ')
            {
                result= result.Insert(result.Length, temp.ToString());
            }
            //запишем результат в файл на диске
            File.WriteAllText(@"C:\Users\79099\Desktop\CsharpProjectFiles\ciphered.txt", result);
            
            //переменые для дешифровки
            string fuckGoback1="";
            string fuckGoBack2 = "";

            if (result.Length % 2 != 0)
            {
                //снова убираем сивол и перезаписываем текст чтобы дешифровка нормально работала
                result = result.Substring(0, result.Length - 1);
            }

            //согласно логике шифра, все четные символы взяты из первой половины, а нечетные из второй, их порядок не изменен
            for (int i = 0; i < result.Length; i++)
            {
                //если символ четный записываем его в первую временную строку
                if (i%2==0 || i == 0)
                {
                    fuckGoback1 = fuckGoback1.Insert(fuckGoback1.Length, result.Substring(i, 1));
                }
                //если символ нечетный записываем во вторую
                else
                {
                    fuckGoBack2 = fuckGoBack2.Insert(fuckGoBack2.Length, result.Substring(i, 1));
                }
            }
            //объединяем полученые строки
            string disRes = fuckGoback1.Insert(fuckGoback1.Length, fuckGoBack2);

            //доваляем убранный символ
            if (temp != ' ')
            {
                disRes = disRes.Insert(disRes.Length, temp.ToString());
            }
            //записываем результат в файл
            File.WriteAllText(@"C:\Users\79099\Desktop\CsharpProjectFiles\deciphered.txt", disRes);
        }

    }
}
