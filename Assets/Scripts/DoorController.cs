using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public bool isEnabled = true;
    public bool reactToPlayer = true;
    public float minimum = 0.075f;
    public float maximum = 2.3f;
    public float speed = 0.05f;
    public float goal = 0f;

    public AudioClip clipOpen;
    public AudioClip clipClose;

    Transform door;
    AudioSource audioSrc;

    void Start()
    {
        door = transform.parent.GetChild(1);
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        goal = Mathf.Min(1f, Mathf.Max(0f, goal));

        if (isEnabled)
        {
            Vector3 doorPos = door.position;
            float state = AbsToRel(doorPos.y);
            float diff = goal - state;
            if (Mathf.Abs(diff) > 0f)
            {
                if (Mathf.Abs(diff) > speed)
                {
                    state += speed * Mathf.Sign(diff);
                }
                else
                {
                    state += diff;
                }
            }
            doorPos.y = RelToAbs(state);
            door.position = doorPos;
        }
    }

    float AbsToRel(float input)
    {
        return (input - minimum) / (maximum - minimum);
    }

    float RelToAbs(float input)
    {
        return minimum + input * (maximum - minimum);
    }

    public void GoToGoal(float input)
    {
        goal = input;
    }

    public void Open()
    {
        if (isEnabled)
        {
            GoToGoal(1f);
            audioSrc.Stop();
            audioSrc.clip = clipOpen;
            audioSrc.Play();
        }
    }

    public void Close()
    {
        if (isEnabled)
        {
            GoToGoal(0f);
            audioSrc.Stop();
            audioSrc.clip = clipClose;
            audioSrc.Play();
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (reactToPlayer && obj.gameObject.tag == "Player")
        {
            Open();
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (reactToPlayer && obj.gameObject.tag == "Player")
        {
            Close();
        }
    }
}
