class Paciente{
    string nome;
    public Paciente(string nome){
        this.nome = nome;
    }
    int[] respostas= new int[60];
    int[] tabelaGabaOD = [0,1,2,3];
    
    int neur = 0; //Neuroticismo
    int extr = 0; //Extroversão
    int aber = 0; //Abertura a experiências
    int amab = 0; //Amabilidade
    int cons = 0; //Conscienciosidade
    int[] ordemDireta = [0,1,2,3];
    int[] arCinza = [1,16,31,46,12,27,42,57,18,23,28,33,48,9,14,19,24,39,44,54,59,15,30,45,55];
    int[] arNeur = [1,6,11,16,21,26,31,36,41,46,51,56];
    int[] arExtr = [2,7,12,17,22,27,32,37,42,47,52,57];
    int[] arAber = [3,8,13,18,23,28,33,38,43,48,53,58];
    int[] arAmab = [4,9,14,19,24,29,34,39,44,49,54,59];
    int[] arCons = [5,10,15,20,25,30,35,40,45,50,55,60];
    public void preencheRespostas(){
        Console.WriteLine($"Preenchendo os dados de {nome}!");
        for(int i = 0; i < respostas.Length; i++){ //lembrar que i sempre estará um abaixo do item de fato
            if(i == 0){
                Console.WriteLine($"Preenchendo a questão {i+1}");
            }
            else{
                Console.WriteLine($"Preenchendo a questão {i+1}! Se quiser corrigir a anterior, digite 'b' em minúsculas!");
            }
            var respAtualString = Console.ReadLine();
            if(respAtualString != "b" || i == 0){ //segue na iteração atual caso digite b ou esteja na primeira iteração
                if(int.TryParse(respAtualString, out int respAtualOK)){ //se for um número, segue
                    if(respAtualOK > 0 && respAtualOK <= 5){ //verifica se é 1, 2, 3 ou 4
                        respostas[i] = respAtualOK - 1; //deixa no padrão (01234) para ser lido pela função das áreas
                    }
                    else{
                        //Console.Clear();
                        Console.WriteLine("Digite um número válido (1,2,3,4)! Tente novamente!");
                        i--;
                        continue;
                    }
                }
                else{ //caso alguma letra tenha sido digitada
                    //Console.Clear();
                    Console.WriteLine("Digite apenas números! Tente novamente");
                    i--; //repete a tentativa de preencher o valor atual
                    continue;
                }
            }
            else{// caso tenha digitado "b"
            //Console.Clear();
            i = i-2;
            continue;
            }
        }
        Console.WriteLine("Respostas computadas!");
    }

    public void exibeGabaritoPreenchido(){
        for(int i = 0; i < respostas.Length; i++){
            Console.WriteLine($"Questão {i+1} marcou gabarito {respostas[i]+1}");
        }
    }

    public int resultadoGeralBruto(){
        int soma = neur + extr + aber + amab + cons;
        return soma;
    }

    public void exibePorAreas(){
        Console.WriteLine($"Neuroticismo: {neur}");
        Console.WriteLine($"Extroversão: {extr}");
        Console.WriteLine($"Abertura a experiências: {aber}");
        Console.WriteLine($"Amabilidade: {amab}");
        Console.WriteLine($"Conscienciosidade: {cons}");
    }
    public void converteParaAreas(){
        for(int i = 0; i < respostas.Length; i++){
            if(!arCinza.Contains(i+1)){//verifica se o item atual é branco
                if(arNeur.Contains(i+1)){ //verifica se o item atual é de Neur
                    neur += respostas[i];
                }
                else if(arExtr.Contains(i+1)){
                    extr += respostas[i];
                }
                else if(arAber.Contains(i+1)){
                    aber += respostas[i];
                }
                else if(arAmab.Contains(i+1)){
                    amab += respostas[i];
                }
                else if(arCons.Contains(i+1)){
                    Console.WriteLine($"o item {i+1} de gabarito {respostas[i]+1} recebeu pontuação {respostas[i]} nos brancos");
                    cons += respostas[i];
                }
            }
            else{
                if(arNeur.Contains(i+1)){ //verifica se o item atual é de Neur
                    neur += 4 - respostas[i];
                }
                else if(arExtr.Contains(i+1)){
                    extr += 4 - respostas[i];
                }
                else if(arAber.Contains(i+1)){
                    aber += 4 - respostas[i];
                }
                else if(arAmab.Contains(i+1)){
                    amab += 4 - respostas[i];
                }
                else if(arCons.Contains(i+1)){
                    Console.WriteLine($"o item {i+1} de gabarito {respostas[i]+1} recebeu pontuação {4-respostas[i]} nos cinzas");
                    cons += 4 - respostas[i];
                }
            }
        }
    }
    public void SalvarResultados(){
        string local = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filename = @$"NEOFFIR_{nome}.txt";
        string path = Path.Combine(local, filename);
        int contador = 1;

        while(File.Exists(path)){
            filename = @$"NEOFFIR_{nome}{contador}.txt";
            path = Path.Combine(local, filename);
            contador++;
        }
        if(!File.Exists(path)){
            using(StreamWriter sw = File.CreateText(path)){
                for(int i = 0; i < respostas.Length; i++){
                    sw.WriteLine($"Questão {i+1} marcou gabarito {respostas[i]+1}");
                }
                sw.WriteLine();
                sw.WriteLine($"Neuroticismo: {neur}");
                sw.WriteLine($"Extroversão: {extr}");
                sw.WriteLine($"Abertura a experiências: {aber}");
                sw.WriteLine($"Amabilidade: {amab}");
                sw.WriteLine($"Conscienciosidade: {cons}");
                sw.WriteLine();
                sw.WriteLine($"Soma geral: {resultadoGeralBruto()}");
                Console.WriteLine("Arquivo salvo!");
            }
        }
    } 
}