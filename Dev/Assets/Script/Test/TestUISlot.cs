using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUISlot : MonoBehaviour
{
    public Image uiSlot;
    public Button btn;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("앙기모띠");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("안기모씨");
    }
}
