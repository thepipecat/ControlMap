using UnityEngine;

namespace ThePipeCat.ControlMap
{
  public class ControlMapManager : MonoBehaviour
  {
    protected static ControlMapManager m_instance;

    private ControlProfile m_profile;

    public static ControlMapManager Instance
    {
      get
      {
        return m_instance;
      }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
      if (m_instance != null)
      {
        DestroyObject(this);
        return;
      }

      m_instance = this;

      DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
      string[] joys = Input.GetJoystickNames();

      foreach (string joyName in joys)
        Debug.Log(joyName);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
      CollectInputs();
    }

    public void CollectInputs()
    {
      for (int i = 0; i < ControlProfile.MAX_KEYS; i++)
      {
        // string label = m_labels[i];

        // if (label == null) continue;

        // m_inputs[i] = Input.GetAxis();
      }
    }
  }
}