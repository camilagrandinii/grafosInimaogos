using System;
namespace grafosInimaogos{
public class Aresta{
  private int origem;
  private int destino;
  private int peso;

  public Aresta(){
    this.origem=-1;
    destino=-1;
    peso=0;
  }
  public Aresta(int orig, int dest, int peso){
    this.origem = orig;
    this.destino = dest;
    this.peso = peso;
  }
  public int getOrig(){
      return this.origem;
  }
  public void setOrig(int orig){
      this.origem = orig;
  }
  public int getDest(){
      return this.destino;
  }
  public void setDest(int dest){
      this.destino = dest;
  }
  public int getPeso(){
      return this.peso;
  }
  public void setPeso(int peso){
      this.peso = peso;
  }
  public void printClass(){
      Console.WriteLine("\nOrigem: "+origem+"\tDestino: "+destino+"\tPeso: "+peso);
  }
}
public class ListaRelacoes{
  private int n_vertices;
  private int n_relacoes;
  
  private List<Aresta> lista_arestas;

  public ListaRelacoes(){
    n_vertices=0;
    n_relacoes=0;
    lista_arestas = new List<Aresta>();
  }
  public ListaRelacoes(int numVert, int numArest){
    n_vertices=numVert;
    n_relacoes=numArest;
    lista_arestas = new List<Aresta>();
  }
  public int get_n_relacoes(){
    return this.n_relacoes;
  }
  public int get_n_vertices(){
    return this.n_vertices;
  }
  public List<Aresta> get_lista_arestas(){
    return this.lista_arestas;
  }
  public void mostraRelacoes(){
    foreach(Aresta ares in lista_arestas){
    ares.printClass();  
    }
  }
  public void newRelacao(int orig, int dest, int peso){
    /* Aresta aresta = new Aresta(orig, dest, peso); */
    /* aresta.printClass(); */
    lista_arestas.Add(new Aresta(orig, dest, peso));
  } 
}
public class criaGrafo{
  public ListaRelacoes mapa;
  private const string NOME_GRAFO = "grafoMapa.txt";
  public criaGrafo(){
    mapa = readClass();
  }
  public void mostraGrafo(){
    mapa.mostraRelacoes();
  }
  // Método que realiza a leitura do arquivo
  public ListaRelacoes readClass(){
      string infoGrafoCompleta;
      int[] infos_grafo = new int[2];
      int[] orig_dest = new int[3];

      StreamReader sr = new StreamReader(NOME_GRAFO);
      infoGrafoCompleta = sr.ReadLine();
      string content = infoGrafoCompleta;
      infos_grafo = limpaLinha(infoGrafoCompleta, 2);
      ListaRelacoes mapa = new ListaRelacoes(infos_grafo[0], infos_grafo[1]);
      
      for (int i=0; content !=null && i<mapa.get_n_relacoes(); i++){
          content = sr.ReadLine();
          orig_dest = limpaLinha(content, 3);
          mapa.newRelacao(orig_dest[0], orig_dest[1], orig_dest[2]);
      }
      return mapa;
    }
    public static int[] limpaLinha(String linha, int num_infos){
        string[] orig_destino_peso;
        string[] dest_peso;
        int[] orig_destino_int = new int[3];

        if(num_infos==3){
          linha = linha.Trim();
          orig_destino_peso = linha.Split(";");
          dest_peso = orig_destino_peso[1].Split(" ");

          orig_destino_int[0] = int.Parse(orig_destino_peso[0]);
          orig_destino_int[1] = int.Parse(dest_peso[0]);

          orig_destino_int[2] = int.Parse(dest_peso[dest_peso.Length-1]);
        }

        else if(num_infos==2){
          orig_destino_peso = linha.Split(" ");
          int.TryParse(orig_destino_peso[0],  out orig_destino_int[0]);
          orig_destino_int[1] = int.Parse(orig_destino_peso[orig_destino_peso.Length-1]);
        }
        
        return orig_destino_int;
    }
}
public class grafosInimaogos{
      static void MainCriaGrafo(String[] args){
        criaGrafo criaGrafo = new criaGrafo();
        criaGrafo.mostraGrafo();
      }
  }
}

