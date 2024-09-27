using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 100f;
    public float scaleDuration = 0.5f; // Duration of the scaling effect
    public float maxScale = 2f; // Maximum scale factor
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.instance.DecreaseCoinCount();
            StartCoroutine(ScaleAndDestroy());
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
    
    IEnumerator ScaleAndDestroy()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * maxScale;
        float elapsedTime = 0f;

        while (elapsedTime < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        Destroy(gameObject);
    }
}
