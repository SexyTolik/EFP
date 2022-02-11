using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    float lastFall = 0;
    void Start()
    {
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                FindObjectOfType<ItemSpawner>().SpawnBlock();

                enabled = false;
            }

            lastFall = Time.time;
        }
    }
    public void Move(int dir)
    {
        transform.position += new Vector3(dir, 0, 0);

        if (isValidGridPos())
            updateGrid();
        else
            transform.position += new Vector3(-dir, 0, 0);
    }
    public void Rotate()
    {
        transform.Rotate(0, 0, -90);
        if (isValidGridPos())
            updateGrid();
        else
            transform.Rotate(0, 0, 90);
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);

            if (!Playfield.insideBorder(v))
                return false;

            if (Playfield.grid[(int)v.x, (int)v.y] != null &&
                Playfield.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }
    void updateGrid()
    {
        for (int y = 0; y < Playfield.h; ++y)
            for (int x = 0; x < Playfield.w; ++x)
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;

        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
