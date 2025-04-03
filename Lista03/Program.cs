using System;
using System.Collections.Specialized;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
namespace Lista03
{
    public class Program
    {
        public unsafe static void Main()
        {
            //exercicio01();
            //exercicio02();
            //exercicio03();
            //exercicio04();
            //exercicio05();
            //exercicio06();
            //exercicio07();
            //exercicio08();
            //exercicio09();
            exercicio10();
        }

        public unsafe static void exercicio01()
        {
            //Criação de uma constante para a quantidade de atletas
            const int qtdAtletas = 5;
            //Criação do vetor da struct de atletas
            Atleta[] atletas = new Atleta[qtdAtletas];

            Console.WriteLine($"Preencha os dados dos atletas");

            //Preenchimento do vetor de atletas com o uso do ponteiro pont_atleta
            fixed (Atleta* pont_atleta = atletas)
            {
                for (int i = 0; i < qtdAtletas; i++)
                {
                    Console.Write($"\nNome  atleta: {i + 1} ");
                    pont_atleta[i].nome = Console.ReadLine();

                    Console.Write($"\nNome  posicao: {i + 1} ");
                    pont_atleta[i].posicao = Console.ReadLine();

                    Console.Write($"\nNome  idade: {i + 1} ");
                    pont_atleta[i].idade = int.Parse(Console.ReadLine());

                    Console.Write($"\nNome  altura: {i + 1} ");
                    pont_atleta[i].altura = float.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nDados inseridos: ");
            imprimeAtletas(atletas, qtdAtletas);

            Console.WriteLine("\nAtletas ordenados do mais velho para o mais novo\n");
            ordenaDecrescenteAtletas(atletas, qtdAtletas);
            imprimeAtletas(atletas, qtdAtletas);
        }

        public static void imprimeAtletas(Atleta[] pessoas, int quantidade)
        {
            //função que percorre um loop for imprimindo os dados dos jogadores 
            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"{pessoas[i].nome} idade: {pessoas[i].idade} {pessoas[i].posicao} altura: {pessoas[i].altura}");
            }
        }

        public static void ordenaDecrescenteAtletas(Atleta[] pessoas, int quantidade)
        {
            //implementação de função bubblesort para ordenar jogares de maneira decrescente
            //em relação a sua idade
            Atleta aux;
            for (int i = 0; i < quantidade; i++)
            {
                for (int j = i + 1; j < quantidade; j++)
                {
                    if (pessoas[i].idade < pessoas[j].idade)
                    {
                        //em vez de trocar apenas as idades deve-se trocar todo o elemento no indice
                        //assim com o uso de uma struct de atleta auxiliar esta troca é realizada
                        aux = pessoas[j];
                        pessoas[j] = pessoas[i];
                        pessoas[i] = aux;
                    }
                }
            }
        }


        //Criação da struct de atleta
        public struct Atleta
        {
            public string nome;
            public string posicao;
            public int idade;
            public float altura;
        }


        public unsafe static void exercicio02()
        {
            //uso de uma constante para a quantidade de produtos
            const int qtdProdutos = 5;
            //criação do vetor da struct de produtos
            Produto[] produtos = new Produto[qtdProdutos];

            Console.WriteLine("Prencha os dados dos produtos: ");

            //Populando o vetor com o uso do ponteiro_prod apontando para a struct de produtos
            fixed (Produto* ponteiro_prod = produtos)
            {
                //Produto* ponteiro_aux = ponteiro_prod;
                for (int i = 0; i < qtdProdutos; i++)
                {
                    Console.WriteLine($"Produto {i + 1}");
                    Console.Write($"\nNome: ");
                    ponteiro_prod[i].nome = Console.ReadLine();

                    Console.Write($"\ncodigo: ");
                    //como o atributo codigo é um ponteiro é necessario usar ao Alloc para definir o tamanho
                    //do espaço de memoria que será utilizado, no caso tamanho de um inteiro
                    ponteiro_prod[i].codigo = (int*)Marshal.AllocHGlobal(sizeof(int));
                    //Após isso a atribuição pode ser realizada ao conteudo que o ponteiro está apontando
                    //o mesmo se aplica para o atributo preço, porém com double ao invés de int
                    *ponteiro_prod[i].codigo = int.Parse(Console.ReadLine());


                    Console.Write($"\npreco: ");
                    ponteiro_prod[i].preco = (double*)Marshal.AllocHGlobal(sizeof(double));
                    *ponteiro_prod[i].preco = double.Parse(Console.ReadLine()); ;

                    Console.Write($"\nfornecedor: ");
                    ponteiro_prod[i].fornecedor = Console.ReadLine();
                }

                if (verificaCodigoProduto(produtos, qtdProdutos))
                {
                    imprimeProdutos(produtos, qtdProdutos);
                }
                else
                {
                    Console.WriteLine("Produtos não podem possuir o mesmo código");
                }

                //liberação da memoria alocada ao final do programa
                for(int i=0; i<qtdProdutos; i++)
                {
                    NativeMemory.Free(ponteiro_prod[i].preco);
                    NativeMemory.Free(ponteiro_prod[i].codigo);
                }

            }
        }

