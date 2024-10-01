/*
O que o programa deve fazer:

- Um lista duplamente encadeada.

- Adicionar um novo dado
- - No início
- - No fim 
- - Em uma posição específica dentro da lista

- Remover um dado pelo valor dele
*/

using System;
using System.Runtime.CompilerServices;

class Noh{
    public string? Dados;       // Armazena o valor do nó
    public Noh? Proximo;    // Referência para o próximo nó
    public Noh? Anterior;    // Referência para o nó anterior

    public Noh(string? dado){
        Dados = dado;
    }
}
class ListaDuplaEncadeada {
    static readonly Action<string> Print = Program.Print;

    private Noh? head;
    public static int contador;

    public ListaDuplaEncadeada(){
        contador = 0;
    }

    public void Exibe(){
        Noh? Atual = head;

        Print("= = = LISTA = = =\nContagem: "+contador+" elementos na lista\n");
        while(Atual != null){
            Print("- "+Atual.Dados);
            Atual = Atual.Proximo;
        }
        Print("\n= = = FIM DA LISTA = = =\n");
    }

    public void Adiciona_ini(string? dado){
        try {
            Noh novoNoh = new(dado);

            if (head == null){
                head = novoNoh;
            } else {
                novoNoh.Proximo = head;
                head.Anterior = novoNoh;
                head = novoNoh;
            }
            Print("Dado adicionado com sucesso!");
            contador++;
        }
        catch (System.Exception e){
            Print("Err: "+e);
        }   
    }

    public void Adiciona_fim(string? dado){
        try{
            Noh novoNoh = new(dado);

            if (head == null){
                head = novoNoh;
            } else {
                Noh Atual = head;

                while (Atual.Proximo != null){
                    Atual = Atual.Proximo;
                }
                Atual.Proximo = novoNoh;
                novoNoh.Anterior = Atual;
            }
            Print("Dado adicionado com sucesso!");
            contador++;
            
        }
        catch (System.Exception e){
             Print("Err: "+e);
        }
    }

    public void Adiciona_posi(string? dado, int posi){
        try{
            Noh novoNoh = new(dado);

            if (head == null){
                head = novoNoh;
                Print("Dado adicionado com sucesso!");
                contador++;
            } else {
                if (posi == contador){
                    Adiciona_fim(dado);
                } else if(posi == 0){
                    Adiciona_ini(dado);
                } else if(posi > contador || posi < 0){
                    Print("Posição inválida!\n");
                    System.Threading.Thread.Sleep(2000);
                } else {

                    Noh? Atual = head;

                    for (int i=0; i < posi; i++){
                        if (Atual != null)
                            Atual = Atual.Proximo;
                    }

                    if (Atual != null){
                        novoNoh.Proximo = Atual;
                        
                        if (Atual.Anterior != null){
                            Atual.Anterior.Proximo = novoNoh;
                            novoNoh.Anterior = Atual.Anterior;
                            Atual.Anterior = novoNoh;

                        } else {
                            Print("[!]Err: Anterior nulo");
                        }

                        Print("Dado adicionado com sucesso!");
                        contador++;
                    } else {
                        Print("[!][!]\n");
                    }

                    System.Threading.Thread.Sleep(2000);

                }
            }
        }
        catch (System.Exception e){
             Print("Err: "+e);
        }
    }

    public void Remove(string? dado){
        Noh? Atual = head;

        if (head == null){
            Print("Lista vazia!\n");
        } else {

            while(Atual != null){
                if (Atual.Dados == dado){
                    if (Atual == head){
                        Print("Atual é o head");
                        head = Atual.Proximo;
                        if (head != null){
                            head.Anterior = null;
                        }
                    } else {                        
                        if (Atual.Anterior != null){
                            Atual.Anterior.Proximo = Atual.Proximo;
                        } else {//Print("Anterior é nulo");
                        }
                        if (Atual.Proximo != null){
                            Atual.Proximo.Anterior = Atual.Anterior;
                        } else {//Print("Próximo é nulo");
                        }
                    }
                    Print("Dado removido com sucesso!");
                    contador--;
                    break;
                }
                Atual = Atual.Proximo;    
            }

        }

    }

}

