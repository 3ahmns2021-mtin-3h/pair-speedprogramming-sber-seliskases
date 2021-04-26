using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject flower;
    public Color[] flowerColors = new Color[5];
    public Canvas canvas;
    public float xSpawnResolution;
    public float ySpawnResolution;

    private int numSpace;
    private int numK;
    private float time;
    private Vector2[] spawnPoints;

    private void Awake()
    {
        spawnPoints = SpawnSystem.CalculateSpawnPoints(canvas, xSpawnResolution, ySpawnResolution);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            numSpace++;
            time = 0; 
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            numK++;
        }

        if (numK > 10)
        {
            int colorID = Random.Range(0, flowerColors.Length - 1);
            SpawnSystem.SpawnFlower(flower, flowerColors[colorID], spawnPoints, gameObject.transform);
            numK = 0;
        }

        if (time > 1)
        {
            for (int i = 0; i < numSpace; i++)
            {
                SpawnSystem.SpawnFlower(flower, flowerColors[0], spawnPoints, gameObject.transform);
            }

            time = 0;
            numSpace = 0;
        }

        time += Time.deltaTime;
    }
}
