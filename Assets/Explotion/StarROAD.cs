using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarROAD : MonoBehaviour
{
    Image im;
    RectTransform Recta;
    Vector2 Destiny;
    float x, y, a;
    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>(); a = 1;
        im.color = new Color(1, 1, 1, 0);
        Recta = GetComponent<RectTransform>();
        x = (Input.mousePosition.x-Screen.width/2)*1.5f;
        y = (Input.mousePosition.y-Screen.height/2)*1.5f;
        Destiny = new Vector2(Random.value-0.5f, Random.value-0.5f);
        Recta.anchoredPosition = new Vector2(x, y);
        Destiny.Normalize(); 
    }

    // Update is called once per frame
    void Update()
    {
        x += Destiny.x * 64 * Time.deltaTime;
        y += Destiny.y * 64 * Time.deltaTime;
        im.color = new Color(1, 1, 1, a);
        a -= Time.deltaTime * 1;
        Recta.anchoredPosition = new Vector2(x, y);
        if (a < 0) { Destroy(gameObject); }
    }
}
