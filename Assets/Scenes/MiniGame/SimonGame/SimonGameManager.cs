using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SimonGameManager : MonoBehaviour {
    //รับ button
    public GameObject gameButtonPrefab;

    public List<SimonButtonSetting> buttonSettings;

    public Transform gameFieldPanelTransform;

    List<GameObject> gameButtons;

    int bleepCount = 3;

    List<int> bleeps;
    List<int> playerBleeps;

    System.Random rg;

    bool inputEnabled = false;
    bool gameOver = false;

    void Start() {
        //สร้างปุ่มขึ้้นมา 4 ปุ่มโดยกำหนดตำแหน่ง 
        gameButtons = new List<GameObject>();
        CreateGameButton(0, new Vector3(-200, 164));
        CreateGameButton(1, new Vector3(164, 164));
        CreateGameButton(2, new Vector3(-200, -164));
        CreateGameButton(3, new Vector3(164, -164));
        StartCoroutine(SimonSays());
    }

    void CreateGameButton(int index, Vector3 position) {

        GameObject gameButton = Instantiate(gameButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;        
        gameButton.transform.SetParent(gameFieldPanelTransform);
        gameButton.transform.localPosition = position;
        gameButton.GetComponent<Image>().color = buttonSettings[index].normalColor;
        gameButton.GetComponent<Button>().onClick.AddListener(() => {
            OnGameButtonClick(index);
        });

        gameButtons.Add(gameButton);
    }

    void PlayAudio(int index) {
        //การเล่นเสียง 
        float length = 0.5f;
        float frequency = 0.001f * ((float)index + 1f);
        AnimationCurve volumeCurve = new AnimationCurve(new Keyframe(0f, 1f, 0f, -1f), new Keyframe(length, 0f, -1f, 0f));
        AnimationCurve frequencyCurve = new AnimationCurve(new Keyframe(0f, frequency, 0f, 0f), new Keyframe(length, frequency, 0f, 0f));
        LeanAudioOptions audioOptions = LeanAudio.options();
        audioOptions.setWaveSine();
        audioOptions.setFrequency(44100);
        AudioClip audioClip = LeanAudio.createAudio(volumeCurve, frequencyCurve, audioOptions);
        LeanAudio.play(audioClip, 0.5f);
    }

    void OnGameButtonClick(int index) {
        if(!inputEnabled) {
            return;
        }

        Bleep(index);

        playerBleeps.Add(index);

        if(bleeps[playerBleeps.Count - 1] != index) {
            GameOver();
            return;
        }

        if(bleeps.Count == playerBleeps.Count) {
            StartCoroutine(SimonSays());
        }
    }

    void GameOver() {
        gameOver = true;
        inputEnabled = false;
    }

    IEnumerator SimonSays() {
        inputEnabled = false;

        rg = new System.Random("hakunamatata".GetHashCode());

        SetBleeps();

        yield return new WaitForSeconds(1f);

        for(int i = 0; i < bleeps.Count; i++) {
            Bleep(bleeps[i]);

            yield return new WaitForSeconds(0.6f);
        }

        inputEnabled = true;

        yield return null;
    }

    void Bleep(int index) {
        //เสียงดังที่เกิดขึ้นจากการกด
        LeanTween.value(gameButtons[index], buttonSettings[index].normalColor, buttonSettings[index].highlightColor, 0.25f).setOnUpdate((Color color) => {
            gameButtons[index].GetComponent<Image>().color = color;
        });

        LeanTween.value(gameButtons[index], buttonSettings[index].highlightColor, buttonSettings[index].normalColor, 0.25f)
            .setDelay(0.5f)
            .setOnUpdate((Color color) => {
                gameButtons[index].GetComponent<Image>().color = color;
            });

        PlayAudio(index);
    }

    void SetBleeps() {
        bleeps = new List<int>();
        playerBleeps = new List<int>();

        for(int i = 0; i < bleepCount; i++) {
            bleeps.Add(rg.Next(0, gameButtons.Count));
        }

        bleepCount++;
    }
}