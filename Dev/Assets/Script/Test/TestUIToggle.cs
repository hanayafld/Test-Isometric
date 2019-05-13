using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUIToggle : MonoBehaviour
{
    public Image uiSlot1;

    //스위치
    private bool uiSlotPop;

    private void Start()
    {
        this.uiSlot1.GetComponent<TestUISlot>().btn.onClick.AddListener(() =>
        {
            this.ShootRay();
        });
    }

    private void ShootRay()
    {
        StartCoroutine(this.ShootRayImpl());
    }

    private IEnumerator ShootRayImpl()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("명중");
                var uiGo = this.uiSlot1.GetComponent<TestUISlot>().uiSlot;
                while (true)
                {
                    if (!this.uiSlotPop)
                    {
                        uiGo.transform.localScale += new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
                        this.uiSlotPop = true;
                    }
                    if (this.uiSlotPop)
                    {
                        uiGo.transform.localScale -= new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
                        if (uiGo.transform.localScale.x >= 1)
                        {
                            uiGo.transform.localScale = new Vector3(1, 1, 1);
                            this.uiSlotPop = false;
                            break;
                        }
                    }
                }
            }
        }
        yield return null;
    }
}
