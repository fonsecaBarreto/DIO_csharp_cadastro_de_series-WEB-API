using System;
using DecolaTech.FonsecaFlix;
using DecolaTech.FonsecaFlix.Helpers;
using DecolaTech.FonsecaFlix.Data;

namespace DecolaTech.FonsecaFlix.Console
{   
    class Program
    {
        static TextFormarter textIO = new TextFormarter();
        static Data.SeriesRepository seriesRepository = new SeriesRepository();
        static SeriesUseCases seriesUseCases = new SeriesUseCases(seriesRepository, textIO);
        static void Main(string[] args)
        {   
            InicioPresentation();

            Loop();

            EncerramentoPresentation();
        }   

        static string MenuPresentation(){
            textIO.Print("> Informe a opção desejada:");
			textIO.Print("  1- Listar séries");
			textIO.Print("  2- Inserir nova série");
			textIO.Print("  3- Atualizar série");
			textIO.Print("  4- Excluir série");
			textIO.Print("  5- Visualizar série");
			textIO.Print("  C- Limpar Tela");
			textIO.Print("  X- Sair");
			textIO.Print(" ");
            string resultado;
            textIO.Read(out resultado, "Opção: ");
            return resultado;
        }   
        static void handleAction(string action){
            textIO.Print(" ");
            switch(action.ToUpper()){
                case "1": 
                    textIO.Print("> Listar séries\n");
                    seriesUseCases.ListarSeries();
                    break;
                case "2":
                    textIO.Print("> Inserir nova série\n");
                    seriesUseCases.InserirSerie();
                    break;
                case "3":
                    textIO.Print("> Atualizar série\n");
                    seriesUseCases.AtualizarSerie();
                    break;
                case "4":
                    textIO.Print("> Excluir série\n");
                    seriesUseCases.ExcluirSerie();
                    break;
                case "5":
                    textIO.Print("> Visualizar série\n");
                    seriesUseCases.VisualizarSerie();
                    break;
                case "C":
                    textIO.Print("> Limpar Tela\n");
                    System.Console.Clear();
                    break;
                default: 
                    textIO.Print("!! Favor Escolher uma opção valida");
                    break;
            }

        }

        static void Loop(){
            string requiredAction = MenuPresentation();

            while(requiredAction.ToUpper() != "X"){
                handleAction(requiredAction);
                
                textIO.PrintBorder();
                textIO.Read(out string continuar, "Aperte qualquer Tecla para continuar ou 'X' para sair : ");
                if(continuar.ToUpper() == "x") break;
                textIO.PrintBorder();

                requiredAction = MenuPresentation();
            }   
        }

        static void InicioPresentation(){
            System.Console.WriteLine("\n");
            textIO.PrintBorder();
            textIO.Print($"Bem Vindo ao Catalago de Series Dio.FonsecaFlix.Ltda!");
            textIO.PrintBorder();
            textIO.Print($"Use os menus de acesso, através de seus respectivos numeros para realizar as alteraçoes e buscas que achar necessario.\n");
        }

         static void EncerramentoPresentation(){
            textIO.PrintBorder();
            textIO.Print($"\n Obrigado por ter usado o nosso sistema!");
            textIO.Print($"Até uma proxima!\n");
            textIO.Print($"Autor: Lucas Fonseca");
            textIO.Print($"Git: github.com/fonsecaBarreto\n");
            textIO.PrintBorder();
        }
    }
}
