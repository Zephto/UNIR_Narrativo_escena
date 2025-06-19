using System.Collections;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public GameObject canvasElement;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Information());
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;


            foreach (Transform child in this.transform)
            {
                child.gameObject.SetActive(false);
            }

            // this.gameObject.SetActive(false);

        }
    }

    private IEnumerator Information()
    {
        canvasElement.SetActive(true);
        yield return new WaitForSeconds(3f);
        canvasElement.SetActive(false);
    }
}
