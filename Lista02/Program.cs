using System;
using System.ComponentModel;
using System.Formats.Asn1;

namespace Lista02
{
    class Programa
    {
        public static void Main(string[] args)
        {
            
            //exercicio01();
            //exercicio02();
            //exercicio03();
            //exercicio04();
            //exercicio05();
            //exercicio06();
            exercicio07();
        }

        public static void exercicio01()
        {
            Random rand = new Random();
            Conta[] contas = new Conta[5];

            Console.WriteLine("Preencha os dados das contas");
            for(int i=0; i<5; i++)
            {
                //leitura dos dados de nome da conta e cpf
                Console.WriteLine($"Nome conta {i+1}: ");
                contas[i].nome = Console.ReadLine();

                Console.WriteLine($"Cpf conta {i+1}: ");
                contas[i].cpf = long.Parse(Console.ReadLine());

                //saldo preenchido automaticamente por meio da função rand.Next que gera um numero entre 
                //50 e 10000 e atribui ao saldo da conta que esta sendo preenchida
                contas[i].saldo = rand.Next(50, 10000);
            }

            ordenaContas(contas, 5);

            Console.WriteLine("Contas ordenadas em forma drescente: ");

            for(int i=0; i<5; i++)
            {
                Console.WriteLine($"Conta {i+1}: Nome: {contas[i].nome} Saldo: {contas[i].saldo}");
            }


        }


        //implementação de metodo bubblesort para ordenar de maneira decrescente as contas de acordo com o saldo
        static public Conta[] ordenaContas (Conta[] contas, int tamanhoVetor)
        {
            float aux;
            for(int i=0; i<tamanhoVetor; i++)
            {
                for(int j=i+1; j<tamanhoVetor; j++)
                {
                    if(contas[i].saldo < contas[j].saldo)
                    {
                        aux = contas[i].saldo;
                        contas[i].saldo = contas[j].saldo;
                        contas[j].saldo = aux;
                    }
                }
            }
            return contas;
        }


        //Criação da estrutura Conta 
        public struct Conta
        {
            public string nome;
            public long cpf;
            public float saldo;
        }

        static public void exercicio02()
        {
            //Uso da Classe Random para gerar numeros aleatorios para preencher os dados do programa
            //em relação as dadas de nascimento
            Random rand = new();
            //criação de uma constante para o tamanho do vetor da struct de pessoas
            const int tamanho = 5;
            Pessoa[] pessoas = new Pessoa[tamanho];
            
            Console.WriteLine($"Digite o nome e a data de nascimento de {tamanho} pessoas");

            for(int i=0; i<tamanho; i++)
            {
                //atribuição do nome de cada pessoa por meio de entrada de dados do usuario
                Console.WriteLine($"Digite o nome da pessoa {i+1}: ");
                pessoas[i].nome = Console.ReadLine();

                Console.WriteLine($"Data de nascimento da pessoa {pessoas[i].nome}");
                pessoas[i].data_nasc.dia = rand.Next(1,30);
                pessoas[i].data_nasc.mes = rand.Next(1,12);
                pessoas[i].data_nasc.ano = rand.Next(1950,2024);
                Console.WriteLine($"{pessoas[i].data_nasc.dia} / {pessoas[i].data_nasc.mes} / {pessoas[i].data_nasc.ano}");
            }

            //atribuição do resultado da funcao que encontra a pessoa mais velha para a variavel pessoa_mais_velha
            Pessoa pessoa_mais_velha = encontraMaisVelho(pessoas, tamanho);

            //Impressão dos dados da pessoa masi velha
            Console.WriteLine($"A pessoa mais velha é : {pessoa_mais_velha.nome} ");
            Console.WriteLine($"{pessoa_mais_velha.data_nasc.dia} / {pessoa_mais_velha.data_nasc.mes} / {pessoa_mais_velha.data_nasc.ano}");

        }

        //declaração da struct de Data
        public struct Data
        {
            public int dia;
            public int mes;
            public int ano;
        }

        //Declaração da struct de Pessoa

        public struct Pessoa
        {
            public string nome;
            public Data data_nasc;
        }

        public static Pessoa encontraMaisVelho(Pessoa[] pessoas, int tamanho)
        {
            Pessoa pessoa_velha = pessoas[0];

            for(int i=1; i<tamanho; i++)
            {
                //percorre o vetor de pessoas verificando a idade em ano, dia e mes
                //caso o ano das idades sejam iguais ira usar o mes como criterio de quem é mais velho
                //caso o mes seja igual usara o dia como criterio de quem é mais velho 
                if(pessoas[i].data_nasc.ano <= pessoa_velha.data_nasc.ano)
                {
                    pessoa_velha = pessoas[i];

                    if(pessoas[i].data_nasc.mes <= pessoa_velha.data_nasc.mes)
                    {
                        pessoa_velha = pessoas[i];

                        if (pessoas[i].data_nasc.dia <= pessoa_velha.data_nasc.dia)
                        {
                            pessoa_velha = pessoas[i];
                        }
                    }

                }
            }

            return pessoa_velha;
        }

