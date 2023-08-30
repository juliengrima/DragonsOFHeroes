using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Champs
    [SerializeField] Slider _slider;


    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    public void SetHealth(int health)
    {
        _slider.value = health;
    }
    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        //_slider.value = health;
    }
    #endregion
    #region Coroutines
    #endregion
}
