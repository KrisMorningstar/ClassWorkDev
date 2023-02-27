using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerClass : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI classText;

    [SerializeField] private List<string> classes = new List<string>();

    [SerializeField] private TMP_Dropdown classDrop;

    // Start is called before the first frame update
    void Start()
    {
        classes.Add("Knight");
        classes.Add("Rogue");
        classes.Add("Wizard");

        classText.text = "Class: " + classDrop.options[classDrop.value].text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateClass()
    {
        classText.text = "Class: " + classes[classDrop.value];
    }
}
