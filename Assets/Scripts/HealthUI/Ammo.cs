using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int ammoCount;
    [SerializeField] private Text ammoText;
    [SerializeField] private InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = 8008135;
        ammoText.text = "Current Ammo: " + ammoCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceAmmo()
    {
        ammoCount -= 10;
        ammoText.text = "Current Ammo: " + ammoCount;
    }

    public void IncreaseAmmo()
    {
        ammoCount += int.Parse(inputField.text);
        ammoText.text = "Current Ammo: " + ammoCount;
    }
}