        public static void exercicio03()
        {
            //criando pontos A e B
            Ponto pontoA = new();
            Ponto pontoB = new();

            Console.WriteLine("Calculando a distância entre dois pontos no plano cartesiano");
            Console.WriteLine("Insira as medidas x e y do ponto A respectivamente: ");
            pontoA.x = double.Parse(Console.ReadLine());
            pontoA.y = double.Parse(Console.ReadLine());

            Console.WriteLine("Insira as medidas x e y do ponto B respectivamente: ");
            pontoB.x = double.Parse(Console.ReadLine());
            pontoB.y = double.Parse(Console.ReadLine());

            double distancia_pA_pB = distanciaPontos(pontoA, pontoB);

            Console.WriteLine($"a distancia entre os pontos A e B tem como resultado: {Math.Round(distancia_pA_pB, 2)}");
        }

        public static double distanciaPontos(Ponto p1, Ponto p2)
        {
            double distancia_pontos;

            distancia_pontos = Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
            
            return distancia_pontos;
        } 

        public struct Ponto 
        {
            public double x;
            public double y;
        }

        public static void exercicio04()
        {
            //uso da classe random para gerar numeros aleatorios
            Random rand = new();
            
            //criação das constantes tamanho e qtdLados para facilitador o uso dos loops e tamanho de arrays
            const int tamanho = 2;
            const int qtdLados = 3;
            
            //variavel j seria usado no caso de entrada de dados pelo usuario
            int j=0;

            //instancia dos dois triangulos
            Triangulo[] triangulos = new Triangulo[tamanho];

            //criacao de dois vetores para armazenar medidas dos lados dos triangulos
            double[] medidas_triangulo1 = new double[qtdLados];
            double[] medidas_triangulo2 = new double[qtdLados];


            Console.WriteLine("Preencha as medidas dos triangulos");
            
            for(int i=0; i<tamanho; i++)
            {
                //As linhas comentadas representam como seria a entrada de dados
                //se fosse realizada pelo usuario e não pela classe random


                j++;
                //Console.WriteLine($"Digite as medidas dos pontos X e Y do ponto {j} do triangulo {i+1} respectivamente");
                //triangulos[i].p1.x = double.Parse(Console.ReadLine());
                triangulos[i].p1.x = rand.Next(1,10);
                triangulos[i].p1.y = rand.Next(1,10);
                //triangulos[i].p1.y = double.Parse(Console.ReadLine());
                j++;

                //Console.WriteLine($"Digite as medidas dos pontos X e Y do ponto {j} do triangulo {i+1} respectivamente");
                //triangulos[i].p2.x = double.Parse(Console.ReadLine());
                triangulos[i].p2.x = rand.Next(1,10);
                triangulos[i].p2.y = rand.Next(1,10);
                //triangulos[i].p2.y = double.Parse(Console.ReadLine());
                j++;

                //Console.WriteLine($"Digite as medidas dos pontos X e Y do ponto{j} do triangulo {i+1} respectivamente");
                //triangulos[i].p3.x = double.Parse(Console.ReadLine());
                triangulos[i].p3.x = rand.Next(1,10);
                triangulos[i].p3.y = rand.Next(1,10);
                //triangulos[i].p3.y = double.Parse(Console.ReadLine());
                j=0;

            }


            //Chamada da função ladostriangulo para calcular os lados dos triangulos e salvar dentro
            //do vetor medidas_triangulo
            medidas_triangulo1 = ladostriangulo(triangulos[0]);
            medidas_triangulo2 = ladostriangulo(triangulos[1]);

            //Impressão das medidas dos triangulos para os usuarios
            Console.WriteLine("Medidas dos lados do triangulo 1: ");
            imprimeLados(medidas_triangulo1);

            Console.WriteLine("Medidas dos lados do triangulo 2: ");
            imprimeLados(medidas_triangulo2);

            //Verificação das medidas dos triangulos por meio da chamada da função verificaTipoTriangulo
            Console.WriteLine($"Triangulo 1 é: {verificaTipoTriangulo(medidas_triangulo1)}");
            Console.WriteLine($"Triangulo 2 é: {verificaTipoTriangulo(medidas_triangulo2)}");
          
        }

