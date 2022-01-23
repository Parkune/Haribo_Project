using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderAnimation : MonoBehaviour
{

    private LineRenderer lr;
    private Renderer rend;
    float offset;
    float scrollSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        rend = GetComponent<Renderer>();
        offset = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        offset -= Time.deltaTime * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        if (offset <= -1f)
        {
            offset = 0;
        }
        //print(offset);
    }
}
