using UnityEngine;
using UnityEngine.UI; 

public class DayAndNight : MonoBehaviour
{
    [SerializeField] private float DayStateTime = 10f;
    [SerializeField] private GameObject Sun;
    [SerializeField] private GameObject Fog;
    [SerializeField] private Light light;
    [SerializeField] private FadeInOut inout;
    [SerializeField] private CanvasGroup InvitationUI;
    [SerializeField] private Button btn; 

    private void Start()
    {
        InvitationUI.alpha = 0f; 
    }

    private void Update()
    {
        DisappearDay();
    }

    private void DisappearDay()
    {
        Sun.transform.Translate(Vector3.down * Time.deltaTime * DayStateTime);
        Fog.transform.Translate(Vector3.up * Time.deltaTime * DayStateTime);
     
        if (Sun.transform.position.y < -60 || (Fog.transform.position.y > 1f))
        {
            Sun.SetActive(false);
            Sun.transform.position = new Vector3(0, -90, 0);
            Fog.transform.position = new Vector3(Fog.transform.position.x, 1f, Fog.transform.position.z);
            inout.FadeIn(InvitationUI, 1);
        }
    }

  
}


