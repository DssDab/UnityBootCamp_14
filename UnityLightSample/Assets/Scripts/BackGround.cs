using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material mat;

    public float scrollSpeed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.up;
        mat.mainTextureOffset += dir*scrollSpeed*Time.deltaTime;
    }
}
