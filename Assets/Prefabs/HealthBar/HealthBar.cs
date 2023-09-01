using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Champs
    [SerializeField] Slider _slider; //Get vale to scale image
    [SerializeField] Gradient _gradient; //Colors source for graduate
    [SerializeField] Image _fill; //Image source ti get fill value

    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health; //max value of slider
        _slider.value = health; //Current value of slider
        _fill.color = _gradient.Evaluate(1f); //Graduation of image's colors
    }
    public void SetHealth(int health)
    {
        _slider.value = health; //Set value of slider with currentHealth
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
    #endregion
    #region Coroutines
    #endregion
}
