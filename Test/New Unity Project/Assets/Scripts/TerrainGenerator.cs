using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TerrainGenerator : MonoBehaviour //Used in heigh mapping scene
{
    Terrain terrain;
    [RangeAttribute(1f,20f)]
    public float flatness = 1f;
    [RangeAttribute(1f,20f)]
    Texture2D heightmap2D;

    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>(); //get terrain component
        heightmap2D = new Texture2D(terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight); //make a texture for the terrain map
        heightmap2D.LoadImage(File.ReadAllBytes("Assets/MountHood.jpg")); //load the Mt. Hood image into the heightmap

        float[,] heightmap = terrain.terrainData.GetHeights(0,0, terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight);

        for(int i=0; i < terrain.terrainData.heightmapHeight; ++i)
        {
            for (int j=0; j < terrain.terrainData.heightmapWidth; ++j)
            {
                float x = i / (float) terrain.terrainData.heightmapHeight;
                float y = j / (float) terrain.terrainData.heightmapWidth;
                float height = heightmap2D.GetPixel(i,j).b; //set the height of each point to the height dictated in the Mt. Hood image

                heightmap[i, j] = height/flatness;
            }
        }
        terrain.terrainData.SetHeights(0, 0, heightmap); //set the height in the terrain

    }
}
