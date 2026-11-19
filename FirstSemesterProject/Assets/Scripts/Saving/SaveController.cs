using System.Collections;
using System.IO;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public static SaveController Instance;

    private string saveLocation;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
    }

    public void SaveGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SaveData saveData = new SaveData
        {
            playerPosition = player.transform.position,
            sceneName = player.scene.name,
            hp = player.GetComponent<PlayerLife>().GetHp()
        };
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
    }

    private IEnumerator LoadSaveFile(SaveData saveData)
    {
        SceneManager.LoadScene(saveData.sceneName);
        GameObject player = null;

        while (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            yield return null;
        }

        player.transform.position = saveData.playerPosition;    
        player.GetComponent<PlayerLife>().SetHp(saveData.hp);
    }
}