        //Função que verifica o tipo do triangulo
        public static String verificaTipoTriangulo(double[] lados)
        {
            //chamada da função que verifica a condição de existencia do triangulo
            //como o seu retorno é do tipo boolean, caso seja falso ira retornar a string (triangulo invalido)
            //caso seja verdadeiro ira entrar na verificação do tipo do triangulo
            if(verificaSeTrianguloPodeExistir(lados))
            {
                //primeiro verifica se algum lado é igual, caso não o triangulo sera escaleno
                if(lados[0] == lados[1] || lados[0] == lados[2] || lados[1] == lados[2])
                {
                    //caso existam lados comuns é feita outra verificação para caso todos os lados sejam iguais
                    //se sim o triangulo será equilatero, se não será Isósceles
                    if(lados[0] == lados[1] && lados[0] == lados[2])
                    {
                        return "Equilátero";
                    }
                    return "Isósceles";
                }else
                {
                    return "Escaleno";
                }
            }else
            {
                return $"Triangulo inválido";
            }
            
        }

        public static void imprimeLados (double[] medidasLados)
        {
            //função utilizada somente para automatizar impressão dos dados do triangulo
            //uso de um loop for para imprimir a medida de cada lado armazenada no vetor double
            for(int i=0; i<3; i++)
            {
                Console.WriteLine($"lado {i+1} do triangulo: {Math.Round(medidasLados[i]), 2}");
            }
        }


