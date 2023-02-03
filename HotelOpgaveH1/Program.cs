using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelOpgaveH1
{
    class Program
    {

        public static void Format(int x, int y, string text) // i have made a method named Format it can handle positioning on the screen on x and y cords and text.
        {
            Console.SetCursorPosition(x, y); // set cords.
            Console.Write(text); // print text to screen.
        }

        static void Main(string[] args)   // main method, program runs here.
        {

            Console.Title = "Hoteller i Paris H1 Opgave";  // title of the main window.
            // euro (€) = ( danske kroner * 100 ) / kurs    || F. x: euro = (1490,00 kr. * 100,00 ) / 745,00 = 200,00 €. 

            Console.CursorVisible = true;  // sets the cursor visible(blinking)
            Console.BackgroundColor = ConsoleColor.DarkBlue;  // background color set to darkblue.
            Console.BufferWidth = Console.WindowWidth = 120; Console.BufferHeight = Console.WindowHeight = 40;  // size of the console window.
            Console.OutputEncoding = Encoding.Unicode;   // output encoding set to Unicode, it can show Danish alphabets now.
            ConsoleKeyInfo cki = new ConsoleKeyInfo(); // cki is checking keyinfo, wich key is pressed.

            while (cki.Key != ConsoleKey.Escape) // runs an infinite loop and watching if escape is pressed or not.
            {
                myRamme(2, 2, 119, 38);

                Console.CursorVisible = true;
                double resultfromDK; // result of dkk to eur is tored in this variable.
                double KURS = 745.00;  // the KURS

                Format(10, 2, "╡  Hotelpriser i Paris. ╞");  // sets the cords x=10 and y=5 then prints text to screen.
                Format(10, 6, "Dkk KURS : 745,00");
                Format(10, 36, "Tryk på en tast for at køre igen, eller [ESC] for luk programmet.");
                Format(10, 8, "Indtast venligst hvor meget Danske kroner du har: ");

                var value = ReadLineOrEsc(); //watching values in readline method called here. value out from DK.
                                             //(Hungarian for me : ez az érték bármi lehet azért "var", és ez próbálja kitalálni a DK-ból mit ütöttünk be)

                double DK;  // amount of dkk stored here when you input.
                if (!double.TryParse(value, out DK)) // error handling for input, if the input is not numeric show error message for 1 sec.
                {
                    Console.CursorVisible = false;
                    Format(18, 14, "Fejl - Du skal taste et nummer!"); Thread.Sleep(1000); Console.Clear();

                    //Format(10, 25, "Tryk på en tast for at køre igen, eller [ESC] for luk programmet.");
                    Console.CursorVisible = true;
                }
                else
                {
                    resultfromDK = (DK * 100) / KURS;  // changeing method from dkk to eur.
                    Format(10, 11, "Du har valuta: " + DK.ToString("0.##") + " dkk.");
                    Format(10, 12, "Valuta omregnet til: " + resultfromDK.ToString("0.##") + "-€"); //prints the changed valuta in string format to the screen with 2 decimals behind it.

                    if (resultfromDK >= 200)  // check if the resultformDk more or equal than 200.
                    {
                        Format(10, 14, "Du har råd til [Hotel Color for] 200 Euro");
                        Format(10, 15, "Tryk på en tast");

                    }
                    else if (resultfromDK >= 50.00 && resultfromDK <= 99.99) // check if the resultformDk more or equal to 50 but less than 99.99.
                    {
                        Format(10, 14, "Du har råd til [Hotel Saphir Grenelle] for 50 Euro");
                        Format(10, 15, "Tryk på en tast");

                    }
                    else if (resultfromDK >= 100.00 && resultfromDK <= 199.99) // check if the resultformDk more or equal than 100 but less than 199.99.
                    {
                        Format(10, 14, "Du har råd til [Hotel Timhotel Montparnasse] for 100 Euro");
                        Format(10, 15, "Tryk på en tast");

                    }
                    else if (resultfromDK <= 49.99)  // check if the result is less than 49.99 euro and show message sleep on the street.
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // alphabets are colored to red ig resultformDk is less than 49.99.
                        Format(10, 14, "Du har kun: " + resultfromDK.ToString("0.##") + "€ til rådlighed");
                        Format(10, 15, "Sov på gaden.");
                        Format(10, 16, "Tryk på en tast");
                    }
                    Console.CursorVisible = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Format(10, 36, "Tryk på en tast for at køre igen, eller [ESC] for luk programmet.");

                    Console.ReadKey();  // waiting for a key pressed.
                    Console.Clear();  // clear screen.

                }
            }

        }

        private static string ReadLineOrEsc()  // method called ReadLineorESC watching which key i pressed.
        {

            string retString = "";  // empty string to alter strings.

            int curIndex = 0; // watching characters.
            do // loop ...
            {
                ConsoleKeyInfo KeyResult = Console.ReadKey(true);

                // handling Esc
                if (KeyResult.Key == ConsoleKey.Escape)  // checking if escape pressed if pressed then exiting the application.
                {
                    Environment.Exit(0);  // exiting application
                }

                // handling  Enter
                if (KeyResult.Key == ConsoleKey.Enter)
                {
                    return retString; // giving back the retString value , which can be NULL or a character depends on what we wrote in the string.
                }

                // handling backspace
                if (KeyResult.Key == ConsoleKey.Backspace)  // handling of the backspace button.
                {
                    if (curIndex > 0) // if curIndex is bigget than 0
                    {
                        retString = retString.Remove(retString.Length - 1);  // then remove the chars one by one if backspace pressed.
                        Console.Write(KeyResult.KeyChar); // giving back a result which is ' ' nothing, empty char.
                        Console.Write(' ');
                        Console.Write(KeyResult.KeyChar);
                        curIndex--;
                    }
                }
                else
                // handle all other keypresses
                {
                    retString += KeyResult.KeyChar;
                    Console.Write(KeyResult.KeyChar);
                    curIndex++;
                }
            }
            while (true); // ...until true
        }

        public static void myRamme(int x1,int y1,int x2,int y2)
        {

            Console.SetCursorPosition(x1, y1);
            Console.Write("╔");
            Console.SetCursorPosition(x2, y1);
            Console.Write("╗");
            Console.SetCursorPosition(x2, y2);
            Console.Write("╝");
            Console.SetCursorPosition(x1, y2);
            Console.Write("╚");

            for (int i = x1 + 1; i < x2; i++)
            {          
                Console.SetCursorPosition(i, y1);
                Console.Write("═");
                Console.SetCursorPosition(i, y2);
                Console.Write("═");

            }
            for (int j = y2 - 1; j > y1; j--)
            {
                Console.SetCursorPosition(y1, j);
                Console.WriteLine("║");
                Console.SetCursorPosition(x2, j);
                Console.Write("║");
            }
            

        }


    }
}