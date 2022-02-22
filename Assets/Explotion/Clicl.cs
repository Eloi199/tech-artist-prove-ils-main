using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicl : MonoBehaviour
{
    public GameObject Clic;
    public void ins(GameObject G)
    {
        GameObject B = Instantiate(G, G.transform.position, G.transform.rotation);
        B.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Star();
    }
    public void Star()
    {
        Instantiate(Clic,transform);
        Instantiate(Clic,transform);
        Instantiate(Clic,transform);
        Instantiate(Clic,transform);
        Instantiate(Clic,transform);
    }
}
