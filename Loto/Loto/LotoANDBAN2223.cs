using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    //
    public class Loto
    {
        /// <summary>
        /// Constante Maximum 6 números.
        /// </summary>
        public const int MAX_NUMEROS = 6;
        /// <summary>
        /// Constante Número menor con valor 1
        /// </summary>
        public const int NUMERO_MENOR = 1;
        /// <summary>
        /// Constante Número mayor con valor 49
        /// </summary>
        public const int NUMERO_MAYOR = 49;
        /// <summary>
        /// Array con 6 numeros de la combinación.
        /// </summary>
        private int[] _nums = new int[MAX_NUMEROS];
        /// <summary>
        /// Combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)
        /// </summary>
        public bool ok = false;

        public int[] Nums { 
            get => _nums; 
            set => _nums = value; 
        }

        // En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta 
        public Loto()
        {
            Random r = new Random();    // clase generadora de números aleatorios

            int i = 0, j, num;

            do             // generamos la combinación
            {                       
                num = r.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     // generamos un número aleatorio del 1 al 49
                for (j = 0; j < i; j++)    // comprobamos que el número no está
                    if (Nums[j] == num)
                        break;
                if (i == j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Nums[i] = num;
                    i++;
                }
            } while (i < MAX_NUMEROS);

            ok = true;
        }

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misnums es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)
        public Loto(int[] misnums)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for (int i = 0; i < MAX_NUMEROS; i++)
                if (misnums[i] >= NUMERO_MENOR && misnums[i] <= NUMERO_MAYOR) {
                    int j;
                    for (j = 0; j < i; j++) 
                        if (misnums[i] == Nums[j])
                            break;
                    if (i == j)
                        Nums[i] = misnums[i]; // validamos la combinación
                    else {
                        ok = false;
                        return;
                    }
                }
                else
                {
                    ok = false;     // La combinación no es válida, terminamos
                    return;
                }
	        ok = true;
        }

        /// <summary>
        /// Método que comprueba el número de aciertos.
        /// </summary>
        /// <remarks>premi es un array con la combinación ganadora</remarks>
        /// <param name="aciertos">Devuelve el número de aciertos.</param>
        public int Comprobar(int[] premi)
        {
            int aciertos = 0;
            for (int i = 0; i < MAX_NUMEROS; i++)
                for (int j = 0; j < MAX_NUMEROS; j++)
                    if (premi[i] == Nums[j]) 
                        aciertos++;
            return aciertos;
        }
    }

}
