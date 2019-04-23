using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject chara;
    public Transform end;
    public Animator transitionAnim;
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        if(chara.transform.position == end.position)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName);
    }
}
