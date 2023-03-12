using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{
    private string playerName;

    [SerializeField] private TextMeshProUGUI nameText;

    [SerializeField] private TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateName()
    {
        playerName = inputField.text;
        nameText.text = "Name: " + playerName;
    }
}
