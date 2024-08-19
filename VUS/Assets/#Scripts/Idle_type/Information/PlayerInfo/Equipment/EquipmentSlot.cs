using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;
using static WearingEquipment;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] int index; //���� ��ȣ
    EquipmentData slotData;//�ش�ĭ�� ��� ������
    string path = "#SaveJSON/EquipmentSlot/EquipmentSlot";

    ImageData selectData;

    [SerializeField] ImageData hatImg;
    [SerializeField] ImageData armorImg;
    [SerializeField] ImageData clothImg;
    [SerializeField] ImageData pantImg;
    [SerializeField] ImageData backImg;
    [SerializeField] ImageData ringImg;
    [SerializeField] ImageData necklaceImg;
    [SerializeField] ImageData weaponImg;

    EQUIPMENTTYPE equipType;
    List<MeasureData> MeasureDataList;

    GameObject Blocker;
    GameObject slotInfo;

    [Header("#���� ������")]
    [SerializeField] GameObject hat;
    [SerializeField] GameObject armor;
    [SerializeField] GameObject cloth;
    [SerializeField] GameObject pant;
    [SerializeField] GameObject back;
    [SerializeField] GameObject ring1;
    [SerializeField] GameObject ring2;
    [SerializeField] GameObject necklace1;
    [SerializeField] GameObject necklace2;
    [SerializeField] GameObject rightWeapon;
    [SerializeField] GameObject leftWeapon;

    GameObject selectEquipment; //���õ� ��� 

    EquipmentData equipmentData;


    private void Start()
    {
        Blocker = GameObject.Find("FullBlocker");
        slotInfo = transform.parent.parent.parent.parent.parent.parent.GetChild(5).gameObject;
        gameObject.GetComponent<Button>().onClick.AddListener(ShowInfo);//��ư Ŭ�� 

        path = path + index + ".json";
        DataLoad();
    }

    public void DataLoad() //������ �ε� �Լ�
    {
        string filePath = Path.Combine(Application.dataPath, path);

        if(File.Exists(filePath))
        {
            // JSON ���� �б�
            string jsonData = File.ReadAllText(filePath);

            // JSON �����͸� EquipmentData ��ü�� ��ȯ 
            slotData = JsonUtility.FromJson<EquipmentData>(jsonData);
        }
        else
        {
            Debug.LogError("Cannot find JSON file at " + filePath);
        }

        equipType = slotData.type;

        SortData();

        ImgChange();
    }


    public void ShowInfo()
    {
        Blocker.GetComponent<Canvas>().sortingOrder += 1;
        slotInfo.SetActive(true);
        SelectedGameObj(slotData.type);

        string filePath = Path.Combine(Application.dataPath, selectEquipment.GetComponent<WearingEquipment>().path);

        if(File.Exists(filePath))
        {
            // JSON ���� �б�
            string jsonData = File.ReadAllText(filePath);

            // JSON �����͸� EquipmentData ��ü�� ��ȯ 
            equipmentData = JsonUtility.FromJson<EquipmentData>(jsonData);
        }

        selectEquipment.GetComponent<WearingEquipment>().InfoImg(slotInfo.transform.GetChild(0).gameObject);
        SlotInfoImg(slotInfo.transform.GetChild(1).gameObject);

        string slotPath = Path.Combine(Application.dataPath, path);

        slotInfo.GetComponent<InfoSlotEquipment>().LoadData(filePath, slotPath, equipmentData, slotData, selectEquipment, gameObject);
    }



    void SelectedGameObj(EQUIPMENTTYPE type) //slot�� ���� ��� �������� �Լ� 
    {
        switch(type)
        {
            case EQUIPMENTTYPE.HAT:
                selectEquipment = hat;
                break;
            case EQUIPMENTTYPE.ARMOR:
                selectEquipment = armor;
                break;
            case EQUIPMENTTYPE.CLOTH:
                selectEquipment = cloth;
                break;
            case EQUIPMENTTYPE.PANT:
                selectEquipment = pant;
                break;
            case EQUIPMENTTYPE.BACK:
                selectEquipment = back;
                break;
            case EQUIPMENTTYPE.R_WEAPON:
                selectEquipment = rightWeapon;
                break;
            case EQUIPMENTTYPE.L_WEAPON:
                selectEquipment = leftWeapon;
                break;
            case EQUIPMENTTYPE.NECKLACE:
                selectEquipment = necklace1;
                break;
            case EQUIPMENTTYPE.RING:
                selectEquipment = ring1;
                break;
        }
    }

    void SortData()//Data�� ���� �̹��� ������
    {
        switch(equipType)
        {
            case EQUIPMENTTYPE.HAT:
                selectData = hatImg;
                break;
            case EQUIPMENTTYPE.ARMOR:
                selectData = armorImg;
                break;
            case EQUIPMENTTYPE.CLOTH:
                selectData = clothImg;
                break;
            case EQUIPMENTTYPE.PANT:
                selectData = pantImg;
                break;
            case EQUIPMENTTYPE.BACK:
                selectData = backImg;
                break;
            case EQUIPMENTTYPE.R_WEAPON:
                selectData = weaponImg;
                break;
            case EQUIPMENTTYPE.L_WEAPON:
                selectData = weaponImg;
                break;
            case EQUIPMENTTYPE.RING:
                selectData = ringImg;
                break;
            case EQUIPMENTTYPE.NECKLACE:
                selectData = necklaceImg;
                break;
        }

        MeasureDataByType(equipType);
    }

    void ImgChange()//�̹��� ��ȯ
    {
        if(equipType == EQUIPMENTTYPE.ARMOR || equipType == EQUIPMENTTYPE.CLOTH)//�̹����� 3���� ���ľ��ϴ� ���
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);


            Image center = transform.GetChild(0).GetChild(0).GetComponent<Image>();
            Image right = transform.GetChild(0).GetChild(1).GetComponent<Image>();
            Image left = transform.GetChild(0).GetChild(2).GetComponent<Image>();

            center.sprite = selectData.center[slotData.id];
            right.sprite = selectData.right[slotData.id];
            left.sprite = selectData.left[slotData.id];

            MeasureBodySizeControl(ref center, slotData.id);
            MeasureArmSizeControl(ref right, slotData.id);
            MeasureArmSizeControl(ref left, slotData.id);

            center.GetComponent<RectTransform>().sizeDelta *= 1.2f;
            right.GetComponent<RectTransform>().sizeDelta *= 1.2f;
            left.GetComponent<RectTransform>().sizeDelta *= 1.2f;

        }
        else if(equipType == EQUIPMENTTYPE.PANT)//�̹����� 2���� ���ľ��ϴ� ��� 
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);

            Image right = transform.GetChild(1).GetChild(0).GetComponent<Image>();
            Image left = transform.GetChild(1).GetChild(1).GetComponent<Image>();

            right.sprite = selectData.right[slotData.id];
            left.sprite = selectData.left[slotData.id];

            MeasureArmSizeControl(ref right, slotData.id);
            MeasureArmSizeControl(ref left, slotData.id);

            right.GetComponent<RectTransform>().sizeDelta *= 1.2f;
            left.GetComponent<RectTransform>().sizeDelta *= 1.2f;
        }
        else if(equipType == EQUIPMENTTYPE.R_WEAPON || equipType == EQUIPMENTTYPE.L_WEAPON)//���� ������ ��
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            Image center = transform.GetChild(2).GetChild(0).GetComponent<Image>();

            center.sprite = selectData.center[slotData.id];

            MeasureBodySizeControl(ref center, slotData.id);

            center.GetComponent<RectTransform>().sizeDelta *= 1.2f;
        }
        else//������ ���
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            Image center = transform.GetChild(2).GetChild(0).GetComponent<Image>();

            center.sprite = selectData.center[slotData.id];

            SizeControl(ref center);

            center.GetComponent<RectTransform>().sizeDelta *= 1.2f;
        }
    }

    void SlotInfoImg(GameObject equipmentInfo) //���� ���� �Լ� 
    {
        if(equipType == EQUIPMENTTYPE.ARMOR || equipType == EQUIPMENTTYPE.CLOTH)//�̹����� 3���� ���ľ��ϴ� ���
        {
            equipmentInfo.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            equipmentInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);

            Image center = equipmentInfo.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
            Image right = equipmentInfo.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
            Image left = equipmentInfo.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>();


            center.sprite = selectData.center[slotData.id];
            right.sprite = selectData.right[slotData.id];
            left.sprite = selectData.left[slotData.id];

            MeasureBodySizeControl(ref center, equipmentData.id);
            MeasureArmSizeControl(ref right, equipmentData.id);
            MeasureArmSizeControl(ref left, equipmentData.id);

            center.GetComponent<RectTransform>().sizeDelta *= 1.2f;
            right.GetComponent<RectTransform>().sizeDelta *= 1.2f;
            left.GetComponent<RectTransform>().sizeDelta *= 1.2f;

        }
        else if(equipType == EQUIPMENTTYPE.PANT)//�̹����� 2���� ���ľ��ϴ� ��� 
        {
            equipmentInfo.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            equipmentInfo.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);

            Image right = equipmentInfo.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
            Image left = equipmentInfo.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>();

            right.sprite = selectData.right[slotData.id];
            left.sprite = selectData.left[slotData.id];

            MeasureArmSizeControl(ref right, equipmentData.id);
            MeasureArmSizeControl(ref left, equipmentData.id);

            right.GetComponent<RectTransform>().sizeDelta *= 1.2f;
            left.GetComponent<RectTransform>().sizeDelta *= 1.2f;
        }
        else if(equipType == EQUIPMENTTYPE.R_WEAPON || equipType == EQUIPMENTTYPE.L_WEAPON)//���� ������ ��
        {
            equipmentInfo.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);

            Image center = equipmentInfo.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<Image>();

            center.sprite = selectData.center[slotData.id];
            MeasureBodySizeControl(ref center, equipmentData.id);

            center.GetComponent<RectTransform>().sizeDelta *= 1.2f;
        }
        else//������ ���
        {
            equipmentInfo.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);

            Image center = equipmentInfo.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<Image>();

            center.sprite = selectData.center[slotData.id];

            SizeControl(ref center);

            center.GetComponent<RectTransform>().sizeDelta *= 1.2f;
        }

        equipmentInfo.transform.GetChild(2).GetComponent<Text>().text = slotData.name + $"{((slotData.level != 0) ? "+" + slotData.level : null)}";
        equipmentInfo.transform.GetChild(5).GetComponentInChildren<Text>().text =
            $"{((slotData.attackPower != 0) ? "���ݷ� : + " + slotData.attackPower + "\n" : null)}" +
            $"{((slotData.magicPower != 0) ? "�ֹ��� : + " + slotData.magicPower + "\n" : null)}" +
            $"{((slotData.speed != 0) ? "�̵� �ӵ� : + " + slotData.speed + "\n" : null)}" +
            $"{((slotData.maxHp != 0) ? "��ü��ȭ : + " + slotData.maxHp / 10 + "\n" : null)}" +
            $"{((slotData.cri != 0) ? "ġ��Ÿ : + " + slotData.cri + "\n" : null)}" +
            $"{((slotData.criDmg != 0) ? "ġ��Ÿ ������ : + " + slotData.criDmg + "\n" : null)}";

        switch(slotData.synergy)
        {
            case EQUIPMENTSYNERGY.NONE:
                for(int i = 0; i < 6; i++)
                {
                    equipmentInfo.transform.GetChild(6).GetChild(i).GetComponent<Text>().text = null;
                }
                break;
            default:
                break;
        }
    }

    void SizeControl(ref Image img) //�� �̹��� ũ�⿡ ���� �ٸ��� ���� 
    {
        if(img.sprite == null)
        {
            return;
        }

        Texture2D spriteImg = img.sprite.texture; //�̹��� ũ�� �����ϱ� 
        float spriteImgWidth = spriteImg.width;
        float spriteImgHeight = spriteImg.height;

        img.GetComponent<RectTransform>().sizeDelta = new Vector2(spriteImgWidth * 4, spriteImgHeight * 4);
    }

    void MeasureDataByType(EQUIPMENTTYPE type)//Ÿ��(Armor, Cloth, Pants)�� ���� ������ �� �ε�
    {
        string jsonData = "";

        switch(type)
        {
            case EQUIPMENTTYPE.ARMOR:
                jsonData = File.ReadAllText("Assets/#Scripts/Idle_type/Information/PlayerInfo/Equipment/ALLEquipmentInfo/EquiptmentMeasure/ArmorMeasure.json");
                break;
            case EQUIPMENTTYPE.CLOTH:
                jsonData = File.ReadAllText("Assets/#Scripts/Idle_type/Information/PlayerInfo/Equipment/ALLEquipmentInfo/EquiptmentMeasure/ClothMeasure.json");
                break;
            case EQUIPMENTTYPE.PANT:
                jsonData = File.ReadAllText("Assets/#Scripts/Idle_type/Information/PlayerInfo/Equipment/ALLEquipmentInfo/EquiptmentMeasure/PantsMeasure.json");
                break;
            case EQUIPMENTTYPE.R_WEAPON:
                jsonData = File.ReadAllText("Assets/#Scripts/Idle_type/Information/PlayerInfo/Equipment/ALLEquipmentInfo/EquiptmentMeasure/WeaponMeasure.json");
                break;
            case EQUIPMENTTYPE.L_WEAPON:
                jsonData = File.ReadAllText("Assets/#Scripts/Idle_type/Information/PlayerInfo/Equipment/ALLEquipmentInfo/EquiptmentMeasure/WeaponMeasure.json");
                break;
            default:
                return;
        }

        MeasureData[] dataArray = JsonHelper.FromJson<MeasureData>(jsonData);
        MeasureDataList = new List<MeasureData>(dataArray);
    }

    void MeasureBodySizeControl(ref Image img, int index) //���������Ϳ� ���� �̹��� ũ�� ����(Body) 
    {
        MeasureData data = GetMeasureDataById(index);
        img.GetComponent<RectTransform>().sizeDelta = new Vector2(data.width * 5, data.height * 5);
        if((equipType == EQUIPMENTTYPE.L_WEAPON || equipType == EQUIPMENTTYPE.R_WEAPON) && (index == 4 || index == 5))
        {
            img.GetComponent<RectTransform>().sizeDelta = new Vector2(data.width * 3, data.height * 3);
        }
    }

    void MeasureArmSizeControl(ref Image img, int index) //���������Ϳ� ���� �̹��� ũ�� ����(Arm && Pants) 
    {
        MeasureData data = GetMeasureDataById(index);
        img.GetComponent<RectTransform>().sizeDelta = new Vector2(data.armWidth * 5, data.armHeight * 5);
    }

    MeasureData GetMeasureDataById(int id) // Ư�� ID�� �ش��ϴ� �����͸� �˻�
    {
        return MeasureDataList.Find(data => data.id == id);
    }

    public static class JsonHelper //Json �迭�� ��ü �迭�� ��ȯ�ϴ� Ŭ���� => ���� ���ؼ� json�� �迭 ����ϱ� ���ؼ� ���
    {
        public static T[] FromJson<T>(string json)
        {
            string newJson = "{\"array\":" + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.array;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }

}
