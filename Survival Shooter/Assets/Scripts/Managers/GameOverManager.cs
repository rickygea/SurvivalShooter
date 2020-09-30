using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{
    public GameObject warning;
    Text warningtext;
    public PlayerHealth playerHealth;
    Animator anim;

    public float restartDelay = 5f;
    float restartTimer;                    


    void Awake()
    {
        anim = GetComponent<Animator>();
        warningtext = warning.GetComponent<Text>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("Gameover");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
   
    public void ShowWarning()
    {
        anim.SetTrigger("warning");
    }

    public void closewarning() {
        warning.SetActive(false);
        anim.SetBool("warning", false);
    }
    public void ubahtext(float enemyDistance) {
        warningtext.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
    }
}