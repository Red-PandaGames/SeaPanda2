using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public Animator fadeSystem;
    void Update() {
        if (Enemy.isAttacking) {
            StartCoroutine(loadGameOver());
        }
    }

    public IEnumerator loadGameOver() {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver"); 
    }
}
