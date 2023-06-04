using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public Text coinText;
    int contMonedas;
    public bool canShoot;
    public float powerUpDuration = 5;
    public float powerUpTimer = 0;
    public List<GameObject> enemiesInScreen = new List<GameObject>();

   public void GameOver()
    {
        isGameOver = true;
        
        //Se llama a la funcion con 1s y medio de retraso
        //Invoke("LoadScene", 1.5f);

        //Llamamos a la corutina LoadScene
        StartCoroutine("LoadScene");
    }

    void Update() 
    {
        ShootPowerUp();

        if(Input.GetKeyDown(KeyCode.P))
        {
            KillAllEnemies();
        }
    }

   /* void LoadScene()
    {
        SceneManager.LoadScene(2);
    }*/

    IEnumerator LoadScene()
    {
        //Para la corrutina durante 2,5s
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }

    public void AddCoin()
    {
        contMonedas++;
        coinText.text = "coin " + contMonedas.ToString();
    }

    void ShootPowerUp()
    {
        if(canShoot)
        {
            if(powerUpTimer <= powerUpDuration)
            {
                powerUpTimer += Time.deltaTime;
            }else
            {
                canShoot = false;
                powerUpTimer = 0;
            }
        }
    }

    void KillAllEnemies()
    {
        for (int i = 0; i < enemiesInScreen.Count; i++)
        {
            Destroy(enemiesInScreen[i]);
        }
    }
}
