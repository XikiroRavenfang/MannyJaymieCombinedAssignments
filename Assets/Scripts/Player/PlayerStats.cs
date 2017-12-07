using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float speed = 10f;

    private Renderer pRend;

    void Start()
    {
        pRend = GetComponentInChildren<Renderer>();
        if (!PlayerPrefs.HasKey("PlayerName"))
            SceneManager.LoadScene("CharacterCreation");
        else
            Load();      
    }

    void Load()
    {
        gameObject.name = PlayerPrefs.GetString("PlayerName");
        SetTexture("Eyes", PlayerPrefs.GetInt("Eyes", 1));
        SetTexture("Skin", PlayerPrefs.GetInt("Skin", 1));
        SetTexture("Body", PlayerPrefs.GetInt("Body", 1));
        SetTexture("Sash", PlayerPrefs.GetInt("Sash", 1));
        SetTexture("Backpack", PlayerPrefs.GetInt("Backpack", 1));
        SetTexture("Buckle", PlayerPrefs.GetInt("Buckle", 1));
    }

    void SetTexture(string type, int index)
    {
        index += 1;
        Texture2D tex = null;
        int matIndex = 0;
        switch (type)
        {
            case "Eyes":
                tex = Resources.Load("Player/Eyes_" + index.ToString()) as Texture2D;
                matIndex = 0;
                break;
            case "Skin":
                tex = Resources.Load("Player/Skin_" + index.ToString()) as Texture2D;
                matIndex = 1;
                break;
            case "Body":
                tex = Resources.Load("Player/Body_" + index.ToString()) as Texture2D;
                matIndex = 2;
                break;
            case "Sash":
                tex = Resources.Load("Player/Sash_" + index.ToString()) as Texture2D;
                matIndex = 3;
                break;
            case "Backpack":
                tex = Resources.Load("Player/Backpack_" + index.ToString()) as Texture2D;
                matIndex = 4;
                break;
            case "Buckle":
                tex = Resources.Load("Player/Buckle_" + index.ToString()) as Texture2D;
                matIndex = 5;
                break;
        }

        Material[] mats = pRend.materials;
        mats[matIndex].mainTexture = tex;
        pRend.materials = mats;
    }
}
