using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathFinding : MapDataBase
{
    Node[,] graph;
    public GameObject selcPawn;

    private void Start()
    {
        GeneratePathFindingGraph();        
    }
    private void GeneratePathFindingGraph()
    {
        // Initialize array
        graph = new Node[mapSizeX, mapSizeZ];

        // initialize Node for each array item        
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeZ; z++)
            {
                graph[x, z] = new Node();
                graph[x, z].x = x;
                graph[x, z].z = z;
            }
        }
        // calc neighbours of all nodes
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int z = 0; z < mapSizeZ; z++)
            {

                // 4 side connected tiles
                if (x > 0)
                    graph[x, z].neighbours.Add(graph[x - 1, z]);
                if (x < mapSizeX - 1)
                    graph[x, z].neighbours.Add(graph[x + 1, z]);

                if (z > 0)
                    graph[x, z].neighbours.Add(graph[x, z - 1]);
                if (z < mapSizeZ - 1)
                    graph[x, z].neighbours.Add(graph[x, z + 1]);
            }
        }
    }

    public void MoveSelcPawnTo1(int x, int z)
    {
        print("click");
        //selcPawn.GetComponent<FleetPawn>().TileX = x;
        //selcPawn.GetComponent<FleetPawn>().TileZ = z;
        //selcPawn.transform.position = TileCoordToWorldCoord(x, z);

        List<Node> unvisited = new List<Node>();

        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

        Node source = graph[selcPawn.GetComponent<FleetPawn>().tileX, selcPawn.GetComponent<FleetPawn>().tileZ];

        dist[source] = 0;
        prev[source] = null;

        // Initialize everything with infinite distance atm
        foreach(Node v in graph)
        {
            if(v != source)
            {
                dist[v] = Mathf.Infinity;
                prev[v] = null;
            }
            unvisited.Add(v);
        }
        while(unvisited.Count > 0)
        {
            Node u = unvisited.OrderBy(n => dist[n]).First();
        }
    }
}
