using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    public int FadeTime;

    private Image _image;
    private float _startTime;

    void Start()
    {
        _image = this.GetComponent<Image>();
        _startTime = Time.time + FadeTime;
    }

    void Update()
    {
        if (_startTime - Time.time  <= 0)
        {
            _image.color = Color.Lerp(_image.color, new Color(0, 0, 0, 0.75f), Time.deltaTime * 2);
            Invoke("DestroyFadeObject", FadeTime);
        }
    }

    void DestroyFadeObject()
    {
        Destroy(this.gameObject);
    }
}
