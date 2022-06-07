using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Image timerImage;
    public GameScript game;

    private float _timeLeft = 0f;

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            if (normalizedValue > 0.5f)
            {
                timerImage.color = Color.green;
            }
            else if(normalizedValue > 0.25f)
            {
                timerImage.color = Color.yellow;
            }
            else if (normalizedValue <= 0.25f)
            {
                timerImage.color = Color.red;
            }

            if (_timeLeft <= 0f) //в случае если таймер заканчивается уровень завершается
            {
                game.endLevel();
            }
            yield return null;
        }
    }

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
   

    public void resetTimer() //перезаписать таймер
    {
        _timeLeft = time;
    }

    public void addTime(float addTimeCount = 8f) //добавить время
    {
        _timeLeft += addTimeCount;
        if (_timeLeft >= time) 
        {
            _timeLeft = time;
        }
    }
}