class Program{
    static ListaDuplaEncadeada Lista = new();

    static void Main(string[] args){
        Print("Modo teste?\n[s]\n[n]");
            if(Console.ReadLine()=="n"){
                Menu();
            } 
            else {

                string[,] entrada = new string[8,2];

                entrada[0,0] = "2b";
                entrada[0,1] = "Arroz";

                entrada[1,0] = "2b";
                entrada[1,1] = "Feijão";


                entrada[2,0] = "2b";
                entrada[2,1] = "Macarrão";

                entrada[3,0] = "1";

                entrada[4,0] = "2a";
                entrada[4,1] = "Sacar dinheiro";

                entrada[5,0] = "1";

                entrada[6,0] = "3";
                entrada[6,1] = "Feijão";

                entrada[7,0] = "1";

                Menu(entrada);
            }
    }

    static void Menu(){
        do {
            Print("= = = Lista Duplamente encadeada = = =\n\nO que deseja fazer?\n");
            Print("1- Ver a lsita");
            Print("2- Adicionar dado");
            Print("3- Remover dado");
            Print("x- Sair");

        } while (Options(Console.ReadLine()));
        
    }

    static void Menu(string[,] args){

        string[] instructions = new string[args.GetLength(0)];
        string[] dados = new string[args.GetLength(0)];

        
        for (int i= 0; i < args.GetLength(0); i++){
            instructions[i] = args[i,0];
            dados[i] = args[i,1];
        }



        for (int i= 0; i < args.GetLength(0); i++){
        
            switch(instructions[i]){
                case "1":
                    Lista.Exibe();
                break;

                case "2a":
                    Lista.Adiciona_ini(dados[i]);
                break;

                case "2b":
                    Lista.Adiciona_fim(dados[i]);
                break;

                case "2c":
                break;

                case "3":
                    Lista.Remove(dados[i]);
                break;

                case "x":
                break;
            }
        }
    }

    static bool Options(string? a){
        //Console.Clear();
        switch(a){
            case "1":
                Lista.Exibe();
                System.Threading.Thread.Sleep(2000);
            break;

            case "2":
                Print("== Adicionar dado: ==\na - No início\nb - No fim\nc - Em uma posição determinada\n");
                switch(Console.ReadLine()){
                    

                    case "a":
                        Print("= = Adicionar no início da lista = =\n= = Digite o dado: ");
                        Lista.Adiciona_ini(Console.ReadLine());
                        //Console.Clear();
                    break;

                    case "b":
                        Print("= = Adicionar no final da lista = =\n= = Digite o dado: ");
                        Lista.Adiciona_fim(Console.ReadLine());
                        //Console.Clear();
                    break;

                    case "c":
                        Print("= = Adicionar em uma posição da lista = =\n= = Digite o dado: ");
                        string? dado = Console.ReadLine();
                        string? posiString;
                        int posiInt;
                        do{  
                            Print("Digite a posição: ");
                            posiString = Console.ReadLine();
                        } while (!int.TryParse(posiString, out posiInt));
                   
                        Lista.Adiciona_posi(dado,posiInt);
                        //Console.Clear();
                    break;

                    default:
                        Print("\n [!] Opção inválida [!]\n");
                        Menu();
                    break;
                }
            break;

            case "3":
                Print("Qual o valor do dado?: ");
                Lista.Remove(Console.ReadLine());
            break;

            case "x":
                return false;

            default:
                Print("\n [!] Opção inválida [!]\n");
                Menu();
            break;
        }
        
        return true;
    }
    
    public static void Print(string a){
        Console.WriteLine(a);
    }

}