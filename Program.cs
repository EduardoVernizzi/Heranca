
Console.WriteLine("\nConta Corrente: Número: 111 Titular: Maria");

Contas conta = new();

conta.Numero = 123;
conta.Titular = "Maria";

Console.WriteLine("\nDepositando R$1000,00");
conta.Depositar(1000);
Console.WriteLine("Sacando R$100,00");
conta.Sacar(100);

Console.WriteLine($"Saldo da conta: {conta.Saldo.ToString("c")}");

Console.WriteLine("Sacando R$2000,00");
conta.Sacar(2000);

Console.WriteLine($"Saldo da conta: {conta.Saldo.ToString("c")}");


Console.ReadKey();


Console.WriteLine("\nConta Poupança: Número: 222 Titular: José");

ContaPoupanca contaPoupanca = new();
contaPoupanca.Numero = 222;
contaPoupanca.Titular = "José";

Console.WriteLine("Depositando R$1000,00");
contaPoupanca.Depositar(1000);
Console.WriteLine($"Saldo da Conta Poupança: {contaPoupanca.Saldo.ToString("c")}");
Console.WriteLine("Sacando R$100,00");
contaPoupanca.Sacar(100);
Console.WriteLine($"Saldo da Conta Poupança: {contaPoupanca.Saldo.ToString("c")}");
Console.WriteLine("Sacando R$2000,00");
contaPoupanca.Sacar(2000);
Console.WriteLine($"Saldo da Conta Poupança: {contaPoupanca.Saldo.ToString("c")}");


Console.ReadKey();

Console.WriteLine("\nConta Investimento: Número: 333 Titular: Carlos");

ContaInvestimento contaInvestimento = new();
contaInvestimento.Numero = 333;
contaInvestimento.Titular = "Carlos";

Console.WriteLine("Depositando R$1000,00");
contaInvestimento.Depositar(1000);
Console.WriteLine($"Saldo da Conta Investimento: {contaInvestimento.Saldo.ToString("c")}");
Console.WriteLine("Sacando R$100,00");
contaInvestimento.Sacar(100);
Console.WriteLine($"Saldo da Conta Investimento: {contaInvestimento.Saldo.ToString("c")}");
Console.WriteLine("Sacando R$2000,00");
contaInvestimento.Sacar(2000);
Console.WriteLine($"Saldo da Conta Investimento: {contaInvestimento.Saldo.ToString("c")}");


//Classes
public class Contas

{
    public int Numero { get; set; }
    public string? Titular { get; set; }
    public decimal Saldo { get; set; } = 0;
    public virtual double Juros { get; set; } = 0;

    private decimal CalculaRemuneracao (double juros)
    {
        return Saldo * (decimal)Juros;
    }

    public virtual decimal Sacar (decimal valor)
    {
        Saldo = Saldo - valor;
        return Saldo;
    }
    public decimal Depositar (decimal valor)
    {
        Saldo = Saldo + valor;
        Saldo = Saldo + CalculaRemuneracao(Juros);
        return Saldo;
    }

}



public class ContaPoupanca : Contas
{
    public override double Juros { get; set; } = 0.005;

    public override decimal Sacar(decimal valor)
    {
        if (Saldo >= valor)
        {
            Saldo = Saldo - valor;
            return Saldo;
        }
        else
        {
            Console.WriteLine($"Saldo insuficiente...");
            return Saldo;
        }
    }

}

public class ContaInvestimento : Contas
{
    public override double Juros { get; set; } = 0.009;
    public double Imposto { get; set; } = 0.001;

    private decimal CalcularImposto(double imposto)
    {
        return Saldo * (decimal)Imposto;
    }

    public override decimal Sacar(decimal valor)
    {
        if (Saldo >= valor)
        {
            Saldo = Saldo - valor - CalcularImposto(Imposto);
            return Saldo;
        }
        else
        {
            Console.WriteLine($"Saldo insuficiente...");
            return Saldo;
        }
    }
}