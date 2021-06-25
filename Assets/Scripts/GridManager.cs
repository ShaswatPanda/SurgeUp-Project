using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameObject spriteObject;
    public Text generateButtonText;
    public GameObject[,] grid;
    public int rows = 3;
    public int columns = 3;
    public Color defaultColor = new Color(90, 90, 90, 200);
    public Color red = new Color(255, 0, 0, 200);
    public Color green = new Color(0, 255, 0, 200);
    public Color blue = new Color(0, 0, 255, 200);
    private Color selectedColor;

    void Start()
    {

        selectedColor = red;
        grid = new GameObject[rows, columns];

        for(int i = 0; i<columns; i++)
        {
            for(int j = 0; j<rows; j++)
            {
                SpawnTile(i, j);
            }
        }
    }

    void SpawnTile(int x, int y)
    {
        //GameObject g = new GameObject(x + "," + y);
        GameObject g = Instantiate(spriteObject) as GameObject;
        g.name = x + "," + y;
        g.transform.SetParent(gameObject.transform);
        g.transform.position = new Vector2(x-1, y-1);

        grid[x, y] = g;

        //g.GetComponent<SpriteRenderer>().color = defaultColor;
        
        //var s = g.AddComponent<SpriteRenderer>();
        //s.sprite = sprite;
        
    }

    public void Red()
    {
        selectedColor = red;
        DefaultColor();
        grid[1, 0].GetComponent<SpriteRenderer>().color = red;
        grid[1, 1].GetComponent<SpriteRenderer>().color = red;
        grid[1, 2].GetComponent<SpriteRenderer>().color = red;
    }
    public void Green()
    {
        selectedColor = green;
        DefaultColor();
        grid[1, 0].GetComponent<SpriteRenderer>().color = green;
        grid[1, 1].GetComponent<SpriteRenderer>().color = green;
        grid[1, 2].GetComponent<SpriteRenderer>().color = green;
    }
    public void Blue()
    {
        selectedColor = blue;
        DefaultColor();
        grid[1, 0].GetComponent<SpriteRenderer>().color = blue;
        grid[1, 1].GetComponent<SpriteRenderer>().color = blue;
        grid[1, 2].GetComponent<SpriteRenderer>().color = blue;
    }

    public void Generator()
    {
        /*
        Combinations:
        (0,0),(1,1),(2,2)
        (2,0),(1,1),(0,2)
        (1,0), 
        */

        DefaultColor();


        int choice = Random.Range(1,9);

        switch(choice)
        {
            case 1:
                grid[1, 0].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[1, 1].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[1, 2].GetComponent<SpriteRenderer>().color = selectedColor;
                break;
            case 2:
                grid[2, 2].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[1, 1].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[0, 0].GetComponent<SpriteRenderer>().color = selectedColor;
                break;
            case 3:
                grid[0, 1].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[1, 1].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[2, 1].GetComponent<SpriteRenderer>().color = selectedColor;
                break;
            case 4:
                grid[0, 2].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[1, 1].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[2, 0].GetComponent<SpriteRenderer>().color = selectedColor;
                break;
            case 5:
                grid[0, 2].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[1, 2].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[2, 2].GetComponent<SpriteRenderer>().color = selectedColor;
                break;
            case 6:
                grid[2, 2].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[2, 1].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[2, 0].GetComponent<SpriteRenderer>().color = selectedColor;
                break;
            case 7:
                grid[0, 0].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[1, 0].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[2, 0].GetComponent<SpriteRenderer>().color = selectedColor;
                break;
            case 8:
                grid[0, 0].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[0, 1].GetComponent<SpriteRenderer>().color = selectedColor;
                grid[0, 2].GetComponent<SpriteRenderer>().color = selectedColor;
                break;

        }

        generateButtonText.text = "REGENERATE";
    }

    void DefaultColor()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                grid[i, j].GetComponent<SpriteRenderer>().color = defaultColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
