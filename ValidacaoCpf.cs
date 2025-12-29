using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_de_Emprestimos
{
    public class ValidacaoCpf
    {
        public string Numero {  get; set; }

        // Validar o CPF.
        public static bool ValidarCpf(string cpf)
        {
            bool cpfValido = true;

            // Verificar se o CPF tem 11 Dígitos.
            if (cpf.Length != 11)
            {
                cpfValido = false;
            }
            else
            {
                // Verificar se todos os caracteres de CPF São Dígitos Numéricos.
                for (int i = 0; i < cpf.Length; i++)
                {
                    if (!char.IsDigit(cpf[i]))
                    {
                        cpfValido = false;
                        break;
                    }
                }
            }

            // Verificar se o CPF Digitado é 00000000000, 11111111111, 99999999999...
            if (cpfValido)
            {
                for (byte i = 0; i < 10; i++)
                {
                    var temp = new string(char.Parse(i.ToString()), 11);
                    if (cpf == temp)
                    {
                        cpfValido = false;
                        break;
                    }
                }

            }

            // Verificar Dígito de controle do CPF
            // d1 = Primeiro Digito
            // d2 = Segundo Digito
            if (cpfValido)
            {
                var j = 0;
                var d1 = 0;
                var d2 = 0;

                // Validar o primeiro número do dígito de controle
                for (int i = 10; i > 1; i--)
                {
                    d1 += Convert.ToInt32(cpf.Substring(j, 1)) * i;
                    j++;
                }

                // Resto da Divisão
                d1 = (d1 * 10) % 11;
                if (d1 == 10)
                {
                    d1 = 0;
                }

                // Verificar se o primeiro Número Bateu ---- posição  9 (penúltima)
                if (d1 != Convert.ToInt32(cpf.Substring(9, 1)))
                {
                    cpfValido = false;
                }

                // Validar o segundo Número (Dígito) do controle
                if (cpfValido)
                {
                    j = 0;
                    for (int i = 11; i > 1; i--)
                    {
                        d2 += Convert.ToInt32(cpf.Substring(j,1)) * i;
                        j++;
                    }

                    // Resto da Divisão
                    d2 = (d2 * 10) % 11;
                    if (d2 == 10)
                    {
                        d2 = 0; 
                    }

                    // Verificar se o segundo Digito bateu -- posição 10 (última)
                    if (d2 != Convert.ToInt32(cpf.Substring(10,1)))
                    {
                        cpfValido = false;
                    }
                }
            }

            return cpfValido;
        }
    }
}
