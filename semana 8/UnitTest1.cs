using System;
using Xunit;

namespace semana_8
{
    public class UnitTest1
    {
        // Definimos la función MCD para calcular el Máximo Común Divisor (MCD) de dos números
        public static int MCD(int nro1, int nro2)
        {
            // Definimos una función interna para verificar si un número es divisible por otro
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

            // Determinamos cuál de los dos números es el menor
            int menor = nro1 > nro2 ? nro2 : nro1;

            // Probamos todos los números desde 1 hasta el número menor
            int mcd = 1;
            for (int i = 1; i <= menor; i++)
            {
                // Si nro1 y nro2 son divisibles por i, entonces i es un divisor común
                if (EsDivisible(nro1, i) && EsDivisible(nro2, i))
                {
                    // Guardamos el divisor común más grande encontrado hasta ahora
                    mcd = i;
                }
            }

            // Devolvemos el MCD de nro1 y nro2
            return mcd;
        }

        // Definimos una función para calcular el MCD de cuatro números
        public static int MCDCuatroNumeros(int a, int b, int c, int d)
        {
            return MCD(MCD(MCD(a, b), c), d);
        }

        [Fact]
        public void Test1()
        {
            // Prueba para la función MCD
            Assert.Equal(6, MCD(48, 18));
            Assert.Equal(1, MCD(101, 103));

            // Prueba para la función MCDCuatroNumeros
            Assert.Equal(1, MCDCuatroNumeros(48, 18, 101, 103));
            Assert.Equal(12, MCDCuatroNumeros(48, 24, 36, 60));
        }
    }
}
