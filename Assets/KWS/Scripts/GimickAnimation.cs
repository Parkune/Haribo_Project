using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimickAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer rend;
    float offset;
    float scrollSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        if (offset >= 1.0f)
        {
            offset = -1.0f;
            gameObject.SetActive(false);
        }
        //print(offset);
    }

}
