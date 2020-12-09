using System;
using System.Collections.Generic;
using System.Text;

namespace LoginSystem
{
    public class PasswordRule
    {
        public bool check_pass(string pass)//funkcja sprawdzająca poprawnosc hasla
        {
            bool is_upper = false;
            bool is_number = false;
            if (pass.Length < 8)
            {
                return false;
            }


            for (int i = 0; i < pass.Length; i++)
            {
                if (Char.IsUpper(pass[i]))
                {
                    is_upper = true;
                }
                if (Char.IsDigit(pass[i]))
                {
                    is_number = true;
                }
            }
            if (is_number && is_upper)
            {
                return true;
            }
            return false;
        }
    }
}
