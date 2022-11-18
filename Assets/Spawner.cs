using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    const int NUM_B = 11;
    [SerializeField] GameObject Balloon;

    // Start is called before the first frame update
    void Start()
    {
        if (Balloon == null)
        {
            Balloon = GameObject.FindGameObjectWithTag("Balloon");
        }
        Spawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    { 
   
        int xMin = -14;
        int xMax = 17;
        int yMin = 5;
        int yMax = 9;

        for (int i = 0; i < NUM_B; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(Balloon, position, Quaternion.identity);
        }
    }
}
