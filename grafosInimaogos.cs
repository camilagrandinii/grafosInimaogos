class Pessoa{
  // varíáveis privadas para o nome
  // e idade da pessoa
  private int origem;
  private int destino;
 
  public void setNome(string nome){
    this.nome = nome;
  }
}
public void criaNodos(Nodo origem, Nodo destino)
{
    nodos = new List<Nodo>();
    nodos.Add(origem);
    gameObjectsNodos = GameObject.FindGameObjectsWithTag("Nodo");
    foreach (var nodo in gameObjectsNodos) {
        Nodo aux = nodo.GetComponent<Nodo>();
        nodos.Add(aux);
    }
    nodos.Add(destino);
    grafo = new Grafo(nodos.ToArray());
}
