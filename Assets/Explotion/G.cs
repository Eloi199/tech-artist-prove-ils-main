using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G : MonoBehaviour
{
    RawImage im;
    float U, V;
    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<RawImage>();
        U = 0.125f; V = 0.125f;
    }

    // Update is called once per frame
    void Update()
    {
        im.uvRect = new Rect(U,V,0.125f,0.125f);
        U += 0.125f;
        if (U % 1 == 0) { V += 0.125f; U = 0.125f; }
        if (V+U > 2) { Destroy(this.gameObject); };
    }
}
