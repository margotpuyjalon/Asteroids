using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Slider inertiaSlider;

    [SerializeField]
    private Slider lagPlayerSlider;

    [SerializeField]
    private Slider lagAsteroidSlider;

    [SerializeField]
    private Dropdown shipColorDropdown;

    [SerializeField]
    private Toggle coherentSoundToggle;

    [SerializeField]
    private Slider lagSoundSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSettings()
    {
        this.inertiaSlider.value = PerceptiveParameters.inertia;
        this.lagPlayerSlider.value = PerceptiveParameters.lagPlayer;
        this.lagAsteroidSlider.value = PerceptiveParameters.lagAsteroid;
        this.shipColorDropdown.value = (int)PerceptiveParameters.shipColor;
        this.coherentSoundToggle.isOn = PerceptiveParameters.coherentSound;
        this.lagSoundSlider.value = PerceptiveParameters.lagSound;
        
    }

    public void SaveSettings()
    {
        PerceptiveParameters.inertia = this.inertiaSlider.value;
        PerceptiveParameters.lagPlayer = this.lagPlayerSlider.value;
        PerceptiveParameters.lagAsteroid = this.lagAsteroidSlider.value;
        PerceptiveParameters.shipColor = (ShipColor)this.shipColorDropdown.value ;
        PerceptiveParameters.coherentSound = this.coherentSoundToggle.isOn;
        PerceptiveParameters.lagSound = this.lagSoundSlider.value ;
    }
}
