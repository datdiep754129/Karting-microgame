using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{

    public TextMeshProUGUI selectLevel;
    public TextMeshProUGUI selectMode;
    private Button button;
    public int selectPlaymode;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetLevel);
    }

    void SetLevel()
    {
        Debug.Log(button.gameObject.name + "was clicked!");

    }
}
