using System;
using Xunit;

namespace semana_8
{
    public class UnitTest1
    {
        // Definimos la funci�n MCD para calcular el M�ximo Com�n Divisor (MCD) de dos n�meros
        public static int MCD(int nro1, int nro2)
        {
            // Definimos una funci�n interna para verificar si un n�mero es divisible por otro
            static bool EsDivisible(int nro, int i)
            {
                // Restamos i de nro hasta que nro sea menor que i
                while (nro >= i)
                {
                    nro = nro - i;
                }
                // Si nro es 0, entonces nro es divisible por i
                return nro == 0;
            }

            // Determinamos cu�l de los dos n�meros es el menor
            int menor = nro1 > nro2 ? nro2 : nro1;

            // Probamos todos los n�meros desde 1 hasta el n�mero menor
            int mcd = 1;
            for (int i = 1; i <= menor; i++)
            {
                // Si nro1 y nro2 son divisibles por i, entonces i es un divisor com�n
                if (EsDivisible(nro1, i) && EsDivisible(nro2, i))
                {
                    // Guardamos el divisor com�n m�s grande encontrado hasta ahora
                    mcd = i;
                }
            }

            // Devolvemos el MCD de nro1 y nro2
            return mcd;
        }

        // Definimos una funci�n para calcular el MCD de cuatro n�meros
        public static int MCDCuatroNumeros(int a, int b, int c, int d)
        {
            return MCD(MCD(MCD(a, b), c), d);
        }

        [Fact]
        public void Test1()
        {
            // Prueba para la funci�n MCD
            Assert.Equal(6, MCD(48, 18));
            Assert.Equal(1, MCD(101, 103));

            // Prueba para la funci�n MCDCuatroNumeros
            Assert.Equal(1, MCDCuatroNumeros(48, 18, 101, 103));
            Assert.Equal(12, MCDCuatroNumeros(48, 24, 36, 60));
        }
    }
}
