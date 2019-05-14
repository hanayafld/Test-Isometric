using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObj2x2 : MonoBehaviour
{
    public GameObject[] arrObjCol;
    public GameObject objGo;
    public bool dragOn;

    private bool buildPossible;

    private void Start()
    {
        Debug.Log("2x2오브젝트 생성완료");
    }

    private void Update()
    {
        StartCoroutine(this.OnMouseDrag());
    }

    public IEnumerator OnMouseDrag()
    {
        while (dragOn)
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            yield return null;
        }
    }
}