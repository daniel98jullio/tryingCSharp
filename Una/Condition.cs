using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Una
	{
		static void main(string[] args)
		{
			mediaIdadeFamilia();
		}

		static void tabuada()
		{
			double num;

			Console.WriteLine("========= Tabuada =========");
			Console.Write("|| Digite o número que deseja ser calculado... ");
			num = double.Parse(Console.ReadLine());

			Console.WriteLine("========= Resultado =========");
			Console.WriteLine("|| O número escolhido foi: " + num);
			Console.WriteLine("|| 0x" + num + " = " + num * 0);
			Console.WriteLine("|| 1x" + num + " = " + num * 1);
			Console.WriteLine("|| 2x" + num + " = " + num * 2);
			Console.WriteLine("|| 3x" + num + " = " + num * 3);
			Console.WriteLine("|| 4x" + num + " = " + num * 4);
			Console.WriteLine("|| 5x" + num + " = " + num * 5);
			Console.WriteLine("|| 6x" + num + " = " + num * 6);
			Console.WriteLine("|| 7x" + num + " = " + num * 7);
			Console.WriteLine("|| 8x" + num + " = " + num * 8);
			Console.WriteLine("|| 9x" + num + " = " + num * 9);
			Console.WriteLine("|| 10x" + num + " = " + num * 10);

			Console.ReadKey();
		}

		static void inverteNumero()
		{
			double num;

			Console.WriteLine("========= Inverte Número =========");
			Console.Write("|| Digite um número negativo que deseja inverter... ");
			num = double.Parse(Console.ReadLine());

			Console.WriteLine("========= Resultado =========");

			if (num < 0)
			{
				num *= -1;
				Console.WriteLine("|| O número invertido é: " + num);
			}
			else
			{
				Console.WriteLine("|| Não informado não é negativo");
			}

			Console.ReadKey();
		}

		static void areaLosango()
		{
			double dmaior, dmenor, area;

			Console.WriteLine("========= Area losango =========");
			Console.Write("|| Digite o valor da base menor... ");
			dmenor = double.Parse(Console.ReadLine());

			Console.Write("|| Digite o valor da base maior... ");
			dmaior = double.Parse(Console.ReadLine());

			Console.WriteLine("========= Resultado =========");

			area = (dmaior * dmenor) / 2;

			Console.WriteLine("|| O área é: " + area);

			Console.ReadKey();
		}

		static void celsiusParaFahrenheit()
		{
			double tCelsius, tFahrenheit;

			Console.WriteLine("========= Celsius para Fahrenheit =========");
			Console.Write("|| Digite o valor da temperatura em celsius... ");
			tCelsius = double.Parse(Console.ReadLine());

			Console.WriteLine("========= Resultado =========");

			tFahrenheit = (tCelsius * 1.8) + 32;

			Console.WriteLine("|| A temperatura convertida é: " + tFahrenheit);

			Console.ReadKey();
		}

		static void peso()
		{
			double peso, peso15, peso20;
			Console.WriteLine("========= Peso =========");
			Console.Write("|| Digite o seu peso... ");
			peso = double.Parse(Console.ReadLine());

			Console.WriteLine("========= Resultado =========");

			peso15 = (peso * 0.15) + peso;
			peso20 = (peso * 0.20) + peso;
			Console.WriteLine("|| Se engordar 15% seu peso será: " + peso15);
			Console.WriteLine("|| Se engordar 20% seu peso será: " + peso20);

			Console.ReadKey();
		}

		static void salario()
		{
			double salario, salarioMin, qtSalarios;
			Console.WriteLine("========= Quantidade de salarios minimos =========");
			Console.Write("|| Digite o salario minimo... ");
			salarioMin = double.Parse(Console.ReadLine());

			Console.Write("|| Digite o seu salario... ");
			salario = double.Parse(Console.ReadLine());

			Console.WriteLine("========= Resultado =========");

			qtSalarios = salario / salarioMin;
			Console.Write("|| A quantidade de salarios minimos que voce ganha é: " + qtSalarios);

			Console.ReadKey();
		}

		static void diasVida()
		{
			int dia, mes, ano;
			Console.WriteLine("========= Dias vividos =========");
			Console.Write("|| Digite o dia de seu nascimento... ");
			dia = int.Parse(Console.ReadLine());
			Console.Write("|| Digite o mês de seu nascimento... ");
			mes = int.Parse(Console.ReadLine());
			Console.Write("|| Digite o ano de seu nascimento... ");
			ano = int.Parse(Console.ReadLine());

			var data = new DateTime(ano, mes, dia);
			var hoje = DateTime.Now;
			TimeSpan diff = hoje - data;
			Console.WriteLine("Você já viveu aproximadamente " + diff.TotalDays);

			Console.ReadKey();
		}

		static void q8()
		{
			//a -> comando1, comando5
			//b -> comando3, comando4, comando5
			//c -> comando2, comando5
			//d -> a = F | b = V | c = V
			//d -> a = F | b = F | c = F/V
		}
		static void validaTriangulo()
		{
			double ld1, ld2, ld3, somaLados;
			bool valido;
			Console.WriteLine("========= Validação de triangulo =========");
			Console.Write("|| Digite o primeiro lado... ");
			ld1 = double.Parse(Console.ReadLine());
			Console.Write("|| Digite o segundo lado... ");
			ld2 = double.Parse(Console.ReadLine());
			Console.Write("|| Digite o terceiro lado... ");
			ld3 = double.Parse(Console.ReadLine());

			somaLados = ld2 + ld3;
			valido = somaLados > ld1;

			somaLados = ld1 + ld3;
			valido = valido && somaLados > ld2;

			somaLados = ld2 + ld1;
			valido = valido && somaLados > ld3;


			if (valido)
			{
				Console.WriteLine("|| É possível formar um triangulo com os fornecidos.");
			}
			else
			{
				Console.WriteLine("|| Não é possível formar um triangulo com os fornecidos.");
			}

			Console.ReadKey();
		}

		static void leitorProdutos()
		{
			int cdProduto;
			string classificacao;
			Console.WriteLine("========= Leitor de Produtos =========");
			Console.Write("|| Digite o código do produto... ");
			cdProduto = int.Parse(Console.ReadLine());

			if (cdProduto == 1)
			{
				classificacao = "Alimento não-perecível";
			}
			else if (cdProduto == 2 || cdProduto == 3 || cdProduto == 4)
			{
				classificacao = "Alimento perecível";
			}
			else if (cdProduto == 5 || cdProduto == 6)
			{
				classificacao = "Vestuário";
			}
			else if (cdProduto == 7)
			{
				classificacao = "Higiene Pessoal";
			}
			else if (cdProduto >= 8 && cdProduto <= 15)
			{
				classificacao = "Limpeza e utensílios domestico";
			}
			else
			{
				classificacao = "Inválido";
			}

			Console.WriteLine("|| A classificação do produto é: " + classificacao);

			Console.ReadKey();
		}

		static void calculoImc()
		{
			double altura, peso, imc;
			string msg;
			Console.WriteLine("========= Calculo do IMC =========");
			Console.Write("|| Digite o peso... ");
			peso = double.Parse(Console.ReadLine());

			Console.Write("|| Digite a altura... ");
			altura = double.Parse(Console.ReadLine());

			imc = peso / (altura * altura);

			if (imc > 40)
			{
				msg = "Obeso Mórbido";
			}
			else if (imc > 30)
			{
				msg = "Obeso";
			}
			else if (imc > 25)
			{
				msg = "Sobre peso";
			}
			else if (imc >= 20)
			{
				msg = "Peso normal";
			}
			else
			{
				msg = "Abaixo do peso";
			}

			Console.WriteLine("|| Sua classificação foi {0}.\n||Seu IMC é {1}", msg, imc);

			Console.ReadKey();
		}

        static void calculoDiariaHotel() {
            int dias;
            double vrDiaria = 50, vrTotal, txServ;
			Console.WriteLine("========= Calculo valor diária de hotel =========");
			Console.Write("|| Digite o número de dias que ficou hospedado... ");

            dias = int.Parse(Console.ReadLine());
            vrTotal = (dias * vrDiaria);
            txServ = dias * 1.0;

            if (dias > 15) {
                txServ = dias * 0.5;
            } else if (dias < 15) {
                txServ = dias * 1.5;
			}

			vrTotal += txServ;
            Console.WriteLine("|| O valor total da estadia foi de: {0}", vrTotal);

			Console.ReadKey();
        }

        static void mensalidadeAcademia() {
            int idade; char sexo;
            double vrMen;
            Console.WriteLine("========= Calculo de mensalidade alunos academia =========");
			Console.Write("|| Digite sua idade... ");
            idade = int.Parse(Console.ReadLine());

            Console.Write("|| Digite seu sexo('M' para 'Masculino' e 'F' para 'Feminino')... ");
            sexo = char.Parse(Console.ReadLine());

            if (sexo == 'F' || sexo == 'M') {
				vrMen = 80;
				vrMen = (sexo == 'F' && idade >= 26 && idade <= 40) ? 85 : vrMen;
				vrMen = (sexo == 'F' && idade >= 19 && idade <= 25) ? 90 : vrMen;
				vrMen = (sexo == 'F' && idade < 19) ? 60 : vrMen;
				vrMen = (sexo == 'M' && idade >= 31 && idade <= 40) ? 85 : vrMen;
				vrMen = (sexo == 'M' && idade >= 19 && idade <= 30) ? 90 : vrMen;
				vrMen = (sexo == 'M' && idade >= 16 && idade <= 18) ? 75 : vrMen;
				vrMen = (sexo == 'M' && idade < 16) ? 60 : vrMen;

				Console.WriteLine("|| O valor da mensalidade é {0}", vrMen);
            } else {
				Console.WriteLine("Sexo informado ainda não é válido.");
			}

			Console.ReadKey();
        }

        static void calculoDiariaHotel2() {
            int dias; char tpApto;
            double vrDia = 0, vrTot;

            Console.WriteLine("========= Calculo de mensalidade alunos academia =========");
			Console.Write("|| Digite o tipo de apartamento('S' para apt simples e 'D' para apto Dublo)... ");
			tpApto = char.Parse(Console.ReadLine());

            Console.Write("|| Digite a quantidade de dias que ficou hospedado... ");
			dias = int.Parse(Console.ReadLine());

			vrDia = (tpApto == 'D') ? 120 : vrDia;
			vrDia = (tpApto == 'D') && dias < 10 ? 140 : vrDia;
			vrDia = (tpApto == 'D') && dias > 15 ? 100 : vrDia;
			vrDia = (tpApto == 'S') ? 90 : vrDia;
			vrDia = (tpApto == 'S') && dias < 10 ? 100 : vrDia;
			vrDia = (tpApto == 'S') && dias > 15 ? 80 : vrDia;
            vrTot = dias * vrDia;

			Console.WriteLine("|| O valor da estadia é {0}", vrTot);

            Console.ReadKey();
        }

        static void mediaIdadeFamilia() {
            int idade, idade1, idade2, idade3, idade4, idadeProx; double media, diff = 0, minDiff = 0;

			Console.WriteLine("========= Calculo de mensalidade alunos academia =========");
			Console.Write("|| Digite a idade da pessoa 1... ");
            media = idade = int.Parse(Console.ReadLine());

			Console.Write("|| Digite a idade da pessoa 2... ");
            idade1 = int.Parse(Console.ReadLine());
            media += idade1; 
			
            Console.Write("|| Digite a idade da pessoa 3... ");
            idade2 = int.Parse(Console.ReadLine());
			media += idade2;

			Console.Write("|| Digite a idade da pessoa 4... ");
            idade3 = int.Parse(Console.ReadLine());
			media += idade3;
			
            Console.Write("|| Digite a idade da pessoa 5... ");
            idadeProx = idade4 = int.Parse(Console.ReadLine());
			media += idade4;

            media = media / 5;

            diff = Math.Abs(media - idade4);
            minDiff = diff;
            idadeProx = (diff < minDiff) ? idade4 : idadeProx;

			diff = Math.Abs(media - idade3);
			idadeProx = (diff < minDiff) ? idade3 : idadeProx;
			minDiff = (diff < minDiff) ? diff : minDiff;

			diff = Math.Abs(media - idade2);
            idadeProx = (diff < minDiff) ? idade2 : idadeProx;
			minDiff = (diff < minDiff) ? diff : minDiff;

			diff = Math.Abs(media - idade1);
            idadeProx = (diff < minDiff) ? idade1 : idadeProx;
			minDiff = (diff < minDiff) ? diff : minDiff;

			diff = Math.Abs(media - idade);
            idadeProx = (diff < minDiff) ? idade : idadeProx;
			minDiff = (diff < minDiff) ? diff : minDiff;

			Console.WriteLine("|| O valor mais próximo é {0}", idadeProx);

			Console.ReadKey();
        }
	}
}


