using System;
namespace Una
{
    public class Repeticao
    {
        static void Main(string[] args) {
            q3();
        }

        static void q1() {
            char sexo; int qtMasc = 0, qtFem = 0;
            double peso;
			Console.WriteLine("========= Peso pessoas =========");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("|| " + (i+1) + " Digite o sexo da pessoa('F' para feminino, 'M' para masculino)... ");
				sexo = char.Parse(Console.ReadLine());

				Console.Write("|| Digite o peso... ");
				peso = double.Parse(Console.ReadLine());

                if (sexo == 'M' && peso > 60 && peso < 80) {
                    qtMasc++;
                }
                if (sexo == 'F' && peso > 50 && peso < 70) {
                    qtFem++;
                }
            }
			Console.WriteLine("|| A quantidade de mulheres é de {0}", qtFem);
			Console.WriteLine("|| A quantidade de homens é de {0}", qtMasc);

            Console.ReadKey();
        }

		static void q2()
		{
			char sexo; int qt = 0, idade;
			Console.WriteLine("========= Idade pessoas =========");

			for (int i = 0; i < 3; i++)
			{
				Console.Write("|| " + (i + 1) + " Digite o sexo da pessoa('F' para feminino, 'M' para masculino)... ");
				sexo = char.Parse(Console.ReadLine());

				Console.Write("|| Digite o idade... ");
				idade = int.Parse(Console.ReadLine());

				if (sexo == 'F' && idade > 20 && idade < 40)
				{
					qt++;
				}
			}

			Console.WriteLine("|| A quantidade de mulheres entre 20 e 40 anos é de {0}", qt);
			Console.ReadKey();
		}

        static void q3() {
            Console.WriteLine("========= Média 5 notas alunos =========");

            for (int i = 0; i < 30; i++)
            {
				int media = 0;
                for (int l = 0; l < 5; l++)
                {
                    Console.Write("|| Digite a nota {0} do aluno {1}... ", l+1, i+1);
					media += int.Parse(Console.ReadLine());
				}
                Console.WriteLine("|| A média da notas do aluno {1} é: {0}", media/5, i+1);
            }

            Console.ReadKey();
		}

        static void q4() {
            int idade, idadeMin = -1, idadeMax = 0;
            Console.WriteLine("========= Idade pessoas (min/max) =========");

            for (int i = 0; i < 5; i++)
            {
				Console.Write("|| " + (i + 1) + " Digite o idade... ");
				idade = int.Parse(Console.ReadLine());

                idadeMin = (idade < idadeMin || idadeMin == -1) ? idade : idadeMin;
				idadeMax = idade > idadeMax ? idade : idadeMax;
			}

            Console.WriteLine("|| A idade min é de {0} e a idade max é de {1}", idadeMin, idadeMax);

            Console.ReadKey();
		}
    }
}
