using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class MeasureData
{
    public int id;
    public int width;
    public int height;

    public int armWidth;
    public int armHeight;
}

public class WearingEquipment : MonoBehaviour
{
    EquipmentData equipmentData;            //������ ����� ������
    [SerializeField] EQUIPMENTTYPE equipType;//�ش� ĭ�� ���� Ÿ��
    [SerializeField] Sprite[] sprite;       //������ �̹��� 
    [SerializeField] public Image img;             //�ش� ĭ �̹��� ��ȯ 
    [SerializeField] public string path;           //�ش� ĭ�� ��� ����
    [SerializeField] GameObject wearingEquipInfo;
    [SerializeField] GameObject Blocker;

    [Header("Cloth,Ammor,Pant ����")]
    [SerializeField] Image centerImg; //��� �̹���
    [SerializeField] Image rightImg; //������ �̹���
    [SerializeField] Image leftImg;   //���� �̹���
    //������ �̹���
    [SerializeField]public Sprite[] centerSprite;
    [SerializeField]public Sprite[] rightSprite;
    [SerializeField]public Sprite[] leftSprite;

    List<MeasureData> MeasureDataList;

    [Header("���� ����")]
    [SerializeField] GameObject hat;
    [SerializeField] GameObject armor;
    [SerializeField] GameObject armorArmR;
    [SerializeField] GameObject armorArmL;
    [SerializeField] GameObject cloth;
    [SerializeField] GameObject clothArmR;
    [SerializeField] GameObject clothArmL;
    [SerializeField] GameObject pantR;
    [SerializeField] GameObject pantL;
    [SerializeField] GameObject back;
    [SerializeField] GameObject weaponR;
    [SerializeField] GameObject weaponL;



    private void Start()
    {
        MeasureDataByType(equipType);
        DataLoad();
    }

    void DataLoad() //������ �ε� ����
    {
        string filePath = Path.Combine(Application.dataPath, path);

        if(File.Exists(filePath))
        {
            // JSON ���� �б�
            string jsonData = File.ReadAllText(filePath);

            // JSON �����͸� EquipmentData ��ü�� ��ȯ 
            equipmentData = JsonUtility.FromJson<EquipmentData>(jsonData);

            ImgApply();
        }
        else
        {
            Debug.LogError("Cannot find JSON file at " + filePath);
        }
    }

    public void ImgApply() //�̹��� ����
    {
        if(equipType == EQUIPMENTTYPE.ARMOR || equipType == EQUIPMENTTYPE.CLOTH)//�̹����� 3���� ���ľ��ϴ� ���
        {
            centerImg.sprite = centerSprite[equipmentData.id];
            rightImg.sprite = rightSprite[equipmentData.id];
            leftImg.sprite = leftSprite[equipmentData.id];

            MeasureBodySizeControl(ref centerImg, equipmentData.id);
            MeasureArmSizeControl(ref rightImg, equipmentData.id);
            MeasureArmSizeControl(ref leftImg, equipmentData.id);

            if(equipType == EQUIPMENTTYPE.ARMOR)
            {
                armor.GetComponent<SpriteRenderer>().sprite = centerSprite[equipmentData.id];
                armorArmR.GetComponent<SpriteRenderer>().sprite = rightSprite[equipmentData.id];
                armorArmL.GetComponent<SpriteRenderer>().sprite = leftSprite[equipmentData.id];
            }
            else if(equipType == EQUIPMENTTYPE.CLOTH)
            {
                cloth.GetComponent<SpriteRenderer>().sprite = centerSprite[equipmentData.id];
                clothArmR.GetComponent<SpriteRenderer>().sprite = rightSprite[equipmentData.id];
                clothArmL.GetComponent<SpriteRenderer>().sprite = leftSprite[equipmentData.id];
            }

        }
        else if(equipType == EQUIPMENTTYPE.PANT)//�̹����� 2���� ���ľ��ϴ� ��� 
        {
            rightImg.sprite = rightSprite[equipmentData.id];
            leftImg.sprite = leftSprite[equipmentData.id];

            MeasureArmSizeControl(ref rightImg, equipmentData.id);
            MeasureArmSizeControl(ref leftImg, equipmentData.id);

            pantR.GetComponent<SpriteRenderer>().sprite = rightSprite[equipmentData.id];
            pantL.GetComponent<SpriteRenderer>().sprite = leftSprite[equipmentData.id];
        }
        else if(equipType == EQUIPMENTTYPE.R_WEAPON || equipType == EQUIPMENTTYPE.L_WEAPON)//���� ������ ��
        {
            img.sprite = sprite[equipmentData.id];
            MeasureBodySizeControl(ref img, equipmentData.id);

            if(equipType == EQUIPMENTTYPE.R_WEAPON)
            {
                weaponR.GetComponent<SpriteRenderer>().sprite = sprite[equipmentData.id];
                Debug.Log("����");
            }
            else if(equipType == EQUIPMENTTYPE.L_WEAPON)
            {
                weaponL.GetComponent<SpriteRenderer>().sprite = sprite[equipmentData.id];
            }
        }
        else//������ ���
        {
            img.sprite = sprite[equipmentData.id];
            SizeControl(ref img);

            if(equipType == EQUIPMENTTYPE.HAT)
            {
                hat.GetComponent<SpriteRenderer>().sprite = sprite[equipmentData.id];
            }
            else if(equipType == EQUIPMENTTYPE.BACK)
            {
                back.GetComponent<SpriteRenderer>().sprite = sprite[equipmentData.id];
            }
        }
    }

