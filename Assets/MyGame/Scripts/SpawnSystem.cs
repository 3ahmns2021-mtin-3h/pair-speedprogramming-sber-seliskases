using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static Vector2[] CalculateSpawnPoints(Canvas canvas, float xResolution, float yResolution)
    {
        Vector2 leftTopCorner = new Vector2(canvas.pixelRect.width / -2, canvas.pixelRect.height / 2) * canvas.GetComponent<RectTransform>().localScale;
        Vector2 rightTopCorner = new Vector2(canvas.pixelRect.width / 2, canvas.pixelRect.height / 2) * canvas.GetComponent<RectTransform>().localScale;
        Vector2 leftBottomCorner = new Vector2(canvas.pixelRect.width / -2, canvas.pixelRect.height / -2) * canvas.GetComponent<RectTransform>().localScale;
        Vector2 rightBottomCorner = new Vector2(canvas.pixelRect.width / 2, canvas.pixelRect.height / -2) * canvas.GetComponent<RectTransform>().localScale; 

        float xSummand = (rightTopCorner.x - leftTopCorner.x) / (xResolution - 1);
        float ySummand = (rightTopCorner.y - rightBottomCorner.y) / (yResolution - 1);

        List<float> xCoordinates = new List<float>();
        List<float> yCoordinates = new List<float>();
        List<Vector2> spawnPoints = new List<Vector2>();

        for (int i = 0; i < xResolution; i++)
        {
            xCoordinates.Add(leftTopCorner.x + (xSummand * i));
        }

        for (int i = 0; i < yResolution; i++)
        {
            yCoordinates.Add(leftBottomCorner.y + (ySummand * i));
        }

        foreach (float x in xCoordinates)
        {
            foreach (float y in yCoordinates)
            {
                spawnPoints.Add(new Vector2(x, y));
            }
        }

        return spawnPoints.ToArray();
    }

    public static void SpawnFlower(GameObject flower, Color color, Vector2[] spawnPoints, Transform parent)
    {
        int spawnPointID = Random.Range(1, spawnPoints.Length);
        GameObject spawnedObject = Instantiate(flower, spawnPoints[spawnPointID], Quaternion.identity, parent);
        spawnedObject.GetComponent<SpriteRenderer>().color = color;
    }
}
