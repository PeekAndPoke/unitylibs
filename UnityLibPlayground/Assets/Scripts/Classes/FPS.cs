using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour
{
    private Texture2D _texture;
    private Color32[] pixels;

    private int width = 128;
    private int height = 128;


	// Use this for initialization
	void Start () {
        _texture = new Texture2D(width, height);

        pixels = new Color32[100 * 100];

        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                _texture.SetPixel(i, j, Color.black);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnGUI()
    {

        _texture.SetPixel(32, 32, Color.green);

        _texture.Apply();

        Graphics.DrawTexture(new Rect(500, 300, width, height), _texture);
    }
}
