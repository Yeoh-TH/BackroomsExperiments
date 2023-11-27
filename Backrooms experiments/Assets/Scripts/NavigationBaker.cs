using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavigationBaker : MonoBehaviour
{
    public NavMeshSurface[] surfaces;
    public NavMeshObstacle[] obstacles;
    

    
    void Start()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].carveOnlyStationary = true;
            
        }
    }
}