    public void ShowButton()//�����͸� �����ִ� ��ư 
    {
        wearingEquipInfo.GetComponent<InfoWearingEquipment>().UploadData(equipmentData, path);

        Blocker.GetComponent<Canvas>().sortingOrder += 1;
        wearingEquipInfo.SetActive(true);

        InfoImg(wearingEquipInfo);
    }

    public void InfoImg(GameObject equipmentInfo) //���� ���� �Լ� 
    {
        if(equipType == EQUIPMENTTYPE.ARMOR || equipType == EQUIPMENTTYPE.CLOTH)//�̹����� 3���� ���ľ��ϴ� ���
        {
            equipmentInfo.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            equipmentInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);

            Image center = equipmentInfo.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
            Image right = equipmentInfo.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
            Image left = equipmentInfo.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>();

            center.sprite = centerSprite[equipmentData.id];
            right.sprite = rightSprite[equipmentData.id];
            left.sprite = leftSprite[equipmentData.id];

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

            right.sprite = rightSprite[equipmentData.id];
            left.sprite = leftSprite[equipmentData.id];

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

            center.sprite = sprite[equipmentData.id];

            MeasureBodySizeControl(ref center, equipmentData.id);

            center.GetComponent<RectTransform>().sizeDelta *= 1.2f;
        }
        else//������ ���
        {
            equipmentInfo.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            equipmentInfo.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);

            Image center = equipmentInfo.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<Image>();

            center.sprite = sprite[equipmentData.id];

            SizeControl(ref center);

            center.GetComponent<RectTransform>().sizeDelta *= 1.2f;
        }

        equipmentInfo.transform.GetChild(2).GetComponent<Text>().text = equipmentData.name + $"{((equipmentData.level != 0) ? "+" + equipmentData.level : null)}";
        equipmentInfo.transform.GetChild(5).GetComponentInChildren<Text>().text =
            $"{((equipmentData.attackPower != 0) ? "���ݷ� : + " + equipmentData.attackPower + "\n" : null)}" +
            $"{((equipmentData.magicPower != 0) ? "�ֹ��� : + " + equipmentData.magicPower + "\n" : null)}" +
            $"{((equipmentData.speed != 0) ? "�̵� �ӵ� : + " + equipmentData.speed + "\n" : null)}" +
            $"{((equipmentData.maxHp != 0) ? "��ü��ȭ : + " + equipmentData.maxHp / 10 + "\n" : null)}" +
            $"{((equipmentData.cri != 0) ? "ġ��Ÿ : + " + equipmentData.cri + "\n" : null)}" +
            $"{((equipmentData.criDmg != 0) ? "ġ��Ÿ ������ : + " + equipmentData.criDmg + "\n" : null)}";

        switch(equipmentData.synergy)
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

    //������ ��ȯ �Լ���
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
