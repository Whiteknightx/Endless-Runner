using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public LayerMask obstacle;
    public GameObject CheckPoint;
    public Vector3 offset;
    public bool CastRay;
    // Update is called once per frame
    void Update()
    {
        if (!CastRay) return;
        if (Physics.Raycast(CheckPoint.transform.position + offset, CheckPoint.transform.forward,out RaycastHit hitInfo, 1f, obstacle))
        {
            Debug.Log("Hit");
            Time.timeScale = 0.15f;
            SceneManagement.Instance.ShowGameOverUI();
        }

        Debug.DrawRay(CheckPoint.transform.position + offset, CheckPoint.transform.forward, Color.green);
    }
}
