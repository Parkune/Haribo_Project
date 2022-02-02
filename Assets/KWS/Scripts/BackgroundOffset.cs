using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
    private Renderer rend;
    float offset;
    float scrollSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
