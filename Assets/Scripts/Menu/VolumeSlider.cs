using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour {
    public GameObject slider;

    private void Start() {
        slider.GetComponent<Slider>().value = Statics.CurrentVolume;
    }

    void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal") / 100;
        if (dir > 0)
            slider.GetComponent<Slider>().value = Mathf.Min(1, slider.GetComponent<Slider>().value + dir);
        else
            slider.GetComponent<Slider>().value = Mathf.Max(-1, slider.GetComponent<Slider>().value + dir);

        Statics.CurrentVolume = slider.GetComponent<Slider>().value;        
    }
}