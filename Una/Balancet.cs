using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Balancet
	{
		static void main(string[] args)
		{
			writeTitle();
			keepWorking();
			sair();
		}

		static void keepWorking()
		{
			int keepWorking;
			do
			{
				saveBalance();
				Console.Write("||\n|| Deseja continuar cadastrando? (0 - 'Não' | 1 - 'Sim') ");
				keepWorking = int.Parse(Console.ReadLine());

				Console.Clear();
				writeTitle();

			} while (keepWorking != 0);
		}

		static void writeTitle()
		{
			Console.WriteLine("########### Balancete ###########");
		}

		static void saveBalance()
		{
			int tpOperac;
			double vrSpend;
            string date;

			tpOperac = readTpOperac();

			switch (tpOperac)
			{
				case 0:
					vrSpend = readSpent();
                    date = readDate();
					debitWriteNewLine(vrSpend, date);
					break;
				case 1:
					vrSpend = readSpent();
					date = readDate();
					creditWriteNewLine(vrSpend, date);
					break;
				default:
					Console.WriteLine("|| Opção de operação inválida");
					break;
			}

			writeBalance();
		}

		static int readTpOperac()
		{
			Console.Write("|| Selecione o tipo de operação ('0' - Débito | '1' - Crédito): ");
			return int.Parse(Console.ReadLine());
		}

		static double readSpent()
		{
			Console.Write("|| Informe a quantidade: R$");
			return double.Parse(Console.ReadLine());
		}

		static void debitWriteNewLine(double value, string date)
		{
			using (var outputFile = new StreamWriter("Debit.txt", true))
			{
				outputFile.Write(value);
				outputFile.Write(' ');
                outputFile.WriteLine(date);
			}
		}

		static void creditWriteNewLine(double value, string date)
		{
			using (var outputFile = new StreamWriter("Credit.txt", true))
			{
				outputFile.Write(value);
                outputFile.Write(' ');
                outputFile.WriteLine(date);
			}
		}

		static string[] readFile(string fileName)
		{
			string lines;
            if (File.Exists(fileName)) {
				using (var sr = new StreamReader(fileName))
				{
					lines = sr.ReadToEnd();
				}

				return lines.Replace("\r", "").Split('\n');   
            }
            return new string[0];
		}

		static double calculateVrTot(string[] lines)
		{
			double vrTot = 0;
			for (int i = 0; i < lines.Length; i++)
			{
                var vrLine = lines[i].Split(' ')[0];
				double value = lines[i] != "" ? double.Parse(vrLine) : 0;
				vrTot += value;
			}
			return vrTot;
		}

		static void writeBalance()
		{
			double vrTotDeb = calculateVrTot(readFile("Debit.txt"));
			double vrTotCred = calculateVrTot(readFile("Credit.txt"));
			double tot = vrTotCred - vrTotDeb;

			Console.WriteLine("||\n|| Balancete");
			Console.WriteLine("||     Saldo credito: R$" + vrTotCred);
			Console.WriteLine("||     Saldo debito: R$" + vrTotDeb);
			Console.WriteLine("||     Saldo atual: R$" + tot);
		}

		static void sair()
		{
			Console.Write("|| Pressione qualquer tecla para sair...");
			Console.ReadKey();
		}

        static string readDate() {
            Console.Write("|| Informe a data da operação: ");
            return Console.ReadLine();
        }
	}
}