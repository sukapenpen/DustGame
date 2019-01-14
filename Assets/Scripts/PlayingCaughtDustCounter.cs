using UnityEngine;

public class PlayingCaughtDustCounter : SingletonMonoBehaviour<PlayingCaughtDustCounter>
{
    private const string templateTheNumberOf = "燃えたゴミの数：";
    private string text;

    private void Awake()
    {
        GetComponent<TextMesh>().text = templateTheNumberOf + "0";
        gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateCounter();
    }

    private void OnDisable()
    {
        GetComponent<TextMesh>().text = templateTheNumberOf + "0";
    }

    public void UpdateCounter()
    {
        GetComponent<TextMesh>().text = templateTheNumberOf + DustManager.Instance.GameTrashDustCounter.ToString();
    }

}