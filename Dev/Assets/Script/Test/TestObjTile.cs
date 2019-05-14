using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjTile : MonoBehaviour
{
    public GameObject Tile;
    
    private Color color;

    public bool onTile;

    private void Awake()
    {
        this.color = this.Tile.GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Tile")
        {
            Debug.Log(other.tag);
            this.Tile.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, this.color.a);
            this.onTile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.Tile.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, this.color.a);
        this.onTile = false;
    }
}
