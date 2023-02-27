using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour
{
    public int ammoCount;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = 80085;
        ammoText.text = "Ammo: " + ammoCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceAmmo()
    {
        ammoCount -= 10;
        ammoText.text = "Ammo: " + ammoCount;
    }

    public void IncreaseAmmo()
    {
        ammoCount += int.Parse(inputField.text);
        ammoText.text = "Ammo: " + ammoCount;
    }
}
