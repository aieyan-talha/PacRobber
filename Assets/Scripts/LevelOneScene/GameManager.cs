using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject robberLifePrefab;
    public int robberLives;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosition = new Vector3(-680, -460, 0);

        for (int i = 0; i < robberLives; i++)
        {
            GameObject robberLifeInstance = Instantiate(robberLifePrefab);

            robberLifeInstance.transform.SetParent(canvas.transform, false);

            robberLifeInstance.transform.localPosition = startPosition + new Vector3(i * 50, 0, 0);
        }

        //Hide the ghost timer on start of the game
        HideTextWithTag("GhostTimerLabel");
        HideTextWithTag("GhostTimerValue");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideTextWithTag(string tag)
    {
        TextMeshProUGUI[] textObjects = GameObject.FindGameObjectsWithTag(tag)
            .Select(go => go.GetComponent<TextMeshProUGUI>())
            .Where(text => text != null)
            .ToArray();

        foreach (TextMeshProUGUI textComponent in textObjects)
        {
            textComponent.enabled = false;
        }
    }

    public void ShowTextWithTag(string tag)
    {
        TextMeshProUGUI[] textObjects = GameObject.FindGameObjectsWithTag(tag)
            .Select(go => go.GetComponent<TextMeshProUGUI>())
            .Where(text => text != null)
            .ToArray();

        foreach (TextMeshProUGUI textComponent in textObjects)
        {
            textComponent.enabled = true;
        }
    }
}
