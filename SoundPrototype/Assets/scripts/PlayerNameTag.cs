using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameTag : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI nameText;
    private PlayerConfigurationManager playerConfigManager;
    private PlayerHandle handle;
    private int playerIndex;



    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void GetPlayerColor(int pi)
    {
        playerIndex = pi;
        nameText.SetText("P " + (pi + 1).ToString());
    }
   
}
