class Program(){
    static void Main(){
        Console.WriteLine("Calculadora de NEO-FFI-R");
        Console.WriteLine("DF = 1, D = 2, N = 3, C = 4, CF = 5");
        Console.WriteLine("Digite o nome do paciente!");
        Paciente paciente = new Paciente(Console.ReadLine());
        paciente.preencheRespostas();
        paciente.converteParaAreas();
        paciente.exibeGabaritoPreenchido();
        Console.WriteLine(paciente.resultadoGeralBruto());
        paciente.exibePorAreas();
        Console.WriteLine("Deseja salvar os resultados? Digite 's' minúsculo se sim");
        if(Console.ReadLine() == "s"){
            paciente.SalvarResultados();
        }
    }
}