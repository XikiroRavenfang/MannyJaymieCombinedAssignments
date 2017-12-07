using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    private List<Texture2D> eyes = new List<Texture2D>();
    private List<Texture2D> skin = new List<Texture2D>();
    private List<Texture2D> body = new List<Texture2D>();
    private List<Texture2D> sash = new List<Texture2D>();
    private List<Texture2D> backpack = new List<Texture2D>();
    private List<Texture2D> buckle = new List<Texture2D>();

    private GameObject player;
    private Renderer pRend;

    public int[] visualCustomMaxs;
    public string[] visualCustomTypes;
    private int eyesIndex, skinIndex, bodyIndex, sashIndex, backpackIndex, buckleIndex;

    private string playerName = "Steve";
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pRend = player.GetComponentInChildren<Renderer>();
        for (int typeIndex = 0; typeIndex < visualCustomMaxs.Length; typeIndex++)
        {
            for (int i = 1; !(i > visualCustomMaxs[typeIndex]); i++)
            {
                Texture2D temp = Resources.Load("Player/" + visualCustomTypes[typeIndex] + "_" + i.ToString()) as Texture2D;
                switch (visualCustomTypes[typeIndex])
                {
                    case "Eyes":
                        eyes.Add(temp);
                        break;
                    case "Skin":
                        skin.Add(temp);
                        break;
                    case "Body":
                        body.Add(temp);
                        break;
                    case "Sash":
                        sash.Add(temp);
                        break;
                    case "Backpack":
                        backpack.Add(temp);
                        break;
                    case "Buckle":
                        buckle.Add(temp);
                        break;
                    default:
                        Debug.Log("DumbKeyboard");
                        break;
                }
            }
            SetTexture(typeIndex, 0);
        }
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        playerName = GUI.TextField(new Rect(1.25f * scrW, 1f * scrH, 2.25f * scrW, 0.5f * scrH), playerName, 12);

        for (int i = 0; i < visualCustomTypes.Length; i++)
        {
            if (GUI.Button(new Rect(1.25f * scrW, scrH + (i + 1) * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
            {
                SetTexture(i, -1);
            }
            GUI.Box(new Rect(1.75f * scrW, scrH + (i + 1) * (0.5f * scrH), scrW * 1.25f, 0.5f * scrH), visualCustomTypes[i]);
            if (GUI.Button(new Rect(3f * scrW, scrH + (i + 1) * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
            {
                SetTexture(i, 1);
            }
        }
        if (GUI.Button(new Rect(13f * scrW, 7.5f * scrH, 2f * scrW, 0.5f * scrH), "Save and Play"))
            SaveAndPlay();
    }

    void SetTexture(int typeIndex, int dir)
    {
        int index = 0;
        Texture2D[] textures = new Texture2D[0];
        switch (visualCustomTypes[typeIndex])
        {
            case "Eyes":
                index = eyesIndex;
                textures = eyes.ToArray();
                break;
            case "Skin":
                index = skinIndex;
                textures = skin.ToArray();
                break;
            case "Body":
                index = bodyIndex;
                textures = body.ToArray();
                break;
            case "Sash":
                index = sashIndex;
                textures = sash.ToArray();
                break;
            case "Backpack":
                index = backpackIndex;
                textures = backpack.ToArray();
                break;
            case "Buckle":
                index = buckleIndex;
                textures = buckle.ToArray();
                break;
            default:
                Debug.Log("DumbKeyboard");
                break;
        }

        index += dir;
        if (index > visualCustomMaxs[typeIndex] - 1)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = visualCustomMaxs[typeIndex] - 1;
        }

        Material[] mat = pRend.materials;
        mat[typeIndex].mainTexture = textures[index];
        pRend.materials = mat;

        switch (visualCustomTypes[typeIndex])
        {
            case "Eyes":
                eyesIndex = index;
                break;
            case "Skin":
                skinIndex = index;
                break;
            case "Body":
                bodyIndex = index;
                break;
            case "Sash":
                sashIndex = index;
                break;
            case "Backpack":
                backpackIndex = index;
                break;
            case "Buckle":
                buckleIndex = index;
                break;
            default:
                Debug.Log("DumbKeyboard");
                break;
        }
    }

    void SaveAndPlay()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("Eyes", eyesIndex);
        PlayerPrefs.SetInt("Skin", skinIndex);
        PlayerPrefs.SetInt("Body", bodyIndex);
        PlayerPrefs.SetInt("Sash", sashIndex);
        PlayerPrefs.SetInt("Backpack", backpackIndex);
        PlayerPrefs.SetInt("Buckle", buckleIndex);
        SceneManager.LoadScene("GameScene");
    }
}
