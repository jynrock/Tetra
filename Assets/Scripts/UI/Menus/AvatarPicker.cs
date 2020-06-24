using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarPicker : MonoBehaviour
{
    [SerializeField]
    private GameObject previewIconPrefab;
    [SerializeField]
    private GameObject previewIconHolder;
    [SerializeField]
    private ProfilePanel profilePanel;

    public void PopulateIcons()
    {
        List<Sprite> availableAvatars = PlayerProfile.Instance.GetAvailableAvatars();
        foreach(Sprite s in availableAvatars)
        {
            GameObject i = Instantiate(previewIconPrefab);
            i.GetComponent<Image>().sprite = s;
            i.transform.SetParent(previewIconHolder.transform);
        }
    }

    public void ClosePicker()
    {
        profilePanel.UpdateSettings();
        gameObject.SetActive(false);
    }
}
