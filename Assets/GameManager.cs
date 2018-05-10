using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Image idImg;
    public Image healthImg;
    public Sprite[] healthImgs;
    public bool hasKeycard;

    private Player player;

    // Use this for initialization
    void Start()
    {
        hasKeycard = false;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (player.playerHealth)
        {
            case (10):
                healthImg.sprite = healthImgs[0];
                break;
            case (9):
                healthImg.sprite = healthImgs[1];
                break;
            case (8):
                healthImg.sprite = healthImgs[2];
                break;
            case (7):
                healthImg.sprite = healthImgs[3];
                break;
            case (6):
                healthImg.sprite = healthImgs[4];
                break;
            case (5):
                healthImg.sprite = healthImgs[5];
                break;
            case (4):
                healthImg.sprite = healthImgs[6];
                break;
            case (3):
                healthImg.sprite = healthImgs[7];
                break;
            case (2):
                healthImg.sprite = healthImgs[8];
                break;
            case (1):
                healthImg.sprite = healthImgs[9];
                break;
            case (0):
                healthImg.sprite = healthImgs[10];
                break;
        }
        if (hasKeycard)
        {
            idImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            idImg.color = new Color(0, 0, 0, 0);
        }
    }
}
