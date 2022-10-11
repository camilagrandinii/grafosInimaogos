class Aresta{
  private int origem;
  private int destino;
  private int peso;

  Aresta(){
    origem=-1;
    destino=-1;
    peso=0;
  }
  Aresta(int orig, int dest, int peso){
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
class ListaRelacoes{
  private int n_vertices;
  private int n_relacoes;
  
  private List<Aresta> lista_arestas;

  ListaRelacoes(){
    n_vertices=0;
    n_relacoes=0;
    List<Aresta> lista_arestas = new List<Aresta>();
  }
  ListaRelacoes(int numVert, int numArest){
    n_vertices=numVert;
    n_relacoes=numArest;
    List<Aresta> lista_arestas = new List<Aresta>();
  }
  public get_n_relacoes(){
    return this.n_relacoes;
  }
  public get_n_vertices(){
    return this.n_vertices;
  }
  public mostraRelacoes(){
    foreach(Aresta ares in lista_arestas){
    ares.printClass();  
    }
  }
  public void newRelacao(int orig, int dest, int peso){
    Aresta aresta = new Aresta(orig, dest, peso);
    lista_arestas.Add(aresta);
  }
}
class criaGrafo{
  private ListaRelacoes mapa;
  private const string NOME_GRAFO = "grafosMapa.txt";

  criaGrafo(){
    readClass();
  }
  // Método que realiza a leitura do arquivo, com base no nome digitado pelo usuário
  public void readClass(){
      string infoGrafoCompleta;
      int[] infos_grafo = new int[2];
      int[] orig_dest = new int[3];

      StreamReader sr = new StreamReader(NOME_GRAFO);
      infoGrafoCompleta = sr.ReadLine();
      infos_grafo = limpaLinha(infoGrafoCompleta, 2);
      ListaRelacoes mapa = new ListaRelacoes(infos_grafo[0], infos_grafo[1]);

      for (int i=0; content !=null && i<mapa.get_n_relacoes; i++){
          content = sr.readLine();
          orig_dest = limpaLinha(content, 3);
          mapa.newRelacao(orig_dest[0], orig_dest[1], orig_dest[3]);
      }
    }
    public static int[] limpaLinha(String linha, int num_infos){
        string[] orig_destino;
        int[] orig_destino_int = new int[3];
        linha = linha.trim();
        orig_destino = linha.split(" ");
        orig_destino_int[0] = int.Parse(orig_destino[0]);
        orig_destino_int[1] = int.Parse(orig_destino[1]);

        if(num_infos==3){
        orig_destino_int[2] = int.Parse(orig_destino[2]);
        }

        return orig_destino_int;
    }
}
class grafoInimaogos{
    public void main(String[] args){
      criaGrafo();
    }
}

