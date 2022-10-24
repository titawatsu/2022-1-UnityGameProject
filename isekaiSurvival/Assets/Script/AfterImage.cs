using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour
{
    
    [SerializeField] private float imageDelay;
    private float imageDelaySeconds;

    public GameObject imageContainer;
    [HideInInspector] public bool enableImage = false;

    private void Start() => imageDelaySeconds = imageDelay;

    private void Update()
    {
        if (enableImage) ImageCondition();
        
    }

    private void ImageCondition()
    {
        if (imageDelaySeconds > 0) imageDelaySeconds -= Time.deltaTime;
        else
        {
            GameObject currentImage = Instantiate(imageContainer, transform.position, transform.rotation);
            Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
            currentImage.transform.localScale = this.transform.localScale;
            currentImage.GetComponent<SpriteRenderer>().sprite = currentSprite;
            imageDelaySeconds = imageDelay;
            Destroy(currentImage, 1f);
        }
    }
}