        public static unsafe void imprimeProdutos(Produto[] prods, int tamanho)
        {
            //Função que realiza a impressão dos produtos cadastrados
            for (int i = 0; i < tamanho; i++)
            {
                //como os atributos codigo e preço são ponteiros são necessarios criar ponteiros para realizar a sua impressão
                //assim exibindo o seu conteudo e não o endereço de memoria que o ponteiro aponta.
                int* codigo = prods[i].codigo;
                double* preco = prods[i].preco;
                Console.WriteLine($"{prods[i].nome}: {*preco} codigo: {*codigo} fornecedor: {prods[i].fornecedor}");
            }
        }

        //Função para verificar se os produtos possuem códigos iguais
        public static unsafe bool verificaCodigoProduto(Produto[] produtos, int tamanho)
        {
            //Uso de for aninhado para realizar a comparação de todos os conteudos dentro do ponteiro de codigo
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = i + 1; j < tamanho; j++)
                {
                    if (*produtos[i].codigo == *produtos[j].codigo)
                    {
                        //Caso os conteudos sejam iguais ele irá retornar falso, caso contrario retorna verdadeiro
                        return false;
                    }
                }
            }

            return true;
        }

        //Criação da struct de produto
        public unsafe struct Produto
        {
            public string nome;
            public int* codigo;
            public double* preco;
            public string fornecedor;
        }

        public unsafe static void exercicio03()
        {
            //int arr[5] = { 10, 80, 40, 30, 20 }; sintaxe errada
            int[] vet = { 10, 80, 40, 30, 20 };
            int inx;
            fixed (int* parr = &vet[4])
            {
                inx = 0;
                inx = *parr + 1;
                Console.WriteLine($"Para aonde parr está apontando: {*parr}");
            }

            Console.WriteLine($"Valor de inx: {inx}");

            //A. o codigo não compilaria por erros em sua sintaxe
            //B. 21, pois é o conteudo de parr (20) + 1 = 21
            //C. parr continua apontando para o indice 4 do vetor
        }

        public unsafe static void exercicio04()
        {
            /*
            string* nome1 = "Luis";
            string* nome2 = "Fernando";
            string* nome3 = "Vitoria";
            string* nome4 = "Leticia";
            */

            string[] nomes = { "Luis", "Fernando", "Vitoria", "Leticia" };

            fixed (string* ptr_nomes = nomes)
            {
                Console.WriteLine($"Concatenando strings");

                Console.WriteLine($"{ptr_nomes[0]} {ptr_nomes[1]} {ptr_nomes[2]} {ptr_nomes[3]} ");

            }
        }


        public unsafe static void exercicio05()
        {
            int count = 30; 
            int sum = 2;
            int*temp;

            temp = &count;
            *temp = 20;
            Console.WriteLine($"variavel count: {count}");
            Console.WriteLine($"conteudo do ponteiro temp {*temp}");

            //temp = 8; esta linha gera erro, pois esta tentando associar um valor inteiro a um ponteiro q armazena um numero hexadecimal da memoria

            * temp = count;
            Console.WriteLine($"conteudo do ponteiro temp {*temp}");
            //como o valor do conteudo de temp foi alterado para 20 a variavel count também passa a valer 20
        }

        public unsafe static void exercicio06()
        {
            //instancia de objeto da classe random para auxiliar na população dos vetores
            Random rand = new Random();
            //criação de uma constante para o tamanho dos vetores
            const int tamanhoVetores = 5;
            //instancia da estrutura 
            struct_ex06 estrutura = new struct_ex06();
            
            //delimitação de cada vetor da estrutura para o tamanho da constante criada
            estrutura.inteiros = new int[tamanhoVetores];
            estrutura.decimais = new double[tamanhoVetores];
            estrutura.letras = new char[tamanhoVetores];

            for(int i=0; i<tamanhoVetores; i++)
            {
                //população dos vetores aleatoriamente com uso da classe rand e da função geraLetraAleatoria
                estrutura.inteiros[i] = rand.Next(1,10);
                estrutura.decimais[i] = rand.NextDouble();
                estrutura.letras[i] = geraLetraAleatoria();
            }

            //impressao da struct
            imprimeScruct(estrutura, tamanhoVetores);

            //declaração dos ponteiros no inicio de cada vetor da estrutura
            fixed(int* ptr_inteiros = estrutura.inteiros)
            fixed(double* ptr_decimais = estrutura.decimais)
            fixed(char* ptr_letras = estrutura.letras)
            {
                //percorre cada vetor por meio do seu respectivo ponteiro, alterando seu conteudo
                for(int i=0; i<tamanhoVetores; i++)
                {
                    ptr_inteiros[i] = 100;
                    ptr_decimais[i] = 1.99;
                    ptr_letras[i] = 'W';
                }
            }
            
            //Impressão do vetor alterado pelos ponteiros
            Console.WriteLine("\nPreenchendo valores por ponteiros");
            imprimeScruct(estrutura, tamanhoVetores);
        }

        public static void imprimeScruct(struct_ex06 estrutura, int tamanho)
        {
            //função para imprimir dados dentro de cada indice da estrutura
            for(int i=0; i<tamanho; i++)
            {
                Console.Write($"Indice {i+1}");
                Console.WriteLine($" {estrutura.inteiros[i]} {Math.Round(estrutura.decimais[i], 4)} {estrutura.letras[i]}");
            }
        }

        //função que gera letra aleatoria do alfabeto
        public static char geraLetraAleatoria()
        {
            //criação de uma string com as letras do alfabeto
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new();

            //com o uso da clance random sorteia um indice de numero aleatorio de 0 a 25
            int indice = rand.Next(0, 25);

            //retorna conteudo dentro desse indice que será uma letra aleatoria
            return letras[indice];
        }

        //Declaração da estrutura do exercicio 6
        public struct struct_ex06
        {
            public int[] inteiros ;
            public double[] decimais;
            public char[] letras;
        }

        public unsafe static void exercicio07()
        {
            //Criação de uma constante para o tamanho dos vetores de struct
            const int qtdProdutos = 10;
            //instancia das structs de produtos, uma sendo para o preço original e a outra para o novo preço
            produto_ex07[] produtos = new produto_ex07[qtdProdutos];
            produto_ex07[] produtos_novo = new produto_ex07[qtdProdutos];

            //Chamada de função para popular as structs
            populaStructProdutos(produtos, qtdProdutos);
            //chamad da função que copia dados de um vetor de produtos para o outro
            copiaVetorProdutos(produtos, produtos_novo, qtdProdutos);

            fixed(produto_ex07* ptr_produto = produtos_novo)
            {
                //uso de um ponteiro apontando para o vetor de produtos_novos para manipular seus dados
                //realizando um aumento de 4,78 % em seus preços
                for(int i=0;i<qtdProdutos; i++)
                {
                    ptr_produto[i].preco = ptr_produto[i].preco* 1.0478;
                }
            }
            
            //exibição dos preços antigos e dos preços novos pela chamda da função que exibe a estrutura
            Console.WriteLine("\nPreços antigos: ");
            exibeStructProdutos(produtos, qtdProdutos);

            Console.WriteLine("\nPreços novos: ");
            exibeStructProdutos(produtos_novo, qtdProdutos);
        
        }

        public static void copiaVetorProdutos (produto_ex07[] prods, produto_ex07[] prods_novo,int tamanho)
        {
            for(int i=0; i<tamanho; i++)
            {
                //Função que realiza a copia dos dados da primeira struct para a segunda
                prods_novo[i].nome = prods[i].nome;
                prods_novo[i].preco = prods[i].preco; 
            }
        }

        public static void populaStructProdutos(produto_ex07[] prods, int tamanho)
        {
            Random rand = new();
            for(int i=0; i<tamanho; i++)
            {
                //Uso da função gera letra aleatoria para gerar 3 letras aleatorias para o nome
                prods[i].nome = Convert.ToString(geraLetraAleatoria()) + Convert.ToString(geraLetraAleatoria()) + Convert.ToString(geraLetraAleatoria());
                //Uso da função rand para gerar um numero aleatorio de 10 a 100
                prods[i].preco = rand.Next(10,100);
            }
        }

        //Função que exibe a struct de produtos e seus atributos por meio de um loop for
        public static void exibeStructProdutos(produto_ex07[] prods, int tamanho)
        {
            for(int i=0; i<tamanho; i++)
            {
                Console.WriteLine($"produto {i+1} nome: {prods[i].nome} preço: {Math.Round(prods[i].preco, 2)}");
            }
        }

        //Criação da struct produto usada no exercicio 7
        public struct produto_ex07
        {
            public string nome;
            public double preco;
        }

        public static unsafe void exercicio08()
        {
            //criação de constantes para o tamanho deo vetor e da matriz
            const int tamanhoVet = 9;
            const int tamanhoMatriz = 3;

            //uso da classe random para gerar numeros aleatorios para popular o vetor
            Random rand = new();

            //criação do vetor unidimendsional e do vetor bidimensional(matriz)
            int[] vetor = new int[tamanhoVet];
            int[,] matriz = new int[tamanhoMatriz, tamanhoMatriz];

            fixed(int* ptr_vetor = vetor)
            {
                //percorrendo vetor por meio do ponteiro ptr_vetor e adicionando um valor aleatorio por meio da classe random
                for(int i=0;i<tamanhoVet; i++)
                {
                    ptr_vetor[i] = rand.Next(1,20);
                }
            }

            //chamada da função para ordenar o vetor (bubblesort)
            ordenaVetor(vetor, tamanhoVet);

            Console.WriteLine("Exibindo vetor: ");
            //chamada da função para exibir o vetor
            exibeVetor(vetor, tamanhoVet);

            fixed(int* ptr_vetor = vetor)
            {
                //uso da variavel contador_vet para guardar o indice que sera usado para passar o valor do mesmo para a matriz
                int contador_vet = 0;
                for(int i=0; i<tamanhoMatriz; i++)
                {
                    //uso de loops for aninhados, sendo um para a linha e outro para a coluna da matriz
                    for(int j=0; j<tamanhoMatriz; j++)
                    {
                        //atribuição do valor do vetor para a matriz
                        matriz[i,j] = vetor[contador_vet];
                        //incremento da variavel contador_vet para adicionar o proximo valor no proximo laço
                        contador_vet++;
                    }
                }
            }

            Console.WriteLine("Exibindo matriz com populada com elementos do array");
            //chamada da função para exibir a matriz
            exibeMatriz(matriz, tamanhoMatriz, tamanhoMatriz);
        }

        //implementação de metodo de ordenação bubblesort
        public static void ordenaVetor(int[] vet, int tamanho)
        {
            int aux;
            //uso de loops for aninhados para percorrer o vetor e trocar de posicao
            //caso a variavel no indice i seja maior que no indice j (que sempre sera maior que i)
            //Assim o vetor fica ordenado de maneira crescente
            for(int i=0; i<tamanho; i++)
            {
                for(int j=i+1; j<tamanho; j++)
                {
                    if(vet[i]>vet[j])
                    {
                        aux = vet[i];
                        vet[i] = vet[j];
                        vet[j] = aux;
                    }
                }
            }
        }

        public static void exibeMatriz(int[,] matriz, int linha, int coluna)
        {
            //exibe a matriz por meio de loops for aninhados, sendo um para a linha e outro para a coluna
            for(int i=0; i<linha; i++)
            {
                for(int j=0; j<coluna; j++)
                {
                    Console.Write($"{matriz[i,j]} ");
                }
                Console.Write("\n");
            }
        }
    
        public static void exibeVetor(int[] vet, int tamanho)
        {
            //loop for simples para exibir dados do array em uma unica linha
            Console.WriteLine("");
            for(int i=0; i<tamanho; i++)
            {
                Console.Write($"{vet[i]} ");
            }
            Console.WriteLine("\n");
        }

        public static unsafe void exercicio09()
        {
            //criação das variaveis frase1 e frase2
            string frase1;
            string frase2;
            Console.WriteLine("Digite duas frases");

            //entrada de dados nas variaveis frase
            Console.WriteLine("Primeira frase: ");
            frase1 = Console.ReadLine();

            Console.WriteLine("Segunda frase: ");
            frase2 = Console.ReadLine();

            //armazenamento do tamanho de cada frase em uma variavel do tipo inteiro realizada pela
            //chamada da função contarFrase
            int tamanhoFrase1 = contarFrase(frase1);
            int tamanhoFrase2 = contarFrase(frase2);
            
            if(tamanhoFrase1 > tamanhoFrase2)
            {
                Console.WriteLine($"Primeira frase é a maior frase com {tamanhoFrase1} caracteres");
            }else if(tamanhoFrase1 < tamanhoFrase2)
            {
                Console.WriteLine($"Segunda frase é a maior frase com {tamanhoFrase2} caracteres");
            }else
            {
                Console.WriteLine($"Ambas as frases possuem o mesmo tamanho sendo ele {tamanhoFrase1}");
            }


        }

        public unsafe static int contarFrase(string frase)
        {
            //a função utiliza um ponteiro de char para percorrer a frase passada como parametro para a função
            int contador=0;
            fixed(char* ptr = frase)
            {
                //assim por uso de um loop while é comparado se o ponteiro apontando para a frase possui o valor diferente de \0
                //pois \0 representa o final de uma string em c#, assim utilizando um contador dentro do loop é possivel descobrir o tamanho
                // da string, percorrendo ela até encontrar o caracter especial \0, assim retornando o contador
                int i=0;
                while(ptr[i] != '\0')
                {
                    contador++;
                    i++;
                }
            }

            return contador;
        }

        public static unsafe void exercicio10()
        {
            //criação de uma constante para o tamanho do vetor
            const int tamanhoVet = 10;

            //instancia de objeto da classe random para gerar numeros aleatorios para popular o vetor
            Random rand = new Random();
            //criação de vetor de inteiros 
            int[] vetor = new int[tamanhoVet];

            fixed(int* ptr_vetor = vetor)
            {
                //loop for que percorre o vetor por meio de um ponteiro e atribui valores a ele por meio da classe rand  
                for(int i=0; i<tamanhoVet; i++)
                {
                    ptr_vetor[i] = rand.Next(1, 10);
                }
            }

            //funções exibeVetor e ordenaVetor foram implementadas no exercicio 8 e foram usadas novamente
            //exibeVetor(vetor, tamanhoVet);

            ordenaVetor(vetor, tamanhoVet);

            exibeVetor(vetor, tamanhoVet);

            //entrada de dados do usuario de qual numero ele deseja buscar
            Console.WriteLine("Digite o numero que deseja buscar no vetor");
            int num_busca = int.Parse(Console.ReadLine());

            //caso a função procuraNum retorne true sera exibido que o numero existe no vetor
            //caso contrario será exibido que o numero não existe no vetor
            if(procuraNum(num_busca, vetor, tamanhoVet))
            {
                Console.WriteLine($"Numero {num_busca} existe no vetor");
            }else
            {
                Console.WriteLine($"Numero {num_busca} não encontrado no vetor");
            }
        }

        public static bool procuraNum(int num_busca, int[] vet, int vetTamanho)
        {
            //loop for que percorre o vetor procurando numero num_busca passado como parametro
            //caso encontre o numero retorna true, caso contrario retorna false
            for(int i=0; i<vetTamanho; i++)
            {
                if(vet[i] == num_busca)
                {
                    return true;
                }
            }

            return false;
        }       
    }
}