using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScale : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    private void Update()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            textMeshProUGUI.transform.rotation = Quaternion.identity;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            textMeshProUGUI.transform.rotation = Quaternion.identity;
        }
    }
}
