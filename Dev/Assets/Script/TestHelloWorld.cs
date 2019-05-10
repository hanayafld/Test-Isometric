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

    private float tileWidth = 0.64f;
    private float tileHeight = 0.64f;
    private int countX;
    private int countY;
    private void Awake()
    {
        this.tilePrefab = Resources.Load<GameObject>("hollymolly");
    }

    void Start()
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder txtPos = new StringBuilder();
        int col = 4;
        int row = 3;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                sb.AppendFormat("({0},{1})", j, i);
                sb.Append(" ");
            }
            sb.Append("\n");
        }
        Debug.Log(sb.ToString());

        //버튼눌러 타일 생성, 및 위치
        this.btn.onClick.AddListener(() =>
        {
            //버튼눌러 만듬
            Debug.Log("아뽜튼누름");
            this.tileGo = GameObject.Instantiate(tilePrefab);
            this.tileGo.transform.SetParent(this.tiles.transform);
            this.tileGo.transform.position = MapToScreen(new Vector2(countX, -countY));

            //텍스트
            txtPos.AppendFormat("({0}, {1})", countX, countY);
            this.tileGo.GetComponent<Tile>().txt.text = txtPos.ToString();
            txtPos.Clear();

            //카운팅 쇽쇽
            this.countX++;

            if (countX == col)
            {
                this.countY++;
                this.countX = 0;
            }

            if(countY==row)
            {
                btn.gameObject.SetActive(false);
            }

        });


        //타일의 위치를 128, -64
        //스크린 포인트를 월드포인트로 바꿔서 놓아야해용
        //this.tile.transform.position = Camera.main.ScreenToViewportPoint(new Vector3(64, -64, 0));
        //this.tilePrefab.transform.position = new Vector3(0.64f, -0.64f, 0);
    }

    public Vector2 MapToScreen(Vector2 mapPos)
    {
        var screenX = mapPos.x * this.tileWidth + (8 * -1 * 0.64f);
        var screenY = mapPos.y * this.tileHeight + (6 * 1 * 0.64f);

        //var pos = Camera.main.ScreenToWorldPoint(new Vector2(screenX, screenY));

        return new Vector2(screenX, screenY);
        //return pos;
    }

    public Vector2 ScreenToMap(Vector2 screenPos)
    {
        var mapX = (int)screenPos.x / this.tileWidth;
        var mapY = (int)screenPos.y / this.tileHeight;
        return new Vector2(mapX, mapY);
    }
}
