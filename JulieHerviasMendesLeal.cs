using System;
using System.Collections.Specialized;
namespace app
{
    class Programa
    {
        public static void Main(string[] args)
        {
            //exercicio1();

            //exercicio2();          

            // exercicio3();

            //exercicio4();

            //exercicio6();

            //exercicio7();

            exercicio8();

            //exercicio9();

            //exercicio10();
        }



        //Exercicio 1
        static public void exercicio1()
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(i + " x " + j + " = " + i * j + "\t");
                }
                Console.Write("\n");
            }
        }

        public static void exercicio2()
        {
            Random rand = new Random();
            double[] precos_produtos = new double[10];

            for(int i =0; i<precos_produtos.Length; i++)
            {
                //preenchendo vetor com valores aleatorios entre 5 e 60
                precos_produtos[i] = Convert.ToDouble(rand.Next(5,100));

                //aumentando preço do produto em 15% de após o preenchimento de seu valor
                precos_produtos[i] = precos_produtos[i] * 1.15;


                //Exibindo Vetor para o Usuario
                Console.WriteLine("Produto: " + i + " Preço: " + Math.Round(precos_produtos[i], 2));
            }
        }

        public static void exercicio3()
        {
            Console.WriteLine("Digite 10 numeros");
            //Instanciando vetor do tipo double com 10 de espaço
            double[] vetor = new double[10];
            double soma=0, media=0;

            for(int i=0; i<10; i++)
            {
                //preenchimento do vetor com entrada de dados do usuario
                vetor[i] = Convert.ToDouble(Console.ReadLine());
                //soma dos elementos do vetor para realizar a media posteriormente
                soma += vetor[i];
            }

            //calculo da media do vetor
            media = soma / 10;

            Console.WriteLine("Media: " + media);

            for(int i=0; i<10; i++)
            {
                if (vetor[i] == media)
                {
                    //Encerra o programa caso um dos elementos do vetor seja igual a sua media e o exibe ao usuario
                    Console.WriteLine("Elemento no indice: " + i+1 + " é igual a media: " + vetor[i]);
                    break;
                }
            }
        }

    
        public static void exercicio4()
        {
            /* Fazer uma rotina aguarda um strgin do teclado e retorna o valor 1 se a string
            digitada foi "SIM" e 0 se a string digitado foi "NAO". A rotina/função só deve retornar 
            alguma coisa se a string digitadxor for "SIM" ou "NAO". Faça a verificação para que
            o usuário não estrague seu código*/

            Console.WriteLine("Digite a palavra SIM ou NAO");
            //Armazena a string digitada pelo usuario na variavel palavra
            string palavra = Console.ReadLine();
            rotina_do_exercicio4(palavra);

        }

        public static void rotina_do_exercicio4(string palavraParaVerificar){
            //Verifica se a string passada como parametro é diferente de SIM ou NAO, caso
            // seja verdadeiro sai da rotina e encerra o exercicio
            if(!(palavraParaVerificar.Equals("SIM") || palavraParaVerificar.Equals("NAO")))
            {
                return;
            }

            //imprime para o usuario qual o tipo de retorno ele deve ter da rotina
            if (palavraParaVerificar.Equals("NAO"))
            {
                Console.WriteLine("0");
            }else{
                Console.WriteLine("1");
            }
        }

        public static void exercicio6()
        {
            //Realizar a sequencia de fibonnaci ate o 10 termo
            Console.WriteLine("Digite um numero inteiro para passar pela sequencia de fibbonaci");
            //Armazena o numero da entrada de dados do usuario o convertendo de string para inteiro
            int numero = Convert.ToInt32(Console.ReadLine());
            fibonacci_ex6(numero);
        }

        public static void fibonacci_ex6(int number)
        {
            Console.Write("Sequencia de fibonacci para o numero: " + number + "\n");
            //criacao de um vetor para armazenar a sequencia de numeros
            int[] fibbonaci = new int[12];

            //dois primeiros elementos armazenados no vetor são iguais ao numero passado como parametro para a função
            fibbonaci[0] = number;
            fibbonaci[1] = number;

            //realiza a conta do termo atual ser o resultado da soma dos dois termos anteriores
            //armazenando seu valor no vetor para usa-lo como o termo anterior no calculo do proximo termo
            for(int i=2; i<12; i++){
                fibbonaci[i] = fibbonaci[i-1] + fibbonaci[i-2];
                Console.Write(fibbonaci[i] + " ");
            }
        }

        public static void exercicio7()
        {
            int[] vetor = new int[4];
            int i=0;
            Console.WriteLine("Digite 4 numeros inteiros");
            while(i<vetor.Length)
            {
                //recebendo entrada de dados dos 4 inteiros do usuario
                vetor[i] = Convert.ToInt32(Console.ReadLine());
                i++;
            }
            
            Console.WriteLine(calculo_ex07(vetor));
        }

        public static float calculo_ex07(int[] vet)
        {
            float res;
            //realizando a conta e armazena resultado em um valor inteiro
            res = (float) (vet[0]*3) + vet[1] + vet[2];
            //retornando resultado para o usuario
            return res;
        }

        public static void exercicio8()
        {
            //Instanciando a Classe Random para poder gerar numeros aleatorios;
            Random rand = new Random();
            int[] vetor = new int[10];

            Console.WriteLine("Vetor com numeros gerados aleatoriamente: ");
            for(int i=0; i<vetor.Length; i++)
            {
                //Preenchendo Vetor com numeros aleatorios do tipo inteiro entre 0 e 100
                vetor[i] = Convert.ToInt32(rand.Next(0, 100));
                //Imprimindo Vetor na ordem em que foi preenchido
                Console.Write(vetor[i] + " ");
            }

            Console.WriteLine("\nVetor com numeros ordenados: ");
            //Chamada da Função bubblesort 
            bubbleSort(vetor);
            for(int i=0; i<vetor.Length; i++)
            {
                Console.Write(vetor[i] + " ");
            }
        }

        public static int[] bubbleSort(int[] vetorParametro)
        {
            //Criação da variavel auxiliar
            int aux;
            //Vetor é percorrido duas vezes em loops for aninhados, loop i e loop j
            for(int i=0; i<vetorParametro.Length; i++)
            {
                //numero i serve como o numero base para o loop j
                for(int j=i+1; j<vetorParametro.Length; j++)
                {
                    //caso o numero no indice i seja maior que o numero no indice j
                    //é realizada a troca dos valores com o uso da variavel auxiliar
                    if(vetorParametro[i] > vetorParametro[j])
                    {
                        aux = vetorParametro[j];
                        vetorParametro[j] = vetorParametro[i];
                        vetorParametro[i] = aux;
                    }
                }
            }
            //retorno do vetor ordenado
            return vetorParametro;
        }

        public static void exercicio9()
        {
            //Instanciando a Classe Random para poder gerar numeros aleatorios;
            Random rand = new Random();
            float[] vetor = new float[10];

            Console.WriteLine("Vetor com numeros gerados aleatoriamente: ");
            for(int i=0; i<vetor.Length; i++)
            {
                //Preenchendo Vetor com numeros aleatorios do tipo inteiro entre 0 e 100
                vetor[i] = rand.Next(0, 100);
                //Imprimindo Vetor na ordem em que foi preenchido
                Console.Write(vetor[i] + " ");
            }

            //Imprimindo maior e menor elemento do vetor com o uso das funções
            //verificaMenor e verificaMaior
            Console.WriteLine("\nMenor elemento do vetor: " + verificaMenor(vetor));
            Console.WriteLine("Maior elemento do vetor: " + verificaMaior(vetor));

            
        }

        public static float verificaMenor(float[] vet)
        {
            //Assume o valor de menor para o primeiro elemento no vetor
            float menor=vet[0];

            //percorrendo o vetor com um loop
            for(int i=1; i<vet.Length; i++)
            {
                
                if(menor > vet[i])
                {
                    menor = vet[i];
                }
            }

            //retorno da variavel menor
            return menor;
        }

        public static float verificaMaior(float[] vet)
        {
            //Assume o valor de maior para o primeiro elemento no vetor
            float maior=vet[0];

            //percorrendo o vetor com um loop
            for(int i=1; i<vet.Length; i++)
            {
                //se o elemento mario for maior que o elemento no indice i
                //a variavel maior asssume o valor do vetor no indice i
                //realizando isso por todo o vetor é obtido seu maior elemento 
                if(maior < vet[i])
                {
                    maior = vet[i];
                }
            }

            //retorno da variavel maior
            return maior;
        }

        public static void exercicio10()
        {
            Console.WriteLine("Digite um numero inteiro: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            parOuImpar(numero);
        }

        public static void parOuImpar(int number){
            if(number % 2 == 0){
                Console.WriteLine("Numero " + number +" é par");
            }else{
                Console.WriteLine("Numero " + number +" é ímpar");
            }
        }
    }

}
