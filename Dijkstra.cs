﻿using System;
using grafosInimaogos;
class GFG {
	static int V = 40;
	int minDistance(int[] dist, bool[] foundShortestPath)
	{
		// Initialize min value
		int min = int.MaxValue, min_index = -1;

		for (int v = 0; v < V; v++)
			if (foundShortestPath[v] == false && dist[v] <= min) {
				min = dist[v];
				min_index = v;
			}

		return min_index;
	}
	void printSolution(int[] dist, int n, int origem, int destino)
	{
		Console.Write("Vertex	 Distance "
					+ "from Source\n");
		for (int i = 0; i < V; i++)
			if(i == destino)
				Console.Write(i + " \t\t " + dist[i] + "\n");
	}

	void dijkstra(int[, ] graph, int origem, int destino)
	{
		int[] dist = new int[V]; // The output array. dist[i] will hold the shortest distance from origem to i

		bool[] foundShortestPath = new bool[V];

		Aresta[] verticesUntilOrigin = new Aresta[V];

		// Initialize all distances as INFINITE and stpSet[] as false
		for (int i = 0; i < V; i++) {
			dist[i] = int.MaxValue;
			foundShortestPath[i] = false;
		}

		dist[origem] = 0;

		// Find shortest path for all vertices
		for (int count = 0; count < V - 1; count++) {
			int u = minDistance(dist, foundShortestPath);

			foundShortestPath[u] = true;
			
			// Update dist value of the adjacent vertices of the picked vertex.
			for (int v = 0; v < V; v++) {
				if (!foundShortestPath[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v]) {
					dist[v] = dist[u] + graph[u, v];
				}
			}
				
		}

		// print the constructed distance array
		printSolution(dist, V, origem, destino); 
	}

	// Driver Code
	public static void Main()
	{
		List<Aresta> lista_arestas = new List<Aresta>();
		createGraph grafo = new createGraph();

		int[, ] graph = new int[V,V];
		
		int n_relacoes = grafo.mapa.get_n_relacoes();
		int peso = 0, destino = 0, origem=0;
		lista_arestas = grafo.mapa.get_lista_arestas();

		for(int i=0; i<V; i++) {
			for(int j=0; j<V; j++) {
				graph[i,j] = 0;
			}
		}

		foreach(Aresta ares in lista_arestas){
			origem = ares.getOrig() - 1;
			destino = ares.getDest() - 1;
			peso = ares.getPeso();

			graph[origem, destino] = peso;
			graph[destino, origem] = peso;
		}
		
		/* for(int i=1; i<V; i++) {
			for(int j=1; j<V; j++) {
				Console.Write(graph[i,j]+" ");
			}
			Console.Write("\n");
		} */

		GFG t = new GFG();
		t.dijkstra(graph, 10, 3);
	}
}   
