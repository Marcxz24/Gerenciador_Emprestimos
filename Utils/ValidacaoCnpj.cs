using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos.Utils
{
    public class ValidacaoCnpj
    {
        public static bool ValidarCnpj(string cnpj)
        {
            bool cnpjValido = true;

            // Verificar se o CNPJ tem 14 Dígitos.
            if (cnpj.Length != 14)
            {
                cnpjValido = false;
            }
            else
            {
                // Verificar se todos os caracteres do CNPJ são Dígitos Numéricos.
                for (int i = 0; i < cnpj.Length; i++)
                {
                    if (!char.IsDigit(cnpj[i]))
                    {
                        cnpjValido = false;
                        break;
                    }
                }
            }

            // Verificar se o CNPJ digitado é composto por números repetidos (00000000000000, 11111111111111...)
            if (cnpjValido)
            {
                for (byte i = 0; i < 10; i++)
                {
                    var temp = new string(char.Parse(i.ToString()), 14);
                    if (cnpj == temp)
                    {
                        cnpjValido = false;
                        break;
                    }
                }
            }

            // Verificar Dígitos de controle do CNPJ
            if (cnpjValido)
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

                int soma = 0;
                int resto = 0;

                // Validar o primeiro dígito de controle (posição 12)
                for (int i = 0; i < 12; i++)
                {
                    soma += Convert.ToInt32(cnpj.Substring(i, 1)) * multiplicador1[i];
                }

                resto = soma % 11;
                int d1 = (resto < 2) ? 0 : 11 - resto;

                if (d1 != Convert.ToInt32(cnpj.Substring(12, 1)))
                {
                    cnpjValido = false;
                }

                // Validar o segundo dígito de controle (posição 13)
                if (cnpjValido)
                {
                    soma = 0;
                    for (int i = 0; i < 13; i++)
                    {
                        soma += Convert.ToInt32(cnpj.Substring(i, 1)) * multiplicador2[i];
                    }

                    resto = soma % 11;
                    int d2 = (resto < 2) ? 0 : 11 - resto;

                    if (d2 != Convert.ToInt32(cnpj.Substring(13, 1)))
                    {
                        cnpjValido = false;
                    }
                }
            }

            return cnpjValido;
        }
    }
}
