using UnityEngine;

namespace ThePipeCat
{
  [CreateAssetMenuAttribute(fileName = "Control Profile", menuName = "Control Profile")]
  public class ControlProfile : ScriptableObject
  {
    public const int MAX_LAYOUTS = 20;
    public const int MAX_KEYS = 220;

    private string[] m_labels = new string[MAX_KEYS];
    private float[] m_inputs = new float[MAX_KEYS];
    private ControlLayout[] m_layouts = new ControlLayout[MAX_LAYOUTS];
    private int m_currentLayout = 0;
    private ControlLayout m_layout;

    public ControlLayout[] GetLayouts()
    {
      return m_layouts;
    }

    public ControlLayout GetLayout()
    {
      return m_layout;
    }

    public void SetLayout(int index)
    {
      m_currentLayout = index;
      m_layout = m_layouts[m_currentLayout];
    }

    public string GetLabelForKey(string keyName)
    {
      string labelName = null;

      return labelName;
    }

    public string GetKeyForLabel(string labelName)
    {
      string keyName = null;

      return keyName;
    }

    public float IsPressed(string labelName)
    {
      float input = 0;

      for (int i = 0; i < MAX_KEYS; i++)
      {
        if (m_labels[i] == labelName)
        {
          input = m_inputs[i];

          m_inputs[i] = 0;

          break;
        }
      }

      return input;
    }
  }
}