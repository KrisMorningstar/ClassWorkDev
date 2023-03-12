using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Volume : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volumeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        volumeText.text = "Volume: " + volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume()
    {
        volumeText.text = "Volume: " + volumeSlider.value;
    }
}
