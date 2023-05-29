using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offSet;
    private Material mat;
    private float horizontal;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        offSet += (Time.deltaTime * scrollSpeed * horizontal) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
    }
}
