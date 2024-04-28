using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller Instance;
    public UnityEvent<float> movEvt;
    public UnityEvent jumpEvt, deathEvt;

    [SerializeField] GameObject confirmPanel;

    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(this);
        }
    }

    public void MovementOnClick(float mov){
        movEvt.Invoke(mov);
    }

    public void JumpOnClick(){
        jumpEvt.Invoke();
    }

    public void DeathOnClick(){
        deathEvt.Invoke();
    }

    public void SwitchConfirmPanel(bool state){
        confirmPanel.SetActive(state);
    }

    public void RealoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
        
    
}
