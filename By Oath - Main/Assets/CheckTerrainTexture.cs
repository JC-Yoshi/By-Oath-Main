using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerrainTexture : MonoBehaviour
{
    public Transform playerTransform;
    public Terrain terrainObject;

    public int posX;
    public int posZ;
    public float[] textureValues;

    void Start()
    {
        terrainObject = Terrain.activeTerrain;
        playerTransform = gameObject.transform;

    }

    public void GetTerrainTexture()
    {
        UpdatePosition();
        CheckTexture();
    }
        

    

    /*Updating Players Position
     
    taking players position from the terrain position, to remove the offset
    giving the world position over the terrain object

    taking the new terrain position / the width & height of the terrain object (over the world space)
    this gives the x and z coordinates for the player 

    via multiplying these coordinate by the height and width of the alpha-map, get the coordinates of the player position
    giving a close coordinate location on the terrain
    */

    void UpdatePosition ()
    {
        Vector3 terrainPosition = playerTransform.position - terrainObject.transform.position;
        Vector3 mapPosition = new Vector3(terrainPosition.x / terrainObject.terrainData.size.x, 0, terrainPosition.z / terrainObject.terrainData.size.z);
        float xCoord = mapPosition.x * terrainObject.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * terrainObject.terrainData.alphamapHeight;
        posX = (int)xCoord;
        posZ = (int)zCoord;

    }

    void CheckTexture()
    {
        float[,,] splatMap = terrainObject.terrainData.GetAlphamaps(posX, posZ,1,1);
        textureValues[0] = splatMap[0, 0, 0];
        textureValues[1] = splatMap[0, 0, 1];
        textureValues[2] = splatMap[0, 0, 2];
    }

}
