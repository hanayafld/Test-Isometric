using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TestHelloWorld : MonoBehaviour
{
    public Button btn;
    public GameObject tiles;

    private GameObject tilePrefab;
    private GameObject tileGo;

    //타일의 크기
    private float tileWidth = 0.64f;
    private float tileHeight = -0.32f;

    //타일의 개수를 정해줌
    //x로 몇개, Y로 몇개
    public int col;
    public int row;

    //타일이 찍힐 좌표
    private int isoPosX;
    private int isoPosY;

    private void Awake()
    {
        this.tilePrefab = Resources.Load<GameObject>("IsoTile");
    }

    void Start()
    {
        StringBuilder txtPos = new StringBuilder();

        //버튼눌러 타일 생성, 및 위치
        this.btn.onClick.AddListener(() =>
        {
            while (true)
            {
                //버튼눌러 만듬
                //Debug.Log("아뽜튼누름");
                this.tileGo = GameObject.Instantiate(tilePrefab);
                this.tileGo.transform.SetParent(this.tiles.transform);
                this.tileGo.transform.position = this.IsoMapToScreen(this.isoPosX, this.isoPosY);
                this.tileGo.GetComponent<Tile>().Pos = new Vector2(this.isoPosX, this.isoPosY);
                //텍스트
                this.tileGo.GetComponent<Tile>().txt.text = string.Format("({0}, {1})", this.isoPosX, this.isoPosY);
                
                //카운팅 쇽쇽
                this.isoPosX++;

                if (this.isoPosX == col)
                {
                    this.isoPosY++;
                    this.isoPosX = 0;
                }
                if (isoPosY == row)
                {
                    this.btn.gameObject.SetActive(false);
                    this.StartSearchTile();
                break;
            }
        }
        });
    }

    private Vector2 IsoMapToScreen(float x, float y)
    {
        var screenX = this.tiles.transform.position.x + (x - y) * this.tileWidth;
        var screenY = this.tiles.transform.position.y + (x + y) * this.tileHeight;

        //Debug.LogFormat("{0},{1}",screenX, screenY);
        return new Vector2(screenX, screenY);
    }

    private Vector2 IsoScreenToMap(float x, float y)
    {
        //var mapX = this.tiles.transform.position.x - (x + y) / this.tileWidth;
        //var mapY = this.tiles.transform.position.y - (x - y) / this.tileHeight;

        float mapX = (x - y) / this.tileWidth;
        float mapY = (x + y) / this.tileHeight;
        

        Debug.LogFormat("{0},{1}", mapX, mapY);
        return new Vector2(mapX, mapY);
    }

    private void StartSearchTile()
    {
        StartCoroutine(this.StartSearchTileImpl());
    }

    private IEnumerator StartSearchTileImpl()
    {
        while (true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.LogFormat("({0}, {1})", hit.collider.GetComponent<Tile>().Pos.x, hit.collider.GetComponent<Tile>().Pos.y);
                }
            }
            yield return null;
        }
    }
}