using System;
namespace NextPalindrome
{

    public class NextPlaindrome
    {
        public static void Main()
        {

            string num = "152";

            int n = Convert.ToInt32(num);
            for(int i = n+1; i < n*n; i++)
            {
                char[] c = i.ToString().ToCharArray();
                string s = string.Empty;
             for(int j = c.Length-1; j > -1; j--)
                {
                    s += c[j];
                }
                if (s == i.ToString())
                {
                    Console.WriteLine(s);
                    break;
                }
            }

        }
    }
}