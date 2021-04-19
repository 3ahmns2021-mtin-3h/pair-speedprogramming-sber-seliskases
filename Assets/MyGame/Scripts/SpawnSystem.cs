using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static void SpawnFlower(GameObject flower, Canvas canvas, float xResolution, float yResolution, Transform parent)
    {
        Vector2 leftTopCorner = new Vector2(canvas.pixelRect.width / -2, canvas.pixelRect.height / 2);
        Vector2 rightTopCorner = new Vector2(canvas.pixelRect.width / 2, canvas.pixelRect.height / 2);
        Vector2 leftBottomCorner = new Vector2(canvas.pixelRect.width / -2, canvas.pixelRect.height / -2);
        Vector2 rightBottomCorner = new Vector2(canvas.pixelRect.width / 2, canvas.pixelRect.height / -2);

        float xSummand = (rightTopCorner.x - leftTopCorner.x) / (xResolution + 1);
        float ySummand = (rightTopCorner.y - rightBottomCorner.y) / (yResolution + 1);

        List<float> xCoordinates = new List<float>();
        List<float> yCoordinates = new List<float>();
        List<Vector2> spawnPoints = new List<Vector2>();

        for(int x = 1; x <= xResolution; x++)
        {
            for(int y = 1; y <= yResolution; y++)
            {
                spawnPoints.Add(new Vector2(x, y));
            }
        }

        int spawnPointID = Random.Range(1, spawnPoints.Count);
        GameObject spawnedObject = Instantiate(flower, spawnPoints[spawnPointID], Quaternion.identity);
        spawnedObject.transform.parent = parent;
    }
}
