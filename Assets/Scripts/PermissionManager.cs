using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

/*public class PostNotification : MonoBehaviour
{
    string notifPermission = "android.permission.POST_NOTIFICATION";
    string cameraPermission = "android.permission.CAMERA";
    string vibratePermission = "android.permission.VIBRATE";

    private void Start()
    {
        var callbacks = new PermissionCallbacks();
        callbacks.PermissionDenied += PermissionCallbacks_PermissionDenied;
        callbacks.PermissionGranted += PermissionCallbacks_PermissionGranted;
        callbacks.PermissionDeniedAndDontAskAgain += PermissionCallbacks_PermissionDeniedAndDontAskAgain;

        if (!Permission.HasUserAuthorizedPermission(notifPermission))
        {
            Debug.LogWarning("Asking for permission");
            Permission.RequestUserPermission(notifPermission, callbacks);
        }
        if (!Permission.HasUserAuthorizedPermission(cameraPermission))
        {
            Debug.LogWarning("Asking for permission");
            Permission.RequestUserPermission(cameraPermission, callbacks);
        }
        if (!Permission.HasUserAuthorizedPermission(vibratePermission))
        {
            Debug.LogWarning("Asking for permission");
            Permission.RequestUserPermission(vibratePermission, callbacks);
        }
    }

    private void PermissionCallbacks_PermissionDeniedAndDontAskAgain(string obj)
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    private void PermissionCallbacks_PermissionGranted(string obj)
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    private void PermissionCallbacks_PermissionDenied(string obj)
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }


}*/

public class PermissionManager : MonoBehaviour
{
    //private AndroidJavaObject screenRecorder;

    [SerializeField] private TextMeshProUGUI ProcessText;
    void Start()
    {
        StartCoroutine(RequestPermissionsCoroutine());
    }

    IEnumerator RequestPermissionsCoroutine()
    {
        yield return RequestPermissionCoroutine(Permission.Camera);
        yield return RequestPermissionCoroutine(Permission.Microphone);
        yield return RequestPermissionCoroutine(Permission.ExternalStorageWrite);

    }

    IEnumerator RequestPermissionCoroutine(string permission)
    {
        if (!Permission.HasUserAuthorizedPermission(permission))
        {
            Permission.RequestUserPermission(permission);

            while (!Permission.HasUserAuthorizedPermission(permission))
            {
                yield return null;
            }

            if (Permission.HasUserAuthorizedPermission(permission))
            {
                Debug.Log(permission + " permission granted");

                ProcessText.text = permission + " permission granted";
            }
            else
            {
                Debug.LogWarning(permission + " permission denied");

                ProcessText.text = permission + " permission denied";
            }
        }
        else
        {
            Debug.Log(permission + " permission already granted");

            ProcessText.text = permission + " permission already granted";
        }
    }

    /*void CallStartRecording()
    {
        screenRecorder = new AndroidJavaObject("com.Rado.NewRecorder.ScreenRecorder");

        if (screenRecorder != null)
        {
            screenRecorder.Call("startRecording");
            Debug.Log("Screen recording started");

            ProcessText.text = "Screen recording started";
        }
        else
        {
            Debug.LogError("ScreenRecorder object is null. Screen recording cannot be started.");

            ProcessText.text = "ScreenRecorder object is null. Screen recording cannot be started.";
        }
    }

    void OnApplicationQuit()
    {
        StopRecording();
    }

    void OnDisable()
    {
        StopRecording();
    }

    void StopRecording()
    {
        if (screenRecorder != null)
        {
            screenRecorder.Call("stopRecording");
            Debug.Log("Screen recording stopped");

            ProcessText.text = "Screen recording stopped";
        }
        else
        {
            Debug.LogError("ScreenRecorder object is null. Screen recording cannot be stopped.");

            ProcessText.text = "ScreenRecorder object is null. Screen recording cannot be stopped.";
        }
    } */
}
