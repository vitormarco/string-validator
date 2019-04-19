using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace teste
{
    class ValidadorString
    {
        public bool Validar(String entrada)
        {
            bool hasNumber = Regex.IsMatch(entrada, @"\d+");

            String newEntrada = "";

            String CHARVALID = "{}[]()";

            for (int i = 0; i < entrada.Length; i++)
            {
                for (int j = 0; j < CHARVALID.Length; j++)
                {
                    if (entrada[i] == CHARVALID[j])
                    {
                        newEntrada += entrada[i];
                    }
                }
            }

            bool hasAllFinishing = newEntrada.Length % 2 == 0;

            if (hasNumber || !hasAllFinishing)
            {
                return false;
            }

            char toClose = ' ';

            return Validar(newEntrada, 0, 1, toClose, true, 0);
        }

        private bool Validar(String entrada, int posVerify, int nextPos, char toClose, bool stringIsValid, int beforeToClose)
        {

            if (nextPos > entrada.Length - 1 && stringIsValid)
            {
                return true;
            }


            bool posValid = entrada[nextPos] == '{' || entrada[nextPos] == '(' || entrada[nextPos] == '[';


            switch (entrada[posVerify])
            {
                case '{':
                    toClose = '}';
                    break;
                case '[':
                    toClose = ']';
                    break;
                case '(':
                    toClose = ')';
                    break;
            }

            if (entrada[nextPos] != toClose && posValid)
            {
                beforeToClose = posVerify;

                return Validar(entrada, ++posVerify, ++nextPos, toClose, posValid, beforeToClose);
            }

            if (entrada[nextPos] == toClose && nextPos < entrada.Length)
            {

                return Validar(entrada, beforeToClose, ++nextPos, toClose, stringIsValid, beforeToClose);
            }

            return false;
        }
    }
}
