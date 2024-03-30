/*
 * Attached to "Player" GameObject
 */
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float speed;
    private int pickUpCount = 0;
    private int waitTime = 3;
    private const int TOTAL_PICK_UPS = 20;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public SceneLoader sceneLoader;
    void Start()
    {
        sceneLoader = new SceneLoader();
        rigidbody = GetComponent<Rigidbody>();
        speed = 15.5f;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movementVector = new Vector3(moveHorizontal, 0, moveVertical);
        rigidbody.AddForce(movementVector * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {

            other.gameObject.SetActive(false);
            pickUpCount++;
            SetCountText();
            if (pickUpCount == TOTAL_PICK_UPS)
            {
                DisplayYouWin();
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + pickUpCount.ToString();
    }

    void DisplayYouWin()
    {
        winTextObject.SetActive(true);
        Invoke("LoadEndScene", waitTime);
    }
    void LoadEndScene()
    {
        sceneLoader.LoadNextScene();
    }

    /*
     * This was an interesting assignment. I watched the video but had some issues and I found the version of the Unity's documentation version of the project. https://learn.unity.com/project/roll-a-ball. I even went ahead and built and published my project on the website as described from the Unity page. 
     * 
     * I can see there is a lot to learn and I think I'll continue hacking around with Unity after this course is complete. I see a lot of potential learning from a programming/project perspective.
     * 
     * I'm also going to start learning about game project design as well as game design. I can see myself need technical skills to code it up, organizational skills to code it up properly, and creative skills to code up something worth playing
     *
     * Eager to see what the next assignment holds
     * 
     */
}