        //Função para verificar se triangulo obedece as condições de existencia de um triangulo
        public static bool verificaSeTrianguloPodeExistir(double[] lados)
        {
            //A condição de existencia de um triangulo consiste em a soma de 2 lados do triangulo
            //sempre devem ser maiores do que o outro lado
            if(lados[0]+ lados[1] > lados[2])
            {
                if(lados[0] + lados[2] > lados[1])
                {
                    if(lados[2] + lados[1] > lados[0])
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        
        //Função usada para calcular os lados do triangulo
        public static double[] ladostriangulo(Triangulo triangulo)
        {
            //criação de vetor do tipo double para armazenar valor da distancia entre os pontos do triangulo
            double[] ladosTriangulo = new double[3];
            
            //Calculo da distancia entre os pontos do triangulo com o uso da função distanciaPontos
            ladosTriangulo[0] = distanciaPontos(triangulo.p1, triangulo.p2);
            ladosTriangulo[1] = distanciaPontos(triangulo.p1, triangulo.p3);
            ladosTriangulo[2] = distanciaPontos(triangulo.p2, triangulo.p3);
            

            return ladosTriangulo;
        }
        

        //Criação da Struct Triangulo contando 3 structs ponto
        public struct Triangulo
        {
            public Ponto p1;
            public Ponto p2;
            public Ponto p3;
        }


        public static void exercicio05()
        {
            const int tamanho = 5;

            Produto[] produtos = new Produto[tamanho];
            Console.WriteLine("Digite os dados dos produtos");
            cadastroProdutos(produtos, tamanho);

            while(verificaQtdProdutos(produtos, tamanho))
            {
                exibeProdutos(produtos, tamanho);

                vendaProduto(produtos, tamanho);

                if(!(verificaQtdProdutos(produtos, tamanho)))
                {
                    break;
                }
            }

            Console.WriteLine("Saldo final");

            exibeProdutos(produtos, tamanho);

            
            



        }

        public static Produto[] vendaProduto(Produto[] prods, int tamanho)
        {
            //usuario entra com os dados do codigo de qual produto deseja vender
            Console.WriteLine("Digite o código do produto: ");
            int codigo_prod = int.Parse(Console.ReadLine());

            if(codigo_prod > tamanho)
            {
                //o codigo do produto é atribuido automaticamente, indo de 0 a 5
                //assim caso o codigo seja maior que 5 significa que o codigo é invalido
                Console.WriteLine("Codigo não encontrado");
                //retorna a função
                return prods;
            }

            //loop for que percorre o vetor de produtos
            for(int i=0; i<tamanho; i++)
            {
                //ao encontrar o produto com o mesmo codigo informado, começa a verificação da quantidade que deseja vender
                if(prods[i].codigo == codigo_prod)
                {
                    Console.WriteLine("Digite a quantidade que deseja do produto");
                    int quantidade = int.Parse(Console.ReadLine());

                    //verifica se a quantidade é valida
                    if(prods[i].quantidade >= quantidade)
                    {
                        prods[i].quantidade -= quantidade;

                        //subtrai da quantidade atual e mostra ao usuario a nova quantidade
                        Console.WriteLine($"Pedido efetuado, nova quantidade: {prods[i].quantidade}");
                    }else {
                        Console.WriteLine("Quantidade inválida");
                    }
                }
            }
            
            return prods;
        }

        public static bool verificaQtdProdutos(Produto[] prods, int tamanho)
        {
            //verifica se a quantidade pedida é valida
            for(int i=0; i<tamanho; i++)
            {
                if(prods[i].quantidade <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void exibeProdutos(Produto[] prods, int tamanho)
        {
            //exibe todos os produtos e seus atributos
            for(int i=0; i<tamanho; i++)
            {
                Console.WriteLine($"{prods[i].nome} codigo: {prods[i].codigo} quantidade: {prods[i].quantidade} preço: {prods[i].preco}");
            }
        }

        public static Produto[] cadastroProdutos(Produto[] prods, int tamanho)
        {
            //função que armazena o cadastro de produtos em cada unidade do vetor de structs de produto seu respectivos dados
            for(int i=0; i<tamanho; i++)
            {
                Console.WriteLine("Nome: ");
                prods[i].nome = Console.ReadLine();

                Console.WriteLine("codigo: ");
                prods[i].codigo = i+1;

                Console.WriteLine("quantidade: ");
                prods[i].quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Preço: ");
                prods[i].preco = float.Parse(Console.ReadLine());
            }
            
            //retorno do vetor de produtos 
            return prods;
        }

        //Criação da struct produto com seus atributos
        public struct Produto
        {
            public int codigo;
            public String nome;
            public int quantidade;
            public float preco;    
        }


        public static void exercicio06()
        {
            //criação de uma constante tamanho para facilitar o uso de loops
            const int tamanho = 10;

            //uso da classe Random para gerar numeros aleatorios
            Random rand = new();
            //Criação do vetor de pessoas 
            Pessoa_ex06[] pessoas = new Pessoa_ex06[tamanho];
            
            //preenchimento dos nomes de cada pessoa
            pessoas[0].nome = "Maria";
            pessoas[1].nome = "Ana";
            pessoas[2].nome = "Bruna";
            pessoas[3].nome = "Julia";
            pessoas[4].nome = "Ricardo";
            pessoas[5].nome = "Rose";
            pessoas[6].nome = "José";
            pessoas[7].nome = "Mario";
            pessoas[8].nome = "Dante";
            pessoas[9].nome = "Viktor";

            for(int i=0; i<tamanho; i++)
            {
                //atribuição a um numero aleatorio de 1 a 10 para cada pessoa
                pessoas[i].numero = rand.Next(1,10);
            }

            Console.WriteLine("Jogo da advinhação!");
            Console.WriteLine("Digite um numero: ");

            int numero_entrada = int.Parse(Console.ReadLine());

            for(int i = 0; i<tamanho; i++)
            {
                if(pessoas[i].numero == numero_entrada)
                {
                    //Para cada pessoa que o numero for igual ao numero inserido pelo usuario
                    //sera exibido na tela o numero da pessoa e seu nome
                    Console.WriteLine($"Voce acertou o numero da pessoa numero: {i+1} nome: {pessoas[i].nome}");
                }
            }

            Console.WriteLine("Numero de cada pessoa:");
            for(int i=0;i<tamanho; i++)
            {
                //impressao de cada pessoa e seu respectivo numero
                Console.WriteLine($"{pessoas[i].nome} numero: {pessoas[i].numero}");
            }

        }

        //Criação da struct pessoa para o exercicio 6
        public struct Pessoa_ex06
        {
            public String nome;
            public int numero;
        }

        public static void exercicio07()
        {
            //criação de constantes para declarar q quantidade de voos e de aeroportos
            const int quantidadeVoos = 10;
            const int quantidadeAeroportos = 5;

            //instancia dos vetores de voos e de areportos
            Aeroporto[] aeroportos = new Aeroporto[quantidadeAeroportos];
            Voo[] voos = new Voo[quantidadeVoos];

            //chamada da função que atribui codigos de 1 a 5 a cada aeroporto
            codigoAeroporto(aeroportos, quantidadeAeroportos);
            Console.WriteLine("Codigo dos aeropotos: ");
            //chamad ada função que exibe os codigos de cada aeroporto
            exibeCodigoAeroportos(aeroportos, quantidadeAeroportos);

            Console.WriteLine("Preencha os voos: ");
            //chamada da função para preencher os dados dos voos, com o aeroporto de ida e de chegada
            populaVoos(voos, quantidadeVoos);

            //chamada da função que armazena os dados
            armazenaDados(voos, quantidadeVoos, aeroportos, quantidadeAeroportos);


            //chamada da função que exibe as informações de cada aeroporto
            exibeInformações(aeroportos, quantidadeAeroportos);

        }

        public static void exibeInformações(Aeroporto[] aeroportos, int quantidadeAeroportos)
        {
            for(int i=0; i<quantidadeAeroportos; i++)
            {
                //loop for que exibe as informações do aeroporto, com seu numero de voos de ida e de chegada        
                Console.WriteLine($"Aeroporto {i+1}:");
                Console.WriteLine($"Voos chegada: {aeroportos[i].voos_chegada} \n Voos saida: {aeroportos[i].voos_saida}");
            }
        }

        public static Aeroporto[] armazenaDados (Voo[] voos, int quantidadeVoos, Aeroporto[] aeroportos, int quantidadeAeroportos)
        {
            //Loop for que ira percorrer de 1 a 5 (quantiade de aeroportos no program)
            for(int i=0; i<quantidadeAeroportos; i++)
            {
                //dentro de cada loop i, tera outro loop j que ira verificar se o voo no indice [j]
                //tem o mesmo codigo do aeroporto no indicie[i], assim fazendo a sua atribuição no numero de voos
                for(int j=0; j<quantidadeVoos; j++)
                {
                    //condição if para verificar se cod de ida ou de chegada é igual ao do aeroporto no indidce i
                    if(voos[j].cod_chegada == aeroportos[i].codigo || voos[j].cod_ida == aeroportos[i].codigo)
                    {
                        //verifica se é o codigo de chegada ou de saida que é igual
                        if(voos[j].cod_chegada == aeroportos[i].codigo)
                        {
                            //verificação de o numero de voos é maior q o permitido
                            if(aeroportos[i].voos_chegada >10 )
                            {
                                Console.WriteLine($"limite de voos de chegada atingido para aeroporto {i+1}");
                            }else
                            {
                                //incremento do numero de voos de chegada
                                aeroportos[i].voos_chegada ++; 
                            }
                        }else
                        {   
                            if(aeroportos[i].voos_saida >10)
                            {
                                Console.WriteLine($"limite de voos de saida atingido para aeroporto {i+1}");
                            }else
                            {
                                //incremento do numero de voos de saida
                                aeroportos[i].voos_saida++;
                            }
                        }
                    }
                }
            }

            return aeroportos;
        }


        public static Voo[] populaVoos(Voo[] voos, int quantidadeVoos)
        {
            int i=0;
            //a população do vetor de voos é realizada dentro de um loop while
            while(i<quantidadeVoos)
            {
                Console.WriteLine($"Digite o codigo do aeroporto de ida do voo {i+1}");
                int codigo_vooIda = int.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o codigo do aeroporto de chegada do voo {i+1}");
                int codigo_vooChegada = int.Parse(Console.ReadLine());

                
                //caso o codigo seja invalido ele entrada na condição else, repitindo o loop novamente no mesmo indice
                //o caso invalido esta para codigos fora do intervalo de 1 a 5 e codigos repitidos para ida e chegada do mesmo voo
                if((codigo_vooIda >=1 && codigo_vooIda <= 5) && (codigo_vooChegada >=1 && codigo_vooChegada <=5) && (codigo_vooChegada != codigo_vooIda))
                {
                    //Voo no indice do loop ira receber o codigo do voo de ida e de volta
                    voos[i].cod_ida = codigo_vooIda;
        
                    voos[i].cod_chegada = codigo_vooChegada;

                    i++;
                }else
                {
                    Console.WriteLine("Codigo de aeroporto inválido, preencha novamente");
                }

            }
            return voos;
        }

        public static void exibeCodigoAeroportos(Aeroporto[] aeroportos, int quantidadeAeroportos)
        {
            //loop for para imprimir o codigo do aeroporto no seu indice
            for(int i =0; i<quantidadeAeroportos; i++)
            {
                Console.WriteLine($"Codigo aeroporto {i+1}: {aeroportos[i].codigo}");
            }
        }

        public static Aeroporto[] codigoAeroporto (Aeroporto[] aeroportos, int quantidadeAeroportos)
        {
            //função simples para estabelecer o codigo dos aeroportos de 1 a 5 por meio de um loop for

            for(int i=0; i<quantidadeAeroportos; i++)
            {
                aeroportos[i].codigo = i+1; 
            }

            return aeroportos;
        }


        //Criação da struct de aeroporto
        public struct Aeroporto
        {
            public int codigo;
            public int voos_chegada;
            public int voos_saida;
        }



        //Criação da struct de Voo
        public struct Voo
        {
            public int cod_ida;
            public int cod_chegada;
        }
    }
}