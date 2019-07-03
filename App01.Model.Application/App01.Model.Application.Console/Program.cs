using System;

namespace App01.Model.Application.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new LayoutFactory();

            IFile file = new Arquivo(){
                Nome = "Arquivo 1"
            };
            
            var layout = factory.Create("2");
            file = layout.Convert(file);
            System.Console.WriteLine($"Nome do Arquivo: {file.Nome} - Pattern {file.Pattern}");

            System.Console.ReadKey();
        }
    }
}
