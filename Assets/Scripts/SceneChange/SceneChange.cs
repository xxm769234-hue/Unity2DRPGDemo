using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneToLoad;
    public Animator FadeAnim;
    public Vector2 newPlayerPosition;
    private Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.transform;
            FadeAnim.Play("SceneFade");
            StartCoroutine(DelayFade());
        }
    }
    IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(1);
        player.position = newPlayerPosition;
        SceneManager.LoadScene(sceneToLoad);
    }
}
