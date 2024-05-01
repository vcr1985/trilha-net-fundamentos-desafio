using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            string placa = Console.ReadLine();
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.

#pragma warning disable CS8604 // Possível argumento de referência nula.
            veiculos.Add(placa);
#pragma warning restore CS8604 // Possível argumento de referência nula.
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            string placa = Console.ReadLine();
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.

            if (veiculos.Any(x => x.Equals(placa, StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas;
                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Valor inválido. Digite a quantidade de horas novamente:");
                }
                
                decimal valorTotal = precoInicial + (precoPorHora * horas);
#pragma warning disable CS8604 // Possível argumento de referência nula.
                _ = veiculos.Remove(placa);
#pragma warning restore CS8604 // Possível argumento de referência nula.

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
{
    // Verifica se há veículos no estacionamento
    if (veiculos.Any())
    {
        Console.WriteLine("Os veículos estacionados são:");
        foreach (var veiculo in veiculos)
        {
            Console.WriteLine(veiculo);
        }
    }
    else
    {
        Console.WriteLine("Não há veículos estacionados.");
    }
}

}
}

