using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoCorpLibrary
{
    public class Password
    {
        public string Generate(int lenght, string chars, string separator)
        {
            string[] usableChars = { };
            if (chars.Contains(separator))
            {
                usableChars = chars.Split(new string[] { separator }, StringSplitOptions.None);
            }
            else
            {
                throw new Exception("The parameter 'chars' does not contain a sperator.");
            }
            string finalPassword = "";
            Random random = new Random();
            int number = 0;
            if (lenght > 0)
            {
                for (int i = 1; i < lenght; i++)
                {
                    number = random.Next(0, usableChars.Length);
                    finalPassword = finalPassword + usableChars[number];
                }
            }
            else
            {
                throw new Exception("The parameter 'lenght' must be higher than 0.");
            }
            return finalPassword;
        }
    }
}
