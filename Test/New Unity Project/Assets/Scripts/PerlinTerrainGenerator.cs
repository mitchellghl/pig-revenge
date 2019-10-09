using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTerrainGenerator : MonoBehaviour //Used in perlin noise scene
{
    Terrain terrain;
    [RangeAttribute(1f, 20f)]
    public float flatness = 1f;
    [RangeAttribute(1f, 20f)]
    public float frequency = 1f;
    [RangeAttribute(1, 10)]
    public int octaves = 8;

    private float heightOffset = 0f; //used for infinite scrolling
    private float widthOffset = 0f; //used for infinite scrolling

    void Start()
    {
        terrain = GetComponent<Terrain>(); //get the terrain component
    }

    void Update()
    {
        float[,] heightmap = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight); //create array of heights

        heightOffset += (Input.GetAxis("Vertical") / 5f); //if left/right is pressed, increase/decrease offset
        widthOffset += (Input.GetAxis("Horizontal") / 5f); //if up/down is pressed, increase/decrease offset

        for (int i = 0; i < terrain.terrainData.heightmapHeight; ++i)
        {
            for (int j = 0; j < terrain.terrainData.heightmapWidth; ++j) //for every point in the heighmap...
            {
                float x = i / (float)terrain.terrainData.heightmapHeight;
                float y = j / (float)terrain.terrainData.heightmapWidth;

                float height = 0f;
                float current_frequency = frequency;
                float amplitude = 1;
                for (int z = 0; z < octaves; ++z)
                {
                    height = height + Mathf.PerlinNoise(x * current_frequency + heightOffset, y * current_frequency + widthOffset) * amplitude; //...randomly generate height (and modify using offset)
                    amplitude /= 2; //create erosion effect
                    current_frequency *= 2;
                }
                heightmap[i, j] = height / flatness;
            }
        }
        terrain.terrainData.SetHeights(0, 0, heightmap); //actually set the heights in the terrain
    }
}
