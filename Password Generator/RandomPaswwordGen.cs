using System;

namespace Password_Generator
{
    class RandomPaswwordGen
    {
        
        public string Generate(int length, bool? cb1, bool? cb2, bool? cb3, bool? cb4)
        {
            Random rnd = new Random();
            string symbols = "~`!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/";
            string password = "";

            for(int i = 0; i < length; i++)
            {
                int random = rnd.Next(4);
                if (random == 0)
                {
                    if(cb1 == true)
                    {
                        char letter = Convert.ToChar(rnd.Next('A', 'Z' + 1));
                        password += letter;
                    }
                    else
                    {
                        i--;
                    }
                }
                else if(random == 1)
                {
                    if (cb2 == true)
                    {
                        char letter = Convert.ToChar(rnd.Next('a', 'z' + 1));
                        password += letter;
                    }
                    else
                    {
                        i--;
                    }
                }
                else if (random == 2)
                {
                    if (cb3 == true)
                    {
                        string number = rnd.Next(10).ToString();
                        password += number;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    if (cb4 == true)
                    {
                        char symbol = Convert.ToChar(symbols[rnd.Next(symbols.Length)]);
                        password += symbol;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            return password;
        }
    }
}
