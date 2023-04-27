using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour, IDataPersistence
{
    public int ammoCount = 80085;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TMP_InputField inputField;

    public void LoadData(GameData _data)
    {
        this.ammoCount = _data.ammoCount;
    }

    public void SaveData(ref GameData _data)
    {
        _data.ammoCount = this.ammoCount;
    }

    // Start is called before the first frame update
    void Start()
    {
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
