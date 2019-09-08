using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject editorUI;

    public void StartTest()
    {
        GameObject spawn = GameObject.FindGameObjectWithTag("Respawn");
        Camera.main.gameObject.SetActive(false);
        editorUI.SetActive(false);
        GameObject player = Instantiate(playerPrefab, spawn.transform);
        player.transform.Translate(0f, 1f, 0f);
    }
}
