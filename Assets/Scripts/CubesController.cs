using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubesController : MonoBehaviour
{
    [SerializeField] private TMP_Text delaySpawnText;
    [SerializeField] private TMP_Text cubeSpeedText;
    [SerializeField] private TMP_Text targetDistanceText;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TargetPoint targetPoint;

    private float delaySpawn = 1;

    private void Start()
    {
        StartCoroutine(CubesSpawn());

        delaySpawnText.text = delaySpawn.ToString();
        cubeSpeedText.text = Cube.speed.ToString();
        targetDistanceText.text = "1";
    }

    public void DelaySpawn(string number)
    {
        if (number == "") return;

        float num;
        float.TryParse(number, NumberStyles.Float, CultureInfo.InvariantCulture, out num);

        delaySpawn = Mathf.Clamp(num, 0, 10);

        delaySpawnText.text = delaySpawn.ToString();
    }

    public void CubeSpeed(string number)
    {
        if (number == "") return;

        float num;
        float.TryParse(number, NumberStyles.Float, CultureInfo.InvariantCulture, out num);

        Cube.speed = Mathf.Clamp(num, 0, 999);
        cubeSpeedText.text = Cube.speed.ToString();
    }

    public void TargetDistance(string number)
    {
        if (number == "") return;

        float num;
        float.TryParse(number, NumberStyles.Float, CultureInfo.InvariantCulture, out num);

        targetPoint.ChangePosition(Mathf.Clamp(num, 0, 12));
        targetDistanceText.text = num.ToString();
    }

    private IEnumerator CubesSpawn()
    {
        while (true)
        {
            ObjectPooler.Instance.SpawnFromPool(spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(delaySpawn);
        }
    }

    public void InputFieldClear(InputField inputField)
    {
        inputField.text = "";
    }
}
